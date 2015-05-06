using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subtitles.AudioTransformation;
using System.IO;

namespace Subtitles.SubtitlesUtils
{
    public class SubUtils
    {
        /// <summary>
        /// Имя файла с полной аудиодорожкой
        /// </summary>
        private string outputFile = "test.wav";
        /// <summary>
        /// Имя анализируемого видеофайла
        /// </summary>
        private string videoFilename = "";
        /// <summary>
        /// Название каталога, хранящего промежуточные аудиофайлы
        /// </summary>
        public static string speechDirectory = "speech";
        /// <summary>
        /// Коллекция субтитров, с которыми работает пользователь в данный момент
        /// </summary>
        List<Subtitle> subtitles = new List<Subtitle>();

        public SubUtils(string filename)
        {          
            videoFilename = filename;
        }

        /// <summary>
        /// Определение тайминга субтитров для видеофайла
        /// </summary>
        public void AnalyzeAudio(bool simpleAlg)
        {
            WavAudio wavAudio = new WavAudio();
            wavAudio.GetWavAudioFromVideo(videoFilename, outputFile);
            SpeechDetection speechDetection = new SpeechDetection(outputFile);
            List<int[]> timing = speechDetection.GetSpeech(true, simpleAlg);

            for (int i = 0; i < timing.Count; i++)
            {             
                Subtitle sub = new Subtitle();
                
                sub.Start = timing[i][0];
                sub.Finish = timing[i][1];
                sub.Text = "";//test;
                subtitles.Add(sub);
            }
            
            
            File.Delete(outputFile);
        }

        /// <summary>
        /// Определение тайминга субтитров и распознавание их при помощи Google Speech
        /// </summary>
        /// <param name="language">Язык оригинала видео</param>
        public void AnalyzeAudio(string language, bool simpleAlg)
        {
            WavAudio wavAudio = new WavAudio();
            wavAudio.GetWavAudioFromVideo(videoFilename, outputFile);
            SpeechDetection speechDetection = new SpeechDetection(outputFile);
            List<int[]> timing = speechDetection.GetSpeech(false, simpleAlg);
            File.Delete(outputFile);
            string[] files = Directory.GetFiles(speechDirectory);

            for (int i = 0; i < files.Length; i++)
            {
                string text = GetSpeech(files[i], language);
                Subtitle sub = new Subtitle();

                sub.Start = timing[i][0];
                sub.Finish = timing[i][1];
                sub.Text = text;
                subtitles.Add(sub);
            }
        }

        /// <summary>
        /// Перевод субтитров при помощи Google Translate
        /// </summary>
        /// <param name="origLanguage">Текущий язык субтитров</param>
        /// <param name="transLanguage">Язык перевода</param>
        public void TranslateSubtitles(string origLanguage, string transLanguage)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                subtitles[i].Text = GoogleServices.GoogleTranslate.GetTranslation(subtitles[i].Text, origLanguage, transLanguage);
            }
        }

        /// <summary>
        /// Получение распознанных фрагментов речи
        /// </summary>
        /// <param name="pathToWaveFile">Путь к выделенному файлу с речью</param>
        /// <returns>Распознанная строка</returns>
        private string GetSpeech(string pathToWaveFile, string language)
        {
            FileStream test = File.OpenRead(pathToWaveFile);
            byte[] testarr = new byte[test.Length];
            test.Read(testarr, 0, (int)test.Length);
            test.Close();
            string flacName = pathToWaveFile.Substring(0, pathToWaveFile.Length - 3) + "flac";
            int sampleRate = WavAudio.GetFlacFileFromWav(pathToWaveFile, flacName);
            
            File.Delete(pathToWaveFile);
            string result = GoogleServices.GoogleSpeech.GetSpeech(flacName, language, sampleRate);
            
            File.Delete(flacName);
            return result;
        }

        /// <summary>
        /// Сохранение сформированной последовательности субтитров в файл формата .srt.
        /// Вид:
        /// 1
        /// 00:00:00,000 --> 00:00:02,000
        /// Текст субтитра
        /// </summary>
        public void SaveSubtitlesToFile()
        {
            string subtitlesFilename = videoFilename.Remove(videoFilename.Length - 4) + ".srt";
            SaveSubtitlesToFile(subtitlesFilename);
        }

        /// <summary>
        /// Сохранение сформированной последовательности субтитров в файл формата .srt.
        /// Вид:
        /// 1
        /// 00:00:00,000 --> 00:00:02,000
        /// Текст субтитра
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void SaveSubtitlesToFile(string subtitlesFilename)
        {
            StreamWriter writer = File.CreateText(subtitlesFilename);
            int numOfSub = 1;
            subtitles = SubtitlesDivision();//////////////////////////////????????????????????
            for (int i = 0; i < subtitles.Count; i++)
            {
                writer.WriteLine(numOfSub.ToString());
                numOfSub++;
                string time = GetTimeString(subtitles[i].Start, subtitles[i].Finish);
                writer.WriteLine(time);
                writer.WriteLine(subtitles[i].Text);
                writer.WriteLine();
            }
            writer.Close();
        }

        /// <summary>
        /// Загружает субтитры из .srt файла по умолчанию в программу
        /// </summary>
        public void LoadSubtitlesFromFile()
        {
            string subtitlesFilename = videoFilename.Remove(videoFilename.Length - 4) + ".srt";
            LoadSubtitlesFromFile(subtitlesFilename);
        }

        /// <summary>
        /// Загружает субтитры из .srt в файла в программу
        /// </summary>
        /// <param name="subtitlesFilename">Имя файла с субтитрами</param>
        public bool LoadSubtitlesFromFile(string subtitlesFilename)
        {
            if (!File.Exists(subtitlesFilename))
                return false;
            subtitles = new List<Subtitle>();
            StreamReader reader = File.OpenText(subtitlesFilename);
            int numOfSub = 1;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                //Считываем все пустые строки
                while ((!reader.EndOfStream) && (line.Equals("")))
                {
                    line = reader.ReadLine();
                }
                if (reader.EndOfStream)
                    break;
                int num = 0;
                //Первая в группе субтитра - строка с порядковым номером субтитра; если нет - ошибка
                if (!Int32.TryParse(line, out num))
                {
                    reader.Close();
                    return false;
                }
                //Если номер неправильный - ошибка
                if (num != numOfSub)
                {
                    reader.Close();
                    return false;
                }
                numOfSub++;

                //строка времени
                line = reader.ReadLine();
                
                int start = 0;
                int finish = 0;
                if (!ParseTimeString(line, out start, out finish))
                {
                    reader.Close();
                    return false;
                }
                //текст субтитра
                line = reader.ReadLine();
                string text = line +"\r\n";
                while ((!reader.EndOfStream) && (!line.Equals("")))
                {
                    line = reader.ReadLine();
                    if (line.Equals(""))
                        break;
                    text += line +"\r\n";
                }
                text = text.Substring(0, text.Length - 2);
                Subtitle sub = new Subtitle();
                sub.Start = start;
                sub.Finish = finish;
                sub.Text = text;
                subtitles.Add(sub);
            }
            reader.Close();
            return true;
        }

        private int maxSubLength = 85;
        /// <summary>
        /// Разделение слишком длинных строк субтитров на более короткие промежутки времени
        /// </summary>
        /// <returns>Новый набор субтитров</returns>
        private List<Subtitle> SubtitlesDivision()
        {
            List<Subtitle> result = new List<Subtitle>();
            for (int i = 0; i < subtitles.Count; i++)
            {
                string output = new string(subtitles[i].Text.Where(c => char.IsLetterOrDigit(c) || char.IsPunctuation(c)).ToArray());
                if (output.Length <= maxSubLength)
                {
                    result.Add(subtitles[i]);
                }
                else
                {            
                    int length = output.Length;
                    int count = 1;
                    while (length > maxSubLength)
                    {
                        count++;
                        length = length - maxSubLength;
                    }

                    int lastBound = 0;
                    for (int j = 0; j < count - 1; j++)
                    {
                        Subtitle s = new Subtitle();
                        int bound = GetBound(subtitles[i].Text, j);
                        s.Text = subtitles[i].Text.Substring(lastBound, bound - lastBound + 1);
                        
                        if (j == 0)
                            s.Start = subtitles[i].Start;
                        else
                            s.Start = result[result.Count - 1].Finish;
                        s.Finish = s.Start + (int)((subtitles[i].Finish - subtitles[i].Start) / count);
                        result.Add(s);
                        lastBound = bound + 1;
                    }
                    Subtitle sub = new Subtitle();
                    sub.Text = subtitles[i].Text.Substring(lastBound);
                    sub.Start = result[result.Count - 1].Finish;
                    sub.Finish = sub.Start + (int)((subtitles[i].Finish - subtitles[i].Start) / count);
                    result.Add(sub);
                }
            }
            return result;
        }

        /// <summary>
        /// Получение границы субтитра, не являющейся буквой
        /// </summary>
        /// <param name="str">Субтитр</param>
        /// <param name="number">Порядковый номер границы</param>
        /// <returns>Номер граничного элемента</returns>
        private int GetBound(string str, int number)
        {
            int leftBound = maxSubLength * (number + 1);
            int rightBound = maxSubLength * (number + 1);
            while ((Char.IsLetter(str[leftBound])) 
                && (Char.IsLetter(str[rightBound])))
            {
                int count = 0;
                if ((leftBound > 0) && (leftBound > maxSubLength * number))
                {
                    leftBound--;
                    count++;
                }
                if ((rightBound < str.Length - 1) && (rightBound < maxSubLength * (number + 2) - 1))
                {
                    rightBound++;
                    count++;
                }
                if (count == 0)
                    break;
            }
            if (!Char.IsLetter(str[rightBound]))
            {
                return rightBound;
            }
            else
            {
                return leftBound;
            }
        }

        /// <summary>
        /// Формирование строки границ времени субтитра для .srt файла
        /// </summary>
        /// <param name="start">Начало субтитра</param>
        /// <param name="finish">Конец субтитра</param>
        /// <returns>Строка границ времени</returns>
        private string GetTimeString(int start, int finish)
        {
            int startHour = (int)(start / 3600000);
            int startMinute = (int)(start % 3600000) / 60000;
            int startSecond = (int)((start % 3600000) % 60000) / 1000;
            int startMillisecond = (int)(start % 1000);
            int finishHour = (int)finish / 3600000;
            int finishMinute = (int)(finish % 3600000) / 60000;
            int finishSecond = (int)((finish % 3600000) % 60000) / 1000;
            int finishMillisecond = (int)(finish % 1000);
            string time = "";
            if (startHour < 10)
            {
                time += "0";
            }
            time += startHour.ToString();
            time += ":";
            if (startMinute < 10)
            {
                time += "0";
            }
            time += startMinute.ToString();
            time += ":";
            if (startSecond < 10)
            {
                time += "0";
            }
            time += startSecond.ToString();
            time += ",";
            if (startMillisecond < 100)
            {
                time += "0";
                if (startMillisecond < 10)
                    time += "0";
            }
            time += startMillisecond.ToString();
            time += " --> ";


            if (finishHour < 10)
            {
                time += "0";
            }
            time += finishHour.ToString();
            time += ":";
            if (finishMinute < 10)
            {
                time += "0";
            }
            time += finishMinute.ToString();
            time += ":";
            if (finishSecond < 10)
            {
                time += "0";
            }
            time += finishSecond.ToString();
            time += ",";
            if (finishMillisecond < 100)
            {
                time += "0";
                if (finishMillisecond < 10)
                    time += "0";
            }
            time += finishMillisecond.ToString();
            return time;
        }

        /// <summary>
        /// Перевод времени в миллисекундах в строку
        /// </summary>
        /// <param name="start">Время</param>
        /// <returns>Строка</returns>
        public string GetTimeString(int start)
        {
            int startHour = (int)(start / 3600000);
            int startMinute = (int)(start % 3600000) / 60000;
            int startSecond = (int)((start % 3600000) % 60000) / 1000;
            int startMillisecond = (int)(start % 1000);
            string time = "";
            if (startHour < 10)
            {
                time += "0";
            }
            time += startHour.ToString();
            time += ":";
            if (startMinute < 10)
            {
                time += "0";
            }
            time += startMinute.ToString();
            time += ":";
            if (startSecond < 10)
            {
                time += "0";
            }
            time += startSecond.ToString();
            time += ",";
            if (startMillisecond < 100)
            {
                time += "0";
                if (startMillisecond < 10)
                    time += "0";
            }
            time += startMillisecond.ToString();
            return time;
        }

        /// <summary>
        /// Получение границ времени субтитра из строки .srt файла
        /// </summary>
        /// <param name="time">Строка границ времени</param>
        /// <param name="start">Начало субтитра</param>
        /// <param name="finish">Конец субтитра</param>
        /// <returns>Корректность строки</returns>
        private bool ParseTimeString(string time, out int start, out int finish)
        {
            int ind = time.IndexOf("-->");
            start = 0; finish = 0;
            if (ind < 0)
                return false;
            string s = time.Substring(0, ind);
            string f = time.Substring(ind + 3);
            //////////////////////////start:
            //hour
            ind = s.IndexOf(':');
            if (ind < 0)
                return false;
            int t = 0;
            if (!Int32.TryParse(s.Substring(0, ind), out t))
                return false;
            start += 3600000 * t;
            s = s.Substring(ind + 1);
            //minute
            ind = s.IndexOf(':');
            if (ind < 0)
                return false;
            t = 0;
            if (!Int32.TryParse(s.Substring(0, ind), out t))
                return false;
            start += 60000 * t;
            s = s.Substring(ind + 1);
            //second
            ind = s.IndexOf(',');
            if (ind < 0)
                return false;
            t = 0;
            if (!Int32.TryParse(s.Substring(0, ind), out t))
                return false;
            start += 1000 * t;
            s = s.Substring(ind + 1, 3);
            //millisecond
            t = 0;
            if (!Int32.TryParse(s, out t))
                return false;
            start += t;
            //////////////////////////finish:
            //hour
            ind = f.IndexOf(':');
            if (ind < 0)
                return false;
            t = 0;
            if (!Int32.TryParse(f.Substring(0, ind), out t))
                return false;
            finish += 3600000 * t;
            f = f.Substring(ind + 1);
            //minute
            ind = f.IndexOf(':');
            if (ind < 0)
                return false;
            t = 0;
            if (!Int32.TryParse(f.Substring(0, ind), out t))
                return false;
            finish += 60000 * t;
            f = f.Substring(ind + 1);
            //second
            ind = f.IndexOf(',');
            if (ind < 0)
                return false;
            t = 0;
            if (!Int32.TryParse(f.Substring(0, ind), out t))
                return false;
            finish += 1000 * t;
            f = f.Substring(ind + 1, 3);
            //millisecond
            t = 0;
            if (!Int32.TryParse(f, out t))
                return false;
            finish += t;
            return true;
        }
        
        /// <summary>
        /// Получение следующего за данным моментом времени субтитра
        /// </summary>
        /// <param name="start">Текущее время</param>
        /// <returns>Время начала следующего субтитра</returns>
        public int GetNextSubtitle(int start)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                if (subtitles[i].Start > start)
                {
                    return subtitles[i].Start;
                }
            }
            return start;
        }

        /// <summary>
        /// Получение предыдущего относительно данного момента времени субтитра
        /// </summary>
        /// <param name="start">Текущее время</param>
        /// <returns>Время начала предыдущего субтитра</returns>
        public int GetPrevSubtitle(int start)
        {
            for (int i = subtitles.Count - 1; i >= 0; i--)
            {
                if (subtitles[i].Finish <= start)
                {
                    return subtitles[i].Start;
                }
            }
            return start;
        }

        /// <summary>
        /// Сдвиг начала субтитра, соответствующего текущему времени, на заданную величину
        /// </summary>
        /// <param name="time">Текущий момент времени</param>
        /// <param name="step">Сдвиг</param>
        public Subtitle MoveLeftBorder(int time, int step)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                if ((subtitles[i].Start <= time) && (subtitles[i].Finish >= time))
                {
                    if ((step >= 0) || ((Math.Abs(step) <= subtitles[i].Start)))
                    {
                        subtitles[i].Start += step;
                        if (subtitles[i].Start >= subtitles[i].Finish)
                            subtitles[i].Finish = subtitles[i].Start;
                    }
                    else
                    {
                        subtitles[i].Start = 0;
                    }
                    return subtitles[i]; 
                }
            }
            return null;
        }

        /// <summary>
        /// Сдвиг конца субтитра, соответствующего текущему времени, на заданную величину
        /// </summary>
        /// <param name="time">Текущий момент времени</param>
        /// <param name="step">Сдвиг</param>
        public Subtitle MoveRightBorder(int time, int step)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                if ((subtitles[i].Start <= time) && (subtitles[i].Finish >= time))
                {
                    if ((step >= 0) || ((Math.Abs(step) <= subtitles[i].Finish)))
                    {
                        subtitles[i].Finish += step;
                        if (subtitles[i].Start >= subtitles[i].Finish)
                            subtitles[i].Start = subtitles[i].Finish;
                    }
                    else
                    {
                        subtitles[i].Finish = 0;
                    }
                    return subtitles[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Продолжительность субтитра по умолчанию
        /// </summary>
        private int avTime = 3000;

        /// <summary>
        /// Добавление субтитра в данный момент времени
        /// </summary>
        /// <param name="time">Текущее время</param>
        public Subtitle AddSubtitleHere(int time)
        {
            int i = 0;
            while (subtitles[i].Start <= time)
                i++;
            Subtitle sub = new Subtitle();
            sub.Start = time;
            sub.Finish = sub.Start + avTime;
            sub.Text = " ";
            subtitles.Insert(i, sub);
            return sub;
        }

        /// <summary>
        /// Добавление субтитра в данный момент времени
        /// </summary>
        /// <param name="time">Текущее время</param>
        /// <param name="text">Текст субтитра</param>
        public Subtitle AddSubtitleHere(int time, string text)
        {
            int i = 0;
            while ((i < subtitles.Count) && (subtitles[i].Start <= time))
                i++;
            Subtitle sub = new Subtitle();
            sub.Start = time;
            sub.Finish = sub.Start + avTime;
            sub.Text = text;
            subtitles.Insert(i, sub);
            return sub;
        }

        /// <summary>
        /// Удаление субтитра, соответствующего заданному моменту времени
        /// </summary>
        /// <param name="time">Текущее время</param>
        public void DeleteThisSubtitle(int time)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                if ((subtitles[i].Start <= time) && (subtitles[i].Finish >= time))
                {
                    subtitles.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Редактирование текста субтитра, соответствующего заданному моменту времени. Если такого субтитра нет, он создаётся
        /// </summary>
        /// <param name="time">Текущее время</param>
        /// <param name="text">Новый текст субтитра</param>
        public Subtitle EditThisSubtitle(int time, string text)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                if ((subtitles[i].Start <= time) && (subtitles[i].Finish >= time))
                {
                    subtitles[i].Text = text;
                    return subtitles[i];
                }
            }
            return AddSubtitleHere(time, text);
        }

        /// <summary>
        /// Получение строки субтитра, соответствующего данному моменту времени
        /// </summary>
        /// <param name="time">Текущее время</param>
        /// <returns>Субтитр</returns>
        public Subtitle GetThisSubtitle(int time)
        {
            for (int i = 0; i < subtitles.Count; i++)
            {
                if ((subtitles[i].Start <= time) && (subtitles[i].Finish >= time))
                {
                    return subtitles[i];
                }
            }
            return null;
        }
    }
}
