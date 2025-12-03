using System;
using System.Runtime.InteropServices;

namespace projectnet
{
    public static class WinDivertAPI
    {
        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr WinDivertOpen(
    string filter,
    uint layer,
    short priority,
    ulong flags);


        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WinDivertRecv(
            IntPtr handle,
            byte[] pPacket,
            uint packetLen,
            ref WinDivertAddress pAddr,
            ref uint readLen);

        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WinDivertSend(
            IntPtr handle,
            byte[] pPacket,
            uint packetLen,
            ref WinDivertAddress pAddr,
            ref uint sendLen);

        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WinDivertClose(IntPtr handle);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WinDivertAddress
    {
        public ulong Timestamp;
        public byte IfIdx;
        public byte SubIfIdx;
        public byte Direction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] Reserved;
    }

}
