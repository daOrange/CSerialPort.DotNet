using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_parity")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate Parity GetParity(IntPtr instance);
}
