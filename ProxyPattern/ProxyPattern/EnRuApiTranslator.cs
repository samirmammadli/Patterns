using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProxyPattern
{
    class TranslatorProxy
    {
        private Dictionary<string, string> words;
        public TranslatorProxy()
        {
            words = new Dictionary<string, string>();
            words.Add("hello", "Привет");
            words.Add("bye", "Пока");
            words.Add("world", "Мир");
            words.Add("home", "Дом");
        }


        public string Translate(string text)
        {
            var word = text.ToLower();
            if (words.ContainsKey(word))
                return words[word];
            else
            {
                try
                {
                    var translator = EnRuApiTranslator.GetInstance();
                    words.Add(word, translator.Translate(text));
                    return words[word];
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    class EnRuApiTranslator
    {
        static private EnRuApiTranslator Translator;
        private Uri url { get; set; }
        private EnRuApiTranslator()
        {
            url = new Uri(@"https://translate.yandex.net/api/v1.5/tr.json/translate");
            url = url.AddParameter("key", @"trnsl.1.1.20171221T171359Z.7c952e5cee5cce49.4522dd804535b842a0959725f4275cc4bf261f60");
            url = url.AddParameter("lang", @"en-ru");
        }
        static public EnRuApiTranslator GetInstance()
        {
            Translator = Translator ?? new EnRuApiTranslator();
            return Translator;
        }

        public string Translate(string text)
        {
            url = url.AddParameter("text", text);
            using (var webClient = new WebClient())
            {
                var data = Encoding.UTF8.GetString(webClient.DownloadData(url));
                dynamic obj = JObject.Parse(data);
                return obj.text[0];
            }
        }
    }
}
