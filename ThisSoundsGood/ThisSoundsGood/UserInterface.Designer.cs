namespace ThisSoundsGood
{
    partial class UserInterface
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
            this.label1 = new System.Windows.Forms.Label();
            this.pitchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.ProgressBar();
            this.recButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note:";
            // 
            // pitchBox
            // 
            this.pitchBox.Location = new System.Drawing.Point(60, 43);
            this.pitchBox.Name = "pitchBox";
            this.pitchBox.ReadOnly = true;
            this.pitchBox.Size = new System.Drawing.Size(38, 20);
            this.pitchBox.TabIndex = 1;
            this.pitchBox.Text = "...";
            this.pitchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Volume:";
            // 
            // volumeBar
            // 
            this.volumeBar.Location = new System.Drawing.Point(172, 40);
            this.volumeBar.Maximum = 32768;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(100, 23);
            this.volumeBar.TabIndex = 3;
            // 
            // recButton
            // 
            this.recButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recButton.ForeColor = System.Drawing.Color.Red;
            this.recButton.Location = new System.Drawing.Point(117, 89);
            this.recButton.Name = "recButton";
            this.recButton.Size = new System.Drawing.Size(40, 43);
            this.recButton.TabIndex = 4;
            this.recButton.Text = "●";
            this.recButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.recButton.UseMnemonic = false;
            this.recButton.UseVisualStyleBackColor = true;
            this.recButton.Click += new System.EventHandler(this.recButton_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.recButton);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pitchBox);
            this.Controls.Add(this.label1);
            this.Name = "UserInterface";
            this.Text = "ThisSoundsGood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pitchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar volumeBar;
        private System.Windows.Forms.Button recButton;
    }
}

