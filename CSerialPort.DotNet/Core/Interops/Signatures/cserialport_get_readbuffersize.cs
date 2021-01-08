using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_readbuffersize")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate long GetReadBufferSize(IntPtr instance);
}
