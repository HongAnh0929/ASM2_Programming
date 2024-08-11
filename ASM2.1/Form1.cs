using System.Xml.Linq;

namespace ASM2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbName.Text;
            string password = txbPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please Enter Your Name!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbName.Focus();
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please Enter Your Pass!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbPassword.Focus();
            }
            else
            {
                if (username == "hong anh" & password == "6789")
                {
                    Form2 Monthly = new Form2();
                    Monthly.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect name and password!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult check_confirm = MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check_confirm == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Continue...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
