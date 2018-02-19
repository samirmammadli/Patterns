using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text;

namespace ProxyPattern
{
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
            System.Windows.Forms.MessageBox.Show(url.ToString());
            using (var webClient = new WebClient())
            {
                var data = Encoding.UTF8.GetString(webClient.DownloadData(url));
                dynamic obj = JObject.Parse(data);
                return obj.text[0];
            }
        }
    }
}
