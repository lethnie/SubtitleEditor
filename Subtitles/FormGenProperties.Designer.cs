namespace Subtitles
{
    partial class FormGenProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBoxTiming = new System.Windows.Forms.CheckBox();
            this.checkBoxSpeech = new System.Windows.Forms.CheckBox();
            this.checkBoxTranslation = new System.Windows.Forms.CheckBox();
            this.comboBoxOrigLang = new System.Windows.Forms.ComboBox();
            this.comboBoxTransLang = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbQuality = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxTiming
            // 
            this.checkBoxTiming.AutoSize = true;
            this.checkBoxTiming.Checked = true;
            this.checkBoxTiming.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTiming.Enabled = false;
            this.checkBoxTiming.Location = new System.Drawing.Point(23, 27);
            this.checkBoxTiming.Name = "checkBoxTiming";
            this.checkBoxTiming.Size = new System.Drawing.Size(68, 17);
            this.checkBoxTiming.TabIndex = 0;
            this.checkBoxTiming.Text = "тайминг";
            this.checkBoxTiming.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpeech
            // 
            this.checkBoxSpeech.AutoSize = true;
            this.checkBoxSpeech.Location = new System.Drawing.Point(23, 61);
            this.checkBoxSpeech.Name = "checkBoxSpeech";
            this.checkBoxSpeech.Size = new System.Drawing.Size(213, 17);
            this.checkBoxSpeech.TabIndex = 1;
            this.checkBoxSpeech.Text = "распознавание речи (Google Speech)";
            this.checkBoxSpeech.UseVisualStyleBackColor = true;
            this.checkBoxSpeech.CheckedChanged += new System.EventHandler(this.checkBoxSpeech_CheckedChanged);
            // 
            // checkBoxTranslation
            // 
            this.checkBoxTranslation.AutoSize = true;
            this.checkBoxTranslation.Enabled = false;
            this.checkBoxTranslation.Location = new System.Drawing.Point(23, 133);
            this.checkBoxTranslation.Name = "checkBoxTranslation";
            this.checkBoxTranslation.Size = new System.Drawing.Size(158, 17);
            this.checkBoxTranslation.TabIndex = 2;
            this.checkBoxTranslation.Text = "перевод (Google Translate)";
            this.checkBoxTranslation.UseVisualStyleBackColor = true;
            this.checkBoxTranslation.CheckedChanged += new System.EventHandler(this.checkBoxTranslation_CheckedChanged);
            // 
            // comboBoxOrigLang
            // 
            this.comboBoxOrigLang.Enabled = false;
            this.comboBoxOrigLang.FormattingEnabled = true;
            this.comboBoxOrigLang.Location = new System.Drawing.Point(23, 93);
            this.comboBoxOrigLang.Name = "comboBoxOrigLang";
            this.comboBoxOrigLang.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOrigLang.TabIndex = 3;
            // 
            // comboBoxTransLang
            // 
            this.comboBoxTransLang.Enabled = false;
            this.comboBoxTransLang.FormattingEnabled = true;
            this.comboBoxTransLang.Location = new System.Drawing.Point(23, 166);
            this.comboBoxTransLang.Name = "comboBoxTransLang";
            this.comboBoxTransLang.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTransLang.TabIndex = 4;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(102, 302);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(197, 302);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbQuality);
            this.panel1.Controls.Add(this.rbTime);
            this.panel1.Location = new System.Drawing.Point(23, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 90);
            this.panel1.TabIndex = 7;
            // 
            // rbQuality
            // 
            this.rbQuality.AutoSize = true;
            this.rbQuality.Location = new System.Drawing.Point(16, 51);
            this.rbQuality.Name = "rbQuality";
            this.rbQuality.Size = new System.Drawing.Size(126, 17);
            this.rbQuality.TabIndex = 1;
            this.rbQuality.TabStop = true;
            this.rbQuality.Text = "приоритет качества";
            this.toolTip1.SetToolTip(this.rbQuality, "Для зашумлённых сигналов.\r\nТочный но медленный алгоритм поиска речи.");
            this.rbQuality.UseVisualStyleBackColor = true;
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Checked = true;
            this.rbTime.Location = new System.Drawing.Point(16, 18);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(127, 17);
            this.rbTime.TabIndex = 0;
            this.rbTime.TabStop = true;
            this.rbTime.Text = "приоритет скорости";
            this.toolTip1.SetToolTip(this.rbTime, "Для хорошего аудиосигнала без шумов либо с низким уровнем шумов.\r\nБыстрый но прос" +
                    "той алгоритм поиска речи.");
            this.rbTime.UseVisualStyleBackColor = true;
            // 
            // FormGenProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 337);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.comboBoxTransLang);
            this.Controls.Add(this.comboBoxOrigLang);
            this.Controls.Add(this.checkBoxTranslation);
            this.Controls.Add(this.checkBoxSpeech);
            this.Controls.Add(this.checkBoxTiming);
            this.Name = "FormGenProperties";
            this.Text = "Параметры";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTiming;
        private System.Windows.Forms.CheckBox checkBoxSpeech;
        private System.Windows.Forms.CheckBox checkBoxTranslation;
        private System.Windows.Forms.ComboBox comboBoxOrigLang;
        private System.Windows.Forms.ComboBox comboBoxTransLang;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbQuality;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}