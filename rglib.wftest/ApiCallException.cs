using System;

namespace rglib.wftest {
    public class ApiCallException : Exception {
        private uint _apiCallErrorCode = 0;
        public ApiCallException(uint apiCallErrorCode) {
            _apiCallErrorCode = apiCallErrorCode;
        }
        public ApiCallException(string message, uint apiCallErrorCode) : base(message) {
            _apiCallErrorCode = apiCallErrorCode;
        }

        public uint ApiCallErrorCode {
            get { return _apiCallErrorCode; }
        }
    }
}