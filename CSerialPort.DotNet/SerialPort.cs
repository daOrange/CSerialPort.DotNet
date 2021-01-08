using CSerialPort.DotNet.Core.Interops;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;

namespace CSerialPort.DotNet
{
    public class SerialPort
    {
        private readonly CSerialPortManager manager;

        private string portName;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;
        private int readBufferSize;

        public int BytesToRead => GetBytesToRead();

        public bool IsOpen => GetIsOpen();

        [DefaultValue("COM1")]
        public string PortName
        {
            get => portName;
            set
            {
                if (IsOpen)
                {
                    manager.SetPortName(value);
                }
                portName = value;
            }
        }

        [DefaultValue(9600)]
        public int BaudRate
        {
            get => baudRate;
            set
            {
                if (IsOpen)
                {
                    manager.SetBaudRate(value);
                }
                baudRate = value;
            }
        }

        [DefaultValue(Parity.None)]
        public Parity Parity
        {
            get => parity;
            set
            {
                if (IsOpen)
                {
                    manager.SetParity((Core.Interops.Signatures.Parity)value);
                }
                parity = value;
            }
        }

        [DefaultValue(8)]
        public int DataBits
        {
            get => dataBits;
            set
            {
                if (IsOpen)
                {
                    manager.SetDataBits((Core.Interops.Signatures.DataBits)value);
                }
                dataBits = value;
            }
        }

        [DefaultValue(StopBits.One)]
        public StopBits StopBits
        {
            get => stopBits;
            set
            {
                if (IsOpen)
                {
                    manager.SetStopBits(ToSignaturesStopBits(value));
                }
                stopBits = value;
            }
        }

        [DefaultValue(4096)]
        public int ReadBufferSize
        {
            get => readBufferSize;
            set
            {
                if (IsOpen)
                {
                    manager.SetReadBufferSize(Convert.ToInt64(value));
                }
                readBufferSize = value;
            }
        }

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
            portName = "COM1";
            baudRate = 9600;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;
            readBufferSize = 4096;

            manager = new CSerialPortManager(new DirectoryInfo("."));
        }

        public void Open()
        {
            manager.Init(PortName, BaudRate,
                (Core.Interops.Signatures.Parity)Parity,
                (Core.Interops.Signatures.DataBits)DataBits,
                ToSignaturesStopBits(StopBits),
                Convert.ToInt64(ReadBufferSize));
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
            return manager.GetIsOpen();
        }

        private Core.Interops.Signatures.StopBits ToSignaturesStopBits(StopBits stopBits)
        {
            switch (stopBits)
            {
                case StopBits.None:
                    throw new Exception("can not set stopBits to 0");
                case StopBits.One:
                    return Core.Interops.Signatures.StopBits.StopOne;
                case StopBits.Two:
                    return Core.Interops.Signatures.StopBits.StopTwo;
                case StopBits.OnePointFive:
                    return Core.Interops.Signatures.StopBits.StopOneAndHalf;
                default:
                    throw new Exception("unknow stopbits");
            }
        }
    }
}
