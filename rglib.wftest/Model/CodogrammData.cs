using System;

namespace rglib.wftest.Model {
    public class CodogrammData {
        private byte _lengthBits = 32;
        private byte _number = 1;
        private uint _codogrammBody = 0x0f0ff0f0;

        public string Name { get; set; }

        public byte Number {
            get { return _number; }
            set { _number = value; }
        }

        public byte LengthBits {
            get { return _lengthBits; }
            set {
                byte localValue = value;

                if (localValue < 2)
                    localValue = 2;
                if (localValue > 32)
                    localValue = 32;
                _lengthBits = localValue;
            }
        }

        public uint CodogrammBody {
            get { return _codogrammBody; }
            set { _codogrammBody = value; }
        }

        public override string ToString() {
            return string.Format("{0} {1}", Number, string.IsNullOrEmpty(Name) ? "<noname>" : Name);
        }

        internal void Udpate(CodogrammData other) {
            if (other == null) throw new ArgumentNullException("other");

            _lengthBits = other.LengthBits;
            _number = other.Number;
            _codogrammBody = other.CodogrammBody;
        }
    }
}