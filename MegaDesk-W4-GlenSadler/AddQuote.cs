using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MegaDesk_3_GlenSadler
{
    public partial class AddQuote : Form
    {
        DeskTopMaterial material;
        DeskQuote quote = new DeskQuote();

        public AddQuote()
        {
            InitializeComponent();
            // use Lits<T> to populate desktopMaterialComboBox
            List<DeskTopMaterial> MaterialList = Enum.GetValues(typeof(DeskTopMaterial)).Cast<DeskTopMaterial>().ToList();
            desktopMaterialComboBox.DataSource = MaterialList;

            //desktopMaterialComboBox.DataSource = Enum.GetNames(typeof(DeskTopMaterial));
            //comboDrawers.DataSource = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            //comboShipping.DataSource = new int[] { 0, 7, 5, 3 };
        }

        /*private void fileQuote(DeskQuote deskQuote)
        {
            string csvFile = "quotes.txt";

            using (StreamWriter sr = new StreamWriter(csvFile, true))
            {
                sr.WriteLine(
                        $"{quote.QuoteDate}," +
                        $"{quote.CustomerName}," +
                        $"{quote.SurfaceAreaCost}," +
                        $"{quote.Width}," +
                        $"{quote.desk.NumDrawers}," +
                        $"{quote.desk.Material}," +
                        $"{quote.ShippingDays}," +
                        $"{quote.CalculateTotalCost()}");
            }
        }*/


        private void AddQuote_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                material = (DeskTopMaterial)desktopMaterialComboBox.SelectedValue;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*private void AddQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }*/

        

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            quote.CustomerName = customerName.Text;
        }



        private void numericWidthEvent(object sender, EventArgs e)
        {
            //numericWidth.Minimum = 24;
            //numericWidth.Maximum = 96;

            if (int.TryParse(numericWidth.Text, out int WidthInput) == true)
            {
                if (WidthInput < Desk.MINWIDTH || WidthInput > Desk.MAXWIDTH)
                {

                    widthValidateMessage();                   
                }
                else
                {
                    numericWidth.BackColor = System.Drawing.SystemColors.Window;
                    quote.Desk.Width = (int)numericWidth.Value;
                    quoteTotalCost();
                    //widthValidateOk();
                }
            }
            else if (int.TryParse(numericWidth.Text, out WidthInput) == false && numericWidth.Text.Length != 0)
            {
                widthValidateMessage();
            }
            else
            {
                numericWidth.BackColor = System.Drawing.SystemColors.Window;
                quote.Desk.Width = (int)numericWidth.Value;
                //widthValidateOk();
                //rushDayCosts();
                quoteTotalCost();
            }

        }

        private void widthValidateMessage()
        {
            MessageBox.Show($"The width must a whole number between {Desk.MINWIDTH} and {Desk.MAXWIDTH} inches inclusive.");
            numericWidth.Text = String.Empty;
            data_Enter(this, EventArgs.Empty);
            numericWidth.BackColor = Color.Red;
            numericWidth.Focus();
        }

        /*private void widthValidateOk()
        {
            numericWidth.BackColor = System.Drawing.SystemColors.Window;
            quote.Desk.Width = (int)numericWidth.Value;
            //rushDayCosts();
            quoteTotalCost();
        }*/

        private void numericWidth_Keypress(object sender, KeyPressEventArgs e)
        {
            //numericWidth.Minimum = 24;
            //numericWidth.Maximum = 96;
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Please enter a number - Text is not permitted");
                e.Handled = true;
                numericWidth.BackColor = Color.Red;
                numericWidth.Focus();
            }
            else
            {
                numericWidth.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void numericDepthEvent(object sender, EventArgs e)
        {
            //numericDepth.Minimum = 12;
            //numericDepth.Maximum = 48;
            //quote.newDesk.Depth = (int)numericDepth.Value;
            //surfaceAreaCalc.Text = ($"{quote.newDesk.SurfaceArea.ToString()} sq\"");
            if (int.TryParse(numericDepth.Text, out int DepthInput) == true)
            {
                if (DepthInput < Desk.MINDEPTH || DepthInput > Desk.MAXDEPTH)
                {
                    depthValidateMessage();
                }
                else
                {
                    //depthValidateOk();
                    numericDepth.BackColor = System.Drawing.SystemColors.Window;
                    quote.Desk.Depth = (int)numericDepth.Value;
                    //rushDayCosts();
                    quoteTotalCost();
                }
            }
            else if (int.TryParse(numericDepth.Text, out DepthInput) == false && numericDepth.Text.Length != 0)
            {
                depthValidateMessage();
            }
            else
            {
                //depthValidateOk();
                numericDepth.BackColor = System.Drawing.SystemColors.Window;
                quote.Desk.Depth = (int)numericDepth.Value;
                //rushDayCosts();
                quoteTotalCost();
            }
        }

        private void depthValidateMessage()
        {
            MessageBox.Show($"The depth must be a whole number between {Desk.MINDEPTH} and {Desk.MAXDEPTH} inches inclusive");
            numericDepth.Text = String.Empty;
            numericDepth.BackColor = Color.Red;
            numericDepth.Focus();
        }

        /*private void depthValidateOk()
        {
            numericDepth.BackColor = System.Drawing.SystemColors.Window;
            quote.Desk.Depth = (int)numericDepth.Value;
            //rushDayCosts();
            quoteTotalCost();
        }*/

        private void numericDepth_Keypress(object sender, KeyPressEventArgs e)
        {
            //numericDepth.Minimum = 12;
            //numericDepth.Maximum = 48;
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Please enter a number - text is not permitted");
                e.Handled = true;
                numericDepth.BackColor = Color.Red;
                numericDepth.Focus();
            }
            else
            {
                numericDepth.BackColor = System.Drawing.SystemColors.Window;
            }
        }


        private void numericDrawersEvent(object sender, EventArgs e)
        {
            //numericDrawers.Minimum = 0;
            //numericDrawers.Maximum = 7;
            if (int.TryParse(numericDrawers.Text, out int DrawersInput) == true)
            {
                if (DrawersInput < Desk.MINDRAWERS || DrawersInput > Desk.MAXDRAWERS)
                {
                    drawersValidateMessage();                   
                }
                else
                {
                    //drawersValidateOk();
                    numericDrawers.BackColor = System.Drawing.SystemColors.Window;
                    quote.Desk.NumberOfDrawers = (int)numericDrawers.Value;
                    //rushDayCosts();
                    quoteTotalCost();
                }
            }
            else if (int.TryParse(numericDrawers.Text, out DrawersInput) == false && numericDrawers.Text.Length != 0)
            {
                drawersValidateMessage();
            }
            else
            {
                //drawersValidateOk();
                numericDrawers.BackColor = System.Drawing.SystemColors.Window;
                quote.Desk.NumberOfDrawers = (int)numericDrawers.Value;
                //rushDayCosts();
                quoteTotalCost();
            }
            
        }


        private void drawersValidateMessage()
        {
            MessageBox.Show($"The number of drawers must be in the range of  {Desk.MINDRAWERS} - {Desk.MAXDRAWERS} inclusive");
            numericDrawers.Text = String.Empty;
            numericDrawers.BackColor = Color.Red;
            numericDrawers.Focus();
        }

        /*private void drawersValidateOk()
        {
            numericDrawers.BackColor = System.Drawing.SystemColors.Window;
            quote.Desk.NumberOfDrawers = (int)numericDrawers.Value;
            rushDayCosts();
            quoteTotalCost();
        }*/

        private void numericDrawers_KeyPress(object sender, KeyPressEventArgs e)
        {
            //numericDepth.Minimum = 12;
            //numericDepth.Maximum = 48;
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Please enter a number - text is not permitted");
                e.Handled = true;
                numericDrawers.BackColor = Color.Red;
                numericDrawers.Focus();
            }
            else
            {
                numericDrawers.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void deskTopMaterial()
        {

        }

        private void data_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown dataBox = sender as NumericUpDown;

            if (dataBox != null)
            {
                int lengthOfData = dataBox.Value.ToString().Length;
                dataBox.Select(0, lengthOfData);
            }

        }

        private void data_EnterText(object sender, EventArgs e)
        {
            // Select the whole text in a text box
            TextBox dataBox = sender as TextBox;

            {
                int lengthOfData = dataBox.Text.ToString().Length;
                dataBox.Select(0, lengthOfData);
            }
        }

        /*private void comboSurfaceMaterial_TextChanged(object sender, EventArgs e)
        {
            var desk = new Desk
            {
                Width = Int32.Parse(numericWidth.Text),
                Depth = Int32.Parse(numericDepth.Text),
                NumberOfDrawers = Int32.Parse(numericDrawers.Text)
            };

            //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());

            switch (desktopMaterialComboBox.Text)
            {
                case "Oak":
                    desk.DeskTopMaterial = DeskTopMaterial.Oak;
                    MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Laminate":
                    desk.DeskTopMaterial = DeskTopMaterial.Laminate;
                    MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(DeskTopMaterial.Laminate.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Pine":
                    desk.DeskTopMaterial = DeskTopMaterial.Pine;
                    MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Rosewood":
                    desk.DeskTopMaterial = DeskTopMaterial.Rosewood;
                    //MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Veneer":
                    desk.DeskTopMaterial = DeskTopMaterial.Veneer;
                    //MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;
            }
        }*/



        /*private void rushDayCosts()
        {

            if (radioBtnShippingStandard.Checked)
            {
                quote.RushDays = 0;
                //MessageBox.Show("I'm 14 Days");
            }
            else if (radioBtnShipping7days.Checked)
            {
                quote.RushDays = 7;
                //MessageBox.Show("I'm 7 Days");
            }
            else if (radioBtnShipping5days.Checked)
            {
                quote.RushDays = 5;
                //MessageBox.Show("I'm 5 Days");
            }
            else if (radioBtnShipping3days.Checked)
            {
                quote.RushDays = 3;
                //MessageBox.Show("I'm 3 Days");
            }
        }*/


        public void quoteTotalCost()
        {
            costBase.Text = ($"${DeskQuote.PRICE_BASE}");
            surfaceAreaCalc.Text = ($"{quote.Desk.SurfaceArea.ToString()} sq\"");
            costSurfaceArea.Text = ($"${quote.SurfaceAreaCost().ToString()}");
            costDrawers.Text = ($"${quote.DrawerCost().ToString()}");
            costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
            costShipping.Text = ($"${quote.RushDaysCost().ToString()}");
            costTotal.Text = ($"${quote.CalculateQuoteTotal().ToString()}");
        }

        private void radioBtnShippingStandard_CheckedChanged(object sender, EventArgs e)
        {
            quote.RushDays = 0;
            quoteTotalCost();
        }

        private void radioBtnShipping7days_CheckedChanged(object sender, EventArgs e)
        {
            quote.RushDays = 7;
            quoteTotalCost();
        }

        private void radioBtnShipping5days_CheckedChanged(object sender, EventArgs e)
        {
            quote.RushDays = 5;
            quoteTotalCost();
        }

        private void radioBtnShipping3days_CheckedChanged(object sender, EventArgs e)
        {
            quote.RushDays = 3;
            quoteTotalCost();
        }

        private void desktopMaterialComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var desk = new Desk
            {
                Width = Int32.Parse(numericWidth.Text),
                Depth = Int32.Parse(numericDepth.Text),
                NumberOfDrawers = Int32.Parse(numericDrawers.Text)
            };

            //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());

            switch (desktopMaterialComboBox.Text)
            {
                case "Oak":
                    desk.DeskTopMaterial = DeskTopMaterial.Oak;
                    MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Laminate":
                    desk.DeskTopMaterial = DeskTopMaterial.Laminate;
                    MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(DeskTopMaterial.Laminate.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Pine":
                    desk.DeskTopMaterial = DeskTopMaterial.Pine;
                    MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Rosewood":
                    desk.DeskTopMaterial = DeskTopMaterial.Rosewood;
                    //MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;

                case "Veneer":
                    desk.DeskTopMaterial = DeskTopMaterial.Veneer;
                    //MessageBox.Show($"I'm {desk.DeskTopMaterial}");
                    //MessageBox.Show(desktopMaterialComboBox.SelectedValue.ToString());
                    costMaterial.Text = ($"${quote.DeskTopMaterialCost().ToString()}");
                    break;
            }
        }
    }
}
