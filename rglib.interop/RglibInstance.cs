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
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
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
         * @param pEndPointListHandle Указатель на дескриптор перечислителя портов
         * @param enpointTypeMask Маска типов точек подключения
         * @return код ошибки
         */
        public error_t RG_FindEndPoints(ref IntPtr pEndPointListHandle, byte enpointTypeMask, ref uint pCount) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_FindEndPoints(ref pEndPointListHandle, enpointTypeMask, ref pCount);
        }

        /**
         * @brief 
         * @param endPointListHandle Дескриптор перечислителя точек подключения
         * @param pEndpointInfo Указатель на структуру с информацией о точке подключения
         * @return Код ошибки
         */
        public error_t RG_GetFoundEndPointInfo(IntPtr endPointListHandle, uint listIndex, ref RG_PORT_INFO pEndpointInfo) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetFoundEndPointInfo(endPointListHandle, listIndex, ref pEndpointInfo);
        }






        /// <summary>
        /// Выполняет поиск устройств по всем доступным точкам подключения.
        /// </summary>
        /// <param name="pDevicesListHandle">Указатель на переменную, в которомю будет записан дескриптор списка найденных устройств.</param>
        /// <param name="pCount">Указатель на переменную, по которому будет сохранено колличество элементов в списке результатов.</param>
        /// <returns></returns>
        public error_t RG_FindDevices(ref IntPtr pDevicesListHandle, ref uint pCount) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_FindDevices(ref pDevicesListHandle, ref pCount);
        }

        /**
         * @brief 
         * @param endPointListHandle Дескриптор перечислителя портов
         * @param pEndpointInfo Указатель на структуру с информацией о порте
         * @return Код ошибки
         */
        public error_t RG_GetFoundDeviceInfo(IntPtr pDeviceEnumerator, uint deviceIndex, ref RG_PORT_INFO pEndpointInfo, ref RG_DEVICE_INFO_EXT pDeviceInfoExt) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetFoundDeviceInfo(pDeviceEnumerator, deviceIndex, ref pEndpointInfo, ref pDeviceInfoExt);
        }

        /**
         * @brief Производит инициализацию устройства.  Нет необходимости при использовании флага инициализации RIF_TRANSPARENT_INIT
         * @param pEndpoint Строка подключения
         * @param deviceAddress Адрес устройства
         * @return Код ошибки
         */
        public error_t RG_InitDevice(ref RG_ENDPOINT pEndpoint, byte deviceAddress) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_InitDevice(ref pEndpoint, deviceAddress);
        }

        /**
         * @brief Запрашивает и возвращает краткую информацию о считывателе.
         * @param pEndPoint строка подключения
         * @param deviceAddress адрес устройства
         * @param pDeviceInfo не null указатель на структуру с информацией об устройстве
         * @return Код ошибки
         */
        public error_t RG_GetInfo(ref RG_ENDPOINT pEndPoint, byte deviceAddress, ref RG_DEVICE_INFO_SHORT pDeviceInfo) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetInfo(ref pEndPoint, deviceAddress, ref pDeviceInfo);
        }

        /**
        * @brief Запрашивает и возвращает расширенную информацию о считывателе.
        * @param pEndPoint строка подключения
        * @param deviceAddress адрес устройства
        * @param pDeviceInfo не null указатель на структуру с информацией об устройстве
        * @return Код ошибки
        */
        public error_t RG_GetInfoExt(ref RG_ENDPOINT pEndPoint, byte deviceAddress, ref RG_DEVICE_INFO_EXT pDeviceInfo)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetInfoExt(ref pEndPoint, deviceAddress, ref pDeviceInfo);
        }

        /**
        * @brief Запрашивает текущий статус устройства
        * @param pEndpoint указатель на параметры подключения
        * @param deviceAddress адрес сутройства
        * @param pStatusType не null указатель на тип статуса устройства
        * @param pCardInfo не null указатель на структуру данных о карте
        * @param pMemBlock указатель на структуру данных о памяти блока
        * @return Код ошибки
           */
        public error_t RG_GetStatus(
            ref RG_ENDPOINT pEndPoint,
            byte deviceAddress,
            ref RG_DEVICE_STATUS_TYPE pStatusType,
            ref RG_PIN_SATETS_16 pinStates,
            ref RG_CARD_INFO cardInfo,
            ref RG_CARD_MEMORY cardMemory)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_GetStatus(ref pEndPoint, deviceAddress, ref pStatusType, ref pinStates, ref cardInfo, ref cardMemory);
        }

        /**
         * @brief Устанавливает устройству маску считываемых типов карт
         * @param pEndpoint указатель на структура с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param cardfamilyMask маска типов семейств карт
         * @return Код ошибки
         */
        public error_t RG_SetCardsMask(ref RG_ENDPOINT pEndpoint, byte deviceAddress, byte cardfamilyMask) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_SetCardsMask(ref pEndpoint, deviceAddress, cardfamilyMask);
        }

        /**
         * @brief Очищает профили в памяти устройства
         * @param pEndpoint указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @return Код ошибки
         */
        public error_t RG_ResetProfiles(ref RG_ENDPOINT pEndpoint, byte deviceAddress) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_ResetProfiles(ref pEndpoint, deviceAddress);
        }

        /**
         * @brief Записывает профиль в память устройства
         * @param pEndpoint указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param profileNumber номер под которым будет записан профиль в память, в порядке убывания приоритета
         * @param pProfileinfo указатель на структуру с данными профиля
         * @return Код ошибки
         */
        public error_t RG_WriteProfile(
            ref RG_ENDPOINT pEndpoint,
            byte deviceAddress,
            byte profileNumber,
            byte blockNum,
            ref RG_PROFILE_DATA profileData)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_WriteProfile(ref pEndpoint, deviceAddress, profileNumber, blockNum, ref profileData);
        }

        /**
         * @brief Записывает кодограмму (схему андикации) в память устройства
         * @param pEndpoint указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param codogrammLengthBits длина кодограммы в битах ()макс 32)
         * @param codogrammBody тело кодограммы (1HS бит = 100мс)
         * @return Код ошибки
         */
        public error_t RG_WriteCodogramm(ref RG_ENDPOINT pEndpointp, byte deviceAddress, byte codogrammNumber,
            byte codogrammLengthBits, uint codogrammBody) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_WriteCodogramm(ref pEndpointp, deviceAddress, codogrammNumber, codogrammLengthBits, codogrammBody);
        }

        /**
         * @brief Запускает индикацию согласно соттветствующей схеме
         * @param pEndpoint указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param priorityLevel уровень приоритета индикации
         * @param pIndicStart указатель на структуру с информацией о схеме индикации для каждого канала
         * @return 
         */
        public error_t RG_StartInidication(ref RG_ENDPOINT pEndpoint, byte deviceAddress, byte priorityLevel,
            ref RG_INIDICATION_START_INFO pIndicStart) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_StartInidication(ref pEndpoint, deviceAddress, priorityLevel, ref pIndicStart);
        }

        /**
        * @brief Запускает индикацию согласно соттветствующей схеме
        * @param pEndpoint указатель на структуру с параметрами подключения
        * @param deviceAddress адрес устройства
        * @param priorityLevel уровень приоритета индикации
        * @param soundCodogrammNumber номер кодограммы звукового канала индикации
        * @param regCodogrammNumber номер кодограммы канала красного светодиода
        * @param greenCodogrammNumber номер кодограммы канала зеленого светодиода
        * @param blueCodogrammNumber номер кодограммы канала синего светодиода
        * @return Код ошибки
        */
        public error_t RG_StartInidicationDirect(ref RG_ENDPOINT pEndpoint, byte deviceAddress,
            byte priorityLevel, byte soundCodogrammNumber, byte regCodogrammNumber, byte greenCodogrammNumber,
            byte blueCodogrammNumber) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_StartInidicationDirect(ref pEndpoint, deviceAddress, priorityLevel, soundCodogrammNumber,
                regCodogrammNumber, greenCodogrammNumber, blueCodogrammNumber);
        }


        /**
         * @brief 
         * @param pEndpoint указатель на структуру с параметрами подключения
         * @param deviceAddress адрес устройства
         * @param controlOutNumber номер управляющего выхода
         * @param controlOutState устанавливаемое состояние (0/1)
         * @param timeoutSec время удержания состояния в сек. (0 - постоянно)
         * @return Код ошибки
         */
        public error_t RG_SetControlOutState(ref RG_ENDPOINT pEndpoint, byte deviceAddress,
            byte controlOutNumber, byte controlOutState, byte timeoutSec) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_SetControlOutState(ref pEndpoint, deviceAddress, controlOutNumber, controlOutState,
                timeoutSec);
        }

        public error_t RG_ReadBlockDirect(
            ref RG_ENDPOINT pEndpoint,
            byte deviceAddress,
            byte blockNum,
            ref RG_PROFILE_DATA profileData,
            byte[] blockData,
            ref UInt32 blockDataSize,
            ref RG_PIN_SATETS_16 pinStates) {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
            return _delegates.RG_ReadBlockDirect(ref pEndpoint, deviceAddress, blockNum, ref profileData, blockData, ref blockDataSize, ref pinStates);
        }

        #endregion
    }
}