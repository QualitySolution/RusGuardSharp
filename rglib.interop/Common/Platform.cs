using System;
using System.IO;

namespace RglibInterop.Common {
    public static class Platform {
        /// <summary>
        /// True если используется 64 битный рантайм
        /// </summary>
        public static bool Uses64BitRuntime {
            get { return (IntPtr.Size == 8); }
        }

        /// <summary>
        /// True если используется 32 битный рантайм
        /// </summary>
        public static bool Uses32BitRuntime {
            get { return (IntPtr.Size == 4); }
        }

        /// <summary>
        /// True если пользуемся под виндой
        /// </summary>
        private static bool _isWindows = false;

        /// <summary>
        /// True если пользуемся под виндой
        /// </summary>
        public static bool IsWindows {
            get {
                DetectPlatform();
                return _isWindows;
            }
        }

        /// <summary>
        /// True если пользуемся под никсами
        /// </summary>
        private static bool _isLinux = false;

        /// <summary>
        /// True если пользуемся под никсами
        /// </summary>
        public static bool IsLinux {
            get {
                DetectPlatform();
                return _isLinux;
            }
        }

        /// <summary>
        /// Size of native (unmanaged) long type
        /// </summary>
        private static int _nativeULongSize = 0;

        /// <summary>
        /// Size of native (unmanaged) long type.
        /// This property is used by HighLevelAPI to choose correct set of LowLevelAPIs.
        /// Value of this property can be changed if needed.
        /// </summary>
        public static int NativeULongSize {
            get {
                if (_nativeULongSize != 0)
                    return _nativeULongSize;
                _nativeULongSize = IsLinux ? IntPtr.Size : 4;
                return _nativeULongSize;
            }
            set {
                if (value != 4 && value != 8)
                    throw new ArgumentException();
                _nativeULongSize = value;
            }
        }

        private static int _structPackingSize = -1;

        /// <summary>
        /// Определяет стандартный размер упаковски структур
        /// </summary>
        public static int StructPackingSize {
            get {
                if (_structPackingSize != -1)
                    return _structPackingSize;
                _structPackingSize = IsLinux ? 0 : 1;
                return _structPackingSize;
            }
            set {
                if (value != 0 && value != 1)
                    throw new ArgumentException();
                _structPackingSize = value;
            }
        }

        /// <summary>
        /// Производит определение платформы
        /// </summary>
        private static void DetectPlatform() {
            if (_isWindows || _isLinux)
                return;
            // https://github.com/dotnet/corefx/issues/3032
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir)) {
                _isWindows = true;
            }
            else if (File.Exists(@"/proc/sys/kernel/ostype")) {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase)) {
                    _isLinux = true;
                }
            }
            throw new NotSupportedException();
        }
    }
}