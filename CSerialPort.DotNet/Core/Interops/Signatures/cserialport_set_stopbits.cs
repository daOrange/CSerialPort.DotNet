using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_stopbits")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetStopBits(IntPtr instance, StopBits stopbits);
}
