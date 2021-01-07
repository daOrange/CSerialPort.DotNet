using CSerialPort.DotNet.Core.Interops.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        public void Init(string portName, int baudRate)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<Init>().Invoke(instance, portName, baudRate);
        }

        public void Write(byte[] data)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<Write>().Invoke(instance, data, data.Length);
        }

        public int Read(byte[] data, int offset, int count)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");

            var buffer = Marshal.AllocHGlobal(count + 1);
            try
            {
                Marshal.Copy(data, offset, buffer, count);
                Marshal.WriteByte(buffer, count, 0);

                var readCount = libraryLoader.GetInteropDelegate<Read>().Invoke(instance, buffer, count);
                if (readCount <= 0) return 0;

                Marshal.Copy(buffer, data, offset, readCount);
                return readCount;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public bool IsOpen()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<IsOpen>().Invoke(instance);
        }

        public int GetBytesToRead()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetBytesToRead>().Invoke(instance);
        }

        public void SetDtr(bool isEnable)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetDtr>().Invoke(instance, isEnable);
        }

        public bool GetDtr()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetDtr>().Invoke(instance);
        }

        public void SetRts(bool isEnable)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetRts>().Invoke(instance, isEnable);
        }

        public bool GetRts()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetRts>().Invoke(instance);
        }

        public bool GetCts()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetCts>().Invoke(instance);
        }

        public bool GetDsr()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetDsr>().Invoke(instance);
        }
    }
}
