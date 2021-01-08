using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_baudrate")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetBaudRate(IntPtr instance, int baudRate);
}
