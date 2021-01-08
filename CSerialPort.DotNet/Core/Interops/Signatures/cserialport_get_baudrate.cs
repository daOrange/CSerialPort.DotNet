using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_baudrate")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetBaudRate(IntPtr instance);
}
