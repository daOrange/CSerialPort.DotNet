using System;
using CSerialPort.DotNet.Core.Interops.Signatures;

namespace CSerialPort.DotNet.Core.Interops
{
    public sealed class CSerialPortInstance : InteropObjectInstance
    {
        private readonly CSerialPortManager manager;

        internal CSerialPortInstance(CSerialPortManager manager, IntPtr pointer) : base(pointer)
        {
            this.manager = manager;
        }

        protected override void Dispose(bool disposing)
        {
            //if (Pointer != IntPtr.Zero)
            //manager.ReleaseInstance(this);
            base.Dispose(disposing);
        }

        public static implicit operator IntPtr(CSerialPortInstance instance)
        {
            if (instance == null)
                return IntPtr.Zero;

            return instance.Pointer;
        }
    }
}