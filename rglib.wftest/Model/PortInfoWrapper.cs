using System;
using RglibInterop;

namespace rglib.wftest.Model {
    public class PortInfoBindingWrapper  : BindingWrapper<RG_ENDPOINT_INFO> {
        public PortInfoBindingWrapper(RG_ENDPOINT_INFO wrappedObject) : base(wrappedObject) { }

        public string ConnectionString {
            get { return WrappedObject.Address; }
        }

        public RG_ENDPOINT_TYPE PortType {
            get { return WrappedObject.PortType; }
        }

        public string FriendlyName {
            get { return WrappedObject.FriendlyName; }
        }

        public override string ToString() {
            return string.Format("{0} [{1}]", ConnectionString, FriendlyName);
        }
    }
}