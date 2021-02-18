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
    internal delegate error_t RG_GetFoundEndPointInfoDelegate(IntPtr endPointListHandle, uint listIndex, [In, Out] ref RG_ENDPOINT_INFO pEndpointInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_FindDevicesDelegate(ref IntPtr pDevicesListHandle, ref uint pCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetFoundDeviceInfoDelegate(IntPtr pDevicesListHandle, uint deviceIndex, [In, Out] ref RG_ENDPOINT_INFO pEndpointInfo, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfoExt);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_InitDeviceDelegate([In] ref RG_ENDPOINT pEndpoint, byte deviceAddress);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetInfoDelegate(ref RG_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_SHORT pDeviceInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetInfoExtDelegate(ref RG_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_GetStatusDelegate(
        [In] ref RG_ENDPOINT pEndpoint,
        byte deviceAddress,
        [In, Out, MarshalAs(UnmanagedType.U1)] ref RG_DEVICE_STATUS_TYPE pStatusType,
        [In, Out] ref RG_PIN_SATETS_16 pinStates,
        [In, Out] ref RG_CARD_INFO cardInfo,
        [In, Out] ref RG_CARD_MEMORY cardMemory);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_SetCardsMaskDelegate(
        [In] ref RG_ENDPOINT pEndpoint,
        byte deviceAddress,
        byte cardfamilyMask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_ClearProfilesDelegate(
        [In] ref RG_ENDPOINT pEndpoint,
        byte deviceAddress);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_WriteProfileDelegate(
        [In] ref RG_ENDPOINT pEndpoint,
        byte deviceAddress,
        byte profileNumber,
        byte blockNum,
        [In] ref RG_PROFILE_DATA profileData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_WriteCodogrammDelegate(
        [In] ref RG_ENDPOINT pEndpointp,
        byte deviceAddress,
        byte codogrammNumber,
        [In] ref RG_CODOGRAMM pCodogramm);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_StartCodogrammDelegate(
        [In] ref RG_ENDPOINT pEndpoint, 
        byte deviceAddress,
        byte priorityLevel, 
        byte soundCodogrammNumber, 
        byte regCodogrammNumber, 
        byte greenCodogrammNumber,
        byte blueCodogrammNumber);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_SetControlOutputStateDelegate(
        [In] ref RG_ENDPOINT pEndpoint, 
        byte deviceAddress,
        byte controlOutNumber, 
        byte controlOutState, 
        byte timeoutSec);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate error_t RG_ReadBlockDirectDelegate(
        [In] ref RG_ENDPOINT pEndpoint, 
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
            internal static extern error_t RG_GetFoundEndPointInfo(IntPtr pPortEnumerator, uint portIndex, [In, Out] ref RG_ENDPOINT_INFO pEndpointInfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_FindDevices(ref IntPtr pDevicesListHandle, ref uint pCount);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetFoundDeviceInfo(IntPtr pDeviceEnumerator, uint deviceIndex, [In, Out] ref RG_ENDPOINT_INFO pEndpointInfo, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfoExt);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_InitDevice([In] ref RG_ENDPOINT pEndpoint, byte deviceAddress);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetInfo(ref RG_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_SHORT pDeviceInfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetInfoExt(ref RG_ENDPOINT pEndPoint, byte deviceAddress, [In, Out] ref RG_DEVICE_INFO_EXT pDeviceInfo);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_GetStatus(
                [In] ref RG_ENDPOINT pEndpoint,
                byte deviceAddress,
                [In, Out, MarshalAs(UnmanagedType.U1)] ref RG_DEVICE_STATUS_TYPE pStatusType,
                [In, Out] ref RG_PIN_SATETS_16 pinStates,
                [In, Out] ref RG_CARD_INFO pCardInfo,
                [In, Out] ref RG_CARD_MEMORY pCardMemory);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_SetCardsMask(
                [In] ref RG_ENDPOINT pEndpoint,
                byte deviceAddress,
                byte cardfamilyMask);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_ClearProfiles(
                [In] ref RG_ENDPOINT pEndpoint,
                byte deviceAddress);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_WriteProfile(
                [In] ref RG_ENDPOINT pEndpoint,
                byte deviceAddress,
                byte profileNumber,
                byte blockNum,
                [In] ref RG_PROFILE_DATA profileData);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_WriteCodogramm(
                [In] ref RG_ENDPOINT pEndpointp,
                byte deviceAddress,
                byte codogrammNumber,
                [In] ref RG_CODOGRAMM pCodogramm);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_StartCodogramm(
                [In] ref RG_ENDPOINT pEndpoint,
                byte deviceAddress,
                byte priorityLevel,
                byte soundCodogrammNumber,
                byte regCodogrammNumber,
                byte greenCodogrammNumber,
                byte blueCodogrammNumber);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_SetControlOutputState(
                [In] ref RG_ENDPOINT pEndpoint,
                byte deviceAddress,
                byte controlOutNumber,
                byte controlOutState,
                byte timeoutSec);

            [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
            internal static extern error_t RG_ReadBlockDirect(
                [In] ref RG_ENDPOINT pEndpoint,
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

        internal RG_GetStatusDelegate RG_GetStatus = null;

        internal RG_SetCardsMaskDelegate RG_SetCardsMask = null;

        internal RG_ClearProfilesDelegate RG_ClearProfiles = null;

        internal RG_WriteProfileDelegate RG_WriteProfile = null;

        internal RG_WriteCodogrammDelegate RG_WriteCodogramm = null;

        internal RG_StartCodogrammDelegate RG_StartCodogramm = null;

        internal RG_SetControlOutputStateDelegate RG_SetControlOutputState = null;

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

            RG_GetStatus =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_GetStatusDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_GetStatus"));

            RG_SetCardsMask =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_SetCardsMaskDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_SetCardsMask"));

            RG_ClearProfiles =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_ClearProfilesDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_ClearProfiles"));

            RG_WriteProfile =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_WriteProfileDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_WriteProfile"));

            RG_WriteCodogramm =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_WriteCodogrammDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_WriteCodogramm"));

            RG_StartCodogramm =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_StartCodogrammDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_StartCodogramm"));

            RG_SetControlOutputState =
                UnmanagedLibrary.GetDelegateForFunctionPointer<RG_SetControlOutputStateDelegate>(
                    UnmanagedLibrary.GetFunctionPointer(libraryHandle, "RG_SetControlOutputState"));

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
            RG_GetStatus = LibNativeMethods.RG_GetStatus;

            RG_SetCardsMask = LibNativeMethods.RG_SetCardsMask;
            RG_ClearProfiles = LibNativeMethods.RG_ClearProfiles;
            RG_WriteProfile = LibNativeMethods.RG_WriteProfile;
            RG_WriteCodogramm = LibNativeMethods.RG_WriteCodogramm;
            RG_StartCodogramm = LibNativeMethods.RG_StartCodogramm;
            RG_SetControlOutputState = LibNativeMethods.RG_SetControlOutputState;

            RG_ReadBlockDirect = LibNativeMethods.RG_ReadBlockDirect;
        }
    }
}