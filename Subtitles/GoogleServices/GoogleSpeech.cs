using System;
using System.IO;
using System.Net;

namespace Subtitles.GoogleServices
{
    public static class GoogleSpeech
    {

        private static string url = "https://www.google.com/speech-api/v2/recognize?xjerr=1&client=chromium&output=json";
        private static string key = "AIzaSyC30RtJn0AZ9vakQCWf28l52MGFYLB4CTk";

        public static string GetSpeech(string pathToFlacFile, string language, int sampleRate)
        {
            string reqUrl = url + "&lang=" + language + "&key=" + key;
            WebRequest req = WebRequest.Create(reqUrl);
            req.Method = "POST";        
            req.ContentType = "audio/x-flac; rate=" + sampleRate;      
            byte[] data = File.ReadAllBytes(pathToFlacFile);
            req.ContentLength = data.Length;

            Stream sendStream = req.GetRequestStream();
            sendStream.Write(data, 0, data.Length);
            sendStream.Close();

            WebResponse resp = req.GetResponse();
            Stream recStream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(recStream);
            string responseFromServer = sr.ReadToEnd();

            resp.Close();
            sr.Close();

            var res = JsonSpeechParser.GetSubtitleText(responseFromServer);
            if (res.Count > 0)
                return res[0];
            else
                return "";
        }
    }
}
