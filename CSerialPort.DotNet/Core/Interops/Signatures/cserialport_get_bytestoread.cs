using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_bytestoread")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetBytesToRead(IntPtr instance);
}
