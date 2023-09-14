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
            int numberOfWordsFromOneVoc = int.Parse(comboBoxNumberOfWords.SelectedItem.ToString());
            int numberOfVoc = checkedListBoxVoc.CheckedItems.Count;
            MySqlCommand cmd;
            MySqlDataReader rdr;
            richTextBoxTest.Text = "";
            for (int x = 0;x<numberOfVoc;x++)
            {
                if (radioButtonEN.Checked)
                {
                    cmd = new MySqlCommand($"SELECT englishword AS word FROM englishwords ORDER BY RAND() LIMIT {numberOfWordsFromOneVoc}",conn);
                }
                else
                {
                    cmd = new MySqlCommand($"SELECT czechword AS word FROM czechwords ORDER BY RAND() LIMIT {numberOfWordsFromOneVoc}", conn);
                }
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    richTextBoxTest.Text += $"{rdr["word"]}\n";
                }
                rdr.Close();
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
