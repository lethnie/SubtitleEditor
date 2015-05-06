using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechEndpointDetection;
using SpeechEndpointDetection.Algorithms;

namespace Subtitles.AudioTransformation
{
    public class SpeechDetection
    {
        /// <summary>
        /// Имя видеофайла
        /// </summary>
        private string filename;

        private WaveReader speech;
        private Parameters parameters;
        private double step;
        private int sampleRate = 0;

        /// <summary>
        /// Работа с аудиофайлом
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public SpeechDetection(string fileName)
        {
            filename = fileName;
            speech = new WaveReader(fileName);
            parameters = new Parameters(speech.GetSignal(), speech.GetDuration(), speech.GetSampleRate(), 0);
            step = parameters.GetShiftSizeInMs() / 1000.0;
            sampleRate = speech.GetSampleRate();
        }

        /// <summary>
        /// Получение тайминга и сохранение речевых фрагментов в файлы
        /// </summary>
        /// <param name="onlyTiming">Нужен только тайминг или распознавание</param>
        /// <param name="simpleAlg">Использовать простой или сложный алгоритм</param>
        /// <returns></returns>
        public List<int[]> GetSpeech(bool onlyTiming, bool simpleAlg)
        {
            Detection detection = new Detection(parameters);
            List<int[]> timing;
            if (simpleAlg)
                timing = detection.AlgorithmEnergyZCR();
            else
                timing = detection.AlgorithmTeagerEnergyLSFMFrequencyLTSVMeanDelta();
            if (!onlyTiming)
            {
                //для всех речевых промежутков - сохранение в файлы
                int len = timing.Count.ToString().Length;
                for (int i = 0; i < timing.Count; i++)
                {
                    timing[i][0] -= 100;
                    timing[i][1] += 100;
                    string num = "";
                    for (int j = i.ToString().Length; j < len; j++)
                    {
                        num += "0";
                    }
                    num += i.ToString();
                    if (timing[i][0] < 0)
                        timing[i][0] = 0;
                    string filepath = SubtitlesUtils.SubUtils.speechDirectory + "/test" + num + ".wav";
                    speech.CreateWaveFile(filepath, timing[i][0], timing[i][1]);
                }
            }
            return timing;
        }
    }
}
