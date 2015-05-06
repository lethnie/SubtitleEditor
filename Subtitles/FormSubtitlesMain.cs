using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Subtitles.SubtitlesUtils;
using Subtitles.GoogleServices;
using Subtitles.AudioTransformation;
using System.IO;

namespace Subtitles
{
    public partial class FormSubtitlesMain : Form
    {
        public FormSubtitlesMain()
        {
            InitializeComponent();
            panelSubEdit.Enabled = false;
            subtitlesToolStripMenuItem.Enabled = false;

            lblStart.Text = "";
            lblEnd.Text = "";
            lblDur.Text = "";
        }

        string filename = "";
        bool saved = true;
        SubUtils subUtils;

        private void FormSubtitlesMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = ClosingSubtitlesWithoutSavingCancel();
        }

        private bool ClosingSubtitlesWithoutSavingCancel()
        {
            if (!saved)
            {
                string messageBoxText = "Do you want to save changes?";
                string caption = "Subtitles Editor";
                MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                switch (result)
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return true;
                }             
            }
            return false;
        }

        /// <summary>
        /// Сохранить субтитры в файл
        /// </summary>
        private void Save()
        {
            saveSubtitles.FileName = filename.Remove(filename.Length - 4) + ".srt";
            if (saveSubtitles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string subtitlesFilename = saveSubtitles.FileName;
                if (subtitlesFilename.Length > 0)
                {
                    if ((subtitlesFilename.IndexOf('.') == -1) || (!subtitlesFilename.Substring(subtitlesFilename.IndexOf('.') + 1).Equals("srt")))
                    {
                        subtitlesFilename += ".srt";
                    }
                    subUtils.SaveSubtitlesToFile(subtitlesFilename);
                }
                else
                    subUtils.SaveSubtitlesToFile();
                saved = true;
            }            
        }

        /// <summary>
        /// Открыть видеофайл
        /// </summary>
        private void Open()
        {
            string formats = "All Videos Files |*.avi";
            openVideo.Filter = formats;
            if (openVideo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openVideo.FileName;
                openSubtitles.FileName = filename.Remove(filename.Length - 4) + ".srt";
                subUtils = new SubUtils(filename);
                axWindowsMediaPlayer.URL = filename;
                panelSubEdit.Enabled = true;
                subtitlesToolStripMenuItem.Enabled = true;
            }  
        }

        private void Generate()
        {
            if (filename.Length > 0)
            {
                axWindowsMediaPlayer.URL = "";
                FormGenProperties formGen = new FormGenProperties();
                formGen.ShowDialog();
                if (formGen.DialogResult == DialogResult.OK)
                {
                    var data = formGen.GetData();

                    this.Cursor = Cursors.WaitCursor;

                    saved = false;

                    if (data.type == 0)
                        subUtils.AnalyzeAudio(data.simpleAlg);
                    if (data.type == 1)
                        subUtils.AnalyzeAudio(data.origLang, data.simpleAlg);
                    if (data.type == 2)
                    {
                        subUtils.AnalyzeAudio(data.origLang, data.simpleAlg);
                        subUtils.TranslateSubtitles(data.origLang, data.transLang);
                    }

                    axWindowsMediaPlayer.URL = filename;
                    this.Cursor = Cursors.Default;
                }
                axWindowsMediaPlayer.URL = filename;
            }
            else
            {
                MessageBox.Show("Open video first");
            }
        }

        private void buttonAddSub_Click(object sender, EventArgs e)
        {
            AddSubtitleHere();
        }

        private void buttonDelSub_Click(object sender, EventArgs e)
        {
            DeleteThisSubtitle();
        }

        /// <summary>
        /// Переход к моменту следующего субтитра
        /// </summary>
        private void NextSubtitle()
        {
            int start = (int) (axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            int time = subUtils.GetNextSubtitle(start);
            axWindowsMediaPlayer.Ctlcontrols.currentPosition = (double)time / (double)1000;
        }

        /// <summary>
        /// Переход к моменту предыдущего субтитра
        /// </summary>
        private void PrevSubtitle()
        {
            int start = (int) (axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            int time = subUtils.GetPrevSubtitle(start);
            axWindowsMediaPlayer.Ctlcontrols.currentPosition = (double)time / (double)1000;
        }

        /// <summary>
        /// Подвинуть левую границу субтитра на указанное число миллисекунд (-3600000..3600000)
        /// </summary>
        private void MoveLeftBorder()
        {
            saved = false;
            int time = (int) (axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            int step = (int) numericUpDownStep.Value;
            Subtitle current = subUtils.MoveLeftBorder(time, step);
            textBoxSubtitle.Text = current.Text;
            lblStart.Text = subUtils.GetTimeString(current.Start);
            lblEnd.Text = subUtils.GetTimeString(current.Finish);
            lblDur.Text = subUtils.GetTimeString(current.Finish - current.Start);
        }

        /// <summary>
        /// Подвинуть правую границу субтитра на указанное число миллисекунд (-3600000..3600000)
        /// </summary>
        private void MoveRightBorder()
        {
            saved = false;
            int time = (int)(axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            int step = (int)numericUpDownStep.Value;
            Subtitle current = subUtils.MoveRightBorder(time, step);
            textBoxSubtitle.Text = current.Text;
            lblStart.Text = subUtils.GetTimeString(current.Start);
            lblEnd.Text = subUtils.GetTimeString(current.Finish);
            lblDur.Text = subUtils.GetTimeString(current.Finish - current.Start);
        }

        /// <summary>
        /// Добавить субтитр здесь
        /// </summary>
        private void AddSubtitleHere()
        {
            saved = false;
            int time = (int)(axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            Subtitle current;
            if (textBoxSubtitle.Text.Length > 0)
                current = subUtils.AddSubtitleHere(time, textBoxSubtitle.Text);
            else
                current = subUtils.AddSubtitleHere(time);
            textBoxSubtitle.Text = current.Text;
            lblStart.Text = subUtils.GetTimeString(current.Start);
            lblEnd.Text = subUtils.GetTimeString(current.Finish);
            lblDur.Text = subUtils.GetTimeString(current.Finish - current.Start);
        }

        /// <summary>
        /// Удалить этот субтитр
        /// </summary>
        private void DeleteThisSubtitle()
        {
            saved = false;
            int time = (int)(axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            subUtils.DeleteThisSubtitle(time);
            textBoxSubtitle.Text = "";
            lblStart.Text = "";
            lblEnd.Text = "";
            lblDur.Text = "";
        }

        /// <summary>
        /// Редактировать текст текущего субтитра
        /// </summary>
        private void EditThisSubtitle()
        {
            saved = false;
            int time = (int)(axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            subUtils.EditThisSubtitle(time, textBoxSubtitle.Text);
        }

        private void buttonPrevSub_Click(object sender, EventArgs e)
        {
            PrevSubtitle();
        }

        private void buttonNxtSub_Click(object sender, EventArgs e)
        {
            NextSubtitle();
        }

        private void buttonMvLftBorder_Click(object sender, EventArgs e)
        {
            MoveLeftBorder();
        }

        private void buttonMvRightBorder_Click(object sender, EventArgs e)
        {
            MoveRightBorder();
        }

        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)
            {
                playingTimer.Enabled = true;
            }
            else
            {
                playingTimer.Enabled = false;
                int time = (int)(axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
                Subtitle current = subUtils.GetThisSubtitle(time);
                if (current == null)
                {
                    textBoxSubtitle.Text = "";
                    lblStart.Text = "";
                    lblEnd.Text = "";
                    lblDur.Text = "";
                }
                else
                {
                    textBoxSubtitle.Text = current.Text;
                    lblStart.Text = subUtils.GetTimeString(current.Start);
                    lblEnd.Text = subUtils.GetTimeString(current.Finish);
                    lblDur.Text = subUtils.GetTimeString(current.Finish - current.Start);
                }
            }
        }

        private void playingTimer_Tick(object sender, EventArgs e)
        {
            int time = (int) (axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            Subtitle current = subUtils.GetThisSubtitle(time);
            if (current == null)
            {
                textBoxSubtitle.Text = "";
                lblStart.Text = "";
                lblEnd.Text = "";
                lblDur.Text = "";
            }
            else
            {
                textBoxSubtitle.Text = current.Text;
                lblStart.Text = subUtils.GetTimeString(current.Start);
                lblEnd.Text = subUtils.GetTimeString(current.Finish);
                lblDur.Text = subUtils.GetTimeString(current.Finish - current.Start);
            }
        }

        private void axWindowsMediaPlayer_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
            int time = (int)(axWindowsMediaPlayer.Ctlcontrols.currentPosition * 1000);
            Subtitle current = subUtils.GetThisSubtitle(time);
            if (current == null)
            {
                textBoxSubtitle.Text = "";
                lblStart.Text = "";
                lblEnd.Text = "";
                lblDur.Text = "";
            }
            else
            {
                textBoxSubtitle.Text = current.Text;
                lblStart.Text = subUtils.GetTimeString(current.Start);
                lblEnd.Text = subUtils.GetTimeString(current.Finish);
                lblDur.Text = subUtils.GetTimeString(current.Finish - current.Start);
            }
        }

        private void buttonEditSub_Click(object sender, EventArgs e)
        {
            EditThisSubtitle();
        }

        private void openVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClosingSubtitlesWithoutSavingCancel())
            {
                string formats = ".srt files |*.srt";
                openSubtitles.Filter = formats;
                if (openSubtitles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string subName = openSubtitles.FileName;
                    if (!subUtils.LoadSubtitlesFromFile(subName))
                    {
                        MessageBox.Show("Wrong file format");
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subUtils.SaveSubtitlesToFile();
            saved = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private bool IsPanelSqrCorrect(int width, int height)
        {
            if ((width < 135) || (height < 85))
                return false;
            if (width * height < 16000)
                return false;
            return true;
        }

        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.URL = "";
            FormTranslation formTr = new FormTranslation();
            formTr.ShowDialog();
            if (formTr.DialogResult == DialogResult.OK)
            {
                var data = formTr.GetData();
                this.Cursor = Cursors.WaitCursor;
                saved = false;

                subUtils.TranslateSubtitles(data.origLang, data.transLang);
                this.Cursor = Cursors.Default;
            }
            axWindowsMediaPlayer.URL = filename;           
        }
    }
}
