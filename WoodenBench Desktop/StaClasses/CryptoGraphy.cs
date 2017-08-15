using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace WoodenBench.StaClasses
{
    public static class CryptoGraphy
    {
        public static string SHA256Encrypt(string strIN)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(strIN);
            try
            {
                SHA256 sha256 = new SHA256CryptoServiceProvider();
                byte[] retVal = sha256.ComputeHash(bytValue);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetSHA256HashFromString() fail,error:" + ex.Message);
            }

        }

        public static string RandomString(int Length, bool Symbols, string CustomStr = "")
        {
            byte[] b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, f = CustomStr;
            f += "0123456789";
            f += "abcdefghijklmnopqrstuvwxyz";
            f += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (Symbols) f += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}（）_——-~·、，。；‘“’”《》￥……~";
            for (int i = 0; i < Length; i++)
            {
                s += f.Substring(r.Next(0, f.Length - 1), 1);
            }
            return s;
        }
    }
}
