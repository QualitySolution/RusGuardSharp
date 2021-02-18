using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rglib.wftest.Model;
using RglibInterop;

namespace rglib.wftest {
    public partial class FindPortsForm : Form {
        private BindingList<PortInfoBindingWrapper> _availablePorts;
        private BindingList<DeviceInfoBindingWrapper> _availableDevices;
        private string _selectedConnectionString;
        private byte? _selectedAddress;

        public FindPortsForm() {
            InitializeComponent();

            _availablePorts = new BindingList<PortInfoBindingWrapper>();
            _availableDevices = new BindingList<DeviceInfoBindingWrapper>();
            _selectedConnectionString = String.Empty;
            connectionsBox.DataSource = _availablePorts;
            devicesList.DataSource = _availableDevices;

        }

        private void UpdatePortList(bool findUsbFlag, bool findHidFlag) {
            groupBox1.Enabled = false;

            _availablePorts.Clear();
            try {
                IntPtr endPointsListHandle = IntPtr.Zero;
                uint endpointsCount = 0;
                byte endPointsMask = (byte) (0 | (findUsbFlag ? 1 : 0) | (findHidFlag ? 2 : 0));
                if (endPointsMask > 0) {
                    uint errorCode =
                        UnmanagedContext.Instance.RG_FindEndPoints(ref endPointsListHandle, endPointsMask, ref endpointsCount);
                    if (errorCode != 0)
                        throw new ApiCallException("Ошибка при вызове RG_FindEndPoints", errorCode);

                    if (endPointsListHandle != IntPtr.Zero) {
                        RG_ENDPOINT_INFO portInfo = new RG_ENDPOINT_INFO();
                        uint portIndex = 0;
                        while (UnmanagedContext.Instance.RG_GetFoundEndPointInfo(endPointsListHandle, portIndex, ref portInfo) == 0) {
                            _availablePorts.Add(new PortInfoBindingWrapper(portInfo));
                            portIndex++;
                        }

                        UnmanagedContext.Instance.RG_CloseResource(endPointsListHandle);
                    }
                }
            }
            catch (ApiCallException ex) {
                MessageBox.Show(this, string.Format("({1}) {0}", ex.Message, ex.ApiCallErrorCode), "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            connectionsBox.SelectedIndex = -1;

            groupBox1.Enabled = true;
        }

        public string SelectedConnectionString {
            get { return _selectedConnectionString; }
        }

        public byte? SelectedAddress {
            get { return _selectedAddress; }
        }

        private void CheckBoxCheckedStateChanged(object sender, EventArgs e) {
            UpdatePortList(findUsbHid.Checked, findSerial.Checked);
            UpdateDevicesOnPort();
        }

        private void OnLoad(object sender, EventArgs e) {
            if (!DesignMode) {
                UpdatePortList(findUsbHid.Checked, findSerial.Checked);
                UpdateDevicesOnPort();
            }
        }

        private void OkButtonClick(object sender, EventArgs e) {
            _selectedConnectionString = string.Empty;
            if (connectionsBox.SelectedIndex >= 0 && connectionsBox.SelectedItem is PortInfoBindingWrapper) {
                PortInfoBindingWrapper wrapper = connectionsBox.SelectedItem as PortInfoBindingWrapper;
                _selectedConnectionString = wrapper.ConnectionString;
            }

            _selectedAddress = 0;
            if (devicesList.SelectedIndex >= 0 && devicesList.SelectedItem is DeviceInfoBindingWrapper) {
                DeviceInfoBindingWrapper wrapper = devicesList.SelectedItem as DeviceInfoBindingWrapper;
                _selectedAddress = wrapper.DeviceAddress;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void PortListIndexChanged(object sender, EventArgs e) {
            groupBox1.Enabled = false;
            UpdateDevicesOnPort();
            groupBox1.Enabled = true;
        }

        private void UpdateDevicesOnPort() {
            _availableDevices.Clear();
            if (connectionsBox.SelectedIndex >= 0) {
                PortInfoBindingWrapper wrapper = connectionsBox.SelectedItem as PortInfoBindingWrapper;
                if (wrapper != null) {
                    RG_ENDPOINT endpoint = new RG_ENDPOINT();
                    endpoint.Type = wrapper.PortType;
                    endpoint.Address = wrapper.ConnectionString;
                    byte currentDeviceAddress = 0;
                    while (currentDeviceAddress < 4) {
                        uint errorCode = UnmanagedContext.Instance.RG_InitDevice(ref endpoint, currentDeviceAddress);
                        if (errorCode == 0) {
                            RG_DEVICE_INFO_SHORT deviceInfo = new RG_DEVICE_INFO_SHORT();
                            if (UnmanagedContext.Instance.RG_GetInfo(ref endpoint, currentDeviceAddress,
                                    ref deviceInfo) == 0) {
                                _availableDevices.Add(new DeviceInfoBindingWrapper(deviceInfo));
                            }
                        }
                        currentDeviceAddress++;
                    }
                }
            }
        }
    }
}
