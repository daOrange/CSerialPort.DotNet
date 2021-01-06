using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_isopen")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool IsOpen(IntPtr instance);
}
