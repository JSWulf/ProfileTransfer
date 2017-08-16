namespace ProfileTransferCsharp
{
    partial class Transfer
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.txtProgressBar1 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
			this.buttonPanic = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.buttonView = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.SystemColors.MenuText;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 18;
			this.listBox1.Location = new System.Drawing.Point(13, 13);
			this.listBox1.Name = "listBox1";
			this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.listBox1.Size = new System.Drawing.Size(497, 310);
			this.listBox1.TabIndex = 0;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(13, 365);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(707, 23);
			this.progressBar1.TabIndex = 1;
			// 
			// txtProgressBar1
			// 
			this.txtProgressBar1.AutoSize = true;
			this.txtProgressBar1.BackColor = System.Drawing.Color.Transparent;
			this.txtProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProgressBar1.Location = new System.Drawing.Point(332, 342);
			this.txtProgressBar1.Name = "txtProgressBar1";
			this.txtProgressBar1.Size = new System.Drawing.Size(104, 20);
			this.txtProgressBar1.TabIndex = 2;
			this.txtProgressBar1.Text = "0% Complete";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundwork1_reportProgress);
			// 
			// backgroundWorker2
			// 
			this.backgroundWorker2.WorkerReportsProgress = true;
			this.backgroundWorker2.WorkerSupportsCancellation = true;
			this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
			// 
			// backgroundWorker3
			// 
			this.backgroundWorker3.WorkerReportsProgress = true;
			this.backgroundWorker3.WorkerSupportsCancellation = true;
			this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
			// 
			// backgroundWorker4
			// 
			this.backgroundWorker4.WorkerReportsProgress = true;
			this.backgroundWorker4.WorkerSupportsCancellation = true;
			this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
			// 
			// backgroundWorker5
			// 
			this.backgroundWorker5.WorkerReportsProgress = true;
			this.backgroundWorker5.WorkerSupportsCancellation = true;
			this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker5_DoWork);
			// 
			// buttonPanic
			// 
			this.buttonPanic.AutoSize = true;
			this.buttonPanic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonPanic.Location = new System.Drawing.Point(336, 394);
			this.buttonPanic.Name = "buttonPanic";
			this.buttonPanic.Size = new System.Drawing.Size(86, 23);
			this.buttonPanic.TabIndex = 3;
			this.buttonPanic.Text = "Panic! Stop All";
			this.buttonPanic.UseVisualStyleBackColor = true;
			this.buttonPanic.Click += new System.EventHandler(this.buttonPanic_Click);
			// 
			// buttonExit
			// 
			this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonExit.AutoSize = true;
			this.buttonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonExit.Enabled = false;
			this.buttonExit.Location = new System.Drawing.Point(13, 394);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(34, 23);
			this.buttonExit.TabIndex = 4;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// buttonView
			// 
			this.buttonView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonView.AutoSize = true;
			this.buttonView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonView.Location = new System.Drawing.Point(619, 394);
			this.buttonView.Name = "buttonView";
			this.buttonView.Size = new System.Drawing.Size(101, 23);
			this.buttonView.TabIndex = 5;
			this.buttonView.Text = "Open Logs Folder";
			this.buttonView.UseVisualStyleBackColor = true;
			this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 326);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(192, 326);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 18);
			this.label2.TabIndex = 7;
			this.label2.Text = "label2";
			// 
			// listBox2
			// 
			this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 18;
			this.listBox2.Location = new System.Drawing.Point(517, 13);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(203, 310);
			this.listBox2.TabIndex = 9;
			// 
			// Transfer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(730, 429);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonView);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.buttonPanic);
			this.Controls.Add(this.txtProgressBar1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "Transfer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Transfer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.unload);
			this.Load += new System.EventHandler(this.Transfer_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label txtProgressBar1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.ComponentModel.BackgroundWorker backgroundWorker2;
		private System.ComponentModel.BackgroundWorker backgroundWorker3;
		private System.ComponentModel.BackgroundWorker backgroundWorker4;
		private System.ComponentModel.BackgroundWorker backgroundWorker5;
		private System.Windows.Forms.Button buttonPanic;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonView;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox2;
	}
}