
namespace QuestEyes_Server
{
    partial class Updater_Changelog
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
            this.oscTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkFirmUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oscTitle
            // 
            this.oscTitle.AutoSize = true;
            this.oscTitle.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.oscTitle.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.oscTitle.Location = new System.Drawing.Point(11, 10);
            this.oscTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oscTitle.Name = "oscTitle";
            this.oscTitle.Size = new System.Drawing.Size(92, 22);
            this.oscTitle.TabIndex = 23;
            this.oscTitle.Text = "QuestEyes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Update changelog";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 61);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(381, 336);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // checkFirmUpdate
            // 
            this.checkFirmUpdate.Enabled = false;
            this.checkFirmUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkFirmUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkFirmUpdate.Location = new System.Drawing.Point(12, 411);
            this.checkFirmUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkFirmUpdate.Name = "checkFirmUpdate";
            this.checkFirmUpdate.Size = new System.Drawing.Size(177, 27);
            this.checkFirmUpdate.TabIndex = 26;
            this.checkFirmUpdate.Text = "Accept update";
            this.checkFirmUpdate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(216, 411);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 27);
            this.button1.TabIndex = 27;
            this.button1.Text = "Reject update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Updater_Changelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkFirmUpdate);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oscTitle);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater_Changelog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update changelog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oscTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button checkFirmUpdate;
        private System.Windows.Forms.Button button1;
    }
}