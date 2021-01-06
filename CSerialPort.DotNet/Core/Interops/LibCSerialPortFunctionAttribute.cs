using System;

namespace CSerialPort.DotNet.Core.Interops
{
    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple = false)]
    internal sealed class LibCSerialPortFunctionAttribute : Attribute
    {
        public string FunctionName { get; private set; }

        public LibCSerialPortFunctionAttribute(string functionName)
        {
            FunctionName = functionName;
        }
    }
}
