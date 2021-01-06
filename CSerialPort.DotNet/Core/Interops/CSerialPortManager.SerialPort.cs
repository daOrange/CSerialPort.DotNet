using CSerialPort.DotNet.Core.Interops.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSerialPort.DotNet.Core.Interops
{
    public sealed partial class CSerialPortManager
    {
        public void Open()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<Open>().Invoke(instance);
        }

        public void Close()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<Close>().Invoke(instance);
        }

        public void Write(byte[] data)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<Write>().Invoke(instance, data, data.Length);
        }

        public bool IsOpen()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<IsOpen>().Invoke(instance);
        }
    }
}
