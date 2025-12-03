using System;
using System.Runtime.InteropServices;

namespace projectnet
{
    public static class WinDivertSafe
    {
        public static IntPtr Open(string filter)
        {
            IntPtr handle = WinDivertAPI.WinDivertOpen(filter, 0, 0, 0);
            if (handle == IntPtr.Zero || handle == new IntPtr(-1))
            {
                int error = Marshal.GetLastWin32Error();
                throw new InvalidOperationException($"Failed to open WinDivert handle. Error code: {error}.");
            }

            return handle;
        }

        public static bool TryReceive(IntPtr handle, byte[] buffer, out uint readLen, out WinDivertAddress address)
        {
            readLen = 0;
            address = new WinDivertAddress { Reserved = new byte[60] };

            if (buffer == null || buffer.Length == 0)
                throw new ArgumentException("Buffer must be allocated.");

            GCHandle pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            GCHandle pinnedAddress = GCHandle.Alloc(address.Reserved, GCHandleType.Pinned);

            try
            {
                return WinDivertAPI.WinDivertRecv(handle, buffer, (uint)buffer.Length, ref address, ref readLen);
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("Access violation while receiving packet.");
                return false;
            }
            finally
            {
                if (pinnedBuffer.IsAllocated)
                    pinnedBuffer.Free();
                if (pinnedAddress.IsAllocated)
                    pinnedAddress.Free();
            }
        }

        public static void Send(IntPtr handle, byte[] buffer, uint length, WinDivertAddress address)
        {
            uint sendLen = 0;
            try
            {
                WinDivertAPI.WinDivertSend(handle, buffer, length, ref address, ref sendLen);
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("Access violation while sending packet.");
            }
        }

        public static void Close(IntPtr handle)
        {
            if (handle != IntPtr.Zero && handle != new IntPtr(-1))
            {
                WinDivertAPI.WinDivertClose(handle);
            }
        }
    }
}
