using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASM2._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lsvCustomer.View = View.Details;
            lsvCustomer.GridLines = true;
            lsvCustomer.FullRowSelect = true;

            lsvCustomer.Columns.Add("ID", 100);
            lsvCustomer.Columns.Add("Customer name", 200);
            lsvCustomer.Columns.Add("Gender", 80);
            lsvCustomer.Columns.Add("Phone number", 160);
            lsvCustomer.Columns.Add("Customer type", 150);
            lsvCustomer.Columns.Add("Water last month (m3)", 180);
            lsvCustomer.Columns.Add("Water this month (m3)", 180);
            lsvCustomer.Columns.Add("Water consumption (m3)", 160);
            lsvCustomer.Columns.Add("Price (VND/m3)", 70);
            lsvCustomer.Columns.Add("Water bill (VND)", 150);
            lsvCustomer.Columns.Add("Total amount (with VAT, EVM)", 200);
            lsvCustomer.Columns.Add("Description", 200);

            cbbType_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ID = default;
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("Please Enter Your ID!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ID = tbID.Text;
            }

            string Name = default;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Please Enter Your Name!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Name = tbName.Text;
            }

            string Gender = null;
            if (rbMale.Checked)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }

            string Phone = default;
            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                MessageBox.Show("Please Enter Your Phone!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Phone = tbPhone.Text;
            }

            string Customertype = null;
            string Numberofpeople = null;
            if (cbbType.SelectedIndex == 0)
            {
                Customertype = "Household customer";
            }
            else if (cbbType.SelectedIndex == 1)
            {
                Customertype = "Administrative agencies and public";
            }
            else if (cbbType.SelectedIndex == 2)
            {
                Customertype = "Production unit";
            }
            else
            {
                Customertype = "Business services";
            }

            double Lastmonth, Thismonth;
            double Waterconsumption = 0;
            if (!double.TryParse(tbLast.Text, out Lastmonth))
            {
                MessageBox.Show("Please re-enter last month's water meter readings!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(tbThis.Text, out Thismonth))
            {
                MessageBox.Show("Please re-enter this month's water meter readings!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Lastmonth >= Thismonth)
            {
                MessageBox.Show("Please re-enter the value!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Waterconsumption = Thismonth - Lastmonth;
            tbWaterconsumption.Text = Waterconsumption.ToString();


            double Waterbill = 0;
            double Price = 0;
            switch (Customertype)
            {
                case "Household customer":
                    if (Waterconsumption <= 10)
                    {
                        Price = 5973;
                        Waterbill = 10 * 5973;
                    }
                    else if (Waterconsumption <= 20)
                    {
                        Price = 7052;
                        Waterbill = 10 * 5973 + 10 * 7052;
                    }
                    else if (Waterconsumption <= 30)
                    {
                        Price = 8699;
                        Waterbill = 10 * 5973 + 10 * 7052 + 10 * 8699;
                    }
                    else
                    {
                        Price = 15929;
                        Waterbill = 10 * 5973 + 10 * 7052 + 10 * 8699 + (Waterconsumption - 30) * 15929;
                    }
                    break;
                case "Administrative agencies and public":
                    Price = 9955;
                    Waterbill = Waterconsumption * 9955;
                    break;
                case "Production unit":
                    Price = 11615;
                    Waterbill = Waterconsumption * 11615;
                    break;
                case "Business services":
                    Price = 22068;
                    Waterbill = Waterconsumption * 22068;
                    break;
            }
            tbWaterbill.Text = Waterbill.ToString();
            tbPrice.Text = Price.ToString();

            double EVM = 0.1 * Waterbill;

            double Totalbill = Waterbill + EVM;

            double VAT = 0.1 * Totalbill;

            double Totalamount = Totalbill + VAT;

            tbTotalamount.Text = Totalamount.ToString();

            string Description = $"CustomerType: {Customertype}\r\n" +

                                 $"Water consumption: {Waterconsumption}\r\n" +

                                 $"Price: {Price} \r\n" +

                                 $"Environment: {EVM} \r\n" +

                                 $"Total bill: {Totalbill} \r\n" +

                                 $"VAT: {VAT}";

            tbDescription.Text = Description.Trim();

            ListViewItem item = new ListViewItem();

            item.Text = ID;
            item.SubItems.Add(Name);
            item.SubItems.Add(Gender);
            item.SubItems.Add(Phone);
            item.SubItems.Add(Customertype);
            item.SubItems.Add(Lastmonth.ToString());
            item.SubItems.Add(Thismonth.ToString());
            item.SubItems.Add(Waterconsumption.ToString());
            item.SubItems.Add(Price.ToString());
            item.SubItems.Add(Waterbill.ToString());
            item.SubItems.Add(Totalamount.ToString());
            item.SubItems.Add(Description);

            lsvCustomer.Items.Add(item);

            ClearForm();
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == 0)
            {
                lbNumber.Visible = true;
                tbNumber.Visible = true;
            }
            else
            {
                lbNumber.Visible = false;
                tbNumber.Visible = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lsvCustomer.SelectedItems.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Do you want to edit the information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    ListViewItem item = lsvCustomer.SelectedItems[0];

                    item.SubItems[0].Text = tbID.Text;
                    item.SubItems[1].Text = tbName.Text;
                    item.SubItems[2].Text = rbMale.Checked ? "Male" : "Female";
                    item.SubItems[3].Text = tbPhone.Text;
                    item.SubItems[4].Text = cbbType.SelectedItem.ToString();
                    item.SubItems[5].Text = tbLast.Text;
                    item.SubItems[6].Text = tbThis.Text;
                    item.SubItems[7].Text = tbWaterconsumption.Text;
                    item.SubItems[8].Text = tbPrice.Text;
                    item.SubItems[9].Text = tbWaterbill.Text;
                    item.SubItems[10].Text= tbTotalamount.Text;
                    item.SubItems[11].Text = tbDescription.Text;

                    ClearForm();
                }
            }
        }

        private void ClearForm()
        {
            tbID.Clear();
            tbName.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            tbPhone.Clear();
            cbbType.SelectedIndex = -1;
            tbLast.Clear();
            tbThis.Clear();
            tbWaterconsumption.Clear();
            tbPrice.Clear();
            tbWaterbill.Clear();
            tbTotalamount.Clear();
            tbDescription.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvCustomer.SelectedItems.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Do you want to delete the information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    lsvCustomer.Items.Remove(lsvCustomer.SelectedItems[0]);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lsvCustomer.Items.Clear();

            tbID.Clear();
            tbName.Clear();
            tbPhone.Clear();
            tbNumber.Clear();
            tbLast.Clear();
            tbThis.Clear();
            tbWaterconsumption.Clear();
            tbWaterbill.Clear();
            tbTotalamount.Clear();
            tbDescription.Clear();

            cbbType.SelectedIndex = -1;
            rbMale.Checked = false;
            rbFemale.Checked = false;

            ClearForm();
        }

        private void lsvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCustomer.SelectedItems.Count > 0)
            {
                ListViewItem seleted_Item = lsvCustomer.SelectedItems[0];

                tbID.Text = seleted_Item.SubItems[0].Text;
                tbName.Text = seleted_Item.SubItems[1].Text;
                string Gender = seleted_Item.SubItems[2].Text;
                rbMale.Checked = Gender == "Male";
                rbFemale.Checked = Gender == "Female";

                tbPhone.Text = seleted_Item.SubItems[3].Text;
                string Customertype = seleted_Item.SubItems[4].Text;
                cbbType.SelectedIndex = cbbType.Items.IndexOf(Customertype);

                tbLast.Text = seleted_Item.SubItems[5].Text;
                tbThis.Text = seleted_Item.SubItems[6].Text;
                tbWaterconsumption.Text = seleted_Item.SubItems[7].Text;
                tbPrice.Text = seleted_Item.SubItems[8].Text;
                tbWaterbill.Text = seleted_Item.SubItems[9].Text;
                tbTotalamount.Text = seleted_Item.SubItems[10].Text;
                tbDescription.Text = seleted_Item.SubItems[11].Text;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lsvCustomer.SelectedItems.Count > 0)
            {
                Form3 form3 = new Form3(this);
                {

                    form3.UserId = int.Parse(tbID.Text);
                    form3.UserName = tbName.Text;
                    form3.UserGender = rbMale.Checked ? "Male" : "Female";
                    form3.UserPhone = tbPhone.Text;
                    form3.UserType = cbbType.SelectedItem.ToString();

                    if (form3.UserType == " Household customer")
                    {
                        form3.UserNumber = tbNumber.Text;
                    }

                    form3.UserLastmonth = tbLast.Text;
                    form3.UserThismonth = tbThis.Text;
                    form3.UserWaterconsumption = tbWaterconsumption.Text;
                    form3.UserPrice = tbPrice.Text;
                    form3.Waterbill = decimal.Parse(tbWaterbill.Text);
                }

                form3.Show();
            }
        }
    }
}
