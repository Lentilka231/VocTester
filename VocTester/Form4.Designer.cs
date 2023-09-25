
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxTest = new System.Windows.Forms.RichTextBox();
            this.checkedListBoxVoc = new System.Windows.Forms.CheckedListBox();
            this.radioButtonEN = new System.Windows.Forms.RadioButton();
            this.radioButtonCZ = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxNumberOfWords = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(52, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose as many vocabularies as you want.";
            // 
            // richTextBoxTest
            // 
            this.richTextBoxTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.richTextBoxTest.Location = new System.Drawing.Point(455, 49);
            this.richTextBoxTest.Name = "richTextBoxTest";
            this.richTextBoxTest.Size = new System.Drawing.Size(305, 377);
            this.richTextBoxTest.TabIndex = 70;
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
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // comboBoxNumberOfWords
            // 
            this.comboBoxNumberOfWords.FormattingEnabled = true;
            this.comboBoxNumberOfWords.Items.AddRange(new object[] {
            "6",
            "8",
            "12",
            "16",
            "20",
            "24"});
            this.comboBoxNumberOfWords.Location = new System.Drawing.Point(151, 287);
            this.comboBoxNumberOfWords.Name = "comboBoxNumberOfWords";
            this.comboBoxNumberOfWords.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNumberOfWords.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Number of words per vocabulary";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 413);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(56, 25);
            this.buttonBack.TabIndex = 72;
            this.buttonBack.Text = "back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxNumberOfWords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkedListBoxVoc);
            this.Controls.Add(this.richTextBoxTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "Form4";
            this.Text = "HMGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxTest;
        private System.Windows.Forms.CheckedListBox checkedListBoxVoc;
        private System.Windows.Forms.RadioButton radioButtonEN;
        private System.Windows.Forms.RadioButton radioButtonCZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxNumberOfWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBack;
    }
}