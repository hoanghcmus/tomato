using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataAccess.Language
{
    public class LangMap
    {
        public string Key { get; set; }
        public string Value { get; set; }
        List<LangMap> listLangMap = new List<LangMap>();

        public LangMap(string langFilePath)
        {
            string text = System.IO.File.ReadAllText(langFilePath);
            string[] sListKeyValue = text.Split(';');

            for (int i = 0; i < sListKeyValue.Count(); i++)
            {
                string[] sKeyValuePair = sListKeyValue[i].Split('=');
                LangMap langMap = new LangMap(Regex.Replace(sKeyValuePair[0].Trim(), "\r\n", ""), sKeyValuePair[1].Trim());
                listLangMap.Add(langMap);
            }
        }

        public LangMap(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string getText(string key)
        {
            string value = "";
            for (int i = 0; i < listLangMap.Count(); i++)
            {
                if (listLangMap[i].Key.Trim().Equals(key.Trim()))
                {
                    value = listLangMap[i].Value.Trim();
                    break;
                }
            }
            return value;
        }

        public string getLocale(string lang)
        {
            switch (lang)
            {
                case "vn":
                    return "/locale/vn/lang.txt";
                case "en":
                    return "/locale/en/lang.txt";
                case "ru":
                    return "/locale/ru/lang.txt";

                default: return "/locale/vn/lang.txt";
            }
        }

    }
}
