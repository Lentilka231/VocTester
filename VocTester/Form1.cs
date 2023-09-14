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
using System.IO;
using System.Text.Json;
namespace VocTester
{
    public partial class Form1 : Form
    {
        private Form mainform = null;
        private MySqlConnection conn;
        private bool editMode = false;
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

                if (editMode)
                {
                    List<Translation> editListOfTranslations = new List<Translation>();

                    while (rdr.Read())
                    {
                        editListOfTranslations.Add(new Translation()
                        {
                            ID = counter,
                            English = rdr["englishword"].ToString(),
                            Czech = rdr["czechword"].ToString()
                        });
                        counter++;
                    }
                    dataGridViewTranslations.DataSource = editListOfTranslations;
                }
                else
                {
                    Dictionary<string, Translation> studyListOfTranslations = new Dictionary<string, Translation>();
                    while (rdr.Read())
                    {
                        var match = studyListOfTranslations.ContainsKey(rdr["englishword"].ToString());
                        if (match)
                        {
                            studyListOfTranslations[rdr["englishword"].ToString()].Czech +=", "+ rdr["czechword"].ToString();
                        }
                        else
                        {
                            studyListOfTranslations.Add(
                            rdr["englishword"].ToString(),
                            new Translation()
                                {
                                    ID = counter,
                                    English = rdr["englishword"].ToString(),
                                    Czech = rdr["czechword"].ToString()
                                }
                            );
                            counter++;
                        }
                    }

                    dataGridViewTranslations.DataSource = studyListOfTranslations.Values.ToList();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured:" + ex.Message + " - " + ex.Source);
            }
        }
        public void deleteVocabularyFromDB(string vocID)
        {
            try
            {
                Tuple<MySqlConnection,bool> newConnection = openConnection();
                if (newConnection.Item2)
                {
                    MySqlCommand cmd = new MySqlCommand($"SELECT englishid,czechid FROM junctiontable WHERE ParentVocabulary={vocID}", newConnection.Item1);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        deleteRowsFromDB(rdr["englishid"].ToString(), rdr["czechid"].ToString());
                    }
                    rdr.Close();
                    cmd = new MySqlCommand($"DELETE FROM `vocabularies` WHERE ID={vocID}", conn);
                    cmd.ExecuteNonQuery();
                    newConnection.Item1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            updateVocTable();
            updateTranslationTable();
        }
        private Tuple<MySqlConnection,bool> openConnection()
        {
            try
            {
                string connStr;
                using (StreamReader r = new StreamReader("DBInfo.json"))
                {
                    string json = r.ReadToEnd();
                    JsonDocument doc = JsonDocument.Parse(json);
                    JsonElement root = doc.RootElement;
                    connStr = $@"server={root.GetProperty("server")};
                                 user={root.GetProperty("user")};
                                 database={root.GetProperty("database")};
                                 port={root.GetProperty("port")};
                                 password={root.GetProperty("password")}";
                }
                MySqlConnection conn2 = new MySqlConnection(connStr);
                conn2.Open();
                return Tuple.Create(conn2,true);
            }
            catch
            {
                MessageBox.Show("Unable to join the Database!");
            }
            return Tuple.Create(new MySqlConnection(), false);
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
                    MySqlCommand cmd = new MySqlCommand($"SELECT EnglishID FROM englishwords WHERE englishword='{newEN}'", conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        enID = rdr["EnglishID"].ToString();
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
                        cmd = new MySqlCommand($@"INSERT INTO `englishwords` (englishword) VALUES ('{newEN}');", conn);
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
                        cmd = new MySqlCommand($@"INSERT INTO `czechwords` (czechword) VALUES ('{newCZ}')", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand($"SELECT CzechID FROM czechwords WHERE czechword = '{newCZ}'", conn);
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            czID = rdr["CzechID"].ToString();
                        }
                        rdr.Close();
                    }

                    cmd = new MySqlCommand($"SELECT * FROM `junctiontable` WHERE englishid='{enID}' AND czechid='{czID}'",conn);
                    rdr = cmd.ExecuteReader();

                    string noRecordInDB ="";
                    while (rdr.Read())
                    {
                        noRecordInDB = rdr["ParentVocabulary"].ToString();
                    }
                    rdr.Close();
                    if (noRecordInDB == "")
                    {
                        cmd = new MySqlCommand($"INSERT INTO `junctiontable` VALUES ('{enID}','{czID}','{vocID}')", conn);
                        cmd.ExecuteNonQuery();
                        CzechTranslation.Text = "";
                        EnglishTranslation.Text = "";
                        updateTranslationTable();
                    }
                    else
                    {
                        MessageBox.Show("This translation is already notted.");
                    }
                    
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
            buttonRemoveRow.Visible = false;
            try
            {
                MySqlCommand cmd = new MySqlCommand($@"
                    SELECT englishwords.EnglishID,czechwords.CzechID FROM ((junctiontable 
                    INNER JOIN englishwords ON junctiontable.englishid=englishwords.EnglishID)
                    INNER JOIN czechwords ON  junctiontable.czechid=czechwords.CzechID)
                    WHERE englishwords.englishword='{removingRow.Cells[1].Value.ToString()}' 
                    AND czechwords.czechword = '{removingRow.Cells[2].Value.ToString()}'", conn);

                MySqlDataReader rdr = cmd.ExecuteReader();
                string enID="", czID="";
                while (rdr.Read())
                {
                    enID = rdr["EnglishID"].ToString();
                    czID = rdr["CzechID"].ToString();
                }
                rdr.Close();
                deleteRowsFromDB(enID, czID);
                updateTranslationTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteRowsFromDB(string enID,string czID)
        {
            MySqlCommand cmd = new MySqlCommand($@"
                DELETE junctiontable FROM ((junctiontable 
                INNER JOIN englishwords ON junctiontable.englishid=englishwords.EnglishID)
                INNER JOIN czechwords ON junctiontable.czechid=czechwords.CzechID)
                WHERE englishwords.EnglishID='{enID}' 
                AND czechwords.CzechID='{czID}';
                ", conn);
            cmd.ExecuteNonQuery();

            cmd = new MySqlCommand($@"SELECT junctiontable.englishid FROM (junctiontable 
                INNER JOIN englishwords ON junctiontable.englishid=englishwords.EnglishID) 
                WHERE englishwords.EnglishID='{enID}'", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (!rdr.HasRows)
            {
                rdr.Close();
                cmd = new MySqlCommand($"DELETE FROM `englishwords` WHERE EnglishID ='{enID}';", conn);
                cmd.ExecuteNonQuery();
            }
            rdr.Close();

            cmd = new MySqlCommand($@"SELECT junctiontable.czechid FROM (junctiontable 
                    INNER JOIN czechwords ON junctiontable.czechid=czechwords.CzechID) 
                    WHERE czechwords.CzechID='{czID}'", conn);
            rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                rdr.Close();
                cmd = new MySqlCommand($"DELETE FROM `czechwords` WHERE CzechID ='{czID}';", conn);
                cmd.ExecuteNonQuery();
            }
            rdr.Close();
        }
        private void dataGridViewTranslations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonRemoveRow.Visible = (editMode)?true:false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainform.Show();
        }
        private void buttonSwitchMode_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                buttonSwitchMode.Text ="Study mode";
                buttonRemoveRow.Visible = false;
            }
            else
            {
                buttonSwitchMode.Text = "Edit mode";
                buttonRemoveRow.Visible = true;
            }
            editMode = !editMode;
            updateTranslationTable();
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
