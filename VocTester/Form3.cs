using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using MySql.Data.MySqlClient;
namespace VocTester
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            ConnecToDB();
            InitializeComponent();
        }
        private MySqlConnection conn;
        private void ConnecToDB()
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
                conn = new MySqlConnection(connStr);
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Unable to join the Database!");
            }
        }
        private void buttonDictionary_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(this,conn);
            f1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBoxLogo.ImageLocation = "Logo.png";
        }
    }
}
