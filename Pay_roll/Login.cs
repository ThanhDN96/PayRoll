using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pay_roll
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                txtuser.Text = Properties.Settings.Default.Username;
                txtpassword.Text = Properties.Settings.Default.Password;

            }
            chbremeber.Checked = true;
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (chbremeber.Checked == true)
            {
                Properties.Settings.Default.Username = txtuser.Text.Trim();
                Properties.Settings.Default.Password = txtpassword.Text.Trim();
                Properties.Settings.Default.Save();
            }

            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();

            }

            DataTable table = new DataTable();
            table.Columns.Add("User", typeof(string));
            table.Columns.Add("Password", typeof(string));
            table.Rows.Add("admin", "admin");
            table.Rows.Add("admin", "vmo123");
            table.Rows.Add("admin", "1");
            table.AcceptChanges();
            if (txtuser.Text.Trim() == "" || txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("Username or Password cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataRow r in table.Rows)
            {
                if (txtuser.Text.Trim() == r["User"].ToString() && txtuser.Text.Trim() == r["Password"].ToString())
                {
                    MessageBox.Show("Login Successfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Payroll payroll = new Payroll();
                    payroll.ShowDialog();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("UserName or Password Is Valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }
    }
}
