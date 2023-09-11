
namespace VocTester
{
    partial class Form4
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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.numericUpDownNumberOfWords = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxTest = new System.Windows.Forms.RichTextBox();
            this.checkedListBoxVoc = new System.Windows.Forms.CheckedListBox();
            this.radioButtonEN = new System.Windows.Forms.RadioButton();
            this.radioButtonCZ = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfWords)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(165, 351);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(73, 28);
            this.buttonGenerate.TabIndex = 10;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // numericUpDownNumberOfWords
            // 
            this.numericUpDownNumberOfWords.Location = new System.Drawing.Point(151, 283);
            this.numericUpDownNumberOfWords.Name = "numericUpDownNumberOfWords";
            this.numericUpDownNumberOfWords.Size = new System.Drawing.Size(106, 20);
            this.numericUpDownNumberOfWords.TabIndex = 2;
            this.numericUpDownNumberOfWords.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(26, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "How many words do you want from every vocabulary?";
            // 
            // richTextBoxTest
            // 
            this.richTextBoxTest.Location = new System.Drawing.Point(455, 49);
            this.richTextBoxTest.Name = "richTextBoxTest";
            this.richTextBoxTest.Size = new System.Drawing.Size(305, 377);
            this.richTextBoxTest.TabIndex = 4;
            this.richTextBoxTest.Text = "";
            // 
            // checkedListBoxVoc
            // 
            this.checkedListBoxVoc.FormattingEnabled = true;
            this.checkedListBoxVoc.Location = new System.Drawing.Point(56, 130);
            this.checkedListBoxVoc.Name = "checkedListBoxVoc";
            this.checkedListBoxVoc.Size = new System.Drawing.Size(134, 94);
            this.checkedListBoxVoc.TabIndex = 1;
            // 
            // radioButtonEN
            // 
            this.radioButtonEN.AutoSize = true;
            this.radioButtonEN.Location = new System.Drawing.Point(6, 19);
            this.radioButtonEN.Name = "radioButtonEN";
            this.radioButtonEN.Size = new System.Drawing.Size(125, 17);
            this.radioButtonEN.TabIndex = 3;
            this.radioButtonEN.TabStop = true;
            this.radioButtonEN.Text = "from english to czech";
            this.radioButtonEN.UseVisualStyleBackColor = true;
            // 
            // radioButtonCZ
            // 
            this.radioButtonCZ.AutoSize = true;
            this.radioButtonCZ.Location = new System.Drawing.Point(6, 42);
            this.radioButtonCZ.Name = "radioButtonCZ";
            this.radioButtonCZ.Size = new System.Drawing.Size(125, 17);
            this.radioButtonCZ.TabIndex = 4;
            this.radioButtonCZ.TabStop = true;
            this.radioButtonCZ.Text = "from czech to english";
            this.radioButtonCZ.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonEN);
            this.groupBox1.Controls.Add(this.radioButtonCZ);
            this.groupBox1.Location = new System.Drawing.Point(239, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 77);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkedListBoxVoc);
            this.Controls.Add(this.richTextBoxTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownNumberOfWords);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "Form4";
            this.Text = "HMGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfWords)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxTest;
        private System.Windows.Forms.CheckedListBox checkedListBoxVoc;
        private System.Windows.Forms.RadioButton radioButtonEN;
        private System.Windows.Forms.RadioButton radioButtonCZ;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}