
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
            this.updateProgressBar = new System.Windows.Forms.ProgressBar();
            this.updateStageLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Location = new System.Drawing.Point(12, 40);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(460, 23);
            this.updateProgressBar.TabIndex = 0;
            // 
            // updateStageLabel
            // 
            this.updateStageLabel.AutoSize = true;
            this.updateStageLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateStageLabel.Location = new System.Drawing.Point(8, 14);
            this.updateStageLabel.Name = "updateStageLabel";
            this.updateStageLabel.Size = new System.Drawing.Size(208, 19);
            this.updateStageLabel.TabIndex = 2;
            this.updateStageLabel.Text = "Checking for firmware updates...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "NEVER TURN OFF YOUR DEVICE WHILE UPDATING!";
            // 
            // updateClose
            // 
            this.updateClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.updateClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.updateClose.Location = new System.Drawing.Point(389, 76);
            this.updateClose.Name = "updateClose";
            this.updateClose.Size = new System.Drawing.Size(83, 23);
            this.updateClose.TabIndex = 1;
            this.updateClose.Text = "Close";
            this.updateClose.UseVisualStyleBackColor = true;
            this.updateClose.Click += new System.EventHandler(this.updateClose_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(484, 111);
            this.ControlBox = false;
            this.Controls.Add(this.updateClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateStageLabel);
            this.Controls.Add(this.updateProgressBar);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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

        private System.Windows.Forms.ProgressBar updateProgressBar;
        private System.Windows.Forms.Label updateStageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateClose;
    }
}