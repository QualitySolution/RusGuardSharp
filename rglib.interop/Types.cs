// ReSharper disable InconsistentNaming

using System;
using System.Runtime.InteropServices;

namespace RglibInterop {

    class lib_consts {
        internal const int MAX_STRING_LENGTH = 32;
        internal const int UID_DATA_MAX_SIZE = 8;
        internal const int MEMORY_BLOCK_MAX_SIZE = 16;
    }

    /// <summary>
    /// Перечисле кодов семейств карт
    /// </summary>
    public enum RG_CARD_FAMILY_CODE : byte {
        /// <summary>
        /// Ввод с цифровой клавиатуры
        /// </summary>
        CF_PINCODE = 0x01,

        /// <summary>
        /// Карты типа Temic
        /// </summary>
        CF_TEMIC = 0x02,

        /// <summary>
        /// Карты типа HID
        /// </summary>
        CF_HID = 0x04,

        /// <summary>
        /// Карты типа Em-Marine
        /// </summary>
        CF_EMMARINE = 0x08,

        /// <summary>
        /// Карты типа Indala
        /// </summary>
        CF_INDALA = 0x10,

        /// <summary>
        /// Карты типа Cotag
        /// </summary>
        CF_COTAG = 0x20,

        /// <summary>
        /// Карты типа Mifare
        /// </summary>
        EF_MIFARE = 0x40
    }

    public enum RG_CARD_TYPE_CODE : byte {
        /// <summary>
        /// Код склавиатуры
        /// </summary>
        CT_PINCODE = 0x00,

        /// <summary>
        /// Карта Temic
        /// </summary>
        CT_TEMIC = 0x01,

        /// <summary>
        /// Карта HID
        /// </summary>
        CT_HID = 0x02,

        /// <summary>
        /// Карта Em-Marine
        /// </summary>
        CT_EMMARINE = 0x03,

        /// <summary>
        /// Карта Indala
        /// </summary>
        CT_INDALA = 0x04,

        /// <summary>
        /// Карта Сotag
        /// </summary>
        CT_COTAG = 0x05,

        /// <summary>
        /// Карта MIFARE DESFire EV1
        /// </summary>
        CT_MF_DESFIRE_EV1 = 0x06,

        /// <summary>
        /// Карта MIFARE Ultralight
        /// </summary>
        CT_MF_UL = 0x07,

        /// <summary>
        /// Карта MIFARE Mini
        /// </summary>
        CT_MF_MINI = 0x08,

        /// <summary>
        /// Карта MIFARE Classic 1K / MIFARE Plus EV1 2K SL1
        /// </summary>
        CT_MF_CL1K_PL2K = 0x09,

        /// <summary>
        /// Карта MIFARE Classic 4K / MIFARE Plus EV1 4K SL1
        /// </summary>
        CT_MF_CL4K_PL4K = 0x0A,

        /// <summary>
        /// Карта MIFARE Plus 2K SL2
        /// </summary>
        CT_MF_PL2K_SL2 = 0x0B,

        /// <summary>
        /// Карта MIFARE Plus 4K SL2
        /// </summary>
        CT_MF_PL4K_SL2 = 0x0C,

        /// <summary>
        /// Карта MIFARE Plus SL3
        /// </summary>
        CT_MF_Sl3 = 0x0D,

        /// <summary>
        /// Карта SmartMX 4K
        /// </summary>
        CT_SMARTMX4K = 0x0E,

        /// <summary>
        /// Карта SmartMX 1K
        /// </summary>
        CT_SMARTMX1K = 0x0F,

        /// <summary>
        /// Карта отсутствует
        /// </summary>
        CT_NOCARD = 0xFE,

        /// <summary>
        /// Карта не попавшая в класификацию
        /// </summary>
        CT_UNKNOWN = 0xFF
    };

    /// <summary>
    /// Тип подключения
    /// </summary>
    public enum RG_PORT_TYPE : byte {
        /// <summary>
        /// Неизвестный тип подключения (не удалось разобрать строку подключения)
        /// </summary>
        PT_UNKNOWN = 0x00,

        /// <summary>
        /// Подключение через последовательный порт
        /// <remarks>При работе через последовательный порт, максимальное число устрйоств на подключении - 4</remarks>>
        /// </summary>
        PT_USBHID = 0x01,

        /// <summary>
        /// Подключение по USB
        /// </summary>
        PT_SERIAL = 0x02
    }

    /// <summary>
    /// Тип подключения
    /// </summary>
    public enum RG_DEVICE_TYPE : byte {
        /// <summary>
        /// Неизвестное устройство
        /// </summary>
        DT_UNKNONWN = 0x00,

        /// <summary>
        /// Мультиформатный считыватель 202
        /// </summary>
        DT_RDR202MULTY = 0x04,

        /// <summary>
        /// Считыватель R10 EHT
        /// </summary>
        DT_R10EHT = 0x0A
    }

    /// <summary>
    /// Структура определяющая параметры подключения
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RG_PORT_ENDPOINT {
        /// <summary>
        /// Строка подключения (31 символов ASCII + null символ)
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)] public string ConnectionString;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1, Size = 65)]
    public struct RG_PORT_INFO {
        /// <summary>
        /// Тип подключения
        /// </summary>
        [MarshalAs(UnmanagedType.U1)] public RG_PORT_TYPE PortType;

        /// <summary>
        /// Строка подключения
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = lib_consts.MAX_STRING_LENGTH)]
        public string ConnectionString;

        /// <summary>
        /// Отображаемое имя устройства (почти как в диспетчере windows)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = lib_consts.MAX_STRING_LENGTH)]
        public string FriendlyName;
    }

    /// <summary>
    /// Структура информации об устройстве
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1, Size = 4)]
    public struct RG_DEVICE_INFO {
        /// <summary>
        /// Адрес устройства
        /// </summary>
        public byte DeviceAddress;

        /// <summary>
        /// Тип устройства
        /// </summary>
        [MarshalAs(UnmanagedType.U1)] public RG_DEVICE_TYPE DeviceType;

        /// <summary>
        /// Версия прошивки устройства
        /// </summary>
        public byte FirmwareVersion;

        /// <summary>
        /// Количество кодограмм в памяти устройства
        /// </summary>
        public byte CodogrammsCount;
    }

    /// <summary>
    /// Информация о карте
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1, Size = 2 + lib_consts.UID_DATA_MAX_SIZE)]
    public struct RG_CARD_INFO {
        /// <summary>
        /// Код типа карты
        /// </summary>
        [MarshalAs(UnmanagedType.U1)] public RG_CARD_TYPE_CODE CardType;

        /// <summary>
        /// UID карты, формат и точный размер зависят непосредственно от типа карты
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = lib_consts.UID_DATA_MAX_SIZE)]
        public byte[] CardUid;
    }

    /// <summary>
    /// Текущий статус устройства
    /// </summary>
    public enum RG_DEVICE_STATUS_TYPE : byte {
        /// <summary>
        /// Неизвестный статус, либо что-то прошло не так. Смотрите код ошибки.
        /// </summary>
        DS_UNKNONWN = 0x00,

        /// <summary>
        /// Нет прилооженной карты
        /// </summary>
        DS_NOCARD = 0x01,

        /// <summary>
        /// Есть карта, но без памяти или в памяти считывателя нет профилей
        /// </summary>
        DS_CARD = 0x09,

        /// <summary>
        /// Есть карта с памятью и есть профиль, по которому удалось авторизоваться
        /// </summary>
        DS_CARDAUTH = 0x1A,

        /// <summary>
        /// Есть карта с памятью, но ни один профиль не подошел
        /// </summary>
        DS_CARDNOAUTH = 0x0A
    }

    /// <summary>
    /// Структура с информацией о профиле
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1, Size = 24)]
    public struct RG_PROFILE_DATA {
        /// <summary>
        /// Параметры авторизации
        /// </summary>
        public byte AccessFlags;

        /// <summary>
        /// байт ключа Crypto1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] MfKey;

        /// <summary>
        /// 16 байт ключа AES
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] MfAesKey;
    }

    /// <summary>
    /// Структура с информацией о схеме индикации на каждом канале
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1, Size = 4)]
    public struct RG_INIDICATION_START_INFO {
        /// <summary>
        /// номер кодограммы звукового канала индикации
        /// </summary>
        public byte SoundCodogrammNumber;

        /// <summary>
        /// номер кодограммы канала красного светодиода
        /// </summary>
        public byte RegCodogrammNumber;

        /// <summary>
        /// номер кодограммы канала зеленого светодиода
        /// </summary>
        public byte GreenCodogrammNumber;

        /// <summary>
        /// номер кодограммы канала синего светодиода
        /// </summary>
        public byte BlueCodogrammNumber;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1, Size = 2)]
    public struct RG_PIN_SATETS_16 {

        public ushort pinStatesData;

        public bool Pin00 {
            get { return ((pinStatesData >> 0) & 1) == 1; }
            set {
                ushort bitValue = (1 << 0);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin01 {
            get { return ((pinStatesData >> 1) & 1) == 1; }
            set {
                ushort bitValue = (1 << 1);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin02 {
            get { return ((pinStatesData >> 2) & 1) == 1; }
            set {
                ushort bitValue = (1 << 2);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin03 {
            get { return ((pinStatesData >> 3) & 1) == 1; }
            set {
                ushort bitValue = (1 << 3);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin04 {
            get { return ((pinStatesData >> 4) & 1) == 1; }
            set {
                ushort bitValue = (1 << 4);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin05 {
            get { return ((pinStatesData >> 5) & 1) == 1; }
            set {
                ushort bitValue = (1 << 5);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin06 {
            get { return ((pinStatesData >> 6) & 1) == 1; }
            set {
                ushort bitValue = (1 << 6);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin07 {
            get { return ((pinStatesData >> 7) & 1) == 1; }
            set {
                ushort bitValue = (1 << 7);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin08 {
            get { return ((pinStatesData >> 8) & 1) == 1; }
            set {
                ushort bitValue = (1 << 8);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin09 {
            get { return ((pinStatesData >> 9) & 1) == 1; }
            set {
                ushort bitValue = (1 << 9);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin10 {
            get { return ((pinStatesData >> 10) & 1) == 1; }
            set {
                ushort bitValue = (1 << 10);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin11 {
            get { return ((pinStatesData >> 11) & 1) == 1; }
            set {
                ushort bitValue = (1 << 11);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin12 {
            get { return ((pinStatesData >> 12) & 1) == 1; }
            set {
                ushort bitValue = (1 << 12);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin13 {
            get { return ((pinStatesData >> 13) & 1) == 1; }
            set {
                ushort bitValue = (1 << 13);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin14 {
            get { return ((pinStatesData >> 14) & 1) == 1; }
            set {
                ushort bitValue = (1 << 14);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool Pin15 {
            get { return ((pinStatesData >> 15) & 1) == 1; }
            set {
                ushort bitValue = (1 << 15);
                if (value)
                    pinStatesData |= bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }

        public bool this[int index] {
            get {
                if (index < 0 || index > 15)
                    throw new ArgumentOutOfRangeException("index");
                return ((pinStatesData >> index) & 1) == 1;
            }
            set {
                if (index < 0 || index > 15)
                    throw new ArgumentOutOfRangeException("index");
                int bitValue = (1 << index);
                if (value)
                    pinStatesData |= (ushort) bitValue;
                else {
                    pinStatesData &= (ushort) ~bitValue;
                }
            }
        }
    }
}