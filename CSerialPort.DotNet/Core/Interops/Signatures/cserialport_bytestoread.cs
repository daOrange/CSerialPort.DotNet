using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_getbytestoread")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetBytesToRead(IntPtr instance);
}
