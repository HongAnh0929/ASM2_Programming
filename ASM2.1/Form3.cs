using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASM2._1
{
    public partial class Form3 : Form
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserGender { get; set; }
        public string UserPhone { get; set; }
        public string UserType { get; set; }
        public string UserNumber { get; set; }
        public string UserLastmonth { get; set; }
        public string UserThismonth { get; set; }
        public string UserWaterconsumption { get; set; }
        public string UserPrice { get; set; }
        public decimal Waterbill { get; set; }

        private decimal evm = 0.1m;
        private decimal vat = 0.1m;


        private Form2 _form2;
        public Form3(Form2 form2)
        {
            InitializeComponent();
            _form2 = form2;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            decimal EVM = evm * Waterbill;
            decimal Totalbill = Waterbill + EVM;
            decimal VAT = vat * Totalbill;

            lbID.Text = UserId.ToString();
            lbName.Text = UserName;
            lbGender.Text = UserGender;
            lbPhone.Text = UserPhone;
            lbType.Text = UserType;
            lbNumber.Text = UserNumber;
            lbLastmonth.Text = UserLastmonth;
            lbThismonth.Text = UserThismonth;
            lbWaterconsumption.Text = UserWaterconsumption;
            lbWaterconsumption2.Text = UserWaterconsumption;
            lbPrice.Text = UserPrice;
            lbPrice2.Text = UserPrice;
            lbWaterbill.Text = Waterbill.ToString("F2");
            lbWaterbill2.Text = Waterbill.ToString("F2");
            lbVAT.Text = VAT.ToString("F2");
            lbEVM.Text = EVM.ToString("F2");
            lbTotalbill.Text = Totalbill.ToString("F2");
            lbTotalbill2.Text = Totalbill.ToString("F2");
            lbTotalamount.Text = (Totalbill + VAT).ToString("F2");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult check_confirm = MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check_confirm == DialogResult.Yes)
            {
                if (_form2 != null)
                {
                    _form2.Show();
                }
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult check_confirm = MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (check_confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }
    }
}


