using RglibInterop;

namespace rglib.wftest.Model {
    public class DeviceInfoBindingWrapper : BindingWrapper<RG_DEVICE_INFO_SHORT> {
        public DeviceInfoBindingWrapper(RG_DEVICE_INFO_SHORT wrappedObject) : base(wrappedObject) {
        }

        public RG_DEVICE_TYPE DeviceType {
            get { return WrappedObject.DeviceType; }
        }
        public byte FirmwareVersion {
            get { return WrappedObject.FirmwareVersion; }
        }
        public byte CodogrammsCount {
            get { return WrappedObject.CodogrammsCount; }
        }
        public byte DeviceAddress {
            get { return WrappedObject.DeviceAddress; }
        }
        public override string ToString() {
            return string.Format("{0} Адрес: {1} Прошивка: {2}", GetDeviceTypeString(DeviceType), DeviceAddress, FirmwareVersion);
        }

        private string GetDeviceTypeString(RG_DEVICE_TYPE type) {
            switch (type) {
                case RG_DEVICE_TYPE.DT_RDR202MULTY:
                    return "RDR-202 Multy";
                case RG_DEVICE_TYPE.DT_R10EHT:
                    return "R10 EHT";
                case RG_DEVICE_TYPE.DT_UNKNONWN:
                default:
                    return "[Неизвестное устройство]";
            }
        }
    }
}