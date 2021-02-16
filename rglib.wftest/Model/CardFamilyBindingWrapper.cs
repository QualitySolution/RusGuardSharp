using System;
using System.Runtime.Remoting.Messaging;
using RglibInterop;

namespace rglib.wftest.Model {
    public class CardFamilyBindingWrapper : BindingWrapper<RG_CARD_FAMILY_CODE> {
        public CardFamilyBindingWrapper(RG_CARD_FAMILY_CODE wrappedObject) : base(wrappedObject) {
        }

        public byte Value {
            get { return (byte) WrappedObject; }
        }

        public override string ToString() {
            switch (WrappedObject)
            {
                case RG_CARD_FAMILY_CODE.CF_PINCODE:
                    return "PIN conde";
                case RG_CARD_FAMILY_CODE.CF_TEMIC:
                    return "TEMIC";
                case RG_CARD_FAMILY_CODE.CF_HID:
                    return "HID";
                case RG_CARD_FAMILY_CODE.CF_EMMARINE:
                    return "Em-Marine";
                case RG_CARD_FAMILY_CODE.CF_INDALA:
                    return "INDALA";
                case RG_CARD_FAMILY_CODE.CF_COTAG:
                    return "COTAG";
                case RG_CARD_FAMILY_CODE.EF_MIFARE:
                    return "Mifare";
            }

            return "Unknonw";
        }
    }
}