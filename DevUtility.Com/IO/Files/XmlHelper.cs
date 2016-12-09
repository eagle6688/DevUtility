using DevUtility.Com.Extension.SystemIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DevUtility.Com.IO.Files
{
    public class XmlHelper
    {
        #region Serialize

        public static StringBuilder Serialize<TModel>(TModel model, string encoding = "UTF-8") where TModel : class, new()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.GetEncoding(encoding));

                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add("", "");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TModel));
                xmlSerializer.Serialize(xmlTextWriter, model, xmlSerializerNamespaces);
                return memoryStream.ToStringBuilder();
            }
        }

        #endregion

        #region Deserialize

        public static TModel Deserialize<TModel>(string xml) where TModel : class, new()
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            using (StringReader stringReader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TModel));

                try
                {
                    object obj = serializer.Deserialize(stringReader);

                    if (obj == null)
                    {
                        return null;
                    }

                    return obj as TModel;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static TModel DeserializeByPath<TModel>(string path) where TModel : class, new()
        {
            StringBuilder content = FileHelper.GetContent(path);

            if (content.Length == 0)
            {
                return null;
            }

            return Deserialize<TModel>(content.ToString());
        }

        #endregion

        #region Convert string to xDocument

        public static XDocument StringToXDocument(string xmlStr)
        {
            if (string.IsNullOrWhiteSpace(xmlStr))
            {
                return null;
            }

            TextReader textReader = new StringReader(xmlStr);
            return XDocument.Load(textReader);
        }

        #endregion
    }
}