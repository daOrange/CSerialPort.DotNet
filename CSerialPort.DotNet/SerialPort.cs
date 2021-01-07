using CSerialPort.DotNet.Core.Interops;
using System;
using System.IO;

namespace CSerialPort.DotNet
{
    public class SerialPort
    {
        private readonly CSerialPortManager manager;

        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int BytesToRead => GetBytesToRead();

        public bool IsOpen => GetIsOpen();

        public bool DtrEnable
        {
            get => manager.GetDtr();
            set => manager.SetDtr(value);
        }

        public bool RtsEnable
        {
            get => manager.GetRts();
            set => manager.SetRts(value);
        }

        public bool CtsHolding => manager.GetCts();

        public bool DsrHolding => manager.GetDsr();

        public SerialPort()
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
