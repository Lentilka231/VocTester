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
    public partial class Form1 : Form
    {
        private Form mainform = null;
        private MySqlConnection conn;
        public Form1(Form f3,MySqlConnection conn)
        {
            mainform = f3;
            InitializeComponent();
            this.conn = conn;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            updateVocTable();
        }
        private void CreateVocabulary()
        {
            try
            {
                if (textBoxNewVoc.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand($@"
                        INSERT INTO vocabularies (Name,created) VALUES 
                        ('{textBoxNewVoc.Text}','{DateTime.Now.ToString("yyyy-MM-dd")}')", conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("You didn't give a name of a vocabulary");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            updateVocTable();
        }
        private void updateVocTable()
        {
            List<Vocabulary> listOfCreatedVocabularies = new List<Vocabulary>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vocabularies", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listOfCreatedVocabularies.Add(new Vocabulary
                    {
                        VocabularyId = rdr["ID"].ToString(),
                        Name = rdr["Name"].ToString(),
                        DateOfCreation = rdr["created"].ToString()
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dataGridViewAllVocabularies.DataSource = listOfCreatedVocabularies; 
        }
        private void updateTranslationTable()
        {
            List<Translation> listOfTranslations = new List<Translation>();
            try
            {
                MySqlCommand cmd = new MySqlCommand($@"
                    SELECT englishwords.englishword, czechwords.czechword 
                    FROM ((junctiontable 
                    INNER JOIN englishwords ON junctiontable.englishid=englishwords.EnglishID)
                    INNER JOIN czechwords ON junctiontable.czechid=czechwords.CzechID) 
                    WHERE ParentVocabulary={dataGridViewAllVocabularies.SelectedRows[0].Cells[0].Value}", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counter = 1;
                while (rdr.Read())
                {
                    listOfTranslations.Add(new Translation()
                    {
                        ID = counter,
                        English = rdr["englishword"].ToString(),
                        Czech = rdr["czechword"].ToString()
                    });
                    counter++;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured:" + ex.Message + " - " + ex.Source);
            }
            dataGridViewTranslations.DataSource = listOfTranslations;
        }
        public void deleteVocabularyFromDB(string vocID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM `vocabularies` WHERE ID={vocID}", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            updateVocTable();
        }
        private void createVoc_Click(object sender, EventArgs e)
        {
            CreateVocabulary();
            textBoxNewVoc.Text = "";
        }
        private void dataGridViewAllVocabularies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDeleteVoc.Visible = true;
            panelTranslationPart.Visible = true;
            updateTranslationTable();   
        }
        private void buttonDeleteVoc_Click(object sender, EventArgs e)
        {
            var voc = dataGridViewAllVocabularies.SelectedRows[0].DataBoundItem as Vocabulary;
            Form2 f2 = new Form2(this,voc.VocabularyId,voc.Name);
            f2.Show();
            buttonDeleteVoc.Visible = false;
        } 
        private void SubmitTranslation_Click(object sender, EventArgs e)
        {
            if (CzechTranslation.Text != "" && EnglishTranslation.Text != "")
            {
                string vocID = dataGridViewAllVocabularies.SelectedRows[0].Cells[0].Value.ToString();
                string newCZ = CzechTranslation.Text, newEN = EnglishTranslation.Text;
                string enID = "", czID = "";

                try
                {
                    MySqlCommand cmd = new MySqlCommand($"SELECT EnglishID FROM englishwords WHERE englishword='{newEN}'",conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        enID=rdr["EnglishID"].ToString();
                    }
                    rdr.Close();
                    cmd = new MySqlCommand($"SELECT CzechID FROM czechwords WHERE czechword='{newCZ}'", conn);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        czID = rdr["CzechID"].ToString();
                    }
                    rdr.Close();
                    if (enID == "")
                    {
                        cmd = new MySqlCommand($@"INSERT INTO `englishwords` (englishword,ParentVocabulary) VALUES ('{newEN}','{vocID}');",conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand($"SELECT EnglishID FROM englishwords WHERE englishword='{newEN}'", conn);
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            enID = rdr["EnglishID"].ToString();
                        }
                        rdr.Close();
                    }
                    if (czID == "")
                    {
                        cmd = new MySqlCommand($@"INSERT INTO `czechwords` (czechword) VALUES ('{newCZ}')",conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand($"SELECT CzechID FROM czechwords WHERE czechword = '{newCZ}'", conn);
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            czID = rdr["CzechID"].ToString();
                        }
                        rdr.Close();
                    }

                    cmd = new MySqlCommand($"INSERT INTO `junctiontable` VALUES ('{enID}','{czID}')", conn);
                    cmd.ExecuteNonQuery();
                    CzechTranslation.Text = "";
                    EnglishTranslation.Text = "";
                    updateTranslationTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You have to fill both cells.");
            }
        }
        private void buttonRemoveRow_Click(object sender, EventArgs e)
        {
            var removingRow = dataGridViewTranslations.SelectedRows[0];
            
            MySqlCommand cmd = new MySqlCommand($@"
                DELETE junctiontable FROM ((junctiontable 
                INNER JOIN englishwords ON junctiontable.englishid=englishwords.EnglishID)
                INNER JOIN czechwords ON junctiontable.czechid=czechwords.CzechID)
                WHERE englishwords.englishword='{removingRow.Cells[1].Value}' 
                AND czechwords.czechword='{removingRow.Cells[2].Value}';
                ", conn);
            cmd.ExecuteNonQuery();

            cmd = new MySqlCommand($@"SELECT junctiontable.englishid FROM (junctiontable 
                INNER JOIN englishwords ON junctiontable.englishid=englishwords.EnglishID) 
                WHERE englishwords.englishword='{removingRow.Cells[1].Value}'", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (!rdr.HasRows)
            {
                rdr.Close();

                cmd = new MySqlCommand($"DELETE FROM `englishwords` WHERE englishword ='{removingRow.Cells[1].Value}';", conn);
                cmd.ExecuteNonQuery();
            }
            rdr.Close();

            cmd = new MySqlCommand($@"SELECT junctiontable.czechid FROM (junctiontable 
                    INNER JOIN czechwords ON junctiontable.czechid=czechwords.CzechID) 
                    WHERE czechwords.czechword='{removingRow.Cells[2].Value}'", conn);
            rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                rdr.Close();
                cmd = new MySqlCommand($"DELETE FROM `czechwords` WHERE czechword ='{removingRow.Cells[2].Value}';", conn);
                cmd.ExecuteNonQuery();
            }
            rdr.Close();


            updateTranslationTable();

            buttonRemoveRow.Visible = false;
        }

        private void dataGridViewTranslations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonRemoveRow.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }
    }
    public class Vocabulary
    {
        public string VocabularyId { get; set; }
        public string Name { get; set; }
        public string DateOfCreation { get; set; }
    }
    public class Translation
    {
        public int ID { get; set; }
        public string English { get; set; }
        public string Czech { get; set; }
    }
}
