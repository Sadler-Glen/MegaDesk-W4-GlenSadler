using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MegaDesk_3_GlenSadler
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string MaterialSelected = MaterialComboBox.SelectedItem.ToString();

                using (StreamReader sr = new StreamReader(@"quotes.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fieldvalue = sr.ReadLine().Split(',');
                        /*if()
                        {

                        }*/
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
