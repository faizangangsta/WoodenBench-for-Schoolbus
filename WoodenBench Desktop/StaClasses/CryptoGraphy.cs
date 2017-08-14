using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text;

namespace WoodenBench.StaClasses
{
    public static class CryptoGraphy
    {
        public static string SHA256Encrypt(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();
            tmpByte = sha256.ComputeHash(GetKeyByteArray(strIN));
            sha256.Clear();
            return GetStringValue(tmpByte);
        }

        private static string GetStringValue(byte[] Byte)
        {
            string tmpString = "";
            ASCIIEncoding Asc = new ASCIIEncoding();
            tmpString = Asc.GetString(Byte);
            return tmpString;
        }

        private static byte[] GetKeyByteArray(string strKey)
        {
            ASCIIEncoding Asc = new ASCIIEncoding();

            int tmpStrLen = strKey.Length;
            byte[] tmpByte = new byte[tmpStrLen - 1];

            tmpByte = Asc.GetBytes(strKey);

            return tmpByte;

        }
    }
}
