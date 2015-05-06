using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Subtitles
{
    public partial class FormTranslation : Form
    {
        public FormTranslation()
        {
            InitializeComponent();
            LoadLanguages();
        }

        public struct ReturnData
        {
            public string origLang;
            public string transLang;
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

        private ReturnData data = new ReturnData();

        private void buttonOk_Click(object sender, EventArgs e)
        {
            data.origLang = languages[comboBoxOrigLang.SelectedItem.ToString()];
            data.transLang = languages[comboBoxTransLang.SelectedItem.ToString()];
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public ReturnData GetData()
        {
            return data;
        }
    }
}
