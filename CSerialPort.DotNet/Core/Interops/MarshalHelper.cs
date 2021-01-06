using System;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops
{
    /// <summary>
    /// The helper class that helps to call Marshal.XXX methods in a multi-framework way
    /// </summary>
    public static class MarshalHelper
    {
        /// <summary>
        /// Converts a pointer to a C structure into a C# structure
        /// </summary>
        /// <typeparam name="T">The type of structure to convert</typeparam>
        /// <param name="ptr">The pointer</param>
        /// <returns>The converted structure</returns>
        public static T PtrToStructure<T>(IntPtr ptr) where T: struct
        {
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }

        /// <summary>
        /// Gets the size in bytes of a structure
        /// </summary>
        /// <typeparam name="T">The structure type</typeparam>
        /// <returns>The number of bytes in the structure</returns>
        public static int SizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        /// <summary>
        /// Gets the delegate of the function at the given address
        /// </summary>
        /// <typeparam name="T">The delegate type</typeparam>
        /// <param name="ptr">The pointer to the C function</param>
        /// <returns>The delegate</returns>
        public static T GetDelegateForFunctionPointer<T>(IntPtr ptr)
        {
            return (T)(object)Marshal.GetDelegateForFunctionPointer(ptr, typeof(T));
        }
    }
}