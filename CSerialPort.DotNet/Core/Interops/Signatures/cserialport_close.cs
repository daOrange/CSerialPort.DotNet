using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_close")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Close(IntPtr instance);
}
