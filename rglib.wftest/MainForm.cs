using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using rglib.wftest.Model;
using RglibInterop;

namespace rglib.wftest {
    public partial class MainForm : Form {
        private string _currentConenctionString = null;
        private byte _currentReaderAddress = 0;
        private ReaderConnectionContext _currentConnectoinContext = null;

        private BindingList<CardFamilyBindingWrapper> _cardFamilies;
        private BindingList<CodogrammData> _defaultCodogramms;
        private BindingList<ProfileData> _defaultProfiles;
        private int _polling = 0;
        private ManualResetEvent _pollStopEvent = new ManualResetEvent(false);


        public MainForm() {
            InitializeComponent();

            _cardFamilies = new BindingList<CardFamilyBindingWrapper>() {
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.CF_COTAG),
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.CF_EMMARINE),
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.CF_HID),
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.CF_INDALA),
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.CF_PINCODE),
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.CF_TEMIC),
                new CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE.EF_MIFARE)
            };
            checkedListBox1.DataSource = _cardFamilies;

            _defaultProfiles = new BindingList<ProfileData>();
            foreach (int profileIndex in Enumerable.Range(0, 5)) {
                int profileIndexLocal = profileIndex;
                _defaultProfiles.Add(new ProfileData() {Name = string.Format("Профиль {0}", profileIndexLocal + 1)});
            }

            profilesListBox.DataSource = _defaultProfiles;

            _defaultCodogramms = new BindingList<CodogrammData>();
            for (byte index = 0; index < 5; index++) {
                _defaultCodogramms.Add(new CodogrammData() {
                    CodogrammBody = 0x00000000,
                    Name = string.Format("Тестовая {0}", index + 1),
                    Number = (byte) (index + 1),
                    LengthBits = 32

                });
            }

            codogrammsComboBox.DataSource = _defaultCodogramms;
            soundBox.BindingContext = new BindingContext();
            soundBox.DataSource = _defaultCodogramms;

            redBox.BindingContext = new BindingContext();
            redBox.DataSource = _defaultCodogramms;

            greenBox.BindingContext = new BindingContext();
            greenBox.DataSource = _defaultCodogramms;

            blueBox.BindingContext = new BindingContext();
            blueBox.DataSource = _defaultCodogramms;

            priotiryBox.SelectedIndex = 0;

            EnableDisableReaderDataGroup();

        }

        private void OnFormLoad(object sender, EventArgs e) {
            if (!DesignMode) {
                uint libVersion = UnmanagedContext.Instance.RG_GetVersion();
                statusStrip1.BackColor = Color.PaleGreen;
                toolStripLibVersionText.Text = string.Format("Библиотека загружена. Версия {0}.{1}.{2}",
                    libVersion >> 24, (libVersion >> 16) & 0xFF, libVersion & 0xFFFF);
            }
        }

        private void RefreshPortsButtonClick(object sender, EventArgs e) {
            using (FindPortsForm findDialog = new FindPortsForm() {StartPosition = FormStartPosition.CenterParent}) {
                if (findDialog.ShowDialog(this) == DialogResult.OK) {
                    if (!string.IsNullOrEmpty(findDialog.SelectedConnectionString) &&
                        findDialog.SelectedAddress != null) {
                        _currentConenctionString = findDialog.SelectedConnectionString;
                        _currentReaderAddress = findDialog.SelectedAddress.Value;
                    }
                    else {
                        _currentConenctionString = null;
                        _currentReaderAddress = 0;
                    }
                }

                connectionStringTextBox.Text = _currentConenctionString ?? "";
                addressUpDown.Value = _currentReaderAddress;
            }
        }

        private void ConnectButtonClick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(_currentConenctionString)) {
                MessageBox.Show("Неверно задана строка подключения.", "Ошибка", MessageBoxButtons.OK);
            }
            else {
                DoConnectDisconnect();
            }
        }

        private void DoConnectDisconnect() {
            // если не подключены
            if (_currentConnectoinContext == null) {
                UpdateConnectBlock(false);
                try {
                    RG_ENDPOINT portEndpoint = new RG_ENDPOINT();
                    portEndpoint.Address = _currentConenctionString;

                    uint errorCcode = UnmanagedContext.Instance.RG_InitDevice(ref portEndpoint, _currentReaderAddress);
                    if (errorCcode != 0) {
                        throw new ApiCallException("Ошибка при подключении к устройству", errorCcode);
                    }

                    RG_DEVICE_INFO_SHORT deviceInfo = new RG_DEVICE_INFO_SHORT();
                    errorCcode =
                        UnmanagedContext.Instance.RG_GetInfo(ref portEndpoint, _currentReaderAddress,
                            ref deviceInfo);
                    if (errorCcode != 0) {
                        throw new ApiCallException("Ошибка при запросе данных устройства", errorCcode);
                    }

                    _currentConnectoinContext =
                        new ReaderConnectionContext(portEndpoint, _currentReaderAddress, deviceInfo);

                    foreach (CodogrammData defaultCodogramm in _defaultCodogramms) {
                        try {
                            WriteCodogramm(defaultCodogramm);
                        }
                        catch (Exception ex) {
                            MessageBox.Show(this,
                                string.Format("({1}) {0}", ex.Message,
                                    (ex is ApiCallException)
                                        ? (ex as ApiCallException).ApiCallErrorCode.ToString()
                                        : "..."),
                                "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else {
                _pollStopEvent.Set();
                _currentConnectoinContext = null;
            }

            UpdateConnectBlock(true);
            EnableDisableReaderDataGroup();
        }

        private void UpdateConnectBlock(bool buttonState) {
            connectionStringTextBox.Enabled = false;
            addressUpDown.Enabled = false;
            button1.Enabled = !(_currentConnectoinContext != null);
            button2.Text = (_currentConnectoinContext != null) ? "Отключиться..." : "Подключиться...";
            button2.Enabled = buttonState;
        }

        private void EnableDisableReaderDataGroup() {
            readerDataGroup.Enabled = _currentConnectoinContext != null;
        }

        private void WriteCodogramm(CodogrammData data) {
            try {
                RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                byte address = _currentConnectoinContext.ReaderAddress;
                uint errorCode = UnmanagedContext.Instance.RG_WriteCodogramm(ref portEndpoin, address, data.Number,
                    data.LengthBits, data.CodogrammBody);
                if (errorCode != 0) {
                    throw new ApiCallException("Ошибка при записи кодограммы", errorCode);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this,
                    string.Format("({1}) {0}", ex.Message,
                        (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMaskClick(object sender, EventArgs e) {
            if ((_currentConnectoinContext != null)) {
                byte mask = 0;
                foreach (object checkedItem in checkedListBox1.CheckedItems) {
                    if (checkedItem is CardFamilyBindingWrapper) {
                        mask |= (checkedItem as CardFamilyBindingWrapper).Value;
                    }
                }

                try {
                    RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                    byte address = _currentConnectoinContext.ReaderAddress;
                    uint errorCode = UnmanagedContext.Instance.RG_SetCardsMask(ref portEndpoin, address, mask);
                    if (errorCode != 0) {
                        throw new ApiCallException("Ошибка при установке маски карт", errorCode);
                    }

                    MessageBox.Show(this, "Команда выполнена успешно", "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetMaskAllClick(object sender, EventArgs e) {
            if (_currentConnectoinContext != null) {
                byte mask = 0;
                for (int index = 0; index < checkedListBox1.Items.Count; index++) {
                    checkedListBox1.SetItemCheckState(index, CheckState.Checked);
                    if (checkedListBox1.CheckedItems[index] is CardFamilyBindingWrapper) {
                        mask |= (checkedListBox1.CheckedItems[index] as CardFamilyBindingWrapper).Value;
                    }
                }

                try {
                    RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                    byte address = _currentConnectoinContext.ReaderAddress;
                    uint errorCode = UnmanagedContext.Instance.RG_SetCardsMask(ref portEndpoin, address, mask);
                    if (errorCode != 0) {
                        throw new ApiCallException("Ошибка при установке маски карт", errorCode);
                    }

                    MessageBox.Show(this, "Команда выполнена успешно", "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DoConnectDisconnect();
                }
            }
        }

        private void SetMaskResetClick(object sender, EventArgs e) {
            if (_currentConnectoinContext != null) {
                byte mask = 0;
                for (int index = 0; index < checkedListBox1.Items.Count; index++) {
                    checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                }

                try {
                    RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                    byte address = _currentConnectoinContext.ReaderAddress;
                    uint errorCode = UnmanagedContext.Instance.RG_SetCardsMask(ref portEndpoin, address, mask);
                    if (errorCode != 0) {
                        throw new ApiCallException("Ошибка при установке маски карт", errorCode);
                    }

                    MessageBox.Show(this, "Команда выполнена успешно", "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DoConnectDisconnect();
                }
            }
        }

        private void RequestStatusClick(object sender, EventArgs e) {
            if (_currentConnectoinContext != null) {
                try {
                    RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                    byte address = _currentConnectoinContext.ReaderAddress;


                    RG_PIN_SATETS_16 pinStates = new RG_PIN_SATETS_16();
                    RG_DEVICE_STATUS_TYPE statusType = RG_DEVICE_STATUS_TYPE.DS_UNKNONWN;
                    RG_CARD_INFO cardInfo = new RG_CARD_INFO() {CardType = RG_CARD_TYPE_CODE.CT_UNKNOWN};
                    RG_CARD_MEMORY cardMemory = new RG_CARD_MEMORY
                    {
                        ProfileBlock = 0,
                        MemBlock = new byte[16]
                    };

                    uint errorCode = UnmanagedContext.Instance.RG_GetStatus(ref portEndpoin, address,
                        ref statusType, ref pinStates, ref cardInfo, ref cardMemory);
                    if (errorCode != 0 && statusType == RG_DEVICE_STATUS_TYPE.DS_UNKNONWN) {
                        throw new ApiCallException("Ошибка при запросе статуса устройства", errorCode);
                    }

                    Debug.WriteLine("Тампер: {0} Контрольный выход: {1}", pinStates.Pin00, pinStates.Pin01);

                    cardCodeTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : SystemColors.Control;
                    cardTypeTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : SystemColors.Control;
                    cardUidTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : SystemColors.Control;
                    cardMemoryTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : SystemColors.Control;
                    profileNumBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : SystemColors.Control;

                    switch (statusType) {
                        case RG_DEVICE_STATUS_TYPE.DS_NOCARD: {
                            cardCodeTextBox.Text = "";
                            cardTypeTextBox.Text = "";
                            cardUidTextBox.Text = "";
                            profileNumBox.Text = "";
                            cardMemoryTextBox.Text = "";
                            break;
                        }
                        case RG_DEVICE_STATUS_TYPE.DS_CARD: {
                            string enumFieldName = Enum.GetName(typeof(RG_CARD_TYPE_CODE), cardInfo.CardType);
                            string uidField = BitConverter.ToString(cardInfo.CardUid);

                            cardCodeTextBox.Text = ((byte) cardInfo.CardType).ToString("X2");
                            cardTypeTextBox.Text = enumFieldName;
                            cardUidTextBox.Text = uidField;
                            profileNumBox.Text = "";
                            cardMemoryTextBox.Text = "";
                            break;
                        }
                        case RG_DEVICE_STATUS_TYPE.DS_CARDAUTH: {
                            string enumFieldName = Enum.GetName(typeof(RG_CARD_TYPE_CODE), cardInfo.CardType);
                            string uidField = BitConverter.ToString(cardInfo.CardUid);
                            string memoryData = BitConverter.ToString(cardMemory.MemBlock);

                            cardCodeTextBox.Text = ((byte) cardInfo.CardType).ToString("X2");
                            cardTypeTextBox.Text = enumFieldName;
                            cardUidTextBox.Text = uidField;
                            profileNumBox.Text = cardMemory.ProfileBlock.ToString();
                            cardMemoryTextBox.Text = memoryData;

                            break;
                        }
                        case RG_DEVICE_STATUS_TYPE.DS_CARDNOAUTH: {
                            string enumFieldName = Enum.GetName(typeof(RG_CARD_TYPE_CODE), cardInfo.CardType);
                            string uidField = BitConverter.ToString(cardInfo.CardUid);

                            cardCodeTextBox.Text = ((byte) cardInfo.CardType).ToString("X2");
                            cardTypeTextBox.Text = enumFieldName;
                            cardUidTextBox.Text = uidField;
                            profileNumBox.Text = "";
                            cardMemoryTextBox.Text = string.Format("Ошибка доступа 0x{0:X2}", errorCode - 2000);


                            break;
                        }

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PollButtonClick(object sender, EventArgs e) {

            if (Interlocked.CompareExchange(ref _polling, 1, 0) == 0) {
                _pollStopEvent.Reset();
                Task.Factory.StartNew(() => poll(() => {
                    Interlocked.Exchange(ref _polling, 0);

                    readerDataGroup.InvokeIfRequired(() => {
                        button7.Text = "Вкл. опрос";
                        cardCodeTextBox.BackColor = SystemColors.Control;
                        cardTypeTextBox.BackColor = SystemColors.Control;
                        cardUidTextBox.BackColor = SystemColors.Control;
                        profileNumBox.BackColor = SystemColors.Control;
                        cardMemoryTextBox.BackColor = SystemColors.Control;

                        cardCodeTextBox.Text = "";
                        cardTypeTextBox.Text = "";
                        cardUidTextBox.Text = "";
                        profileNumBox.Text = "";
                        cardMemoryTextBox.Text = "";

                    });
                }));

                button7.Text = "Остановить";
            }
            else {
                _pollStopEvent.Set();
            }
        }

        private void poll(Action completeCallback) {
            try {
                while (!_pollStopEvent.WaitOne(200)) {
                    if (_currentConnectoinContext != null) {

                        RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                        byte address = _currentConnectoinContext.ReaderAddress;

                        RG_PIN_SATETS_16 pinStates = new RG_PIN_SATETS_16();
                        RG_DEVICE_STATUS_TYPE statusType = RG_DEVICE_STATUS_TYPE.DS_UNKNONWN;
                        RG_CARD_INFO cardInfo = new RG_CARD_INFO() {CardType = RG_CARD_TYPE_CODE.CT_UNKNOWN};
                        RG_CARD_MEMORY cardMemory = new RG_CARD_MEMORY()
                        {
                            ProfileBlock = 0,
                            MemBlock = new byte[16]
                        };

                        uint errorCode = UnmanagedContext.Instance.RG_GetStatus(ref portEndpoin, address,
                            ref statusType, ref pinStates, ref cardInfo, ref cardMemory);
                        if (errorCode != 0 && statusType == RG_DEVICE_STATUS_TYPE.DS_UNKNONWN) {
                            throw new ApiCallException("Ошибка при запросе статуса устройства", errorCode);
                        }

                        Debug.WriteLine("Тампер: {0} Контрольный выход: {1}", pinStates.Pin00, pinStates.Pin01);

                        readerDataGroup.InvokeIfRequired(() => {
                            cardCodeTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : Color.LightGreen;
                            cardTypeTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : Color.LightGreen;
                            cardUidTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : Color.LightGreen;
                            cardMemoryTextBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : Color.LightGreen;
                            profileNumBox.BackColor = pinStates.Pin00 ? Color.DarkSalmon : Color.LightGreen;
                        });

                        switch (statusType) {
                            case RG_DEVICE_STATUS_TYPE.DS_NOCARD: {
                                readerDataGroup.InvokeIfRequired(() => {
                                    cardCodeTextBox.Text = "";
                                    cardTypeTextBox.Text = "";
                                    cardUidTextBox.Text = "";
                                    profileNumBox.Text = "";
                                    cardMemoryTextBox.Text = "";
                                });
                                break;
                            }
                            case RG_DEVICE_STATUS_TYPE.DS_CARD: {
                                string enumFieldName = Enum.GetName(typeof(RG_CARD_TYPE_CODE), cardInfo.CardType);
                                string uidField = BitConverter.ToString(cardInfo.CardUid);

                                readerDataGroup.InvokeIfRequired(() => {
                                    cardCodeTextBox.Text = ((byte) cardInfo.CardType).ToString("X2");
                                    cardTypeTextBox.Text = enumFieldName;
                                    cardUidTextBox.Text = uidField;
                                    profileNumBox.Text = "";
                                    cardMemoryTextBox.Text = "";
                                });

                                break;
                            }
                            case RG_DEVICE_STATUS_TYPE.DS_CARDAUTH: {
                                string enumFieldName = Enum.GetName(typeof(RG_CARD_TYPE_CODE), cardInfo.CardType);
                                string uidField = BitConverter.ToString(cardInfo.CardUid);
                                string memoryData = BitConverter.ToString(cardMemory.MemBlock);

                                readerDataGroup.InvokeIfRequired(() => {
                                    cardCodeTextBox.Text = ((byte) cardInfo.CardType).ToString("X2");
                                    cardTypeTextBox.Text = enumFieldName;
                                    cardUidTextBox.Text = uidField;
                                    profileNumBox.Text = cardMemory.ProfileBlock.ToString();
                                    cardMemoryTextBox.Text = memoryData;
                                });

                                break;
                            }
                            case RG_DEVICE_STATUS_TYPE.DS_CARDNOAUTH: {
                                string enumFieldName = Enum.GetName(typeof(RG_CARD_TYPE_CODE), cardInfo.CardType);
                                string uidField = BitConverter.ToString(cardInfo.CardUid);

                                readerDataGroup.InvokeIfRequired(() => {
                                    cardCodeTextBox.Text = ((byte) cardInfo.CardType).ToString("X2");
                                    cardTypeTextBox.Text = enumFieldName;
                                    cardUidTextBox.Text = uidField;
                                    profileNumBox.Text = "";
                                    cardMemoryTextBox.Text = string.Format("Ошибка доступа 0x{0:X2}", errorCode - 2000);
                                });

                                break;
                            }
                            default:
                                break;
                        }
                    }
                    else {
                        break;
                    }
                }
            }
            finally {
                if (completeCallback != null) {
                    try {
                        completeCallback();
                    }
                    catch {
                    }
                }
            }
        }

        private void EditCodogrammSelected(object sender, EventArgs e) {
            if (codogrammsComboBox.SelectedIndex >= 0) {
                CodogrammData localData = _defaultCodogramms[codogrammsComboBox.SelectedIndex];
                using (CodogrammEditWindow editDialog =
                    new CodogrammEditWindow(localData) {StartPosition = FormStartPosition.CenterParent}) {
                    if (editDialog.ShowDialog(this) == DialogResult.OK) {
                        codogrammsComboBox.ResetDataSource(_defaultCodogramms);
                        soundBox.ResetDataSource(_defaultCodogramms);
                        redBox.ResetDataSource(_defaultCodogramms);
                        greenBox.ResetDataSource(_defaultCodogramms);
                        blueBox.ResetDataSource(_defaultCodogramms);

                        WriteCodogramm(_defaultCodogramms[codogrammsComboBox.SelectedIndex]);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void readerDataGroup_Enter(object sender, EventArgs e) {

        }

        private void StartIndicationClick(object sender, EventArgs e) {
            try {
                RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                byte address = _currentConnectoinContext.ReaderAddress;

                uint errorCode = UnmanagedContext.Instance.RG_StartInidicationDirect(
                    ref portEndpoin,
                    address,
                    Convert.ToByte(priotiryBox.SelectedIndex),
                    enableSound.Checked ? _defaultCodogramms[soundBox.SelectedIndex].Number : (byte) 0,
                    enableRed.Checked ? _defaultCodogramms[redBox.SelectedIndex].Number : (byte) 0,
                    enableGreen.Checked ? _defaultCodogramms[greenBox.SelectedIndex].Number : (byte) 0,
                    enableBlue.Checked ? _defaultCodogramms[blueBox.SelectedIndex].Number : (byte) 0);

                if (errorCode != 0) {
                    throw new ApiCallException("Ошибка при запске схемы индикации", errorCode);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this,
                    string.Format("({1}) {0}", ex.Message,
                        (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void controlOutSet_Click(object sender, EventArgs e) {
            try {
                RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                byte address = _currentConnectoinContext.ReaderAddress;

                uint errorCode = UnmanagedContext.Instance.RG_SetControlOutState(
                    ref portEndpoin,
                    address,
                    1,
                    (byte) (toGround.Checked ? 1 : 0),
                    Convert.ToByte(controlOutTime.Value));

                if (errorCode != 0) {
                    throw new ApiCallException("Ошибка при задании состояния контрольного выхода", errorCode);
                }

                MessageBox.Show(this, "Команда выполнена успешно", "Сообщение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(this,
                    string.Format("({1}) {0}", ex.Message,
                        (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSelectedProfileClick(object sender, EventArgs e) {
            if (profilesListBox.SelectedIndex >= 0) {
                ProfileData localData = _defaultProfiles[profilesListBox.SelectedIndex];
                using (ProfilesEditDialog editDialog =
                    new ProfilesEditDialog(localData) {StartPosition = FormStartPosition.CenterParent}) {
                    if (editDialog.ShowDialog(this) == DialogResult.OK) {
                        //profilesListBox.ResetDataSource(_defaultProfiles);
                        profilesListBox.Refresh();
                    }
                }
            }
        }

        private void WriteSelectedProfiles(object sender, EventArgs e) {
            if ((_currentConnectoinContext != null)) {
                try {
                    if (profilesListBox.CheckedItems.Count > 0) {
                        RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                        byte address = _currentConnectoinContext.ReaderAddress;

                        uint errorCode =
                            UnmanagedContext.Instance.RG_ResetProfiles(ref portEndpoin, address);
                        if (errorCode != 0) {
                            throw new ApiCallException("Ошибка при очистке профилей", errorCode);
                        }

                        RG_PROFILE_DATA apiProfileData = new RG_PROFILE_DATA();
                        apiProfileData.AccessFlags = 0;
                        apiProfileData.MfKey = new byte[6];
                        apiProfileData.MfAesKey = new byte[16];

                        byte profileIndex = 0;
                        byte[] accesFlagsStorage = new byte[1];
                        foreach (var checkedProfile in profilesListBox.CheckedItems) {
                            ProfileData localData = checkedProfile as ProfileData;

                            BitArray accessFlagsArray = new BitArray(8);
                            switch (localData.ProfileType) {
                                case ProfileType.Mifare:
                                    accessFlagsArray.Set(0, localData.CryptoOneKeyB);
                                    accessFlagsArray.Set(1, localData.AesKeyB);
                                    accessFlagsArray.Set(5, false);
                                    accessFlagsArray.Set(6, false);
                                    break;
                                case ProfileType.AppleGooglePay:
                                case ProfileType.MobileAccess:
                                    accessFlagsArray.Set(0, localData.KeyBitGenerated);
                                    accessFlagsArray.Set(1, localData.KeyBitDirect);
                                    accessFlagsArray.Set(2, localData.KeyBitEmited);

                                    accessFlagsArray.Set(5, localData.ProfileType == ProfileType.AppleGooglePay);
                                    accessFlagsArray.Set(6, localData.ProfileType != ProfileType.AppleGooglePay);

                                    break;                             
                            }
                            accessFlagsArray.CopyTo(accesFlagsStorage, 0);
                            apiProfileData.AccessFlags = accesFlagsStorage[0];

                            Buffer.BlockCopy(localData.CryptoOneKey, 0, apiProfileData.MfKey, 0,
                                apiProfileData.MfKey.Length);
                            Buffer.BlockCopy(localData.AesKey, 0, apiProfileData.MfAesKey, 0,
                                apiProfileData.MfAesKey.Length);

                            errorCode = UnmanagedContext.Instance.RG_WriteProfile(ref portEndpoin, address,
                                profileIndex++, localData.BlockNumber, ref apiProfileData);
                            if (errorCode != 0) {
                                throw new ApiCallException("Ошибка при записи профиля.", errorCode);
                            }
                        }

                        MessageBox.Show(this, "Команда выполнена успешно.", "Сообщение", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void WriteAllPRofiles(object sender, EventArgs e) {
            if ((_currentConnectoinContext != null)) {
                _authorizeCheckBehavior = true;
                for (int index = 0; index < profilesListBox.Items.Count; index++) {
                    profilesListBox.SetItemCheckState(index, CheckState.Checked);
                }
                _authorizeCheckBehavior = false;

                try {

                    RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                    byte address = _currentConnectoinContext.ReaderAddress;

                    uint errorCode =
                        UnmanagedContext.Instance.RG_ResetProfiles(ref portEndpoin, address);
                    if (errorCode != 0) {
                        throw new ApiCallException("Ошибка при очистке профилей", errorCode);
                    }

                    RG_PROFILE_DATA apiProfileData = new RG_PROFILE_DATA();
                    apiProfileData.AccessFlags = 0;
                    apiProfileData.MfKey = new byte[6];
                    apiProfileData.MfAesKey = new byte[16];


                    for (int index = 0; index < profilesListBox.Items.Count; index++) {

                        ProfileData localData = _defaultProfiles[index];
                        var accessFlag = (localData.CryptoOneKeyB ? 1 : 0) | ((localData.AesKeyB ? 1 : 0) << 1);
                        apiProfileData.AccessFlags = Convert.ToByte(accessFlag);
                        Buffer.BlockCopy(localData.CryptoOneKey, 0, apiProfileData.MfKey, 0,
                            apiProfileData.MfKey.Length);
                        Buffer.BlockCopy(localData.AesKey, 0, apiProfileData.MfAesKey, 0,
                            apiProfileData.MfAesKey.Length);

                        errorCode = UnmanagedContext.Instance.RG_WriteProfile(ref portEndpoin, address, Convert.ToByte(index),
                            localData.BlockNumber, ref apiProfileData);
                        if (errorCode != 0) {
                            throw new ApiCallException("Ошибка при записи профиля.", errorCode);
                        }
                    }

                    MessageBox.Show(this, "Команда выполнена успешно.", "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetProfilesClick(object sender, EventArgs e) {
            if ((_currentConnectoinContext != null)) {
                _authorizeCheckBehavior = true;
                for (int index = 0; index < profilesListBox.Items.Count; index++) {
                    profilesListBox.SetItemCheckState(index, CheckState.Unchecked);
                }
                _authorizeCheckBehavior = false;


                try {

                    RG_ENDPOINT portEndpoin = _currentConnectoinContext.ReaderPort;
                    byte address = _currentConnectoinContext.ReaderAddress;

                    uint errorCode =
                        UnmanagedContext.Instance.RG_ResetProfiles(ref portEndpoin, address);
                    if (errorCode != 0) {
                        throw new ApiCallException("Ошибка при очистке профилей", errorCode);
                    }

                    MessageBox.Show(this, "Команда выполнена успешно.", "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex) {
                    MessageBox.Show(this,
                        string.Format("({1}) {0}", ex.Message,
                            (ex is ApiCallException) ? (ex as ApiCallException).ApiCallErrorCode.ToString() : "..."),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool _authorizeCheckBehavior;
        private void DoProfileCheck(object sender, ItemCheckEventArgs e) {
            if (!_authorizeCheckBehavior)
                e.NewValue = e.CurrentValue;
        }

        private void DoProfileCheckDown(object sender, MouseEventArgs e) {
            CheckedListBox targetBox = sender as CheckedListBox;
            Point loc = targetBox.PointToClient(Cursor.Position);
            for (int i = 0; i < targetBox.Items.Count; i++) {
                Rectangle rec = targetBox.GetItemRectangle(i);
                rec.Width = 16;

                if (rec.Contains(loc)) {
                    _authorizeCheckBehavior = true;
                    bool newValue = !targetBox.GetItemChecked(i);
                    targetBox.SetItemChecked(i, newValue);
                    _authorizeCheckBehavior = false;

                    return;
                }
            }
        }
    }


    public static class ControlExtension {
        public static void InvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action) {
            if (obj.InvokeRequired) {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else {
                action();
            }
        }
    }

    public static class DataSourceExtensions {
        public static void ResetDataSource(this ListControl target, object newSource) {
            target.DataSource = null;
            target.DataSource = newSource;
        }
    }

}
