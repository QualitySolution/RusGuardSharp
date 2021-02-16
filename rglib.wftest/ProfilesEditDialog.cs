using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rglib.wftest.Model;

namespace rglib.wftest {
    public partial class ProfilesEditDialog : Form {
        private ProfileData _profileData;

        public ProfilesEditDialog() : this(new ProfileData()) {

        }

        public ProfilesEditDialog(ProfileData profileData)
        {
            _profileData = profileData;
            InitializeComponent();
        }

        private void PreloadData() {
            switch (_profileData.ProfileType) {
                case ProfileType.Mifare: 
                    comboBox1.SelectedIndex = 0;
                    break;               
                case ProfileType.AppleGooglePay:
                    comboBox1.SelectedIndex = 1;
                    break;
                case ProfileType.MobileAccess:
                    comboBox1.SelectedIndex = 2;
                    break;
            }
            profileNameBox.Text = string.IsNullOrEmpty(_profileData.Name) ? "Новый профиль" : _profileData.Name;
            profileBlockBox.Value = _profileData.BlockNumber;
            cryptoOneType.SelectedIndex = _profileData.CryptoOneKeyB ? 1 : 0;
            aesKeyType.SelectedIndex = _profileData.AesKeyB ? 1 : 0;
            genKeyCheckBox.Checked = _profileData.KeyBitGenerated;
            presentKeyCheckBox.Checked = _profileData.KeyBitDirect;
            emitKeyCheckBox.Checked = _profileData.KeyBitEmited;

            hexBox1.ByteProvider = new FixedByteProvider(_profileData.CryptoOneKey);
            hexBox2.ByteProvider = new FixedByteProvider(_profileData.AesKey);
        }

        private void saveButton_Click(object sender, EventArgs e) {
            SaveOnTypeRelative();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
        }

        private void ProfilesEditForm_Load(object sender, EventArgs e) {
            
            PreloadData();
        }

        private void ProfileTypeIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex >= 0) {
                if (comboBox1.SelectedIndex == 0) {
                    mifareGroup.Enabled = true;
                    payGroup.Enabled = false;
                }
                else {
                    mifareGroup.Enabled = false;
                    payGroup.Enabled = true;
                }
            }
        }

        private void SaveOnTypeRelative() {
            if (!string.IsNullOrEmpty(profileNameBox.Text) && profileNameBox.Text != _profileData.Name)
                _profileData.Name = profileNameBox.Text;
            if (comboBox1.SelectedIndex >= 0) {
                switch (comboBox1.SelectedIndex) {
                    case 0: {
                        _profileData.ProfileType = ProfileType.Mifare;
                        _profileData.BlockNumber = Convert.ToByte(profileBlockBox.Value);
                        _profileData.CryptoOneKeyB = cryptoOneType.SelectedIndex == 1;
                        _profileData.AesKeyB = aesKeyType.SelectedIndex == 1;

                        if (hexBox1.ByteProvider.HasChanges()) {
                            hexBox1.ByteProvider.ApplyChanges();
                            Buffer.BlockCopy((hexBox1.ByteProvider as FixedByteProvider).Bytes.ToArray(), 0,
                                _profileData.CryptoOneKey, 0, _profileData.CryptoOneKey.Length);
                        }

                        if (hexBox2.ByteProvider.HasChanges()) {
                            hexBox2.ByteProvider.ApplyChanges();
                            Buffer.BlockCopy((hexBox2.ByteProvider as FixedByteProvider).Bytes.ToArray(), 0,
                                _profileData.AesKey, 0, _profileData.AesKey.Length);
                        }

                        break;
                    }
                    case 1:
                    case 2: {
                        _profileData.ProfileType = comboBox1.SelectedIndex == 1
                            ? ProfileType.AppleGooglePay
                            : ProfileType.MobileAccess;
                        _profileData.KeyBitGenerated = genKeyCheckBox.Checked;
                        _profileData.KeyBitDirect = presentKeyCheckBox.Checked;
                        _profileData.KeyBitEmited = emitKeyCheckBox.Checked;
                        break;
                    }
                }
            }
        }
    }
}
