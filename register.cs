using System.Net.Mail;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System.Diagnostics.Metrics;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WinFormsDemo
{
    public partial class rgstr : Form
    {

        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
       
        public rgstr()
        {
            InitializeComponent();
        }
        private void uNameTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (username.Text.Length <= 5)
            {
                MessageBox.Show("Username should be at least 5 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Focus();
                e.Cancel = true;
            }
        }

        private void passwordTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(password.Text.Length > 8 && password.Text.Any(char.IsUpper) && password.Text.Any(char.IsLower) && password.Text.Any(char.IsDigit)))
            {
                MessageBox.Show("One or more password criteria(s) hasn't been met", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.SelectAll();
                e.Cancel = true;
            }

        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            length.Show();
            capital.Show();
            lowercase.Show();
            number.Show();

            if (password.Text.Length > 8)
                length.ForeColor = Color.Green;
            else
                length.ForeColor = Color.Red;

            if (password.Text.Any(char.IsUpper))
                capital.ForeColor = Color.Green;
            else
                capital.ForeColor = Color.Red;

            if (password.Text.Any(char.IsLower))
                lowercase.ForeColor = Color.Green;
            else
                lowercase.ForeColor = Color.Red;

            if (password.Text.Any(char.IsDigit))
                number.ForeColor = Color.Green;
            else
                number.ForeColor = Color.Red;
        }

        private void emailTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (emailTxt.Text != string.Empty)
            {
                if (!IsValidEmail(emailTxt.Text))
                {
                    MessageBox.Show("email not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    emailTxt.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=userRecords; Integrated Security=True;");
            cn.Open();

            if (password.Text != string.Empty || rePassword.Text != string.Empty)
            {
                if (password.Text == rePassword.Text)
                {
                    SqlCommand cmd = new SqlCommand("select * from userInfo where username='" + username.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into userInfo values(@username,@email, @password)", cn);
                        cmd.Parameters.AddWithValue("username", username.Text);
                        cmd.Parameters.AddWithValue("email", emailTxt.Text);
                        cmd.Parameters.AddWithValue("password", password.Text);
                        cmd.ExecuteNonQuery();
                     
                        MessageBox.Show("Your Account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form2 login = new Form2();
                        login.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }

}


