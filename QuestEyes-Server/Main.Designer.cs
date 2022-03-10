
namespace QuestEyes_Server
{
    partial class Main
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
            this.batPercentage = new System.Windows.Forms.Label();
            this.firmwareVer = new System.Windows.Forms.Label();
            this.checkFirmUpdate = new System.Windows.Forms.Button();
            this.forceReconnect = new System.Windows.Forms.Button();
            this.diagnostics = new System.Windows.Forms.Button();
            this.resetDevice = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.conStatLabel = new System.Windows.Forms.Label();
            this.conStat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.infoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.oscButton = new System.Windows.Forms.Button();
            this.calibrateButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // batPercentage
            // 
            this.batPercentage.AutoSize = true;
            this.batPercentage.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.batPercentage.Location = new System.Drawing.Point(5, 10);
            this.batPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.batPercentage.Name = "batPercentage";
            this.batPercentage.Size = new System.Drawing.Size(237, 19);
            this.batPercentage.TabIndex = 2;
            this.batPercentage.Text = "Device battery percentage: Unknown";
            // 
            // firmwareVer
            // 
            this.firmwareVer.AutoSize = true;
            this.firmwareVer.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firmwareVer.Location = new System.Drawing.Point(5, 10);
            this.firmwareVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firmwareVer.Name = "firmwareVer";
            this.firmwareVer.Size = new System.Drawing.Size(222, 19);
            this.firmwareVer.TabIndex = 3;
            this.firmwareVer.Text = "Device firmware version: Unknown";
            // 
            // checkFirmUpdate
            // 
            this.checkFirmUpdate.Enabled = false;
            this.checkFirmUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkFirmUpdate.Location = new System.Drawing.Point(14, 227);
            this.checkFirmUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkFirmUpdate.Name = "checkFirmUpdate";
            this.checkFirmUpdate.Size = new System.Drawing.Size(177, 27);
            this.checkFirmUpdate.TabIndex = 1;
            this.checkFirmUpdate.Text = "Check for updates";
            this.checkFirmUpdate.UseVisualStyleBackColor = true;
            this.checkFirmUpdate.Click += new System.EventHandler(this.checkFirmUpdate_Click);
            // 
            // forceReconnect
            // 
            this.forceReconnect.Enabled = false;
            this.forceReconnect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.forceReconnect.Location = new System.Drawing.Point(197, 227);
            this.forceReconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.forceReconnect.Name = "forceReconnect";
            this.forceReconnect.Size = new System.Drawing.Size(177, 27);
            this.forceReconnect.TabIndex = 2;
            this.forceReconnect.Text = "Reconnect QuestEyes device";
            this.forceReconnect.UseVisualStyleBackColor = true;
            this.forceReconnect.Click += new System.EventHandler(this.forceReconnect_Click);
            // 
            // diagnostics
            // 
            this.diagnostics.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.diagnostics.Location = new System.Drawing.Point(199, 258);
            this.diagnostics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.diagnostics.Name = "diagnostics";
            this.diagnostics.Size = new System.Drawing.Size(175, 27);
            this.diagnostics.TabIndex = 4;
            this.diagnostics.Text = "Diagnostics";
            this.diagnostics.UseVisualStyleBackColor = true;
            this.diagnostics.Click += new System.EventHandler(this.diagnostics_Click);
            // 
            // resetDevice
            // 
            this.resetDevice.Enabled = false;
            this.resetDevice.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.resetDevice.Location = new System.Drawing.Point(14, 258);
            this.resetDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resetDevice.Name = "resetDevice";
            this.resetDevice.Size = new System.Drawing.Size(177, 27);
            this.resetDevice.TabIndex = 3;
            this.resetDevice.Text = "Factory reset device";
            this.resetDevice.UseVisualStyleBackColor = true;
            this.resetDevice.Click += new System.EventHandler(this.resetDevice_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = System.Drawing.SystemColors.Control;
            this.title.Location = new System.Drawing.Point(118, 19);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(155, 36);
            this.title.TabIndex = 0;
            this.title.Text = "QuestEyes";
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.consoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.consoleBox.DetectUrls = false;
            this.consoleBox.ForeColor = System.Drawing.SystemColors.Window;
            this.consoleBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.consoleBox.Location = new System.Drawing.Point(14, 357);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.consoleBox.ShortcutsEnabled = false;
            this.consoleBox.Size = new System.Drawing.Size(360, 81);
            this.consoleBox.TabIndex = 17;
            this.consoleBox.TabStop = false;
            this.consoleBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.conStatLabel);
            this.panel1.Controls.Add(this.conStat);
            this.panel1.Location = new System.Drawing.Point(14, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 42);
            this.panel1.TabIndex = 18;
            // 
            // conStatLabel
            // 
            this.conStatLabel.AutoSize = true;
            this.conStatLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.conStatLabel.Location = new System.Drawing.Point(5, 10);
            this.conStatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.conStatLabel.Name = "conStatLabel";
            this.conStatLabel.Size = new System.Drawing.Size(124, 19);
            this.conStatLabel.TabIndex = 1;
            this.conStatLabel.Text = "Connection status:";
            // 
            // conStat
            // 
            this.conStat.AutoSize = true;
            this.conStat.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.conStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.conStat.Location = new System.Drawing.Point(126, 10);
            this.conStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.conStat.Name = "conStat";
            this.conStat.Size = new System.Drawing.Size(79, 19);
            this.conStat.TabIndex = 10;
            this.conStat.Text = "Searching...";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.batPercentage);
            this.panel2.Location = new System.Drawing.Point(14, 128);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 42);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.firmwareVer);
            this.panel3.Location = new System.Drawing.Point(14, 177);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 42);
            this.panel3.TabIndex = 19;
            // 
            // infoButton
            // 
            this.infoButton.BackgroundImage = global::QuestEyes_Server.Properties.Resources.information;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoButton.Location = new System.Drawing.Point(345, 444);
            this.infoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(29, 29);
            this.infoButton.TabIndex = 5;
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 449);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "QuestEyes PC App version 1.2.0";
            // 
            // oscButton
            // 
            this.oscButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.oscButton.Location = new System.Drawing.Point(14, 290);
            this.oscButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.oscButton.Name = "oscButton";
            this.oscButton.Size = new System.Drawing.Size(360, 27);
            this.oscButton.TabIndex = 20;
            this.oscButton.Text = "OSC output control (Output to VRChat, etc)";
            this.oscButton.UseVisualStyleBackColor = true;
            this.oscButton.Click += new System.EventHandler(this.oscButton_Click);
            // 
            // calibrateButton
            // 
            this.calibrateButton.Enabled = false;
            this.calibrateButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.calibrateButton.Location = new System.Drawing.Point(14, 321);
            this.calibrateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.calibrateButton.Name = "calibrateButton";
            this.calibrateButton.Size = new System.Drawing.Size(360, 27);
            this.calibrateButton.TabIndex = 21;
            this.calibrateButton.Text = "Begin device calibration";
            this.calibrateButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(389, 480);
            this.Controls.Add(this.calibrateButton);
            this.Controls.Add(this.oscButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.title);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.diagnostics);
            this.Controls.Add(this.resetDevice);
            this.Controls.Add(this.forceReconnect);
            this.Controls.Add(this.checkFirmUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "QuestEyes PC App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label batPercentage;
        private System.Windows.Forms.Label firmwareVer;
        private System.Windows.Forms.Button checkFirmUpdate;
        private System.Windows.Forms.Button forceReconnect;
        private System.Windows.Forms.Button diagnostics;
        private System.Windows.Forms.Button resetDevice;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label conStatLabel;
        private System.Windows.Forms.Label conStat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button oscButton;
        private System.Windows.Forms.Button calibrateButton;
    }
}

