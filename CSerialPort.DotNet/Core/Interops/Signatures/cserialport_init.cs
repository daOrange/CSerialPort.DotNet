using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_init")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Init(IntPtr instance, string portName, int baudRate, Parity parity, DataBits dataBits, StopBits stopbits, long readBufferSize);
}
