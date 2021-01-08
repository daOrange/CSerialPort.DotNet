using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops.Signatures
{
    public enum Parity : int
    {
        ParityNone = 0,  ///< No Parity 无校验
        ParityOdd = 1,   ///< Odd Parity 奇校验
        ParityEven = 2,  ///< Even Parity 偶校验
        ParityMark = 3,  ///< Mark Parity 1校验
        ParitySpace = 4, ///< Space Parity 0校验
    }

    public enum DataBits : int
    {
        DataBits5 = 5, ///< 5 data bits 5位数据位
        DataBits6 = 6, ///< 6 data bits 6位数据位
        DataBits7 = 7, ///< 7 data bits 7位数据位
        DataBits8 = 8  ///< 8 data bits 8位数据位
    }

    public enum StopBits : int
    {
        StopOne = 0,        ///< 1 stop bit 1位停止位
        StopOneAndHalf = 1, ///< 1.5 stop bit 1.5位停止位 - This is only for the Windows platform
        StopTwo = 2         ///< 2 stop bit 2位停止位
    }
}
