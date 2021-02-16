using System;
using System.Runtime.Serialization;

namespace RglibInterop.Common {
    [Serializable]
    public class UnmanagedException : Exception {
        private int? _errorCode = null;

        public int? ErrorCode {
            get { return _errorCode; }
        }

        public UnmanagedException(string message)
            : base(message) {
            _errorCode = null;
        }

        public UnmanagedException(string message, int errorCode)
            : base(message) {
            _errorCode = errorCode;
        }
        protected UnmanagedException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
            bool errorCodeSet = info.GetBoolean("ErrorCodeSet");
            if (errorCodeSet)
                _errorCode = info.GetInt32("ErrorCode");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (info == null)
                throw new ArgumentNullException("info");
            bool errorCodeSet = (_errorCode != null);
            info.AddValue("ErrorCodeSet", errorCodeSet);
            if (errorCodeSet)
                info.AddValue("ErrorCode", _errorCode.Value);

            base.GetObjectData(info, context);
        }
    }
}
