using System;
using System.Runtime.InteropServices;
using RglibInterop.Common;
using error_t = System.UInt32;

namespace RglibInterop {

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetVersionDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_InitializeLibDelegate(uint initFlags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_UninitializeDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_CloseResourceDelegate(IntPtr pHandle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_FindEndPointsDelegate(ref IntPtr pEndPointListHandle, byte enpointTypeMask, ref uint pCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetFoundEndPointInfoDelegate(IntPtr endPointListHandle, uint listIndex, [In, Out] ref RG_PORT_INFO pEndpointInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_FindDevicesDelegate(ref IntPtr pDevicesListHandle, ref uint pCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetFoundDeviceInfoDelegate(IntPtr pDevicesListHandle, uint deviceIndex, [In, Out] ref RG_PORT_INFO pEndpointInfo, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfoExt);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_InitDeviceDelegate([In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetInfoDelegate(ref RG_PORT_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_SHORT pDeviceInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetInfoExtDelegate(ref RG_PORT_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetDeviceStatusDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp,
        byte deviceAddress,
        [In, Out, MarshalAs(UnmanagedType.U1)] ref RG_DEVICE_STATUS_TYPE pStatusType,
        [In, Out] ref RG_PIN_SATETS_16 pinStates,
        [In, Out] ref RG_CARD_INFO carDinfo,
        [In, Out] ref byte profileNum,
        [In, Out] byte[] memBlock);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_RequestCardDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp,
        byte deviceAddress,
        [In, Out] ref RG_CARD_INFO carDinfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_SetCardMaskDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp, 
        byte deviceAddress,
        byte cardfamilyMask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_ResetProfilesDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp,
        byte deviceAddress);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_WriteProfileDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp,
        byte deviceAddress,
        byte profileNumber, 
        byte blockNum,
        [In] ref RG_PROFILE_DATA profileData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_WriteCodogrammDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEpp, 
        byte deviceAddress, 
        byte codogrammNumber,
        byte codogrammLengthBits, 
        uint codogrammBody);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_StartInidicationDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp,
        byte deviceAddress,
        byte priorityLevel, 
        [In] ref RG_INIDICATION_START_INFO pIndicStart);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_StartInidicationDirectDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp, 
        byte deviceAddress,
        byte priorityLevel, 
        byte soundCodogrammNumber, 
        byte regCodogrammNumber, 
        byte greenCodogrammNumber,
        byte blueCodogrammNumber);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_SetControlOutStateDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp, 
        byte deviceAddress,
        byte controlOutNumber, 
        byte controlOutState, 
        byte timeoutSec);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_ReadBlockDirectDelegate(
        [In] ref RG_PORT_ENDPOINT pPortEp, 
        byte deviceAddress,
        byte blockNum,
        [In] ref RG_PROFILE_DATA profileData,
        [In, Out] byte[] blockData,
        [In, Out] ref UInt32 blockDataSize,
        [In, Out] ref RG_PIN_SATETS_16 pinStates);


    internal class Delegates {
        private static class LibNativeMethods {
            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetVersion();

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_InitializeLib(uint initFlags);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_Uninitialize();

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_CloseResource(IntPtr pHandle);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_FindEndPoints(ref IntPtr pEndPointListHandle, byte enpointTypeMask, ref uint pCount);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetFoundEndPointInfo(IntPtr pPortEnumerator, uint portIndex, [In, Out] ref RG_PORT_INFO pPortInfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_FindDevices(ref IntPtr pDevicesListHandle, ref uint pCount);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetFoundDeviceInfo(IntPtr pDeviceEnumerator, uint deviceIndex, [In, Out] ref RG_PORT_INFO pEndpointInfo, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfoExt);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_InitDevice([In] ref RG_PORT_ENDPOINT pPortEp, byte deviceAddress);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetInfo(ref RG_PORT_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_SHORT pDeviceInfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetInfoExt(ref RG_PORT_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetDeviceStatus(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                [In, Out, MarshalAs(UnmanagedType.U1)] ref RG_DEVICE_STATUS_TYPE pStatusType,
                [In, Out] ref RG_PIN_SATETS_16 pinStates,
                [In, Out] ref RG_CARD_INFO pCardInfo,
                [In, Out] ref byte profileNum,
                [In, Out] byte[] memBlock);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_RequestCard(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                [In, Out] ref RG_CARD_INFO carDinfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_SetCardMask(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                byte cardfamilyMask);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_ResetProfiles(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_WriteProfile(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                byte profileNumber,
                byte blockNum,
                [In] ref RG_PROFILE_DATA profileData);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_WriteCodogramm(
                [In] ref RG_PORT_ENDPOINT pPortEpp,
                byte deviceAddress,
                byte codogrammNumber,
                byte codogrammLengthBits,
                uint codogrammBody);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_StartInidication(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                byte priorityLevel,
                [In] ref RG_INIDICATION_START_INFO pIndicStart);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_StartInidicationDirect(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                byte priorityLevel,
                byte soundCodogrammNumber,
                byte regCodogrammNumber,
                byte greenCodogrammNumber,
                byte blueCodogrammNumber);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_SetControlOutState(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                byte controlOutNumber,
                byte controlOutState,
                byte timeoutSec);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_ReadBlockDirect(
                [In] ref RG_PORT_ENDPOINT pPortEp,
                byte deviceAddress,
                byte blockNum,
                [In] ref RG_PROFILE_DATA profileData,
                [In, Out] byte[] blockData,
                [In, Out] ref UInt32 blockDataSize,
                [In, Out] ref RG_PIN_SATETS_16 pinStates);
        }

        internal RG_GetVersionDelegate RG_GetVersion = null;

        internal RG_InitializeLibDelegate RG_InitializeLib = null;

        internal RG_UninitializeDelegate RG_Uninitialize = null;

        internal RG_CloseResourceDelegate RG_CloseResource = null;

        internal RG_FindEndPointsDelegate RG_FindEndPoints = null;

        internal RG_GetFoundEndPointInfoDelegate RG_GetFoundEndPointInfo = null;

        internal RG_FindDevicesDelegate RG_FindDevices = null;

        internal RG_GetFoundDeviceInfoDelegate RG_GetFoundDeviceInfo = null;

        internal RG_InitDeviceDelegate RG_InitDevice = null;

        internal RG_GetInfoDelegate RG_GetInfo = null;

        internal RG_GetInfoExtDelegate RG_GetInfoExt = null;

        internal RG_GetDeviceStatusDelegate RG_GetDeviceStatus = null;

        internal RG_RequestCardDelegate RG_RequestCard = null;

        internal RG_SetCardMaskDelegate RG_SetCardMask = null;

        internal RG_ResetProfilesDelegate RG_ResetProfiles = null;

        internal RG_WriteProfileDelegate RG_WriteProfile = null;

        internal RG_WriteCodogrammDelegate RG_WriteCodogramm = null;

        internal RG_StartInidicationDelegate RG_StartInidication = null;

        internal RG_StartInidicationDirectDelegate RG_StartInidicationDirect = null;

        internal RG_SetControlOutStateDelegate RG_SetControlOutState = null;

        internal RG_ReadBlockDirectDelegate RG_ReadBlockDirect = null;


        internal Delegates(IntPtr libraryHandle) {
            if (libraryHandle != IntPtr.Zero) {
                InitializeWithHandle(libraryHandle);
            }
            else {
                InitializeWithoutHandle();
            }

        }

        private void InitializeWithHandle(IntPtr libraryHandle) {
            RG_GetVersion =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetVersionDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetVersion"));

            RG_InitializeLib =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_InitializeLibDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_InitializeLib"));

            RG_Uninitialize =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_UninitializeDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_Uninitialize"));

            RG_CloseResource =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_CloseResourceDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_CloseResource"));

            RG_FindEndPoints =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_FindEndPointsDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_FindEndPoints"));

            RG_GetFoundEndPointInfo =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetFoundEndPointInfoDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetFoundEndPointInfo"));


            RG_FindDevices =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_FindDevicesDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_FindDevices"));

            RG_GetFoundDeviceInfo =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetFoundDeviceInfoDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetFoundDeviceInfo"));

            RG_InitDevice =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_InitDeviceDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_InitDevice"));

            RG_GetInfo =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetInfoDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetInfo"));

            RG_GetInfoExt =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetInfoExtDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetInfoExt"));

            RG_GetDeviceStatus =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetDeviceStatusDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetDeviceStatus"));

            //TODO: новое
            RG_RequestCard = UnmanagedLibrary.GetDelegateForFunctionPointer<RG_RequestCardDelegate>(
                UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_RequestCard"));

            RG_SetCardMask =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_SetCardMaskDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_SetCardMask"));

            RG_ResetProfiles =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_ResetProfilesDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_ResetProfiles"));

            RG_WriteProfile =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_WriteProfileDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_WriteProfile"));

            RG_WriteCodogramm =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_WriteCodogrammDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_WriteCodogramm"));

            RG_StartInidication =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_StartInidicationDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_StartInidication"));

            RG_StartInidicationDirect =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_StartInidicationDirectDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_StartInidicationDirect"));

            RG_SetControlOutState =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_SetControlOutStateDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_SetControlOutState"));

            RG_ReadBlockDirect =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_ReadBlockDirectDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_ReadBlockDirect"));

        }

        private void InitializeWithoutHandle() {
            RG_GetVersion = LibNativeMethods.RG_GetVersion;
            RG_InitializeLib = LibNativeMethods.RG_InitializeLib;
            RG_Uninitialize = LibNativeMethods.RG_Uninitialize;
            RG_CloseResource = LibNativeMethods.RG_CloseResource;
            RG_FindEndPoints = LibNativeMethods.RG_FindEndPoints;
            RG_GetFoundEndPointInfo = LibNativeMethods.RG_GetFoundEndPointInfo;

            RG_FindDevices = LibNativeMethods.RG_FindDevices;
            RG_GetFoundDeviceInfo = LibNativeMethods.RG_GetFoundDeviceInfo;

            RG_InitDevice = LibNativeMethods.RG_InitDevice;
            RG_GetInfo = LibNativeMethods.RG_GetInfo;
            RG_GetInfoExt = LibNativeMethods.RG_GetInfoExt;
            RG_GetDeviceStatus = LibNativeMethods.RG_GetDeviceStatus;

            RG_RequestCard = LibNativeMethods.RG_RequestCard;

            RG_SetCardMask = LibNativeMethods.RG_SetCardMask;
            RG_ResetProfiles = LibNativeMethods.RG_ResetProfiles;
            RG_WriteProfile = LibNativeMethods.RG_WriteProfile;
            RG_WriteCodogramm = LibNativeMethods.RG_WriteCodogramm;
            RG_StartInidication = LibNativeMethods.RG_StartInidication;
            RG_StartInidicationDirect = LibNativeMethods.RG_StartInidicationDirect;
            RG_SetControlOutState = LibNativeMethods.RG_SetControlOutState;

            RG_ReadBlockDirect = LibNativeMethods.RG_ReadBlockDirect;
        }
    }
}