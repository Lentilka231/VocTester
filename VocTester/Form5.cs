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
    public partial class HMHangman : Form
    {
        private MySqlConnection conn;
        private Form mainForm;
        private int lives;
        public HMHangman(Form f, MySqlConnection conn)
        {
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
                    SELECT englishword,czechwords FROM ((junctiontable
                    INNER JOIN englishwords ON englishwords.EnglishID=junctiontable.englishid)
                    INNER JOIN czechwords ON czechwords.CzechID = junctiontable.czechid)
                    WHERE junctiontable.englishid={rdr["englishid"]}",conn) ;
            }
            rdr.Close();
            rdr = cmd.ExecuteReader();
            string guessWord="";
            List<string> czechVersions = new List<string>();
            while (rdr.Read())
            {
                guessWord = rdr["englishword"].ToString();
                czechVersions.Add(rdr["czechwords"].ToString());
            }
            rdr.Close();
            this.lives = 3;
            labelInCzech.Text += String.Join(", ",czechVersions);
            labelGuessWord.Text = new string('_', guessWord.Length);
            labelLives.Text = "Lives left: "+this.lives;
        }
        
        private void HMHangman_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
