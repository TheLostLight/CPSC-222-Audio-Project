namespace AudioTester
{
    partial class AuTester
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
            this.recordButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.byteButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(52, 55);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 23);
            this.recordButton.TabIndex = 0;
            this.recordButton.Text = "〇";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "setDirectory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // byteButton
            // 
            this.byteButton.Location = new System.Drawing.Point(106, 94);
            this.byteButton.Name = "byteButton";
            this.byteButton.Size = new System.Drawing.Size(75, 23);
            this.byteButton.TabIndex = 2;
            this.byteButton.Text = "Read Bytes";
            this.byteButton.UseVisualStyleBackColor = true;
            this.byteButton.Click += new System.EventHandler(this.byteButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(260, 55);
            this.progressBar1.Maximum = 65536;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(159, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // AuTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 129);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.byteButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.recordButton);
            this.Name = "AuTester";
            this.Text = "Test Audio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button byteButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

