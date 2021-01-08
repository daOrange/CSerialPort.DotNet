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
        public void Init(string portName, int baudRate, Parity parity, DataBits dataBits, StopBits stopbits, long readBufferSize)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<Init>().Invoke(instance, portName, baudRate, parity, dataBits, stopbits, readBufferSize);
        }

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

        public bool GetIsOpen()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetIsOpen>().Invoke(instance);
        }

        public void SetPortName(string portName)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetPortName>().Invoke(instance, portName);
        }

        public string GetPortName()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return Utf8InteropStringConverter.Utf8InteropToString(libraryLoader.GetInteropDelegate<GetPortName>().Invoke(instance));
        }

        public void SetBaudRate(int baudRate)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetBaudRate>().Invoke(instance, baudRate);
        }

        public int GetBaudRate()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetBaudRate>().Invoke(instance);
        }

        public void SetParity(Parity parity)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetParity>().Invoke(instance, parity);
        }

        public Parity GetParity()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetParity>().Invoke(instance);
        }

        public void SetDataBits(DataBits dataBits)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetDataBits>().Invoke(instance, dataBits);
        }

        public DataBits GetDataBits()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetDataBits>().Invoke(instance);
        }

        public void SetStopBits(StopBits stopbits)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetStopBits>().Invoke(instance, stopbits);
        }

        public StopBits GetStopBits()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetStopBits>().Invoke(instance);
        }

        public void SetReadBufferSize(long size)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            libraryLoader.GetInteropDelegate<SetReadBufferSize>().Invoke(instance, size);
        }

        public long GetReadBufferSize()
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("instance is not initialized.");
            return libraryLoader.GetInteropDelegate<GetReadBufferSize>().Invoke(instance);
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
