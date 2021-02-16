using System;
using RglibInterop;

namespace rglib.wftest {
    public class ApiHelper {
        public static uint PerformReaderAction(ReaderConnectionContext ctx, Func<ReaderConnectionContext, uint> actionFunc)
        {
            if (ctx == null)
                throw new ArgumentNullException("ctx");
            if (actionFunc == null)
                throw new ArgumentNullException("actionFunc");
            try
            {
                return actionFunc(ctx);
            }
            catch (ApiCallException exception)
            {
                return exception.ApiCallErrorCode;
            }
            catch
            {
                throw;
            }
        }
    }



    public class ReaderConnectionContext {
        private readonly RG_PORT_ENDPOINT _readerPort;
        private RG_DEVICE_INFO _deviceInfo;
        private readonly byte _readerAddress;

        public ReaderConnectionContext(RG_PORT_ENDPOINT readerPort,  byte readerAddress, RG_DEVICE_INFO deviceInfo) {
            _readerPort = readerPort;
            _readerAddress = readerAddress;
            _deviceInfo = deviceInfo;
        }

        public RG_PORT_ENDPOINT ReaderPort {
            get { return _readerPort; }
        }

        public byte ReaderAddress {
            get { return _readerAddress; }
        }

        public RG_DEVICE_INFO DeviceInfo {
            get { return _deviceInfo; }
        }
    }
}