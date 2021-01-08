using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_stopbits")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate StopBits GetStopBits(IntPtr instance);
}
