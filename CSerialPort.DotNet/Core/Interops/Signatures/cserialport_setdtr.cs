using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_setdtr")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetDtr(IntPtr instance, bool isEnable);
}
