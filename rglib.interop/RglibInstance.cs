using System;
using System.Runtime.InteropServices;
using RglibInterop.Common;

using error_t = System.UInt32;

namespace RglibInterop {
    public class RglibInterface : IDisposable {
        private bool _disposed = false;
        private IntPtr _libraryHandle = IntPtr.Zero;
        private Delegates _delegates = null;

        public RglibInterface(string libraryPath) {
            try {
                if (!string.IsNullOrEmpty(libraryPath))
                    _libraryHandle = UnmanagedLibrary.Load(libraryPath);

                _delegates = new Delegates(_libraryHandle);
            }
            catch {
                Release();
                throw;
            }
        }

        private void Release() {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            if (_libraryHandle != IntPtr.Zero) {
                UnmanagedLibrary.Unload(_libraryHandle);
                _libraryHandle = IntPtr.Zero;
            }
        }

        #region IDisposable

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    Release();
                }

                _disposed = true;
            }
        }

        ~RglibInterface() {
            Dispose(false);
        }

        #endregion

        #region Methods

        /**
         * @brief Возвращает версию библиотеки
         * @return версия библиотеки
         */
        public error_t RG_GetVersion()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetVersion();
        }

        /**
         * @brief Инициализирует внутренние механизмыбиблиотеки перед началом работы
         * @return Код ошибки
         */
        public error_t RG_InitializeLib(uint initFlags) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_InitializeLib(initFlags);
        }

        /**
         * @brief Завершает работу внутренних механизмов библиотеки, ощиает ресурсы
         * @return Код ошибки
         */
        public error_t RG_Uninitialize()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_Uninitialize();
        }

        /**
         * @brief Закрывает ресурс аллоцированный библиотекой.
         * @param pHandle Дескриптор ресурса
         * @return Код ошибки
         */
        public error_t RG_CloseResource(IntPtr pHandle) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_CloseResource(pHandle);
        }

        /**
         * @brief Возвращает перечислитель доступных в системе совместимых портов
         * @param lpPortEnumerator Указатель на дескриптор перечислителя портов
         * @param aPortTypeMask Маска типов портов
         * @return код ошибки
         */
        public error_t RG_EnumeratePorts(ref IntPtr lpPortEnumerator, byte aPortTypeMask, ref uint portsCount) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_EnumeratePorts(ref lpPortEnumerator, aPortTypeMask, ref portsCount);
        }

        /**
         * @brief 
         * @param pPortEnumerator Дескриптор перечислителя портов
         * @param pPortInfo Указатель на структуру с информацией о порте
         * @return Код ошибки
         */
        public error_t RG_GetPortInfo(IntPtr pPortEnumerator, uint portIndex, ref RG_PORT_INFO pPortInfo) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetPortInfo(pPortEnumerator, portIndex, ref pPortInfo);
        }

        /**
         * @brief Возвращает перечислитель доступных в системе совместимых портов
         * @param lpPortEnumerator Указатель на дескриптор перечислителя портов
         * @param aPortTypeMask Маска типов портов
         * @return код ошибки
         */
        public error_t RG_EnumerateDevices(ref RG_PORT_ENDPOINT pPortEp, ref IntPtr lpDeviceEnumerator,
            ref uint devicesCount) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_EnumerateDevices(ref pPortEp, ref lpDeviceEnumerator, ref devicesCount);
        }

        /**
         * @brief 
         * @param pPortEnumerator Дескриптор перечислителя портов
         * @param pPortInfo Указатель на структуру с информацией о порте
         * @return Код ошибки
         */
        public error_t RG_GetNextDeviceInfo(IntPtr pDeviceEnumerator, uint deviceIndex,
            ref RG_DEVICE_INFO pDeviceInfo) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetNextDeviceInfo(pDeviceEnumerator, deviceIndex, ref pDeviceInfo);
        }

        /**
         * @brief Производит инициализацию устройства.  Нет необходимости при использовании флага инициализации RIF_TRANSPARENT_INIT
         * @param pPortEp Строка подключения
         * @param deviceAddress Адрес устройства
         * @return Код ошибки
         */
        public error_t RG_InitDevice(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_InitDevice(ref pPortEp, deviceAddress);
        }

        /**
         * @brief возвращает информацию об устройстве
         * @param pPortEp строка подключения
         * @param deviceAddress адрес устройства
         * @param pDeviceInfo не null указатель на структуру с информацией об устройстве
         * @return Код ошибки
         */
        public error_t RG_GetDeviceInfo(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress,
            ref RG_DEVICE_INFO pDeviceInfo) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetDeviceInfo(ref pPortEp, deviceAddress, ref pDeviceInfo);
        }

        /**
        * @brief Запрашивает текущий статус устройства
        * @param pPortEp указатель на параметры подключения
        * @param deviceAddress адрес сутройства
        * @param pStatusType не null указатель на тип статуса устройства
        * @param pCardInfo не null указатель на структуру данных о карте
        * @param pMemBlock указатель на структуру данных о памяти блока
        * @return Код ошибки
           */
        public error_t RG_GetDeviceStatus(
            ref RG_PORT_ENDPOINT pPortEp,
            byte deviceAddress,
            ref RG_DEVICE_STATUS_TYPE pStatusType,
            ref RG_PIN_SATETS_16 pinStates,
            ref RG_CARD_INFO carDinfo,
            ref byte profileNum,
            byte[] memBlock)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetDeviceStatus(ref pPortEp, deviceAddress, ref pStatusType, ref pinStates, ref carDinfo, ref profileNum, memBlock);
        }


        public error_t RG_RequestCard(
            ref RG_PORT_ENDPOINT pPortEp,
            byte deviceAddress,
            ref RG_CARD_INFO carDinfo) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_RequestCard(ref pPortEp, deviceAddress, ref carDinfo);
        }

        /**
         * @brief Устанавливает устройству маску считываемых типов карт
         * @param pPortEp указатель на структура с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param cardfamilyMask маска типов семейств карт
         * @return Код ошибки
         */
        public error_t RG_SetCardMask(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress, byte cardfamilyMask) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_SetCardMask(ref pPortEp, deviceAddress, cardfamilyMask);
        }

        /**
         * @brief Очищает профили в памяти устройства
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @return Код ошибки
         */
        public error_t RG_ResetProfiles(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_ResetProfiles(ref pPortEp, deviceAddress);
        }

        /**
         * @brief Записывает профиль в память устройства
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param profileNumber номер под которым будет записан профиль в память, в порядке убывания приоритета
         * @param pProfileinfo указатель на структуру с данными профиля
         * @return Код ошибки
         */
        public error_t RG_WriteProfile(
            ref RG_PORT_ENDPOINT pPortEp,
            byte deviceAddress,
            byte profileNumber,
            byte blockNum,
            ref RG_PROFILE_DATA profileData)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_WriteProfile(ref pPortEp, deviceAddress, profileNumber, blockNum, ref profileData);
        }

        /**
         * @brief Записывает кодограмму (схему андикации) в память устройства
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param codogrammLengthBits длина кодограммы в битах ()макс 32)
         * @param codogrammBody тело кодограммы (1HS бит = 100мс)
         * @return Код ошибки
         */
        public error_t RG_WriteCodogramm(ref RG_PORT_ENDPOINT pPortEpp, byte deviceAddress, byte codogrammNumber,
            byte codogrammLengthBits, uint codogrammBody) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_WriteCodogramm(ref pPortEpp, deviceAddress, codogrammNumber, codogrammLengthBits, codogrammBody);
        }

        /**
         * @brief Запускает индикацию согласно соттветствующей схеме
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param priorityLevel уровень приоритета индикации
         * @param pIndicStart указатель на структуру с информацией о схеме индикации для каждого канала
         * @return 
         */
        public error_t RG_StartInidication(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress, byte priorityLevel,
            ref RG_INIDICATION_START_INFO pIndicStart) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_StartInidication(ref pPortEp, deviceAddress, priorityLevel, ref pIndicStart);
        }

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
        public error_t RG_StartInidicationDirect(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress,
            byte priorityLevel, byte soundCodogrammNumber, byte regCodogrammNumber, byte greenCodogrammNumber,
            byte blueCodogrammNumber) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_StartInidicationDirect(ref pPortEp, deviceAddress, priorityLevel, soundCodogrammNumber,
                regCodogrammNumber, greenCodogrammNumber, blueCodogrammNumber);
        }


        /**
         * @brief 
         * @param pPortEp указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param controlOutNumber номер управляющего выхода
         * @param controlOutState устанавливаемое состояние (0/1)
         * @param timeoutSec время удержания состояния в сек. (0 - постоянно)
         * @return Код ошибки
         */
        public error_t RG_SetControlOutState(ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress,
            byte controlOutNumber, byte controlOutState, byte timeoutSec) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_SetControlOutState(ref pPortEp, deviceAddress, controlOutNumber, controlOutState,
                timeoutSec);
        }

        public error_t RG_ReadBlockDirect(
            ref RG_PORT_ENDPOINT pPortEp,
            byte deviceAddress,
            byte blockNum,
            ref RG_PROFILE_DATA profileData,
            byte[] blockData,
            ref UInt32 blockDataSize,
            ref RG_PIN_SATETS_16 pinStates) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_ReadBlockDirect(ref pPortEp, deviceAddress, blockNum, ref profileData, blockData, ref blockDataSize, ref pinStates);
        }

        #endregion
    }
}