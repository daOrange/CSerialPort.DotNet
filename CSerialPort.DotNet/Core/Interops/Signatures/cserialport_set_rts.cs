using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_rts")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetRts(IntPtr instance, bool isEnable);
}
