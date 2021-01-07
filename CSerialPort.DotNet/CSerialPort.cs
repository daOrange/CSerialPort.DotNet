using CSerialPort.DotNet.Core.Interops;
using System;
using System.IO;

namespace CSerialPort.DotNet
{
    public class CSerialPort
    {
        private readonly CSerialPortManager manager;

        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int BytesToRead => GetBytesToRead();

        public bool IsOpen => GetIsOpen();

        public CSerialPort()
        {
            manager = new CSerialPortManager(new DirectoryInfo("."));
        }

        public void Open()
        {
            manager.Init(PortName, BaudRate);
            manager.Open();
        }

        public void Close()
        {
            manager.Close();
        }

        public void Write(byte[] data, int offset, int count)
        {
            var buffer = new byte[count];
            Array.Copy(data, offset, buffer, 0, count);
            manager.Write(buffer);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return manager.Read(buffer, offset, count);
        }

        private int GetBytesToRead()
        {
            var count = manager.GetBytesToRead();
            return count > 0 ? count : 0;
        }

        private bool GetIsOpen()
        {
            return manager.IsOpen();
        }
    }
}
