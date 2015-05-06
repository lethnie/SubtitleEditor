namespace Subtitles
{
    partial class FormSubtitlesMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubtitlesMain));
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.openVideo = new System.Windows.Forms.OpenFileDialog();
            this.buttonAddSub = new System.Windows.Forms.Button();
            this.buttonDelSub = new System.Windows.Forms.Button();
            this.buttonPrevSub = new System.Windows.Forms.Button();
            this.panelSubEdit = new System.Windows.Forms.Panel();
            this.subtitlePanel = new System.Windows.Forms.Panel();
            this.lblDur = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSubtitle = new System.Windows.Forms.TextBox();
            this.buttonEditSub = new System.Windows.Forms.Button();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.buttonMvRightBorder = new System.Windows.Forms.Button();
            this.buttonMvLftBorder = new System.Windows.Forms.Button();
            this.buttonNxtSub = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.playingTimer = new System.Windows.Forms.Timer(this.components);
            this.saveSubtitles = new System.Windows.Forms.SaveFileDialog();
            this.openSubtitles = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtitlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.panelSubEdit.SuspendLayout();
            this.subtitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(0, 27);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(609, 432);
            this.axWindowsMediaPlayer.TabIndex = 0;
            this.axWindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer_PlayStateChange);
            this.axWindowsMediaPlayer.PositionChange += new AxWMPLib._WMPOCXEvents_PositionChangeEventHandler(this.axWindowsMediaPlayer_PositionChange);
            // 
            // openVideo
            // 
            this.openVideo.FileName = "openVideo";
            // 
            // buttonAddSub
            // 
            this.buttonAddSub.Location = new System.Drawing.Point(76, 3);
            this.buttonAddSub.Name = "buttonAddSub";
            this.buttonAddSub.Size = new System.Drawing.Size(24, 23);
            this.buttonAddSub.TabIndex = 4;
            this.buttonAddSub.Text = "+";
            this.toolTip1.SetToolTip(this.buttonAddSub, "Добавить субтитр");
            this.buttonAddSub.UseVisualStyleBackColor = true;
            this.buttonAddSub.Click += new System.EventHandler(this.buttonAddSub_Click);
            // 
            // buttonDelSub
            // 
            this.buttonDelSub.Location = new System.Drawing.Point(106, 3);
            this.buttonDelSub.Name = "buttonDelSub";
            this.buttonDelSub.Size = new System.Drawing.Size(24, 23);
            this.buttonDelSub.TabIndex = 5;
            this.buttonDelSub.Text = "-";
            this.toolTip1.SetToolTip(this.buttonDelSub, "Удалить субтитр");
            this.buttonDelSub.UseVisualStyleBackColor = true;
            this.buttonDelSub.Click += new System.EventHandler(this.buttonDelSub_Click);
            // 
            // buttonPrevSub
            // 
            this.buttonPrevSub.Location = new System.Drawing.Point(16, 3);
            this.buttonPrevSub.Name = "buttonPrevSub";
            this.buttonPrevSub.Size = new System.Drawing.Size(24, 23);
            this.buttonPrevSub.TabIndex = 6;
            this.buttonPrevSub.Text = "«";
            this.toolTip1.SetToolTip(this.buttonPrevSub, "Предыдущий субтитр");
            this.buttonPrevSub.UseVisualStyleBackColor = true;
            this.buttonPrevSub.Click += new System.EventHandler(this.buttonPrevSub_Click);
            // 
            // panelSubEdit
            // 
            this.panelSubEdit.Controls.Add(this.subtitlePanel);
            this.panelSubEdit.Controls.Add(this.buttonEditSub);
            this.panelSubEdit.Controls.Add(this.numericUpDownStep);
            this.panelSubEdit.Controls.Add(this.buttonMvRightBorder);
            this.panelSubEdit.Controls.Add(this.buttonMvLftBorder);
            this.panelSubEdit.Controls.Add(this.buttonNxtSub);
            this.panelSubEdit.Controls.Add(this.buttonDelSub);
            this.panelSubEdit.Controls.Add(this.buttonPrevSub);
            this.panelSubEdit.Controls.Add(this.buttonAddSub);
            this.panelSubEdit.Location = new System.Drawing.Point(615, 27);
            this.panelSubEdit.Name = "panelSubEdit";
            this.panelSubEdit.Size = new System.Drawing.Size(176, 280);
            this.panelSubEdit.TabIndex = 7;
            // 
            // subtitlePanel
            // 
            this.subtitlePanel.Controls.Add(this.lblDur);
            this.subtitlePanel.Controls.Add(this.lblEnd);
            this.subtitlePanel.Controls.Add(this.lblStart);
            this.subtitlePanel.Controls.Add(this.label3);
            this.subtitlePanel.Controls.Add(this.label2);
            this.subtitlePanel.Controls.Add(this.label1);
            this.subtitlePanel.Controls.Add(this.textBoxSubtitle);
            this.subtitlePanel.Location = new System.Drawing.Point(3, 61);
            this.subtitlePanel.Name = "subtitlePanel";
            this.subtitlePanel.Size = new System.Drawing.Size(169, 219);
            this.subtitlePanel.TabIndex = 15;
            // 
            // lblDur
            // 
            this.lblDur.AutoSize = true;
            this.lblDur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDur.Location = new System.Drawing.Point(62, 195);
            this.lblDur.Name = "lblDur";
            this.lblDur.Size = new System.Drawing.Size(45, 16);
            this.lblDur.TabIndex = 18;
            this.lblDur.Text = "label6";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEnd.Location = new System.Drawing.Point(62, 171);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(45, 16);
            this.lblEnd.TabIndex = 17;
            this.lblEnd.Text = "label5";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStart.Location = new System.Drawing.Point(62, 147);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(45, 16);
            this.lblStart.TabIndex = 16;
            this.lblStart.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Длина:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Конец:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Начало:";
            // 
            // textBoxSubtitle
            // 
            this.textBoxSubtitle.Location = new System.Drawing.Point(3, 3);
            this.textBoxSubtitle.Multiline = true;
            this.textBoxSubtitle.Name = "textBoxSubtitle";
            this.textBoxSubtitle.Size = new System.Drawing.Size(163, 141);
            this.textBoxSubtitle.TabIndex = 12;
            // 
            // buttonEditSub
            // 
            this.buttonEditSub.Location = new System.Drawing.Point(136, 3);
            this.buttonEditSub.Name = "buttonEditSub";
            this.buttonEditSub.Size = new System.Drawing.Size(24, 23);
            this.buttonEditSub.TabIndex = 14;
            this.buttonEditSub.Text = "✓";
            this.toolTip1.SetToolTip(this.buttonEditSub, "Редактировать субтитр");
            this.buttonEditSub.UseVisualStyleBackColor = true;
            this.buttonEditSub.Click += new System.EventHandler(this.buttonEditSub_Click);
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.Location = new System.Drawing.Point(82, 35);
            this.numericUpDownStep.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.numericUpDownStep.Minimum = new decimal(new int[] {
            3600000,
            0,
            0,
            -2147483648});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownStep.TabIndex = 10;
            this.numericUpDownStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.numericUpDownStep, "Сдвиг (мс)");
            this.numericUpDownStep.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // buttonMvRightBorder
            // 
            this.buttonMvRightBorder.Location = new System.Drawing.Point(49, 32);
            this.buttonMvRightBorder.Name = "buttonMvRightBorder";
            this.buttonMvRightBorder.Size = new System.Drawing.Size(27, 23);
            this.buttonMvRightBorder.TabIndex = 9;
            this.buttonMvRightBorder.Text = "->";
            this.toolTip1.SetToolTip(this.buttonMvRightBorder, "Сдвинуть правую границу");
            this.buttonMvRightBorder.UseVisualStyleBackColor = true;
            this.buttonMvRightBorder.Click += new System.EventHandler(this.buttonMvRightBorder_Click);
            // 
            // buttonMvLftBorder
            // 
            this.buttonMvLftBorder.Location = new System.Drawing.Point(16, 32);
            this.buttonMvLftBorder.Name = "buttonMvLftBorder";
            this.buttonMvLftBorder.Size = new System.Drawing.Size(27, 23);
            this.buttonMvLftBorder.TabIndex = 8;
            this.buttonMvLftBorder.Text = "<-";
            this.toolTip1.SetToolTip(this.buttonMvLftBorder, "Сдвинуть левую границу");
            this.buttonMvLftBorder.UseVisualStyleBackColor = true;
            this.buttonMvLftBorder.Click += new System.EventHandler(this.buttonMvLftBorder_Click);
            // 
            // buttonNxtSub
            // 
            this.buttonNxtSub.Location = new System.Drawing.Point(46, 3);
            this.buttonNxtSub.Name = "buttonNxtSub";
            this.buttonNxtSub.Size = new System.Drawing.Size(24, 23);
            this.buttonNxtSub.TabIndex = 7;
            this.buttonNxtSub.Text = "»";
            this.toolTip1.SetToolTip(this.buttonNxtSub, "Следующий субтитр");
            this.buttonNxtSub.UseVisualStyleBackColor = true;
            this.buttonNxtSub.Click += new System.EventHandler(this.buttonNxtSub_Click);
            // 
            // playingTimer
            // 
            this.playingTimer.Interval = 200;
            this.playingTimer.Tick += new System.EventHandler(this.playingTimer_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.subtitlesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(794, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVideoToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openVideoToolStripMenuItem
            // 
            this.openVideoToolStripMenuItem.Name = "openVideoToolStripMenuItem";
            this.openVideoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openVideoToolStripMenuItem.Text = "Открыть видео";
            this.openVideoToolStripMenuItem.Click += new System.EventHandler(this.openVideoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // subtitlesToolStripMenuItem
            // 
            this.subtitlesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.translateToolStripMenuItem});
            this.subtitlesToolStripMenuItem.Enabled = false;
            this.subtitlesToolStripMenuItem.Name = "subtitlesToolStripMenuItem";
            this.subtitlesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.subtitlesToolStripMenuItem.Text = "Субтитры";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.generateToolStripMenuItem.Text = "Генерировать";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // translateToolStripMenuItem
            // 
            this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            this.translateToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.translateToolStripMenuItem.Text = "Перевести";
            this.translateToolStripMenuItem.Click += new System.EventHandler(this.translateToolStripMenuItem_Click);
            // 
            // FormSubtitlesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 461);
            this.Controls.Add(this.panelSubEdit);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormSubtitlesMain";
            this.Text = "Редактор субтитров";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSubtitlesMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.panelSubEdit.ResumeLayout(false);
            this.subtitlePanel.ResumeLayout(false);
            this.subtitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.OpenFileDialog openVideo;
        private System.Windows.Forms.Button buttonAddSub;
        private System.Windows.Forms.Button buttonDelSub;
        private System.Windows.Forms.Button buttonPrevSub;
        private System.Windows.Forms.Panel panelSubEdit;
        private System.Windows.Forms.Button buttonNxtSub;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonMvLftBorder;
        private System.Windows.Forms.Button buttonMvRightBorder;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.TextBox textBoxSubtitle;
        private System.Windows.Forms.Timer playingTimer;
        private System.Windows.Forms.SaveFileDialog saveSubtitles;
        private System.Windows.Forms.OpenFileDialog openSubtitles;
        private System.Windows.Forms.Button buttonEditSub;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtitlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
        private System.Windows.Forms.Panel subtitlePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDur;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
    }
}

