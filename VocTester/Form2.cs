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
    public partial class Form2 : Form
    {
        private static string VocID;
        private static string VocName;
        private Form1 mainForm = null;
        public Form2(Form callingform, string vocID, string vocName)
        {
            mainForm = callingform as Form1;
            VocName = vocName;
            VocID = vocID;
            InitializeComponent();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.mainForm.deleteVocabularyFromDB(VocID);
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            labelDelVoc.Text = $"Do you really want to\n delete {VocName}?";
        }
    }
}
