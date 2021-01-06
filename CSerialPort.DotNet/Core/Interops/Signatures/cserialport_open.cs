using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_open")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Open(IntPtr instance);
}
