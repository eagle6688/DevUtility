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
            byte[] compressedBytes = Compress(bytes);
            return System.Convert.ToBase64String(compressedBytes);
        }

        string Decompress(string value)
        {
            string base64Value = value.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");

            if (base64Value.Length % 4 > 0)
            {
                base64Value = base64Value.PadRight(base64Value.Length + 4 - base64Value.Length % 4, '=');
            }

            byte[] compressedBytes = System.Convert.FromBase64String(base64Value);
            byte[] bytes = Decompress(compressedBytes);
            return Encoding.UTF8.GetString(bytes);
        }

        static byte[] Compress(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gZipStream.Write(bytes, 0, bytes.Length);
                }

                return memoryStream.ToArray();
            }
        }

        static byte[] Decompress(byte[] bytes)
        {
            using (MemoryStream compressedStream = new MemoryStream(bytes))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (GZipStream gZipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        gZipStream.CopyTo(memoryStream);
                    }

                    return memoryStream.ToArray();
                }
            }
        }
    }
}