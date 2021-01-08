using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_databits")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetDataBits(IntPtr instance, DataBits dataBits);
}
