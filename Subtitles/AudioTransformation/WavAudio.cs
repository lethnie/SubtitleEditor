using System;
using AviFile;
using System.IO;
using CUETools.Codecs;
using CUETools.Codecs.FLAKE;

namespace Subtitles.AudioTransformation
{
    public class WavAudio
    {
        public void GetWavAudioFromVideo(string inputFilename, string outputFilename)
        {
            AviManager aviManager =
    new AviManager(inputFilename, true);
            AudioStream audioStream = aviManager.GetWaveStream();
            audioStream.ExportStream(outputFilename);
            aviManager.Close();
        }

        public static int GetFlacFileFromWav(string pathToWavFile, string flacName)
        {
            int sampleRate = 0;

            IAudioSource audioSource = new WAVReader(pathToWavFile, null);
            AudioBuffer buff = new AudioBuffer(audioSource, 0x10000);

            FlakeWriter flakewriter = new FlakeWriter(flacName, audioSource.PCM);
            sampleRate = audioSource.PCM.SampleRate;

            FlakeWriter audioDest = flakewriter;
            while (audioSource.Read(buff, -1) != 0)
            {
                audioDest.Write(buff);
            }
            audioSource.Close();

            audioDest.Close();

            return sampleRate;
        }
    }
}
