using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using SPC.Core.Extensions;

namespace SPC.Core.Utility
{
    public class XMLHelper
    {
        private static void Init(string fileName, string rootElementName)
        {
            //创建文件
            string sPath = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(sPath))
                System.IO.Directory.CreateDirectory(sPath);
            FileStream mFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            mFileStream.Close();
            //初始化
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
            XmlDeclaration xmldecl;
            xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmldecl);
            //初始化根节点
            XmlElement docElement = xmlDoc.DocumentElement;
            XmlElement rootElement = xmlDoc.CreateElement(rootElementName);
            xmlDoc.AppendChild(rootElement);
            xmlDoc.Save(fileName);

        }

        /// <summary>
        /// 写入指定的XML文件的键值，文件不存在则自动增加
        /// </summary>
        /// <param name="fileName">XML文件名</param>
        /// <param name="rootElementName">XML根节点名</param>
        /// <param name="keyName">键名</param>
        /// <param name="keyValue">键值</param>
        public static void WriteKeyValue(string fileName, string rootElementName, string dicElementName, string keyName, string keyValue)
        {
            //文件不存在，则新建
            if (!System.IO.File.Exists(fileName))
                Init(fileName, rootElementName);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //寻找根节点
            XmlNode nodeRoot = xmlDoc.SelectSingleNode(rootElementName);
            XmlElement rootElement = nodeRoot as XmlElement;
            if (rootElement == null)
            {
                rootElement = xmlDoc.CreateElement(rootElementName);
                xmlDoc.DocumentElement.AppendChild(rootElement);
            }
            //寻找字典节点
            XmlElement dicElement = null;
            XmlNodeList tempNodeList = xmlDoc.SelectSingleNode(rootElementName).ChildNodes;
            foreach (XmlNode xn in tempNodeList)
            {
                if (xn is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.Name == dicElementName)
                    {
                        dicElement = xe;
                        break;
                    }
                }
            }
            if (dicElement == null)
            {
                dicElement = xmlDoc.CreateElement(dicElementName);
                rootElement.AppendChild(dicElement);
            }

            //寻找键值节点
            XmlElement itemElement = null;
            foreach (XmlNode xn in dicElement.ChildNodes)
            {
                if (xn is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.GetAttribute("Key") == keyName)
                    {
                        itemElement = xe;
                        break;
                    }
                }
            }
            if (itemElement == null)
            {
                itemElement = xmlDoc.CreateElement("NameValue");
                itemElement.SetAttribute("Key", keyName);
                itemElement.SetAttribute("Value", keyValue);
                dicElement.AppendChild(itemElement);
            }
            else
            {
                itemElement.SetAttribute("Value", keyValue);
            }

            xmlDoc.Save(fileName);
        }

        /// <summary>
        /// 读取指定节点下的键值，文件不存在则自动增加
        /// </summary>
        /// <param name="fileName">XML文件名</param>
        /// <param name="rootElementName">XML根节点名</param>
        /// <param name="keyName">键名</param>
        /// <returns>指定的键值</returns>
        public static string ReadKeyValue(string fileName, string rootElementName, string dicElementName, string keyName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(rootElementName).ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                if (xn is XmlElement)
                {
                    //将子节点类型转换为XmlElement类型   
                    XmlElement xe = (XmlElement)xn;
                    if (xe.Name == dicElementName)
                    {
                        foreach (XmlNode xnc in xe.ChildNodes)
                        {
                            if (xnc is XmlElement)
                            {
                                //将子节点类型转换为XmlElement类型   
                                XmlElement xec = (XmlElement)xnc;
                                if (xec.GetAttribute("Key") == keyName)
                                    return xec.GetAttribute("Value");
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 读取指定节点下的键值，文件不存在则自动增加
        /// </summary>
        /// <param name="fileName">XML文件名</param>
        /// <param name="rootElementName">XML根节点名</param>
        /// <param name="keyName">键名</param>
        /// <returns>指定的键值</returns>
        public static string ReadValue(string languageName, string fileName, string rootElementName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNode node = xmlDoc.SelectSingleNode(rootElementName);

            if (node != null)
            {
                XmlElement xe = (XmlElement)node;
                return xe.GetAttribute("Value").IsNullThenEmpty();
            }
            else
            {
                return string.Empty;
            }

        }


        /// <summary>
        /// 读取根节点下的键值对
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="rootElementName"></param>
        /// <returns></returns>
        public static System.Collections.Generic.Dictionary<string, string> ReadDictionaryType(string languageName, string fileName, string rootElementName)
        {
            if (!System.IO.File.Exists(fileName))
                return null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("resource").SelectSingleNode(rootElementName).ChildNodes;
            System.Collections.Generic.Dictionary<string, string> mNameValues = new Dictionary<string, string>();
            foreach (XmlNode xn in nodeList)
            {
                if (xn is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn;
                    string sKey = xe.Name;
                    string sValue = xe.GetAttribute("Caption").IsNullThenEmpty();
                    mNameValues.Add(sKey, sValue);
                }

            }
            return mNameValues;
        }

        /// <summary>
        /// 读取指定节点下的键值对
        /// </summary>
        /// <param name="fileName">XML文件名</param>
        /// <param name="rootElementName">XML根节点名</param>
        /// <returns>根节点下的键值对</returns>
        public static System.Collections.Generic.Dictionary<string, string> ReadDictionary(string fileName, string rootElementName, string dicElementName)
        {
            if (!System.IO.File.Exists(fileName))
                return null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("resource").SelectSingleNode(rootElementName).ChildNodes;

            System.Collections.Generic.Dictionary<string, string> mNameValues = new Dictionary<string, string>();
            foreach (XmlNode xn in nodeList)
            {
                if (xn is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.Name == dicElementName)
                    {
                        foreach (XmlNode xnc in xe.ChildNodes)
                        {
                            if (xnc is XmlElement)
                            {
                                //将子节点类型转换为XmlElement类型  
                                XmlElement xec = (XmlElement)xnc;
                                string sKey = xec.GetAttribute("Key");
                                string sValue = xec.GetAttribute("Value");
                                mNameValues.Add(sKey, sValue);
                            }
                        }
                    }
                }

            }
            return mNameValues;
        }

    }
}