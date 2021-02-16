using System;
using System.Runtime.InteropServices;

namespace RglibInterop.Common {
    /// <summary>
    /// Методы API
    /// </summary>
    internal static class NativeMethods {
        #region Windows

        /// <summary>
        /// Ошибка возникающая при попытке загрузки бинарника, собранного для другой архитектуры
        /// </summary>
        internal const int ERROR_BAD_EXE_FORMAT = 0xC1;

        /// <summary>
        /// Загружает указанный модуль в адресное пространстро процесса
        /// </summary>
        /// <param name="lpFileName">Имя модуля (библиотеки)</param>
        /// <returns> Если функция ывыполнилась успешно, возвращаемое значение будет содержать дескриптор модуля в памяти, иначе там будет null</returns>
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

        /// <summary>
        /// Выгружает указанный модуль из адресного пространства процесса
        /// </summary>
        /// <param name="hModule">Имя модуля (библиотеки)</param>
        /// <returns>Если функция выполнилась успешно, возвращаемое значение будет не нудевым</returns>
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        /// Возвращает адрес фукции или переменной из модуля (dll) загруженной в память процесса
        /// </summary>
        /// <param name="hModule">Дескриптор модуля.</param>
        /// <param name="lpProcName">Имя переменной или функции.</param>
        /// <returns>Если функция выполнилась успешно, возвращаемое значение будет содержать адрес на экспортируемую из библиотеки функцию или переменную</returns>
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        #endregion
    }
}