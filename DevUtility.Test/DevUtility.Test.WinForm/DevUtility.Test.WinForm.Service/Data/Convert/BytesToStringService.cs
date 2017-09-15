using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Convert
{
    public class BytesToStringService : BaseAppService
    {
        public override void Start()
        {
            Student student = new Student();
            student.Age = 1;
            student.Gender = 0;
            student.Name = "Lily";

            string value = JsonConvert.SerializeObject(student);
            DisplayMessage(value);

            string compressedString = Compress(value);
            DisplayMessage($"Compressed: {compressedString}, length: {compressedString.Length}");

            string decompressedString = Decompress(compressedString);
            DisplayMessage($"Decompressed: {decompressedString}, length: {decompressedString.Length}");

            //byte[] originalBytes = Encoding.UTF8.GetBytes("HahahaASDqwe asd!");
            //string utf8String = Encoding.UTF8.GetString(originalBytes);
            //DisplayMessage($"UTF8 : {utf8String}, length: {utf8String.Length}");

            //string base64String = System.Convert.ToBase64String(originalBytes);
            //DisplayMessage($"base64 : {base64String}, length: {base64String.Length}");

            //string serializedString = JsonConvert.SerializeObject(originalBytes);
            //DisplayMessage($"JsonConvert : {serializedString}, length: {serializedString.Length}");
        }

        string Compress(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            string asd = Encoding.UTF8.GetString(bytes);
            byte[] compressedBytes = Compress(bytes);
            return Encoding.UTF8.GetString(compressedBytes);
        }

        string Decompress(string value)
        {
            byte[] utf8Bytes = Encoding.ASCII.GetBytes(value);
            //byte[] bytes = Decompress(utf8Bytes);
            return Decompress(utf8Bytes);
        }

        static byte[] Compress(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream();

            using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                gZipStream.Write(bytes, 0, bytes.Length);
            }

            return memoryStream.ToArray();
        }

        static string Decompress(byte[] bytes)
        {
            //using (GZipStream gZipStream = new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress))
            //{
            //    const int size = 4096;
            //    byte[] buffer = new byte[size];

            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        int count = 0;

            //        while ((count = gZipStream.Read(buffer, 0, size)) > 0)
            //        {
            //            memoryStream.Write(buffer, 0, count);
            //        }

            //        return memoryStream.ToArray();
            //    }
            //}

            using (var decomStream = new MemoryStream(bytes))
            {
                using (var hgs = new GZipStream(decomStream, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(hgs, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public static byte[] CompressObject(object value)
        {
            if (value == null)
            {
                return null;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, value);
                byte[] bytes = memoryStream.ToArray();

                MemoryStream oStream = new MemoryStream();
                DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
                zipStream.Write(bytes, 0, bytes.Length);
                zipStream.Flush();
                zipStream.Close();
                return oStream.ToArray();
            }
        }

        public static object DecompressionObject(byte[] bytes)
        {
            if (bytes == null) return null;
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            object dsResult = null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsResult = (object)bFormatter.Deserialize(unZipStream);
            return dsResult;
        }
    }
}