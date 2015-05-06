using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Subtitles
{
    public partial class FormGenProperties : Form
    {
        public FormGenProperties()
        {
            InitializeComponent();
            LoadLanguages();
        }

        private const string languagesFilename = "languages.txt";
        private Dictionary<string, string> languages = new Dictionary<string, string>();
        
        private void LoadLanguages()
        {
            StreamReader reader = File.OpenText(languagesFilename);
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                string value = str.Substring(0, str.IndexOf(' '));               
                string key = str.Substring(str.IndexOf(' ') + 1);
                comboBoxOrigLang.Items.Add(key);
                comboBoxTransLang.Items.Add(key);
                if (value.Equals("en-US"))
                {
                    comboBoxOrigLang.SelectedItem = comboBoxOrigLang.Items[comboBoxOrigLang.Items.Count - 1];
                    comboBoxTransLang.SelectedItem = comboBoxTransLang.Items[comboBoxTransLang.Items.Count - 1];
                }
                languages.Add(key, value);
            }
        }

        private void checkBoxSpeech_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpeech.Checked)
            {
                checkBoxTranslation.Enabled = true;
                comboBoxOrigLang.Enabled = true;
            }
            else
            {
                checkBoxTranslation.Enabled = false;
                comboBoxOrigLang.Enabled = false;
            }
        }

        private void checkBoxTranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTranslation.Checked)
            {
                comboBoxTransLang.Enabled = true;
            }
            else
            {
                comboBoxTransLang.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public struct ReturnData
        {
            public int type;
            public string origLang;
            public string transLang;
            public bool simpleAlg;
        }

        private ReturnData data = new ReturnData();

        private void buttonOk_Click(object sender, EventArgs e)
        {
            data.type = 0;
            if (checkBoxSpeech.Checked)
                data.type++;
            if (checkBoxTranslation.Checked)
                data.type++;
            if (data.type > 0)
            {
                data.origLang = languages[comboBoxOrigLang.SelectedItem.ToString()];
                if (data.type > 1)
                {
                    data.transLang = languages[comboBoxTransLang.SelectedItem.ToString()];
                }
            }
            if (rbTime.Checked)
                data.simpleAlg = true;
            if (rbQuality.Checked)
                data.simpleAlg = false;
            this.DialogResult = DialogResult.OK;
        }

        public ReturnData GetData()
        {
            return data;
        }
    }
}
