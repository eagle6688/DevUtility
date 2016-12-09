using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevUtility.Com.Data.Cryptography
{
    public class SHA256Helper
    {
        #region Encrypt

        public static string Encrypt(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Encrypt(bytes);
        }

        public static string Encrypt(byte[] bytes)
        {
            using (SHA256 sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] encryptedBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(encryptedBytes).Replace("-", "");
            }
        }

        #endregion

        #region Encrypt file

        public static string EncryptFile(string filePath)
        {
            string value = "";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                HashAlgorithm hashAlgorithm = SHA256.Create();
                byte[] bytes = hashAlgorithm.ComputeHash(fileStream);
                value = BitConverter.ToString(bytes).Replace("-", "");
                bytes = null;
                GC.Collect();
            }

            return value;
        }

        #endregion
    }
}