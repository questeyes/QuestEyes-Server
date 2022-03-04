
namespace QuestEyes_Server
{
    partial class OSCControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSCControlPanel));
            this.oscDescription = new System.Windows.Forms.Label();
            this.vrcCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vrcPort = new System.Windows.Forms.Label();
            this.vrcLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.customPortBox = new System.Windows.Forms.TextBox();
            this.customPortLabel = new System.Windows.Forms.Label();
            this.customCheckBox = new System.Windows.Forms.CheckBox();
            this.oscTitle = new System.Windows.Forms.Label();
            this.oscDescriptionTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // oscDescription
            // 
            this.oscDescription.AutoSize = true;
            this.oscDescription.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oscDescription.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.oscDescription.Location = new System.Drawing.Point(27, 78);
            this.oscDescription.Name = "oscDescription";
            this.oscDescription.Size = new System.Drawing.Size(331, 176);
            this.oscDescription.TabIndex = 2;
            this.oscDescription.Text = resources.GetString("oscDescription.Text");
            this.oscDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // vrcCheckBox
            // 
            this.vrcCheckBox.AutoSize = true;
            this.vrcCheckBox.Location = new System.Drawing.Point(251, 11);
            this.vrcCheckBox.Name = "vrcCheckBox";
            this.vrcCheckBox.Size = new System.Drawing.Size(15, 14);
            this.vrcCheckBox.TabIndex = 3;
            this.vrcCheckBox.UseVisualStyleBackColor = true;
            this.vrcCheckBox.CheckedChanged += new System.EventHandler(this.vrcCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.vrcPort);
            this.panel1.Controls.Add(this.vrcLabel);
            this.panel1.Controls.Add(this.vrcCheckBox);
            this.panel1.Location = new System.Drawing.Point(52, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 36);
            this.panel1.TabIndex = 19;
            // 
            // vrcPort
            // 
            this.vrcPort.AutoSize = true;
            this.vrcPort.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrcPort.Location = new System.Drawing.Point(205, 11);
            this.vrcPort.Name = "vrcPort";
            this.vrcPort.Size = new System.Drawing.Size(32, 16);
            this.vrcPort.TabIndex = 21;
            this.vrcPort.Text = "9000";
            // 
            // vrcLabel
            // 
            this.vrcLabel.AutoSize = true;
            this.vrcLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrcLabel.Location = new System.Drawing.Point(9, 8);
            this.vrcLabel.Name = "vrcLabel";
            this.vrcLabel.Size = new System.Drawing.Size(57, 19);
            this.vrcLabel.TabIndex = 20;
            this.vrcLabel.Text = "VRChat";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.customPortBox);
            this.panel2.Controls.Add(this.customPortLabel);
            this.panel2.Controls.Add(this.customCheckBox);
            this.panel2.Location = new System.Drawing.Point(52, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 36);
            this.panel2.TabIndex = 21;
            // 
            // customPortBox
            // 
            this.customPortBox.Location = new System.Drawing.Point(177, 8);
            this.customPortBox.Name = "customPortBox";
            this.customPortBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.customPortBox.Size = new System.Drawing.Size(60, 20);
            this.customPortBox.TabIndex = 21;
            this.customPortBox.TextChanged += new System.EventHandler(this.customPortBox_TextChanged);
            this.customPortBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customPortBox_KeyPress);
            // 
            // customPortLabel
            // 
            this.customPortLabel.AutoSize = true;
            this.customPortLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customPortLabel.Location = new System.Drawing.Point(9, 8);
            this.customPortLabel.Name = "customPortLabel";
            this.customPortLabel.Size = new System.Drawing.Size(92, 19);
            this.customPortLabel.TabIndex = 20;
            this.customPortLabel.Text = "Custom port";
            // 
            // customCheckBox
            // 
            this.customCheckBox.AutoSize = true;
            this.customCheckBox.Location = new System.Drawing.Point(251, 11);
            this.customCheckBox.Name = "customCheckBox";
            this.customCheckBox.Size = new System.Drawing.Size(15, 14);
            this.customCheckBox.TabIndex = 3;
            this.customCheckBox.UseVisualStyleBackColor = true;
            this.customCheckBox.CheckedChanged += new System.EventHandler(this.customCheckBox_CheckedChanged);
            // 
            // oscTitle
            // 
            this.oscTitle.AutoSize = true;
            this.oscTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oscTitle.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.oscTitle.Location = new System.Drawing.Point(124, 19);
            this.oscTitle.Name = "oscTitle";
            this.oscTitle.Size = new System.Drawing.Size(137, 19);
            this.oscTitle.TabIndex = 22;
            this.oscTitle.Text = "OSC output control";
            // 
            // oscDescriptionTitle
            // 
            this.oscDescriptionTitle.AutoSize = true;
            this.oscDescriptionTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oscDescriptionTitle.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.oscDescriptionTitle.Location = new System.Drawing.Point(147, 56);
            this.oscDescriptionTitle.Name = "oscDescriptionTitle";
            this.oscDescriptionTitle.Size = new System.Drawing.Size(90, 17);
            this.oscDescriptionTitle.TabIndex = 23;
            this.oscDescriptionTitle.Text = "What is OSC?";
            // 
            // OSCControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(384, 391);
            this.Controls.Add(this.oscDescriptionTitle);
            this.Controls.Add(this.oscTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.oscDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OSCControl";
            this.Text = "QuestEyes OSC Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OSCControl_FormClosing);
            this.Load += new System.EventHandler(this.OSCControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oscDescription;
        private System.Windows.Forms.CheckBox vrcCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label vrcLabel;
        private System.Windows.Forms.Label vrcPort;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox customPortBox;
        private System.Windows.Forms.Label customPortLabel;
        private System.Windows.Forms.CheckBox customCheckBox;
        private System.Windows.Forms.Label oscTitle;
        private System.Windows.Forms.Label oscDescriptionTitle;
    }
}