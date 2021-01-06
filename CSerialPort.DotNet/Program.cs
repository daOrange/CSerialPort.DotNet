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
            var manager = new CSerialPortManager(new DirectoryInfo("."), "COM3");

            manager.Open();
            manager.Write(new byte[] { 0x55, 0xff, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01 });
            Console.WriteLine(manager.IsOpen().ToString());
            var data = new byte[1024];
            while (true)
            {
                var readCount = manager.Read(data, 0, 1024);
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(data, 0, readCount));
                Thread.Sleep(1);
            }
            Console.ReadKey();
            manager.Close();
            Console.WriteLine(manager.IsOpen().ToString());
        }
    }
}
