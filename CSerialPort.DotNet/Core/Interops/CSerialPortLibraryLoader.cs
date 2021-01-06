using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CSerialPort.DotNet.Core.Interops
{
    internal class CSerialPortLibraryLoader : IDisposable
    {
        private static Dictionary<string, CSerialPortLibraryLoader> loaderInstances = new Dictionary<string, CSerialPortLibraryLoader>();
        private readonly DirectoryInfo dynamicLinkLibrariesPath;
        private int refCount;

        private IntPtr libCSerialPortDllHandle;
        private IntPtr libCSerialPortExportDllHandle;

        private readonly Dictionary<string, object> interopDelegates = new Dictionary<string, object>();
        private readonly object interopDelegatesLockObject = new object();

        private CSerialPortLibraryLoader(DirectoryInfo dynamicLinkLibrariesPath)
        {
            this.dynamicLinkLibrariesPath = dynamicLinkLibrariesPath;
            refCount = 1;

            var libCSerialPortDllPath = Path.Combine(dynamicLinkLibrariesPath.FullName, "libcserialport.dll");
            if (!File.Exists(libCSerialPortDllPath))
                throw new FileNotFoundException();
            libCSerialPortDllHandle = Win32Interops.LoadLibrary(libCSerialPortDllPath);
            if (libCSerialPortDllHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            var libCSerialPortExportDllPath = Path.Combine(dynamicLinkLibrariesPath.FullName, "libcserialportexport.dll");
            if (!File.Exists(libCSerialPortExportDllPath))
                throw new FileNotFoundException();
            libCSerialPortExportDllHandle = Win32Interops.LoadLibrary(libCSerialPortExportDllPath);
            if (libCSerialPortExportDllHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        internal T GetInteropDelegate<T>()
        {
            string functionName = null;
            try
            {
                var attrs = typeof(T).GetCustomAttributes(typeof(LibCSerialPortFunctionAttribute), false);
                if (attrs.Length == 0)
                    throw new Exception("Could not find the LibCSerialPortFunctionAttribute.");
                var attr = (LibCSerialPortFunctionAttribute)attrs[0];
                functionName = attr.FunctionName;

                lock (this.interopDelegatesLockObject)
                {
                    if (interopDelegates.ContainsKey(functionName))
                    {
                        return (T)interopDelegates[attr.FunctionName];
                    }

                    var procAddress = Win32Interops.GetProcAddress(libCSerialPortExportDllHandle, attr.FunctionName);
                    if (procAddress == IntPtr.Zero)
                        throw new Win32Exception();

                    var delegateForFunctionPointer = MarshalHelper.GetDelegateForFunctionPointer<T>(procAddress);

                    interopDelegates[attr.FunctionName] = delegateForFunctionPointer;

                    return delegateForFunctionPointer;
                }
            }
            catch (Win32Exception e)
            {
                throw new MissingMethodException(string.Format("The address of the function '{0}' does not exist in library.", functionName), e);
            }
        }

        void IDisposable.Dispose()
        {
            if (libCSerialPortDllHandle != IntPtr.Zero)
            {
                Win32Interops.FreeLibrary(libCSerialPortDllHandle);
                libCSerialPortDllHandle = IntPtr.Zero;
            }
            if (libCSerialPortExportDllHandle != IntPtr.Zero)
            {
                Win32Interops.FreeLibrary(libCSerialPortExportDllHandle);
                libCSerialPortExportDllHandle = IntPtr.Zero;
            }
        }

        public static CSerialPortLibraryLoader GetOrCreateLoader(DirectoryInfo dynamicLinkLibrariesPath)
        {
            if (!dynamicLinkLibrariesPath.Exists)
                throw new DirectoryNotFoundException();

            lock (loaderInstances)
            {
                if (loaderInstances.ContainsKey(dynamicLinkLibrariesPath.FullName))
                {
                    var instance = loaderInstances[dynamicLinkLibrariesPath.FullName];
                    instance.refCount++;
                    return instance;
                }

                var returnedInstance = new CSerialPortLibraryLoader(dynamicLinkLibrariesPath);
                loaderInstances[dynamicLinkLibrariesPath.FullName] = returnedInstance;
                return returnedInstance;
            }
        }

        public static void ReleaseLoader(CSerialPortLibraryLoader loader)
        {
            lock (loaderInstances)
            {
                loader.refCount--;
                if (loader.refCount == 0)
                {
                    ((IDisposable)loader).Dispose();
                    loaderInstances.Remove(loader.dynamicLinkLibrariesPath.FullName);
                }
            }
        }
    }
}