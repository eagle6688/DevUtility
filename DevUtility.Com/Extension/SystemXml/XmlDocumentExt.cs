using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DevUtility.Com.Extension.SystemXml
{
    public static class XmlDocumentExt
    {
        #region Safe load

        public static XmlOprResult SafeLoad(this XmlDocument xmlDoc, string xmlFile)
        {
            XmlOprResult result = XmlOprResult.OK;

            try
            {
                xmlDoc.Load(xmlFile);
            }
            catch
            {
                result = XmlOprResult.FailedLoad;
            }

            return result;
        }

        #endregion

        #region Checking existence

        public static bool Exists(this XmlDocument xmlDoc, string xpath)
        {
            bool result = false;
            XmlNode node = xmlDoc.SelectSingleNode(xpath);

            if (node != null)
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Add node

        public static XmlOprResult AddNode(this XmlDocument xmlDoc, string xmlFile, string parentPath, string name)
        {
            XmlOprResult result = XmlOprResult.OK;

            if (Exists(xmlDoc, parentPath))
            {
                XmlNode node = xmlDoc.SelectSingleNode(parentPath);
                XmlElement element = xmlDoc.CreateElement(name);
                node.AppendChild(element);
                xmlDoc.Save(xmlFile);
            }
            else
            {
                result = XmlOprResult.NonExistence;
            }

            return result;
        }

        public static XmlOprResult AddNode(this XmlDocument xmlDoc, string xmlFile, string parentPath, string name, string innerText)
        {
            XmlOprResult result = XmlOprResult.OK;

            if (Exists(xmlDoc, parentPath))
            {
                XmlNode node = xmlDoc.SelectSingleNode(parentPath);
                XmlElement element = xmlDoc.CreateElement(name);
                element.InnerText = innerText;
                node.AppendChild(element);
                xmlDoc.Save(xmlFile);
            }
            else
            {
                result = XmlOprResult.NonExistence;
            }

            return result;
        }

        public static XmlOprResult AddUniqueNode(this XmlDocument xmlDoc, string xmlFile, string parentPath, string name)
        {
            XmlOprResult result = XmlOprResult.OK;

            if (!Exists(xmlDoc, parentPath + "/" + name))
            {
                XmlNode node = xmlDoc.SelectSingleNode(parentPath);
                XmlElement element = xmlDoc.CreateElement(name);
                node.AppendChild(element);
                xmlDoc.Save(xmlFile);
            }
            else
            {
                result = XmlOprResult.Repeated;
            }

            return result;
        }

        public static XmlOprResult AddUniqueNode(this XmlDocument xmlDoc, string xmlFile, string parentPath, string name, string innerText)
        {
            XmlOprResult result = XmlOprResult.OK;

            if (!Exists(xmlDoc, parentPath + "/" + name))
            {
                XmlNode node = xmlDoc.SelectSingleNode(parentPath);
                XmlElement element = xmlDoc.CreateElement(name);
                element.InnerText = innerText;
                node.AppendChild(element);
                xmlDoc.Save(xmlFile);
            }
            else
            {
                result = XmlOprResult.Repeated;
            }

            return result;
        }

        #endregion

        #region Add item

        public static XmlOprResult AddItem(this XmlDocument xmlDoc, string xmlFile, string parentPath, string name, string value)
        {
            XmlOprResult result = XmlOprResult.OK;
            XmlNode node = xmlDoc.SelectSingleNode(parentPath);

            if (node != null)
            {
                XmlElement element = xmlDoc.CreateElement(name);
                XmlText text = xmlDoc.CreateTextNode(value);
                element.AppendChild(text);
                node.AppendChild(element);
                xmlDoc.Save(xmlFile);
            }
            else
            {
                result = XmlOprResult.NonExistence;
            }

            return result;
        }

        #endregion

        #region Modify node

        public static XmlOprResult UpdateInnerText(this XmlDocument xmlDoc, string xmlFile, string parentPath, string value)
        {
            XmlOprResult result = XmlOprResult.OK;
            XmlNode node = xmlDoc.SelectSingleNode(parentPath);

            if (node != null)
            {
                node.InnerText = value;
                xmlDoc.Save(xmlFile);
            }
            else //Have't found
            {
                result = XmlOprResult.NonExistence;
            }

            return result;
        }

        #endregion

        #region Delete node

        public static XmlOprResult Delete(this XmlDocument xmlDoc, string xmlFile, string xpath)
        {
            XmlOprResult result = XmlOprResult.OK;
            XmlNode node = xmlDoc.SelectSingleNode(xpath);

            if (node != null)
            {
                node.RemoveAll();
                xmlDoc.Save(xmlFile);
            }
            else
            {
                result = XmlOprResult.NonExistence;
            }

            return result;
        }

        #endregion

        #region Get node's InnerText

        public static string GetNodeInnerText(this XmlDocument xmlDoc, string xpath)
        {
            string value = "";
            XmlNode node = xmlDoc.SelectSingleNode(xpath);

            if (node != null)
            {
                value = node.InnerText;
            }

            return value;
        }

        #endregion

        #region Get node's children

        /// <summary>
        /// Get node's children
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XmlNodeList GetNodes(this XmlDocument xmlDoc, string parentPath)
        {
            XmlNodeList nodeList = null;
            XmlNode parentNode = xmlDoc.SelectSingleNode(parentPath);

            if (parentNode != null && parentNode.HasChildNodes)
            {
                nodeList = parentNode.ChildNodes;
            }

            return nodeList;
        }

        #endregion

        #region Get node's attribute

        public static string GetAttribute(this XmlDocument xmlDoc, string xpath, string key)
        {
            string value = "";
            XmlNode node = xmlDoc.SelectSingleNode(xpath);

            if (node != null)
            {
                value = node.Attributes[key].Value;
            }

            return value;
        }

        #endregion
    }
}