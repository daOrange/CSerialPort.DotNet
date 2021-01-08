using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_readbuffersize")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetReadBufferSize(IntPtr instance, long size);
}
