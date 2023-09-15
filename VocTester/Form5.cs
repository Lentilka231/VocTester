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
    public partial class Form5 : Form
    {
        private MySqlConnection conn;
        private Form mainForm;
        private int lives;
        private string guessWord;
        private List<string> guessWordInList;
        private List<string> wrongGuesses;
        public Form5(Form f, MySqlConnection conn)
        {
            this.KeyPreview = true;
            this.conn= conn;
            this.mainForm = f;
            
            InitializeComponent();
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            panelChooseVoc.Visible = false;
            MySqlCommand cmd = new MySqlCommand($@"SELECT englishid FROM junctiontable ORDER BY RAND() LIMIT 1",conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                cmd = new MySqlCommand($@"
                    SELECT englishword,czechword FROM ((junctiontable
                    INNER JOIN englishwords ON englishwords.EnglishID=junctiontable.englishid)
                    INNER JOIN czechwords ON czechwords.CzechID = junctiontable.czechid)
                    WHERE junctiontable.englishid={rdr["englishid"]}",conn) ;
            }
            rdr.Close();
            rdr = cmd.ExecuteReader();
            List<string> czechVersions = new List<string>();
            while (rdr.Read())
            {
                this.guessWord = rdr["englishword"].ToString();
                czechVersions.Add(rdr["czechword"].ToString());
            }
            rdr.Close();
            this.lives = 3;
            labelInCzech.Text ="In czech: "+ String.Join(", ",czechVersions);
            this.guessWordInList = Enumerable.Repeat("_", this.guessWord.Length).ToList();
            labelGuessWord.Text =String.Join(" ", this.guessWordInList);
            labelLives.Text = "Lives left: "+this.lives;
            wrongGuesses = new List<string>();
        }
        
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT Name FROM vocabularies", this.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBoxVocChoose.Items.Add(rdr["Name"].ToString());
            }
            rdr.Close();
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lives == 0)
            {
                return;
            }
            if (char.IsLetter(e.KeyChar) && !wrongGuesses.Contains(e.KeyChar.ToString().ToUpper()))
            {
                char letter = e.KeyChar;
                if (guessWord.ToLower().Contains(letter))
                {
                    for(int i = 0; i < this.guessWord.Length;i++)
                    {
                        if(this.guessWord[i]== letter)
                        {
                            guessWordInList[i] = letter.ToString();
                            labelGuessWord.Text = String.Join(" ", this.guessWordInList);
                            break;
                        }
                    }
                }
                else
                {
                    this.lives--;
                    labelLives.Text = "Lives left: " + this.lives;
                    if (this.lives==0)
                    {
                        labelGuessWord.Text = String.Join(" ", this.guessWord.ToList());
                    }
                    wrongGuesses.Add(letter.ToString().ToUpper());
                    labelGussedLetters.Text = "Guessed letters: "+String.Join(", ",wrongGuesses);
                }
            }
        }

    }
}
