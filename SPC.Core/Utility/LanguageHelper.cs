using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPC.Core.Utility
{
    public class LanguageHelper
    {
        public static Dictionary<string, string> SupportLanguage()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("en", "English");
            ret.Add("ko", "Korean");
            ret.Add("zh-CN", "Chinese");
            return ret;
        }

        public static Dictionary<string, string> GetSystemDictionaryType(string languageName)
        {
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string sDictRootName = "SysDictionary";
            switch (languageName)
            {
                case "en": return XMLHelper.ReadDictionaryType("en", sPath + "LanguagePack.en.xml", sDictRootName);
                case "ko": return XMLHelper.ReadDictionaryType("ko", sPath + "LanguagePack.ko.xml", sDictRootName);
                case "zh-CN": return XMLHelper.ReadDictionaryType("zh-CN", sPath + "LanguagePack.zh-cn.xml", sDictRootName);
                default: return XMLHelper.ReadDictionaryType("en", sPath + "LanguagePack.en.xml", sDictRootName);
            }
        }

        public static Dictionary<string, string> GetSystemDictionary(string languageName, string dictName)
        {
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string sDictRootName = "SysDictionary";
            string sFileName = string.Empty;
            switch (languageName)
            {
                case "en": sFileName = sPath + "LanguagePack.en.xml"; break;
                case "ko": sFileName = sPath + "LanguagePack.ko.xml"; break;
                case "chs": sFileName = sPath + "LanguagePack.zh-cn.xml"; break;
                default: sFileName = sPath + "LanguagePack.en.xml"; break;
            }
            return XMLHelper.ReadDictionary(sFileName, sDictRootName, dictName);
        }

        public static string GetSystemKeyValue(string languageName, string rootName)
        {
           
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory + "LanguagePack"+"\\" ;
            switch (languageName)
            {
                case "en": return XMLHelper.ReadValue("en", sPath + "LanguagePack.en.xml", rootName);
                case "ko": return XMLHelper.ReadValue("ko", sPath + "LanguagePack.ko.xml", rootName);
                case "zh-CN": return XMLHelper.ReadValue("zh-CN", sPath + "LanguagePack.zh-cn.xml", rootName);
                default: return XMLHelper.ReadValue("en", sPath + "LanguagePack.en.xml", rootName);
            }
        }

    }
}