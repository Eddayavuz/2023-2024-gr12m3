using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static WinFormsDemo.authenticate;

namespace WinFormsDemo
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void si_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;

            // Validate input before attempting authentication
            if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass))
            {
                User authenticatedUser = DatabaseManager.AuthenticateUser(user, pass);

                if (authenticatedUser != null)
                {
                    // Display the username on Form5
                    Form5 welcome = new Form5(authenticatedUser);
                    welcome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }
    }
}