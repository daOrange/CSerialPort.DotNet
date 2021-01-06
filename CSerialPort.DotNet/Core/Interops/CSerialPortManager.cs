using CSerialPort.DotNet.Core.Interops.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSerialPort.DotNet.Core.Interops
{
    public sealed partial class CSerialPortManager : IDisposable
    {
        private readonly CSerialPortLibraryLoader libraryLoader;
        private readonly CSerialPortInstance instance;

        public CSerialPortManager(DirectoryInfo dynamicLinkLibrariesPath, string portName)
        {
            this.libraryLoader = CSerialPortLibraryLoader.GetOrCreateLoader(dynamicLinkLibrariesPath);
            try
            {
                instance = new CSerialPortInstance(this, libraryLoader.GetInteropDelegate<CreateNewInstance>().Invoke(portName));
            }
            finally
            {
            }
        }

        public void Dispose()
        {
            instance.Dispose();
            CSerialPortLibraryLoader.ReleaseLoader(this.libraryLoader);
        }
    }
}
