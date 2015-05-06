using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Subtitles.GoogleServices
{
    public static class JsonSpeechParser
    {
        /// <summary>
        /// Получение вариантов субтитров из строки json
        /// </summary>
        /// <param name="json">Полученный от Google ответ</param>
        /// <returns>Список вариантов строк</returns>
        public static List<string> GetSubtitleText(string json)
        {
            List<string> result = new List<string>();
            json = json.Substring(json.IndexOf('}') + 2);
            JsonResponse response = JsonConvert.DeserializeObject<JsonResponse>(json);
            if (response != null)
            {
                foreach (JsonResponseAlternatives alt in response.result)
                {
                    foreach (JsonResponseItem item in alt.alternative)
                        result.Add(item.transcript);
                }
            }
            return result;
        }

        class JsonResponseItem
        {
            public string transcript;
            public float confidence;
        }

        class JsonResponseAlternatives
        {
            public JsonResponseItem[] alternative;
            public bool final;
        }

        class JsonResponse
        {
            public JsonResponseAlternatives[] result;
            public int result_index;
        }
    }

    public static class JsonTranslationParser
    {
        /// <summary>
        /// Получение вариантов субтитров из строки json
        /// </summary>
        /// <param name="json">Полученный от Google ответ</param>
        /// <returns>Список вариантов строк</returns>
        public static string GetSubtitleText(string json)
        {
            string result = "";

            JsonResponse response = JsonConvert.DeserializeObject<JsonResponse>(json);
            foreach (JsonResponseItem alt in response.sentences)
            {
                result += alt.trans + " ";
            }
            return result;
        }

        class JsonResponseItem
        {
            public string trans;
            public string orig;
            public string translit;
            public string src_translit;
        }

        class JsonResponse
        {
            public JsonResponseItem[] sentences;
            public string src;
            public int server_time;
        }
    }
}
