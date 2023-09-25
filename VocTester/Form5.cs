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
        private Dictionary<string,List<string>> wordsFromVOC = new Dictionary<string, List<string>>();
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
            getWordsFromDB();
            guessWord = chooseWord();

            this.lives = 3;
            labelGussedLetters.Text = "Guessed letters:";
            labelInCzech.Text = "In czech: " + String.Join(", ",wordsFromVOC[guessWord]);
            this.guessWordInList = Enumerable.Repeat("_", this.guessWord.Length).ToList();
            labelGuessWord.Text =String.Join(" ", this.guessWordInList);
            labelLives.Text = "Lives left: "+this.lives;
            wrongGuesses = new List<string>();

        }
        private void getWordsFromDB()
        {
            wordsFromVOC.Clear();
            MySqlCommand cmd = new MySqlCommand($@" 
                    SELECT englishword,czechword FROM ((junctiontable
                    INNER JOIN englishwords ON englishwords.EnglishID=junctiontable.englishid)
                    INNER JOIN czechwords ON czechwords.CzechID = junctiontable.czechid)
                    WHERE junctiontable.ParentVocabulary='{((ComboBoxItem)comboBoxVocChoose.SelectedItem).HiddenValue}'",conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (!(wordsFromVOC.ContainsKey(rdr["englishword"].ToString())))
                {
                    wordsFromVOC[rdr["englishword"].ToString()] = new List<string> {rdr["czechword"].ToString()};
                }
                else
                {
                    wordsFromVOC[rdr["englishword"].ToString()].Add(rdr["czechword"].ToString());
                }
            }
            rdr.Close();
        }
        private string chooseWord()
        {
            Random rng = new Random();
            return wordsFromVOC.ElementAt(rng.Next(0,wordsFromVOC.Count)).Key;
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
            MySqlCommand cmd = new MySqlCommand("SELECT Name,ID FROM vocabularies", this.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBoxVocChoose.Items.Add(new ComboBoxItem(rdr["Name"].ToString(),rdr["ID"].ToString()));
            }
            rdr.Close();
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lives == 0)
            {
                return;
            }
            if ((char.IsLetter(e.KeyChar)||e.KeyChar=='-') && !wrongGuesses.Contains(e.KeyChar.ToString().ToUpper()))
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
                            if (!this.guessWordInList.Contains("_"))
                            {
                                buttonNewWordFromSameVOC.Visible = true;
                                buttonChangeVOC.Visible = true;
                                MessageBox.Show("Congratulation!!!\nThe hidden word was "+ this.guessWord+".");
                                wordsFromVOC.Remove(guessWord);
                            }
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
                        MessageBox.Show("You failed, the word was " + this.guessWord + ".");
                    }
                    wrongGuesses.Add(letter.ToString().ToUpper());
                    labelGussedLetters.Text = "Guessed letters: "+String.Join(", ",wrongGuesses);
                    buttonNewWordFromSameVOC.Visible = true;
                    buttonChangeVOC.Visible = true;
                }
            }
        }

        private void buttonNewWordFromSameVOC_Click(object sender, EventArgs e)
        {
            if (wordsFromVOC.Count == 0)
            {
                MessageBox.Show("This is end of the vocabulary. You have to choose another.");
                panelChooseVoc.Visible = true;
                buttonNewWordFromSameVOC.Visible = false;
                buttonChangeVOC.Visible = false;
                return;
            }
            guessWord = chooseWord();

            this.lives = 3;
            labelGussedLetters.Text = "Guessed letters:";
            labelInCzech.Text = "In czech: " + String.Join(", ", wordsFromVOC[guessWord]);
            this.guessWordInList = Enumerable.Repeat("_", this.guessWord.Length).ToList();
            labelGuessWord.Text = String.Join(" ", this.guessWordInList);
            labelLives.Text = "Lives left: " + this.lives;
            wrongGuesses = new List<string>();
            buttonNewWordFromSameVOC.Visible = false;
            buttonChangeVOC.Visible = false;
        }

        private void buttonChangeVOC_Click(object sender, EventArgs e)
        {
            panelChooseVoc.Visible = true;
            buttonNewWordFromSameVOC.Visible = false;
            buttonChangeVOC.Visible = false;
        }
    }
    class ComboBoxItem
    {
        string displayValue;
        string hiddenValue;

        public ComboBoxItem(string d, string h)
        {
            displayValue = d;
            hiddenValue = h;
        }
        public string HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }
        public override string ToString()
        {
            return displayValue;
        }
    }
   
}
