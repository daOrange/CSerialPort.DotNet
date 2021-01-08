using CSerialPort.DotNet.Core.Interops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;

namespace CSerialPort.DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //var manager = new CSerialPortManager(new DirectoryInfo("."));
            //Console.WriteLine(manager.IsOpen().ToString());
            //manager.Init("COM3", 9600);
            //Console.WriteLine(manager.IsOpen().ToString());
            //manager.Open();
            //manager.Write(new byte[] { 0x55, 0xff, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01 });
            //Console.WriteLine(manager.IsOpen().ToString());
            //var data = new byte[1024];
            //while (true)
            //{
            //    var readCount = manager.Read(data, 0, 1024);
            //    if (readCount > 0) Console.WriteLine(System.Text.Encoding.UTF8.GetString(data, 0, readCount));
            //    Thread.Sleep(1);
            //}
            //Console.ReadKey();
            //manager.Close();
            //Console.WriteLine(manager.IsOpen().ToString());

            var port = new System.IO.Ports.SerialPort();

            port.PortName = "COM12";
            port.BaudRate = 9600;
            port.Open();

            //Console.WriteLine(port.IsOpen.ToString());
            //var data = new byte[1024];
            //var a = port.DtrEnable;
            //for (int i = 0; i < 200; i++)
            //{
            //    //var readCount = port.Read(data, 0, 1024);
            //    //if (readCount > 0) Console.WriteLine(System.Text.Encoding.UTF8.GetString(data, 0, readCount));
            //    //port.RtsEnable = !port.RtsEnable;
            //    //Console.WriteLine(port.RtsEnable);
            //    port.Write(new byte[] { 0x55, 0xff, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01 }, 0, 4);
            //    Thread.Sleep(1);
            //}
            //port.BaudRate = 115200;
            //Thread.Sleep(5000);
            //for (int i = 0; i < 200; i++)
            //{
            //    //var readCount = port.Read(data, 0, 1024);
            //    //if (readCount > 0) Console.WriteLine(System.Text.Encoding.UTF8.GetString(data, 0, readCount));
            //    //port.RtsEnable = !port.RtsEnable;
            //    //Console.WriteLine(port.RtsEnable);
            //    port.Write(new byte[] { 0x55, 0xff, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01 }, 0, 4);
            //    Thread.Sleep(1);
            //}
            //Console.ReadKey();
            port.Write(new byte[] { 0x55, 0xff, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0x55, 0xff, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01 }, 0, 26);
            Console.ReadKey();
            port.Close();
            Console.WriteLine(port.IsOpen.ToString());
        }
    }
}
