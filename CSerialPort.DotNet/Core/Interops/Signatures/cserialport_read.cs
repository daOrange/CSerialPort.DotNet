using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_read")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int Read(IntPtr instance, IntPtr data, int length);
}
