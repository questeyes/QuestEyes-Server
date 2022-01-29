
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // rightX
            // 
            this.rightX.AutoSize = true;
            this.rightX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightX.Location = new System.Drawing.Point(406, 630);
            this.rightX.Name = "rightX";
            this.rightX.Size = new System.Drawing.Size(114, 13);
            this.rightX.TabIndex = 17;
            this.rightX.Text = "Right eye X: Unknown";
            // 
            // rightY
            // 
            this.rightY.AutoSize = true;
            this.rightY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightY.Location = new System.Drawing.Point(406, 617);
            this.rightY.Name = "rightY";
            this.rightY.Size = new System.Drawing.Size(114, 13);
            this.rightY.TabIndex = 16;
            this.rightY.Text = "Right eye Y: Unknown";
            // 
            // leftX
            // 
            this.leftX.AutoSize = true;
            this.leftX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftX.Location = new System.Drawing.Point(281, 630);
            this.leftX.Name = "leftX";
            this.leftX.Size = new System.Drawing.Size(107, 13);
            this.leftX.TabIndex = 15;
            this.leftX.Text = "Left eye X: Unknown";
            // 
            // leftY
            // 
            this.leftY.AutoSize = true;
            this.leftY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftY.Location = new System.Drawing.Point(281, 617);
            this.leftY.Name = "leftY";
            this.leftY.Size = new System.Drawing.Size(107, 13);
            this.leftY.TabIndex = 14;
            this.leftY.Text = "Left eye Y: Unknown";
            // 
            // Diagnostics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.rightX);
            this.Controls.Add(this.rightY);
            this.Controls.Add(this.leftX);
            this.Controls.Add(this.leftY);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Diagnostics";
            this.Text = "Diagnostics";
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
    }
}