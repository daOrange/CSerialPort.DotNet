using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_write")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Write(IntPtr instance, byte[] data, int maxSize);
}
