using CSerialPort.DotNet.Core.Interops.Signatures;
using System;
using System.IO;

namespace CSerialPort.DotNet.Core.Interops
{
    public sealed partial class CSerialPortManager : IDisposable
    {
        private readonly CSerialPortLibraryLoader libraryLoader;
        private readonly CSerialPortInstance instance;

        public CSerialPortManager(DirectoryInfo dynamicLinkLibrariesPath)
        {
            this.libraryLoader = CSerialPortLibraryLoader.GetOrCreateLoader(dynamicLinkLibrariesPath);
            instance = new CSerialPortInstance(this, libraryLoader.GetInteropDelegate<CreateNewInstance>().Invoke());
        }

        public void Dispose()
        {
            instance.Dispose();
            CSerialPortLibraryLoader.ReleaseLoader(this.libraryLoader);
        }
    }
}
