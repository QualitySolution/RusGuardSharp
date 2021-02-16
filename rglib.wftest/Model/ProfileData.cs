using System;
using System.Collections;
using RglibInterop;

namespace rglib.wftest.Model {
    public enum ProfileType {
        AppleGooglePay,
        MobileAccess,
        Mifare
    }

    public class ProfileData {
        private string _name;

        public ProfileData() {
            ProfileType = ProfileType.Mifare;
            CryptoOneKey = new byte[6] {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};
            AesKey = new byte[16]
                {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};
            BlockNumber = 1;
        }

        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                    _name = value;
            }
        }

        public ProfileType ProfileType { get; set; }

        public bool CryptoOneKeyB { get; set; }

        public bool KeyBitGenerated { get; set; }

        public bool KeyBitDirect { get; set; }

        public bool KeyBitEmited { get; set; }

        public bool AesKeyB { get; set; }

        public byte[] CryptoOneKey { get; set; }

        public byte[] AesKey { get; set; }

        public byte BlockNumber { get; set; }

        public override string ToString() {
            switch (ProfileType) {
                case ProfileType.AppleGooglePay:
                    return string.Format("{0}: Apple/Google Pay", Name);
                case ProfileType.MobileAccess:
                    return string.Format("{0}: Мобильное приложение", Name);
                case ProfileType.Mifare:
                    return string.Format("{0}: Mifare Блок№:{1} C1:{2} AES:{3}", Name, BlockNumber, CryptoOneKeyB ? "B" : "A",
                        AesKeyB ? "B" : "A");
            }

            return "Неизвестный тип профиля";
        }
    }
}