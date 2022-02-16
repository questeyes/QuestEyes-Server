
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
            this.infoButton = new System.Windows.Forms.Button();
            this.diagnostics = new System.Windows.Forms.Button();
            this.resetDevice = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.conStat = new System.Windows.Forms.Label();
            this.conStatLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // batPercentage
            // 
            this.batPercentage.AutoSize = true;
            this.batPercentage.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batPercentage.Location = new System.Drawing.Point(4, 9);
            this.batPercentage.Name = "batPercentage";
            this.batPercentage.Size = new System.Drawing.Size(192, 19);
            this.batPercentage.TabIndex = 2;
            this.batPercentage.Text = "Battery percentage: Unknown";
            // 
            // firmwareVer
            // 
            this.firmwareVer.AutoSize = true;
            this.firmwareVer.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firmwareVer.Location = new System.Drawing.Point(4, 9);
            this.firmwareVer.Name = "firmwareVer";
            this.firmwareVer.Size = new System.Drawing.Size(179, 19);
            this.firmwareVer.TabIndex = 3;
            this.firmwareVer.Text = "Firmware version: Unknown";
            // 
            // checkFirmUpdate
            // 
            this.checkFirmUpdate.Enabled = false;
            this.checkFirmUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkFirmUpdate.Location = new System.Drawing.Point(12, 205);
            this.checkFirmUpdate.Name = "checkFirmUpdate";
            this.checkFirmUpdate.Size = new System.Drawing.Size(177, 23);
            this.checkFirmUpdate.TabIndex = 4;
            this.checkFirmUpdate.Text = "Check for firmware updates";
            this.checkFirmUpdate.UseVisualStyleBackColor = true;
            this.checkFirmUpdate.Click += new System.EventHandler(this.checkFirmUpdate_Click);
            // 
            // forceReconnect
            // 
            this.forceReconnect.Enabled = false;
            this.forceReconnect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.forceReconnect.Location = new System.Drawing.Point(195, 205);
            this.forceReconnect.Name = "forceReconnect";
            this.forceReconnect.Size = new System.Drawing.Size(177, 23);
            this.forceReconnect.TabIndex = 5;
            this.forceReconnect.Text = "Reconnect QuestEyes device";
            this.forceReconnect.UseVisualStyleBackColor = true;
            this.forceReconnect.Click += new System.EventHandler(this.forceReconnect_Click);
            // 
            // infoButton
            // 
            this.infoButton.BackgroundImage = global::QuestEyes_Server.Properties.Resources.information;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoButton.Location = new System.Drawing.Point(356, 346);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(25, 25);
            this.infoButton.TabIndex = 16;
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // diagnostics
            // 
            this.diagnostics.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.diagnostics.Location = new System.Drawing.Point(195, 232);
            this.diagnostics.Name = "diagnostics";
            this.diagnostics.Size = new System.Drawing.Size(177, 23);
            this.diagnostics.TabIndex = 15;
            this.diagnostics.Text = "Diagnostics";
            this.diagnostics.UseVisualStyleBackColor = true;
            this.diagnostics.Click += new System.EventHandler(this.diagnostics_Click);
            // 
            // resetDevice
            // 
            this.resetDevice.Enabled = false;
            this.resetDevice.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.resetDevice.Location = new System.Drawing.Point(12, 232);
            this.resetDevice.Name = "resetDevice";
            this.resetDevice.Size = new System.Drawing.Size(177, 23);
            this.resetDevice.TabIndex = 14;
            this.resetDevice.Text = "Factory reset device";
            this.resetDevice.UseVisualStyleBackColor = true;
            this.resetDevice.Click += new System.EventHandler(this.resetDevice_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.Control;
            this.title.Location = new System.Drawing.Point(115, 15);
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
            this.consoleBox.Location = new System.Drawing.Point(12, 270);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.consoleBox.ShortcutsEnabled = false;
            this.consoleBox.Size = new System.Drawing.Size(360, 70);
            this.consoleBox.TabIndex = 17;
            this.consoleBox.TabStop = false;
            this.consoleBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.conStatLabel);
            this.panel1.Controls.Add(this.conStat);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 36);
            this.panel1.TabIndex = 18;
            // 
            // conStat
            // 
            this.conStat.AutoSize = true;
            this.conStat.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.conStat.Location = new System.Drawing.Point(127, 9);
            this.conStat.Name = "conStat";
            this.conStat.Size = new System.Drawing.Size(79, 19);
            this.conStat.TabIndex = 10;
            this.conStat.Text = "Searching...";
            // 
            // conStatLabel
            // 
            this.conStatLabel.AutoSize = true;
            this.conStatLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conStatLabel.Location = new System.Drawing.Point(4, 9);
            this.conStatLabel.Name = "conStatLabel";
            this.conStatLabel.Size = new System.Drawing.Size(124, 19);
            this.conStatLabel.TabIndex = 1;
            this.conStatLabel.Text = "Connection status:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.batPercentage);
            this.panel2.Location = new System.Drawing.Point(12, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 36);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.firmwareVer);
            this.panel3.Location = new System.Drawing.Point(12, 153);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 36);
            this.panel3.TabIndex = 19;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(384, 377);
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
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "QuestEyes PC App";
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
    }
}

