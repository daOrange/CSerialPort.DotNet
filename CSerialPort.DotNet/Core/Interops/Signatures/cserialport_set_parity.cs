using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_parity")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetParity(IntPtr instance, Parity parity);
}
