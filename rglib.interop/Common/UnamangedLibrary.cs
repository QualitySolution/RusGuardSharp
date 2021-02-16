using System;
using System.Runtime.InteropServices;

namespace RglibInterop.Common {
    public static class UnmanagedLibrary {
        public static IntPtr Load(string fileName) {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            IntPtr libraryHandle = IntPtr.Zero;

            libraryHandle = NativeMethods.LoadLibrary(fileName);
            if (libraryHandle == IntPtr.Zero) {
                int win32Error = Marshal.GetLastWin32Error();
                if (win32Error == NativeMethods.ERROR_BAD_EXE_FORMAT)
                    throw new BadImageFormatException();
                throw new UnmanagedException(
                    string.Format("Ошибка при загрузке библиотеки. Код ошибки: 0x{0:X8}", win32Error), win32Error);
            }


            return libraryHandle;
        }

        public static void Unload(IntPtr libraryHandle) {
            if (libraryHandle == IntPtr.Zero)
                throw new ArgumentNullException("libraryHandle");


            if (!NativeMethods.FreeLibrary(libraryHandle)) {
                int win32Error = Marshal.GetLastWin32Error();
                throw new UnmanagedException(
                    string.Format("Ошибка при выгрузке библиотеки. Код ошибки: 0x{0:X8}", win32Error), win32Error);
            }

        }

        public static IntPtr GetFunctionPointer(IntPtr libraryHandle, string function) {
            if (libraryHandle == IntPtr.Zero)
                throw new ArgumentNullException("libraryHandle");

            if (string.IsNullOrEmpty(function))
                throw new ArgumentNullException("function");

            IntPtr functionPointer = IntPtr.Zero;

            functionPointer = NativeMethods.GetProcAddress(libraryHandle, function);
            if (functionPointer == IntPtr.Zero) {
                int win32Error = Marshal.GetLastWin32Error();
                throw new UnmanagedException(
                    string.Format("Ошибка при получении указателю на функцию '{0}'. Код ошибки: 0x{1:X8}", function, win32Error),
                    win32Error);
            }

            return functionPointer;
        }

        public static T GetDelegateForFunctionPointer<T>(IntPtr functionPointer) {
            return (T) (object) Marshal.GetDelegateForFunctionPointer(functionPointer, typeof(T));
        }

        public static T GetFunctionDelegate<T>(IntPtr libraryHandle, string function) {
            IntPtr functionPtr = GetFunctionPointer(libraryHandle, function);
            return GetDelegateForFunctionPointer<T>(functionPtr);
        }
    }
}