using System;
using System.Runtime.InteropServices;

namespace RglibInterop {
    class lib_methods {

        //[DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_InitializeLib")]
        //public static extern uint RG_InitializeLib(uint initFlags);

        /**
         * @brief Возвращает версию библиотеки
         * @return версия библиотеки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_GetVersion")]
        public static extern uint RG_GetVersion();

        /**
         * @brief Инициализирует внутренние механизмыбиблиотеки перед началом работы
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_InitializeLib")]
        public static extern uint RG_InitializeLib(uint initFlags);

        /**
         * @brief Завершает работу внутренних механизмов библиотеки, ощиает ресурсы
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_Uninitialize")]
        public static extern uint  RG_Uninitialize();

        /**
         * @brief Закрывает ресурс аллоцированный библиотекой.
         * @param pHandle Дескриптор ресурса
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_CloseResource")]
        public static extern uint RG_CloseResource(IntPtr pHandle);

        /**
         * @brief Возвращает перечислитель доступных в системе совместимых портов
         * @param lpPortEnumerator Указатель на дескриптор перечислителя портов
         * @param aPortTypeMask Маска типов портов
         * @return код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_EnumeratePorts")]
        public static extern uint RG_EnumeratePorts(ref IntPtr lpPortEnumerator,  byte aPortTypeMask, ref uint portsCount);

        /**
         * @brief 
         * @param pPortEnumerator Дескриптор перечислителя портов
         * @param pPortInfo Указатель на структуру с информацией о порте
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_GetPortInfo")]
        public static extern uint RG_GetPortInfo(IntPtr pPortEnumerator, uint portIndex, [In, Out] ref RG_PORT_INFO pPortInfo);

        /**
         * @brief Производит инициализацию устройства.  Нет необходимости при использовании флага инициализации RIF_TRANSPARENT_INIT
         * @param pPortEp Строка подключения
         * @param deviceAddress Адрес устройства
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_InitDevice")]
        public static extern uint RG_InitDevice([In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress );

        /**
         * @brief возвращает информацию об устройстве
         * @param pPortEp строка подключения
         * @param deviceAddress адрес устройства
         * @param pDeviceInfo не null указатель на структуру с информацией об устройстве
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_GetDeviceInfo")]
        public static extern uint RG_GetDeviceInfo( ref RG_PORT_ENDPOINT pPortEp,  byte deviceAddress, ref RG_DEVICE_INFO pDeviceInfo );

        /**
        * @brief Запрашивает текущий статус устройства
        * @param pPortEp указатель на параметры подключения
        * @param deviceAddress адрес сутройства
        * @param pStatusType не null указатель на тип статуса устройства
        * @param pCardInfo не null указатель на структуру данных о карте
        * @param pMemBlock указатель на структуру данных о памяти блока
        * @return Код ошибки
           */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_GetDeviceStatus")]
        public static extern uint RG_GetDeviceStatus([In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress, [In, Out] ref byte pStatusType, [In, Out, MarshalAs(UnmanagedType.U1)] ref bool tamperState, [In, Out, MarshalAs(UnmanagedType.U1)] ref bool controlOutState, [In, Out] ref RG_CARD_INFO pCardInfo, [In, Out] ref RG_CARD_MEMORY_BLOCK_INFO pMemBlock);

        /**
         * @brief Устанавливает устройству маску считываемых типов карт
         * @param pPortEp указатель на структура с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param cardfamilyMask маска типов семейств карт
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_SetCardMask")]
        public static extern uint RG_SetCardMask([In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress,  byte cardfamilyMask);

        /**
         * @brief Очищает профили в памяти устройства
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_ResetProfiles")]
        public static extern uint RG_ResetProfiles( [In] ref RG_PORT_ENDPOINT pPortEp,  byte deviceAddress );

        /**
         * @brief Записывает профиль в память устройства
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param profileNumber номер под которым будет записан профиль в память, в порядке убывания приоритета
         * @param pProfileinfo указатель на структуру с данными профиля
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_WriteProfile")]
        public static extern uint RG_WriteProfile([In] ref RG_PORT_ENDPOINT pPortEp,  byte deviceAddress, byte profileNumber, [In] ref RG_PROFILE_INFO pProfileinfo );

        /**
         * @brief Записывает кодограмму (схему андикации) в память устройства
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param codogrammLengthBits длина кодограммы в битах ()макс 32)
         * @param codogrammBody тело кодограммы (1HS бит = 100мс)
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_WriteCodogramm")]
        public static extern uint RG_WriteCodogramm([In] ref RG_PORT_ENDPOINT pPortEpp, byte deviceAddress, byte codogrammLengthBits, uint codogrammBody );

        /**
         * @brief Запускает индикацию согласно соттветствующей схеме
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param priorityLevel уровень приоритета индикации
         * @param pIndicStart указатель на структуру с информацией о схеме индикации для каждого канала
         * @return 
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_StartInidication")]
        public static extern uint RG_StartInidication([In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress, byte priorityLevel, [In] ref RG_INIDICATION_START_INFO pIndicStart);

        /**
        * @brief Запускает индикацию согласно соттветствующей схеме
        * @param pPortEp указатель на структуру с параметрами подключения
        * @param deviceAddress адрес устройства
        * @param priorityLevel уровень приоритета индикации
        * @param soundCodogrammNumber номер кодограммы звукового канала индикации
        * @param regCodogrammNumber номер кодограммы канала красного светодиода
        * @param greenCodogrammNumber номер кодограммы канала зеленого светодиода
        * @param blueCodogrammNumber номер кодограммы канала синего светодиода
        * @return Код ошибки
        */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_StartInidicationDirect")]
        public static extern uint RG_StartInidicationDirect( [In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress, byte priorityLevel, byte soundCodogrammNumber, byte regCodogrammNumber, byte greenCodogrammNumber, byte blueCodogrammNumber);


        /**
         * @brief 
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param controlOutNumber номер управляющего выхода
         * @param controlOutState устанавливаемое состояние (0/1)
         * @param timeoutSec время удержания состояния в сек. (0 - постоянно)
         * @return Код ошибки
         */
        [DllImport("rglib_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RG_SetControlOutState")]
        public static extern uint RG_SetControlOutState( [In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress, byte controlOutNumber,  byte controlOutState, byte timeoutSec);

    }
}