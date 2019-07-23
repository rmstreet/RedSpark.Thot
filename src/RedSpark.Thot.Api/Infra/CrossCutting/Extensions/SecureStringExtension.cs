using System;
using System.Runtime.InteropServices;
using System.Security;

namespace RedSpark.Thot.Api.Infra.CrossCutting.Extensions
{
    /// <summary>
    /// Provides unsafe temporary operations on secured strings.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static class SecureStringExtension
    {
        public static void AppendArrayChar(this SecureString ss, char[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                ss.AppendChar(input[i]);
            }
        }

        /// <summary>
        /// Converts a secured string to an unsecured string.
        /// </summary>
        public static string ToUnsecuredString(this SecureString secureString)
        {
            // copy&paste from the internal System.Net.UnsafeNclNativeMethods
            IntPtr bstrPtr = IntPtr.Zero;
            if (secureString != null)
            {
                if (secureString.Length != 0)
                {
                    try
                    {
                        bstrPtr = Marshal.SecureStringToBSTR(secureString);
                        return Marshal.PtrToStringBSTR(bstrPtr);
                    }
                    finally
                    {
                        if (bstrPtr != IntPtr.Zero)
                            Marshal.ZeroFreeBSTR(bstrPtr);
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Copies the existing instance of a secure string into the destination, clearing the destination beforehand.
        /// </summary>
        public static void CopyInto(this SecureString source, SecureString destination)
        {
            destination.Clear();
            foreach (var chr in source.ToUnsecuredString())
            {
                destination.AppendChar(chr);
            }
        }

        /// <summary>
        /// Converts an unsecured string to a secured string.
        /// </summary>
        public static SecureString ToSecuredString(this string plainString)
        {
            if (string.IsNullOrEmpty(plainString))
            {
                return new SecureString();
            }

            SecureString secure = new SecureString();
            foreach (char c in plainString)
            {
                secure.AppendChar(c);
            }
            return secure;
        }
    }
}
