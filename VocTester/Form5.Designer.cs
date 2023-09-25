
namespace VocTester
{
    partial class Form5
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
            this.labelGuessWord = new System.Windows.Forms.Label();
            this.labelGussedLetters = new System.Windows.Forms.Label();
            this.labelLives = new System.Windows.Forms.Label();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.comboBoxVocChoose = new System.Windows.Forms.ComboBox();
            this.panelChooseVoc = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelInCzech = new System.Windows.Forms.Label();
            this.buttonNewWordFromSameVOC = new System.Windows.Forms.Button();
            this.buttonChangeVOC = new System.Windows.Forms.Button();
            this.panelChooseVoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGuessWord
            // 
            this.labelGuessWord.AutoSize = true;
            this.labelGuessWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.labelGuessWord.Location = new System.Drawing.Point(91, 178);
            this.labelGuessWord.Name = "labelGuessWord";
            this.labelGuessWord.Size = new System.Drawing.Size(276, 51);
            this.labelGuessWord.TabIndex = 0;
            this.labelGuessWord.Text = "incredulously";
            // 
            // labelGussedLetters
            // 
            this.labelGussedLetters.AutoSize = true;
            this.labelGussedLetters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelGussedLetters.Location = new System.Drawing.Point(79, 325);
            this.labelGussedLetters.Name = "labelGussedLetters";
            this.labelGussedLetters.Size = new System.Drawing.Size(133, 20);
            this.labelGussedLetters.TabIndex = 1;
            this.labelGussedLetters.Text = "Guessed letters:";
            // 
            // labelLives
            // 
            this.labelLives.AutoSize = true;
            this.labelLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F);
            this.labelLives.Location = new System.Drawing.Point(472, 93);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(155, 38);
            this.labelLives.TabIndex = 2;
            this.labelLives.Text = "Lives left:";
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(319, 251);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(94, 33);
            this.buttonChoose.TabIndex = 3;
            this.buttonChoose.Text = "Choose a word";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // comboBoxVocChoose
            // 
            this.comboBoxVocChoose.FormattingEnabled = true;
            this.comboBoxVocChoose.Location = new System.Drawing.Point(306, 193);
            this.comboBoxVocChoose.Name = "comboBoxVocChoose";
            this.comboBoxVocChoose.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVocChoose.TabIndex = 4;
            // 
            // panelChooseVoc
            // 
            this.panelChooseVoc.Controls.Add(this.label2);
            this.panelChooseVoc.Controls.Add(this.comboBoxVocChoose);
            this.panelChooseVoc.Controls.Add(this.buttonChoose);
            this.panelChooseVoc.Location = new System.Drawing.Point(37, 12);
            this.panelChooseVoc.Name = "panelChooseVoc";
            this.panelChooseVoc.Size = new System.Drawing.Size(731, 395);
            this.panelChooseVoc.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label2.Location = new System.Drawing.Point(196, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose vocabulary to choose from!";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 413);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(56, 25);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.Text = "back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelInCzech
            // 
            this.labelInCzech.AutoSize = true;
            this.labelInCzech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelInCzech.Location = new System.Drawing.Point(79, 354);
            this.labelInCzech.Name = "labelInCzech";
            this.labelInCzech.Size = new System.Drawing.Size(77, 20);
            this.labelInCzech.TabIndex = 13;
            this.labelInCzech.Text = "In czech:";
            // 
            // buttonNewWordFromSameVOC
            // 
            this.buttonNewWordFromSameVOC.Location = new System.Drawing.Point(479, 325);
            this.buttonNewWordFromSameVOC.Name = "buttonNewWordFromSameVOC";
            this.buttonNewWordFromSameVOC.Size = new System.Drawing.Size(100, 40);
            this.buttonNewWordFromSameVOC.TabIndex = 14;
            this.buttonNewWordFromSameVOC.Text = "New world from same vocabulary";
            this.buttonNewWordFromSameVOC.UseVisualStyleBackColor = true;
            this.buttonNewWordFromSameVOC.Visible = false;
            this.buttonNewWordFromSameVOC.Click += new System.EventHandler(this.buttonNewWordFromSameVOC_Click);
            // 
            // buttonChangeVOC
            // 
            this.buttonChangeVOC.Location = new System.Drawing.Point(598, 325);
            this.buttonChangeVOC.Name = "buttonChangeVOC";
            this.buttonChangeVOC.Size = new System.Drawing.Size(100, 40);
            this.buttonChangeVOC.TabIndex = 15;
            this.buttonChangeVOC.Text = "Change vocabulary";
            this.buttonChangeVOC.UseVisualStyleBackColor = true;
            this.buttonChangeVOC.Visible = false;
            this.buttonChangeVOC.Click += new System.EventHandler(this.buttonChangeVOC_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.panelChooseVoc);
            this.Controls.Add(this.labelLives);
            this.Controls.Add(this.labelGussedLetters);
            this.Controls.Add(this.labelGuessWord);
            this.Controls.Add(this.labelInCzech);
            this.Controls.Add(this.buttonNewWordFromSameVOC);
            this.Controls.Add(this.buttonChangeVOC);
            this.Name = "Form5";
            this.Text = "HMHangman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
            this.Load += new System.EventHandler(this.Form5_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form5_KeyPress);
            this.panelChooseVoc.ResumeLayout(false);
            this.panelChooseVoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGuessWord;
        private System.Windows.Forms.Label labelGussedLetters;
        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.ComboBox comboBoxVocChoose;
        private System.Windows.Forms.Panel panelChooseVoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelInCzech;
        private System.Windows.Forms.Button buttonNewWordFromSameVOC;
        private System.Windows.Forms.Button buttonChangeVOC;
    }
}