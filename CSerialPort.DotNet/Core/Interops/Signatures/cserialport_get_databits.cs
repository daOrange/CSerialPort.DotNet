using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_get_databits")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate DataBits GetDataBits(IntPtr instance);
}
