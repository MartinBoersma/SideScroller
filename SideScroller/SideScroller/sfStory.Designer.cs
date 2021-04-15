namespace SideScroller
{
    partial class sfStory
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
            this.Level1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.activate_lvl1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Level1
            // 
            this.Level1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Level1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level1.Location = new System.Drawing.Point(12, 12);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(215, 46);
            this.Level1.TabIndex = 2;
            this.Level1.Text = "Level 1";
            this.Level1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkGreen;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(26, 106);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(626, 255);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "You have collected the enemy intel in level 1.\r\n\r\nPlayer health has been increase" +
    "d by 50%!";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // activate_lvl1
            // 
            this.activate_lvl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.activate_lvl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activate_lvl1.Location = new System.Drawing.Point(227, 394);
            this.activate_lvl1.Name = "activate_lvl1";
            this.activate_lvl1.Size = new System.Drawing.Size(215, 46);
            this.activate_lvl1.TabIndex = 2;
            this.activate_lvl1.Tag = "activate_lvl1";
            this.activate_lvl1.Text = "Activate";
            this.activate_lvl1.UseVisualStyleBackColor = false;
            this.activate_lvl1.Click += new System.EventHandler(this.activate_lvl1_Click);
            // 
            // sfStory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(664, 481);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.activate_lvl1);
            this.Controls.Add(this.Level1);
            this.Name = "sfStory";
            this.Text = "sfStory";
            this.Load += new System.EventHandler(this.sfStory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Level1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button activate_lvl1;
    }
}