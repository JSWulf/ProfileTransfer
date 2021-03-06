﻿namespace MachineMigrate
{
    partial class FormMain
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
            this.checkBoxSourceLocal = new System.Windows.Forms.CheckBox();
            this.checkBoxTargetLocal = new System.Windows.Forms.CheckBox();
            this.labelFullSource = new System.Windows.Forms.Label();
            this.labelFullTarget = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLocalSourceBrowse = new System.Windows.Forms.Button();
            this.buttonSourceBrowse = new System.Windows.Forms.Button();
            this.textBoxSourceLocalData = new System.Windows.Forms.TextBox();
            this.checkBoxLocalData = new System.Windows.Forms.CheckBox();
            this.comboBoxSourceProfile = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSourceDrive = new System.Windows.Forms.ComboBox();
            this.textBoxSourceHost = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLocalTargetBrowse = new System.Windows.Forms.Button();
            this.buttonTargetBrowse = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTargetLocalData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxTargetProfile = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTargetDrive = new System.Windows.Forms.ComboBox();
            this.textBoxTargetHost = new System.Windows.Forms.TextBox();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonOpenLog = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.listBoxItemsToGo = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelBar = new System.Windows.Forms.Label();
            this.pictureBoxTarget = new System.Windows.Forms.PictureBox();
            this.pictureBoxSource = new System.Windows.Forms.PictureBox();
            this.buttonMappedDrives = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxSourceLocal
            // 
            this.checkBoxSourceLocal.AutoSize = true;
            this.checkBoxSourceLocal.Location = new System.Drawing.Point(6, 33);
            this.checkBoxSourceLocal.Name = "checkBoxSourceLocal";
            this.checkBoxSourceLocal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxSourceLocal.Size = new System.Drawing.Size(52, 17);
            this.checkBoxSourceLocal.TabIndex = 0;
            this.checkBoxSourceLocal.Text = "Local";
            this.checkBoxSourceLocal.UseVisualStyleBackColor = true;
            // 
            // checkBoxTargetLocal
            // 
            this.checkBoxTargetLocal.AutoSize = true;
            this.checkBoxTargetLocal.Location = new System.Drawing.Point(6, 34);
            this.checkBoxTargetLocal.Name = "checkBoxTargetLocal";
            this.checkBoxTargetLocal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxTargetLocal.Size = new System.Drawing.Size(52, 17);
            this.checkBoxTargetLocal.TabIndex = 1;
            this.checkBoxTargetLocal.Text = "Local";
            this.checkBoxTargetLocal.UseVisualStyleBackColor = true;
            // 
            // labelFullSource
            // 
            this.labelFullSource.AutoSize = true;
            this.labelFullSource.Location = new System.Drawing.Point(23, 79);
            this.labelFullSource.Name = "labelFullSource";
            this.labelFullSource.Size = new System.Drawing.Size(35, 13);
            this.labelFullSource.TabIndex = 2;
            this.labelFullSource.Text = "label1";
            // 
            // labelFullTarget
            // 
            this.labelFullTarget.AutoSize = true;
            this.labelFullTarget.Location = new System.Drawing.Point(23, 82);
            this.labelFullTarget.Name = "labelFullTarget";
            this.labelFullTarget.Size = new System.Drawing.Size(35, 13);
            this.labelFullTarget.TabIndex = 3;
            this.labelFullTarget.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLocalSourceBrowse);
            this.groupBox1.Controls.Add(this.buttonSourceBrowse);
            this.groupBox1.Controls.Add(this.pictureBoxSource);
            this.groupBox1.Controls.Add(this.textBoxSourceLocalData);
            this.groupBox1.Controls.Add(this.checkBoxLocalData);
            this.groupBox1.Controls.Add(this.comboBoxSourceProfile);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxSourceDrive);
            this.groupBox1.Controls.Add(this.textBoxSourceHost);
            this.groupBox1.Controls.Add(this.checkBoxSourceLocal);
            this.groupBox1.Controls.Add(this.labelFullSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // buttonLocalSourceBrowse
            // 
            this.buttonLocalSourceBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLocalSourceBrowse.Location = new System.Drawing.Point(393, 54);
            this.buttonLocalSourceBrowse.Name = "buttonLocalSourceBrowse";
            this.buttonLocalSourceBrowse.Size = new System.Drawing.Size(64, 23);
            this.buttonLocalSourceBrowse.TabIndex = 17;
            this.buttonLocalSourceBrowse.Text = "Browse";
            this.buttonLocalSourceBrowse.UseVisualStyleBackColor = true;
            // 
            // buttonSourceBrowse
            // 
            this.buttonSourceBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSourceBrowse.Location = new System.Drawing.Point(393, 29);
            this.buttonSourceBrowse.Name = "buttonSourceBrowse";
            this.buttonSourceBrowse.Size = new System.Drawing.Size(64, 23);
            this.buttonSourceBrowse.TabIndex = 16;
            this.buttonSourceBrowse.Text = "Browse";
            this.buttonSourceBrowse.UseVisualStyleBackColor = true;
            // 
            // textBoxSourceLocalData
            // 
            this.textBoxSourceLocalData.Location = new System.Drawing.Point(222, 56);
            this.textBoxSourceLocalData.Name = "textBoxSourceLocalData";
            this.textBoxSourceLocalData.Size = new System.Drawing.Size(165, 20);
            this.textBoxSourceLocalData.TabIndex = 13;
            // 
            // checkBoxLocalData
            // 
            this.checkBoxLocalData.AutoSize = true;
            this.checkBoxLocalData.Location = new System.Drawing.Point(105, 58);
            this.checkBoxLocalData.Name = "checkBoxLocalData";
            this.checkBoxLocalData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxLocalData.Size = new System.Drawing.Size(111, 17);
            this.checkBoxLocalData.TabIndex = 12;
            this.checkBoxLocalData.Text = "Include Localdata";
            this.checkBoxLocalData.UseVisualStyleBackColor = true;
            this.checkBoxLocalData.CheckedChanged += new System.EventHandler(this.checkBoxLocalData_CheckedChanged);
            // 
            // comboBoxSourceProfile
            // 
            this.comboBoxSourceProfile.FormattingEnabled = true;
            this.comboBoxSourceProfile.Location = new System.Drawing.Point(222, 31);
            this.comboBoxSourceProfile.Name = "comboBoxSourceProfile";
            this.comboBoxSourceProfile.Size = new System.Drawing.Size(165, 21);
            this.comboBoxSourceProfile.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Profile Folder";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Drive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hostname / IP";
            // 
            // comboBoxSourceDrive
            // 
            this.comboBoxSourceDrive.FormattingEnabled = true;
            this.comboBoxSourceDrive.Location = new System.Drawing.Point(176, 31);
            this.comboBoxSourceDrive.Name = "comboBoxSourceDrive";
            this.comboBoxSourceDrive.Size = new System.Drawing.Size(40, 21);
            this.comboBoxSourceDrive.TabIndex = 4;
            // 
            // textBoxSourceHost
            // 
            this.textBoxSourceHost.Location = new System.Drawing.Point(70, 31);
            this.textBoxSourceHost.Name = "textBoxSourceHost";
            this.textBoxSourceHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxSourceHost.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonLocalTargetBrowse);
            this.groupBox2.Controls.Add(this.buttonTargetBrowse);
            this.groupBox2.Controls.Add(this.pictureBoxTarget);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxTargetLocalData);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxTargetProfile);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxTargetDrive);
            this.groupBox2.Controls.Add(this.textBoxTargetHost);
            this.groupBox2.Controls.Add(this.checkBoxTargetLocal);
            this.groupBox2.Controls.Add(this.labelFullTarget);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 103);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // buttonLocalTargetBrowse
            // 
            this.buttonLocalTargetBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLocalTargetBrowse.Location = new System.Drawing.Point(393, 55);
            this.buttonLocalTargetBrowse.Name = "buttonLocalTargetBrowse";
            this.buttonLocalTargetBrowse.Size = new System.Drawing.Size(64, 23);
            this.buttonLocalTargetBrowse.TabIndex = 18;
            this.buttonLocalTargetBrowse.Text = "Browse";
            this.buttonLocalTargetBrowse.UseVisualStyleBackColor = true;
            // 
            // buttonTargetBrowse
            // 
            this.buttonTargetBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonTargetBrowse.Location = new System.Drawing.Point(393, 30);
            this.buttonTargetBrowse.Name = "buttonTargetBrowse";
            this.buttonTargetBrowse.Size = new System.Drawing.Size(64, 23);
            this.buttonTargetBrowse.TabIndex = 17;
            this.buttonTargetBrowse.Text = "Browse";
            this.buttonTargetBrowse.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Localdata to:";
            // 
            // textBoxTargetLocalData
            // 
            this.textBoxTargetLocalData.Location = new System.Drawing.Point(222, 57);
            this.textBoxTargetLocalData.Name = "textBoxTargetLocalData";
            this.textBoxTargetLocalData.Size = new System.Drawing.Size(165, 20);
            this.textBoxTargetLocalData.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Profile Folder";
            // 
            // comboBoxTargetProfile
            // 
            this.comboBoxTargetProfile.FormattingEnabled = true;
            this.comboBoxTargetProfile.Location = new System.Drawing.Point(222, 32);
            this.comboBoxTargetProfile.Name = "comboBoxTargetProfile";
            this.comboBoxTargetProfile.Size = new System.Drawing.Size(165, 21);
            this.comboBoxTargetProfile.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Drive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hostname / IP";
            // 
            // comboBoxTargetDrive
            // 
            this.comboBoxTargetDrive.FormattingEnabled = true;
            this.comboBoxTargetDrive.Location = new System.Drawing.Point(176, 32);
            this.comboBoxTargetDrive.Name = "comboBoxTargetDrive";
            this.comboBoxTargetDrive.Size = new System.Drawing.Size(40, 21);
            this.comboBoxTargetDrive.TabIndex = 5;
            // 
            // textBoxTargetHost
            // 
            this.textBoxTargetHost.Location = new System.Drawing.Point(70, 32);
            this.textBoxTargetHost.Name = "textBoxTargetHost";
            this.textBoxTargetHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxTargetHost.TabIndex = 4;
            // 
            // LogListBox
            // 
            this.LogListBox.BackColor = System.Drawing.Color.Black;
            this.LogListBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogListBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(12, 307);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.ScrollAlwaysVisible = true;
            this.LogListBox.Size = new System.Drawing.Size(776, 173);
            this.LogListBox.TabIndex = 6;
            this.LogListBox.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(12, 227);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(130, 45);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonOpenLog
            // 
            this.buttonOpenLog.Enabled = false;
            this.buttonOpenLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenLog.Location = new System.Drawing.Point(234, 228);
            this.buttonOpenLog.Name = "buttonOpenLog";
            this.buttonOpenLog.Size = new System.Drawing.Size(130, 44);
            this.buttonOpenLog.TabIndex = 8;
            this.buttonOpenLog.Text = "Open Log";
            this.buttonOpenLog.UseVisualStyleBackColor = true;
            this.buttonOpenLog.Click += new System.EventHandler(this.buttonOpenLog_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(447, 228);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(130, 44);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "Panic Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(584, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Start Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(584, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Elapsed Time:";
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartTime.Location = new System.Drawing.Point(721, 252);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelStartTime.Size = new System.Drawing.Size(71, 20);
            this.labelStartTime.TabIndex = 12;
            this.labelStartTime.Text = "00:00:00";
            this.labelStartTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(721, 281);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelTimer.Size = new System.Drawing.Size(71, 20);
            this.labelTimer.TabIndex = 13;
            this.labelTimer.Text = "00:00:00";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listBoxItemsToGo
            // 
            this.listBoxItemsToGo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxItemsToGo.FormattingEnabled = true;
            this.listBoxItemsToGo.ItemHeight = 16;
            this.listBoxItemsToGo.Location = new System.Drawing.Point(588, 50);
            this.listBoxItemsToGo.Name = "listBoxItemsToGo";
            this.listBoxItemsToGo.ScrollAlwaysVisible = true;
            this.listBoxItemsToGo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxItemsToGo.Size = new System.Drawing.Size(196, 196);
            this.listBoxItemsToGo.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 278);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(565, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            // 
            // labelBar
            // 
            this.labelBar.AutoSize = true;
            this.labelBar.BackColor = System.Drawing.Color.Transparent;
            this.labelBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBar.Location = new System.Drawing.Point(278, 281);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(16, 15);
            this.labelBar.TabIndex = 16;
            this.labelBar.Text = "...";
            // 
            // pictureBoxTarget
            // 
            this.pictureBoxTarget.Location = new System.Drawing.Point(463, 20);
            this.pictureBoxTarget.Name = "pictureBoxTarget";
            this.pictureBoxTarget.Size = new System.Drawing.Size(70, 57);
            this.pictureBoxTarget.TabIndex = 15;
            this.pictureBoxTarget.TabStop = false;
            // 
            // pictureBoxSource
            // 
            this.pictureBoxSource.Location = new System.Drawing.Point(463, 19);
            this.pictureBoxSource.Name = "pictureBoxSource";
            this.pictureBoxSource.Size = new System.Drawing.Size(70, 57);
            this.pictureBoxSource.TabIndex = 14;
            this.pictureBoxSource.TabStop = false;
            // 
            // buttonMappedDrives
            // 
            this.buttonMappedDrives.Location = new System.Drawing.Point(588, 12);
            this.buttonMappedDrives.Name = "buttonMappedDrives";
            this.buttonMappedDrives.Size = new System.Drawing.Size(196, 32);
            this.buttonMappedDrives.TabIndex = 17;
            this.buttonMappedDrives.Text = "Get Mapped Drives";
            this.buttonMappedDrives.UseVisualStyleBackColor = true;
            this.buttonMappedDrives.Click += new System.EventHandler(this.buttonMappedDrives_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.buttonMappedDrives);
            this.Controls.Add(this.labelBar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listBoxItemsToGo);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonOpenLog);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User File Migration";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSourceLocal;
        private System.Windows.Forms.CheckBox checkBoxTargetLocal;
        private System.Windows.Forms.Label labelFullSource;
        private System.Windows.Forms.Label labelFullTarget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSourceLocalData;
        private System.Windows.Forms.CheckBox checkBoxLocalData;
        private System.Windows.Forms.ComboBox comboBoxSourceProfile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSourceDrive;
        private System.Windows.Forms.TextBox textBoxSourceHost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTargetLocalData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxTargetProfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTargetDrive;
        private System.Windows.Forms.TextBox textBoxTargetHost;
        private System.Windows.Forms.PictureBox pictureBoxSource;
        private System.Windows.Forms.PictureBox pictureBoxTarget;
        private System.Windows.Forms.Button buttonSourceBrowse;
        private System.Windows.Forms.Button buttonTargetBrowse;
        private System.Windows.Forms.Button buttonLocalSourceBrowse;
        private System.Windows.Forms.Button buttonLocalTargetBrowse;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonOpenLog;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.ListBox listBoxItemsToGo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelBar;
        private System.Windows.Forms.Button buttonMappedDrives;
    }
}

