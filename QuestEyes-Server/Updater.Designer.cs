
namespace QuestEyes_Server
{
    partial class Updater
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
            this.firmwareUpdateProgressBar = new System.Windows.Forms.ProgressBar();
            this.firmwareUpdateStageLabel = new System.Windows.Forms.Label();
            this.updateClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.softwareUpdateStageLabel = new System.Windows.Forms.Label();
            this.softwareUpdateProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // firmwareUpdateProgressBar
            // 
            this.firmwareUpdateProgressBar.Location = new System.Drawing.Point(14, 41);
            this.firmwareUpdateProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firmwareUpdateProgressBar.Name = "firmwareUpdateProgressBar";
            this.firmwareUpdateProgressBar.Size = new System.Drawing.Size(537, 27);
            this.firmwareUpdateProgressBar.TabIndex = 0;
            // 
            // firmwareUpdateStageLabel
            // 
            this.firmwareUpdateStageLabel.AutoSize = true;
            this.firmwareUpdateStageLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firmwareUpdateStageLabel.Location = new System.Drawing.Point(9, 15);
            this.firmwareUpdateStageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firmwareUpdateStageLabel.Name = "firmwareUpdateStageLabel";
            this.firmwareUpdateStageLabel.Size = new System.Drawing.Size(208, 19);
            this.firmwareUpdateStageLabel.TabIndex = 2;
            this.firmwareUpdateStageLabel.Text = "Checking for firmware updates...";
            // 
            // updateClose
            // 
            this.updateClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.updateClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.updateClose.Location = new System.Drawing.Point(454, 155);
            this.updateClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updateClose.Name = "updateClose";
            this.updateClose.Size = new System.Drawing.Size(97, 27);
            this.updateClose.TabIndex = 1;
            this.updateClose.Text = "Close";
            this.updateClose.UseVisualStyleBackColor = true;
            this.updateClose.Click += new System.EventHandler(this.updateClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(14, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "NEVER TURN OFF YOUR DEVICE WHILE UPDATING!";
            // 
            // softwareUpdateStageLabel
            // 
            this.softwareUpdateStageLabel.AutoSize = true;
            this.softwareUpdateStageLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.softwareUpdateStageLabel.Location = new System.Drawing.Point(9, 81);
            this.softwareUpdateStageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.softwareUpdateStageLabel.Name = "softwareUpdateStageLabel";
            this.softwareUpdateStageLabel.Size = new System.Drawing.Size(254, 19);
            this.softwareUpdateStageLabel.TabIndex = 5;
            this.softwareUpdateStageLabel.Text = "Waiting to check for software updates...";
            // 
            // softwareUpdateProgressBar
            // 
            this.softwareUpdateProgressBar.Location = new System.Drawing.Point(14, 107);
            this.softwareUpdateProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.softwareUpdateProgressBar.Name = "softwareUpdateProgressBar";
            this.softwareUpdateProgressBar.Size = new System.Drawing.Size(537, 27);
            this.softwareUpdateProgressBar.TabIndex = 4;
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(565, 197);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.softwareUpdateStageLabel);
            this.Controls.Add(this.softwareUpdateProgressBar);
            this.Controls.Add(this.updateClose);
            this.Controls.Add(this.firmwareUpdateStageLabel);
            this.Controls.Add(this.firmwareUpdateProgressBar);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuestEyes Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Updater_FormClosing);
            this.Load += new System.EventHandler(this.Updater_Load);
            this.Shown += new System.EventHandler(this.Updater_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar firmwareUpdateProgressBar;
        private System.Windows.Forms.Label firmwareUpdateStageLabel;
        private System.Windows.Forms.Button updateClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label softwareUpdateStageLabel;
        private System.Windows.Forms.ProgressBar softwareUpdateProgressBar;
    }
}