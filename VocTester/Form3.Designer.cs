
namespace VocTester
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.buttonGenerateTest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonDictionary = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerateTest
            // 
            this.buttonGenerateTest.Location = new System.Drawing.Point(51, 103);
            this.buttonGenerateTest.Name = "buttonGenerateTest";
            this.buttonGenerateTest.Size = new System.Drawing.Size(110, 37);
            this.buttonGenerateTest.TabIndex = 1;
            this.buttonGenerateTest.Text = "Generate test";
            this.buttonGenerateTest.UseVisualStyleBackColor = true;
            this.buttonGenerateTest.Click += new System.EventHandler(this.buttonGenerateTest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(51, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hangman";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonDictionary
            // 
            this.buttonDictionary.Location = new System.Drawing.Point(51, 246);
            this.buttonDictionary.Name = "buttonDictionary";
            this.buttonDictionary.Size = new System.Drawing.Size(110, 37);
            this.buttonDictionary.TabIndex = 3;
            this.buttonDictionary.Text = "Dictionary";
            this.buttonDictionary.UseVisualStyleBackColor = true;
            this.buttonDictionary.Click += new System.EventHandler(this.buttonDictionary_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.ImageLocation = "\"Logo.png\"";
            this.pictureBoxLogo.Location = new System.Drawing.Point(280, 44);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(477, 303);
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonGenerateTest);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonDictionary);
            this.Name = "Form3";
            this.Text = "Homemade Dictionary";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateTest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonDictionary;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}