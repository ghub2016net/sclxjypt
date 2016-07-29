using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace HzsCommon
{
    public static class Encryption
    {
        public static string Decrypt(string encrypted)
        {
            byte[] buff = Convert.FromBase64String(encrypted);
            byte[] kb = Encoding.Default.GetBytes("chinasunsoft");
            return Encoding.Default.GetString(Decrypt(buff, kb));
        }

        internal static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;
            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        public static string Encrypt(string original)
        {
            byte[] buff = Encoding.Default.GetBytes(original);
            byte[] kb = Encoding.Default.GetBytes("chinasunsoft");
            return Convert.ToBase64String(Encrypt(buff, kb));
        }

        internal static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;
            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        private static byte[] MakeMD5(byte[] original)
        {
            byte[] keyhash = new MD5CryptoServiceProvider().ComputeHash(original);
            return keyhash;
        }
    }
}

