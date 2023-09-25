using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace VocTester
{

    public partial class Form4 : Form
    {
        private Form mainForm = null;
        private MySqlConnection conn = null;
        public Form4(Form f, MySqlConnection conn)
        {
            mainForm = f;
            this.conn = conn;
            InitializeComponent();
            MySqlCommand cmd = new MySqlCommand("SELECT Name FROM vocabularies", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                checkedListBoxVoc.Items.Add(rdr["Name"]);
            }
            rdr.Close();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int numberOfVoc = checkedListBoxVoc.CheckedItems.Count;
            if (numberOfVoc>0 && (radioButtonEN.Checked || radioButtonCZ.Checked) && comboBoxNumberOfWords.SelectedIndex.ToString()!="-1") 
            {


                int numberOfWordsFromOneVoc = int.Parse(comboBoxNumberOfWords.SelectedItem.ToString());
                MySqlCommand cmd;
                MySqlDataReader rdr;
                richTextBoxTest.Text = "";
                for (int x = 0;x<numberOfVoc;x++)
                {
                    if (radioButtonEN.Checked)
                    {
                    
                        cmd = new MySqlCommand($@"SELECT englishword AS word FROM (junctiontable INNER JOIN
                                            englishwords ON junctiontable.englishid=englishwords.EnglishID)
                                            WHERE ParentVocabulary=(SELECT ID FROM vocabularies WHERE vocabularies.Name='{checkedListBoxVoc.CheckedItems[x]}')
                                            GROUP BY englishword ORDER BY RAND() LIMIT {numberOfWordsFromOneVoc}", conn);
                        
                    }
                    else
                    {
                        cmd = new MySqlCommand($@"SELECT englishword AS word FROM (junctiontable INNER JOIN
                                            czechwords ON junctiontable.czechid=czechwords.CzechID)
                                            WHERE ParentVocabulary=(SELECT ID FROM vocabularies WHERE vocabularies.Name='{checkedListBoxVoc.CheckedItems[x]}')
                                            GROUP BY czechwords ORDER BY RAND() LIMIT {numberOfWordsFromOneVoc}", conn);
                    }
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        richTextBoxTest.Text += $"{rdr["word"]}\n";
                    }
                    rdr.Close();
                }
            }
            else
            {
                MessageBox.Show("Fill all inputs");
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
