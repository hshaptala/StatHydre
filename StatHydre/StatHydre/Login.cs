using System;
using System.Windows.Forms;
using System.Drawing;

namespace StatHydre
{
    public partial class Login : Form
    {
        private readonly DatabaseManager db;
        private Analyse analyse;

        private string username;
        private string password;

        public Login()
        {
            InitializeComponent();
            db = new DatabaseManager();
            Utils utils = new Utils();

            // Remove cursor focus from textbox
            this.ActiveControl = labelTitle;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            if (db.Auth(username, password))
            {
                this.Hide();
                analyse = new Analyse(username, password);
                analyse.FormClosed += new FormClosedEventHandler(Login_FormClosed);
                analyse.Show();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Login")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = SystemColors.WindowText;
            }
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Login";
                txtUsername.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = SystemColors.WindowText;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.InactiveCaption;
            }
        }
    }
}
