
namespace QuestEyes_Server
{
    partial class Diagnostics
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rightX = new System.Windows.Forms.Label();
            this.rightY = new System.Windows.Forms.Label();
            this.leftX = new System.Windows.Forms.Label();
            this.leftY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.decodeErrorMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 580);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // rightX
            // 
            this.rightX.AutoSize = true;
            this.rightX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightX.ForeColor = System.Drawing.SystemColors.Control;
            this.rightX.Location = new System.Drawing.Point(406, 636);
            this.rightX.Name = "rightX";
            this.rightX.Size = new System.Drawing.Size(114, 13);
            this.rightX.TabIndex = 17;
            this.rightX.Text = "Right eye X: Unknown";
            // 
            // rightY
            // 
            this.rightY.AutoSize = true;
            this.rightY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightY.ForeColor = System.Drawing.SystemColors.Control;
            this.rightY.Location = new System.Drawing.Point(406, 623);
            this.rightY.Name = "rightY";
            this.rightY.Size = new System.Drawing.Size(114, 13);
            this.rightY.TabIndex = 16;
            this.rightY.Text = "Right eye Y: Unknown";
            // 
            // leftX
            // 
            this.leftX.AutoSize = true;
            this.leftX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftX.ForeColor = System.Drawing.SystemColors.Control;
            this.leftX.Location = new System.Drawing.Point(281, 636);
            this.leftX.Name = "leftX";
            this.leftX.Size = new System.Drawing.Size(107, 13);
            this.leftX.TabIndex = 15;
            this.leftX.Text = "Left eye X: Unknown";
            // 
            // leftY
            // 
            this.leftY.AutoSize = true;
            this.leftY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftY.ForeColor = System.Drawing.SystemColors.Control;
            this.leftY.Location = new System.Drawing.Point(281, 623);
            this.leftY.Name = "leftY";
            this.leftY.Size = new System.Drawing.Size(107, 13);
            this.leftY.TabIndex = 14;
            this.leftY.Text = "Left eye Y: Unknown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(246, 600);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Note: stream may have a slight delay while diagnostics are open";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decodeErrorMessage
            // 
            this.decodeErrorMessage.AutoSize = true;
            this.decodeErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.decodeErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decodeErrorMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.decodeErrorMessage.Location = new System.Drawing.Point(336, 278);
            this.decodeErrorMessage.Name = "decodeErrorMessage";
            this.decodeErrorMessage.Size = new System.Drawing.Size(128, 26);
            this.decodeErrorMessage.TabIndex = 19;
            this.decodeErrorMessage.Text = "Could not decode stream.\r\nIs the device connected?";
            this.decodeErrorMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Diagnostics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(65)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.decodeErrorMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightX);
            this.Controls.Add(this.rightY);
            this.Controls.Add(this.leftX);
            this.Controls.Add(this.leftY);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Diagnostics";
            this.Text = "QuestEyes Diagnostics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Diagnostics_FormClosing);
            this.Load += new System.EventHandler(this.Diagnostics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label rightX;
        private System.Windows.Forms.Label rightY;
        private System.Windows.Forms.Label leftX;
        private System.Windows.Forms.Label leftY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label decodeErrorMessage;
    }
}