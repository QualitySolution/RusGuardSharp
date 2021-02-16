using System;
using RglibInterop;

namespace rglib.wftest.Model {
    public class PortInfoBindingWrapper  : BindingWrapper<RG_PORT_INFO> {
        public PortInfoBindingWrapper(RG_PORT_INFO wrappedObject) : base(wrappedObject) { }

        public string ConnectionString {
            get { return WrappedObject.ConnectionString; }
        }

        public RG_PORT_TYPE PortType {
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