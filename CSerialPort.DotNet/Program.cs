using CSerialPort.DotNet.Core.Interops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace CSerialPort.DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new CSerialPortManager(new DirectoryInfo("."), "COM15");

            manager.Open();
            manager.Write(new byte[] {0x55,0xaa,0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01, 0xaa, 0x01 });
            Console.WriteLine(manager.IsOpen().ToString());
            manager.Close();
            Console.WriteLine(manager.IsOpen().ToString());
        }
    }
}
