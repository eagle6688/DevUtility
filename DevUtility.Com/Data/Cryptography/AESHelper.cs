using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevUtility.Com.Data.Cryptography
{
    public class AESHelper
    {
        #region Variable

        static MD5 md5 = new MD5CryptoServiceProvider();

        static SHA256 sha256 = new SHA256CryptoServiceProvider();

        #endregion

        #region Encrypt

        public static byte[] Encrypt(byte[] keyBytes, byte[] ivBytes, byte[] dataBytes)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                MemoryStream memoryStream = new MemoryStream();

                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        public static string Encrypt(string key, string data)
        {
            string result = "";
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            byte[] aesKeyBytes = sha256.ComputeHash(keyBytes);
            byte[] aesIVBytes = md5.ComputeHash(keyBytes);

            try
            {
                byte[] resultBytes = Encrypt(aesKeyBytes, aesIVBytes, dataBytes);
                result = ConvertHelper.BytesToHexString(resultBytes);
            }
            catch (Exception exception)
            {
                DevUtility.Com.Application.Log.LogHelper.Error(exception);
            }

            return result;
        }

        public static string EncryptToBase64(string key, string data)
        {
            string result = "";
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            byte[] aesKeyBytes = sha256.ComputeHash(keyBytes);
            byte[] aesIVBytes = md5.ComputeHash(keyBytes);

            try
            {
                byte[] resultBytes = Encrypt(aesKeyBytes, aesIVBytes, dataBytes);
                result = Convert.ToBase64String(resultBytes);
            }
            catch(Exception exception)
            {
                DevUtility.Com.Application.Log.LogHelper.Error(exception);
            }

            return result;
        }

        #endregion

        #region Decrypt

        public static byte[] Decrypt(byte[] keyBytes, byte[] ivBytes, byte[] dataBytes)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                MemoryStream memoryStream = new MemoryStream();

                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        public static string Decrypt(string key, string data)
        {
            string result = "";
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = ConvertHelper.HexStringToBytes(data);

            byte[] aesKeyBytes = sha256.ComputeHash(keyBytes);
            byte[] aesIVBytes = md5.ComputeHash(keyBytes);

            try
            {
                byte[] resultBytes = Decrypt(aesKeyBytes, aesIVBytes, dataBytes);
                result = Encoding.UTF8.GetString(resultBytes);
            }
            catch (Exception exception)
            {
                DevUtility.Com.Application.Log.LogHelper.Error(exception);
            }

            return result;
        }

        public static string DecryptFromBase64(string key, string data)
        {
            string result = "";
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = Convert.FromBase64String(data);

            byte[] aesKeyBytes = sha256.ComputeHash(keyBytes);
            byte[] aesIVBytes = md5.ComputeHash(keyBytes);

            try
            {
                byte[] resultBytes = Decrypt(aesKeyBytes, aesIVBytes, dataBytes);
                result = Encoding.UTF8.GetString(resultBytes);
            }
            catch (Exception exception)
            {
                DevUtility.Com.Application.Log.LogHelper.Error(exception);
            }

            return result;
        }

        #endregion
    }
}