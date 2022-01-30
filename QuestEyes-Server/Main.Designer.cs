
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
            this.title = new System.Windows.Forms.Label();
            this.conStatLabel = new System.Windows.Forms.Label();
            this.batPercentage = new System.Windows.Forms.Label();
            this.firmwareVer = new System.Windows.Forms.Label();
            this.checkFirmUpdate = new System.Windows.Forms.Button();
            this.forceReconnect = new System.Windows.Forms.Button();
            this.conStat = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.diagnostics = new System.Windows.Forms.Button();
            this.resetDevice = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(144, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(96, 20);
            this.title.TabIndex = 0;
            this.title.Text = "QuestEyes";
            // 
            // conStatLabel
            // 
            this.conStatLabel.AutoSize = true;
            this.conStatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conStatLabel.Location = new System.Drawing.Point(12, 51);
            this.conStatLabel.Name = "conStatLabel";
            this.conStatLabel.Size = new System.Drawing.Size(95, 13);
            this.conStatLabel.TabIndex = 1;
            this.conStatLabel.Text = "Connection status:";
            // 
            // batPercentage
            // 
            this.batPercentage.AutoSize = true;
            this.batPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batPercentage.Location = new System.Drawing.Point(12, 80);
            this.batPercentage.Name = "batPercentage";
            this.batPercentage.Size = new System.Drawing.Size(149, 13);
            this.batPercentage.TabIndex = 2;
            this.batPercentage.Text = "Battery percentage: Unknown";
            // 
            // firmwareVer
            // 
            this.firmwareVer.AutoSize = true;
            this.firmwareVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firmwareVer.Location = new System.Drawing.Point(12, 93);
            this.firmwareVer.Name = "firmwareVer";
            this.firmwareVer.Size = new System.Drawing.Size(138, 13);
            this.firmwareVer.TabIndex = 3;
            this.firmwareVer.Text = "Firmware version: Unknown";
            // 
            // checkFirmUpdate
            // 
            this.checkFirmUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkFirmUpdate.Location = new System.Drawing.Point(12, 123);
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
            this.forceReconnect.Location = new System.Drawing.Point(195, 123);
            this.forceReconnect.Name = "forceReconnect";
            this.forceReconnect.Size = new System.Drawing.Size(177, 23);
            this.forceReconnect.TabIndex = 5;
            this.forceReconnect.Text = "Reconnect QuestEyes device";
            this.forceReconnect.UseVisualStyleBackColor = true;
            this.forceReconnect.Click += new System.EventHandler(this.forceReconnect_Click);
            // 
            // conStat
            // 
            this.conStat.AutoSize = true;
            this.conStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.conStat.Location = new System.Drawing.Point(104, 51);
            this.conStat.Name = "conStat";
            this.conStat.Size = new System.Drawing.Size(64, 13);
            this.conStat.TabIndex = 10;
            this.conStat.Text = "Searching...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.title);
            this.panel1.Location = new System.Drawing.Point(-3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 40);
            this.panel1.TabIndex = 11;
            // 
            // diagnostics
            // 
            this.diagnostics.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.diagnostics.Location = new System.Drawing.Point(195, 150);
            this.diagnostics.Name = "diagnostics";
            this.diagnostics.Size = new System.Drawing.Size(177, 23);
            this.diagnostics.TabIndex = 15;
            this.diagnostics.Text = "Diagnostics";
            this.diagnostics.UseVisualStyleBackColor = true;
            this.diagnostics.Click += new System.EventHandler(this.diagnostics_Click);
            // 
            // resetDevice
            // 
            this.resetDevice.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.resetDevice.Location = new System.Drawing.Point(12, 150);
            this.resetDevice.Name = "resetDevice";
            this.resetDevice.Size = new System.Drawing.Size(177, 23);
            this.resetDevice.TabIndex = 14;
            this.resetDevice.Text = "Factory reset device";
            this.resetDevice.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.diagnostics);
            this.Controls.Add(this.resetDevice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.conStat);
            this.Controls.Add(this.forceReconnect);
            this.Controls.Add(this.checkFirmUpdate);
            this.Controls.Add(this.firmwareVer);
            this.Controls.Add(this.batPercentage);
            this.Controls.Add(this.conStatLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "QuestEyes PC App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label conStatLabel;
        private System.Windows.Forms.Label batPercentage;
        private System.Windows.Forms.Label firmwareVer;
        private System.Windows.Forms.Button checkFirmUpdate;
        private System.Windows.Forms.Button forceReconnect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label conStat;
        private System.Windows.Forms.Button diagnostics;
        private System.Windows.Forms.Button resetDevice;
    }
}

