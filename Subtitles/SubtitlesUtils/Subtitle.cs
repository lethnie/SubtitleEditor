using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Subtitles.SubtitlesUtils
{
    public class Subtitle
    {
        private int start;
        private int finish;
        private string text;

        /// <summary>
        /// Начало субтитра
        /// </summary>
        public int Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        /// <summary>
        /// Конец субтитра
        /// </summary>
        public int Finish
        {
            get
            {
                return finish;
            }
            set
            {
                finish = value;
            }
        }

        /// <summary>
        /// Текст субтитра
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
    }
}
