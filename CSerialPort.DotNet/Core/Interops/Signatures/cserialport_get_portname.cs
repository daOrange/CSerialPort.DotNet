using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_portname")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetPortName(IntPtr instance);
}
