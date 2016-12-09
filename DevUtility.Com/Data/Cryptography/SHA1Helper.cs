using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevUtility.Com.Data.Cryptography
{
    public class SHA1Helper
    {
        #region Encrypt

        public static string Encrypt(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Encrypt(bytes);
        }

        public static string Encrypt(byte[] bytes)
        {
            string result = "";

            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] encryptedBytes = sha1.ComputeHash(bytes);
                result = BitConverter.ToString(encryptedBytes);
                bytes = null;
                encryptedBytes = null;
                GC.Collect();
            }
            
            return result.Replace("-", "");
        }

        #endregion

        #region Encrypt file

        public static string EncryptFile(string filePath)
        {
            string value = "";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                HashAlgorithm hashAlgorithm = SHA1.Create();
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