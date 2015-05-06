using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Subtitles.GoogleServices
{
    public static class GoogleTranslate
    {
        private static string url = @"http://translate.google.com/translate_a/t?client=j";
        public static string GetTranslation(string str,  string fromLang, string toLang)
        {
            string reqUrl = url + "&sl=" + fromLang + "&tl=" + toLang +"&text=" + str;
            WebRequest req = WebRequest.Create(reqUrl);
            req.Method = "POST";
            req.ContentType = "application/json";

            Stream sendStream = req.GetRequestStream();
            sendStream.Write(new byte[0], 0, 0);
            sendStream.Close();

            WebResponse resp = req.GetResponse();
            Stream recStream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(recStream);
            string responseFromServer = sr.ReadToEnd();

            resp.Close();
            sr.Close();

            return JsonTranslationParser.GetSubtitleText(responseFromServer);
        }
    }
}
