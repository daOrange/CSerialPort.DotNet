﻿using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    [LibCSerialPortFunction("cserialport_set_portname")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetPortName(IntPtr instance, string portname);
}
