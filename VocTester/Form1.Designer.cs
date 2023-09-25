
namespace VocTester
{
    partial class Form1
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
            this.createVoc = new System.Windows.Forms.Button();
            this.dataGridViewAllVocabularies = new System.Windows.Forms.DataGridView();
            this.textBoxNewVoc = new System.Windows.Forms.TextBox();
            this.dataGridViewTranslations = new System.Windows.Forms.DataGridView();
            this.LabelNewVocabulary = new System.Windows.Forms.Label();
            this.panelTranslationPart = new System.Windows.Forms.Panel();
            this.buttonSwitchMode = new System.Windows.Forms.Button();
            this.buttonRemoveRow = new System.Windows.Forms.Button();
            this.SubmitTranslation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CzechTranslation = new System.Windows.Forms.TextBox();
            this.EnglishTranslation = new System.Windows.Forms.TextBox();
            this.buttonDeleteVoc = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllVocabularies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslations)).BeginInit();
            this.panelTranslationPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // createVoc
            // 
            this.createVoc.Location = new System.Drawing.Point(127, 345);
            this.createVoc.Name = "createVoc";
            this.createVoc.Size = new System.Drawing.Size(129, 36);
            this.createVoc.TabIndex = 2;
            this.createVoc.Text = "Create new vocabulary";
            this.createVoc.Click += new System.EventHandler(this.createVoc_Click);
            // 
            // dataGridViewAllVocabularies
            // 
            this.dataGridViewAllVocabularies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllVocabularies.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAllVocabularies.Location = new System.Drawing.Point(22, 55);
            this.dataGridViewAllVocabularies.Name = "dataGridViewAllVocabularies";
            this.dataGridViewAllVocabularies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllVocabularies.Size = new System.Drawing.Size(363, 239);
            this.dataGridViewAllVocabularies.TabIndex = 4;
            this.dataGridViewAllVocabularies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllVocabularies_CellClick);
            // 
            // textBoxNewVoc
            // 
            this.textBoxNewVoc.Location = new System.Drawing.Point(127, 319);
            this.textBoxNewVoc.Name = "textBoxNewVoc";
            this.textBoxNewVoc.Size = new System.Drawing.Size(129, 20);
            this.textBoxNewVoc.TabIndex = 1;
            // 
            // dataGridViewTranslations
            // 
            this.dataGridViewTranslations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTranslations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewTranslations.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTranslations.Name = "dataGridViewTranslations";
            this.dataGridViewTranslations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTranslations.Size = new System.Drawing.Size(501, 279);
            this.dataGridViewTranslations.TabIndex = 6;
            this.dataGridViewTranslations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTranslations_CellClick);
            // 
            // LabelNewVocabulary
            // 
            this.LabelNewVocabulary.AutoSize = true;
            this.LabelNewVocabulary.Location = new System.Drawing.Point(86, 322);
            this.LabelNewVocabulary.Name = "LabelNewVocabulary";
            this.LabelNewVocabulary.Size = new System.Drawing.Size(35, 13);
            this.LabelNewVocabulary.TabIndex = 7;
            this.LabelNewVocabulary.Text = "Name";
            // 
            // panelTranslationPart
            // 
            this.panelTranslationPart.Controls.Add(this.buttonSwitchMode);
            this.panelTranslationPart.Controls.Add(this.buttonRemoveRow);
            this.panelTranslationPart.Controls.Add(this.SubmitTranslation);
            this.panelTranslationPart.Controls.Add(this.label2);
            this.panelTranslationPart.Controls.Add(this.label1);
            this.panelTranslationPart.Controls.Add(this.CzechTranslation);
            this.panelTranslationPart.Controls.Add(this.EnglishTranslation);
            this.panelTranslationPart.Controls.Add(this.dataGridViewTranslations);
            this.panelTranslationPart.Location = new System.Drawing.Point(415, 12);
            this.panelTranslationPart.Name = "panelTranslationPart";
            this.panelTranslationPart.Size = new System.Drawing.Size(507, 426);
            this.panelTranslationPart.TabIndex = 9;
            this.panelTranslationPart.Visible = false;
            // 
            // buttonSwitchMode
            // 
            this.buttonSwitchMode.Location = new System.Drawing.Point(254, 308);
            this.buttonSwitchMode.Name = "buttonSwitchMode";
            this.buttonSwitchMode.Size = new System.Drawing.Size(75, 23);
            this.buttonSwitchMode.TabIndex = 13;
            this.buttonSwitchMode.Text = "Study mode";
            this.buttonSwitchMode.UseVisualStyleBackColor = true;
            this.buttonSwitchMode.Click += new System.EventHandler(this.buttonSwitchMode_Click);
            // 
            // buttonRemoveRow
            // 
            this.buttonRemoveRow.BackColor = System.Drawing.Color.Tomato;
            this.buttonRemoveRow.Location = new System.Drawing.Point(253, 340);
            this.buttonRemoveRow.Name = "buttonRemoveRow";
            this.buttonRemoveRow.Size = new System.Drawing.Size(76, 22);
            this.buttonRemoveRow.TabIndex = 13;
            this.buttonRemoveRow.Text = "Remove row";
            this.buttonRemoveRow.UseVisualStyleBackColor = false;
            this.buttonRemoveRow.Visible = false;
            this.buttonRemoveRow.Click += new System.EventHandler(this.buttonRemoveRow_Click);
            // 
            // SubmitTranslation
            // 
            this.SubmitTranslation.Location = new System.Drawing.Point(83, 380);
            this.SubmitTranslation.Name = "SubmitTranslation";
            this.SubmitTranslation.Size = new System.Drawing.Size(75, 23);
            this.SubmitTranslation.TabIndex = 12;
            this.SubmitTranslation.Text = "Submit";
            this.SubmitTranslation.UseVisualStyleBackColor = true;
            this.SubmitTranslation.Click += new System.EventHandler(this.SubmitTranslation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Czech";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "English";
            // 
            // CzechTranslation
            // 
            this.CzechTranslation.Location = new System.Drawing.Point(83, 342);
            this.CzechTranslation.Name = "CzechTranslation";
            this.CzechTranslation.Size = new System.Drawing.Size(129, 20);
            this.CzechTranslation.TabIndex = 11;
            // 
            // EnglishTranslation
            // 
            this.EnglishTranslation.Location = new System.Drawing.Point(83, 307);
            this.EnglishTranslation.Name = "EnglishTranslation";
            this.EnglishTranslation.Size = new System.Drawing.Size(129, 20);
            this.EnglishTranslation.TabIndex = 10;
            // 
            // buttonDeleteVoc
            // 
            this.buttonDeleteVoc.BackColor = System.Drawing.Color.Tomato;
            this.buttonDeleteVoc.Location = new System.Drawing.Point(294, 345);
            this.buttonDeleteVoc.Name = "buttonDeleteVoc";
            this.buttonDeleteVoc.Size = new System.Drawing.Size(76, 36);
            this.buttonDeleteVoc.TabIndex = 3;
            this.buttonDeleteVoc.Text = "Delete Vocabulary";
            this.buttonDeleteVoc.UseVisualStyleBackColor = false;
            this.buttonDeleteVoc.Visible = false;
            this.buttonDeleteVoc.Click += new System.EventHandler(this.buttonDeleteVoc_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 413);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(56, 25);
            this.buttonBack.TabIndex = 11;
            this.buttonBack.Text = "back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 451);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDeleteVoc);
            this.Controls.Add(this.panelTranslationPart);
            this.Controls.Add(this.LabelNewVocabulary);
            this.Controls.Add(this.textBoxNewVoc);
            this.Controls.Add(this.dataGridViewAllVocabularies);
            this.Controls.Add(this.createVoc);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HMDictionary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllVocabularies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslations)).EndInit();
            this.panelTranslationPart.ResumeLayout(false);
            this.panelTranslationPart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createVoc;
        private System.Windows.Forms.DataGridView dataGridViewAllVocabularies;
        private System.Windows.Forms.TextBox textBoxNewVoc;
        private System.Windows.Forms.DataGridView dataGridViewTranslations;
        private System.Windows.Forms.Label LabelNewVocabulary;
        private System.Windows.Forms.Panel panelTranslationPart;
        private System.Windows.Forms.Button SubmitTranslation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CzechTranslation;
        private System.Windows.Forms.TextBox EnglishTranslation;
        private System.Windows.Forms.Button buttonDeleteVoc;
        private System.Windows.Forms.Button buttonRemoveRow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSwitchMode;
    }
}

