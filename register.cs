using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class rgstr : Form
    {
        private SqlCommand cmd;
        private SqlConnection cn;
        private SqlDataReader dr;

        public rgstr()
        {
            InitializeComponent();
        }

        // Validation for username length
        private void uNameTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (username.Text.Length <= 5)
            {
                MessageBox.Show("Username should be at least 5 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Focus();
                e.Cancel = true;
            }
        }

        // Validation for password complexity
        private void passwordTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(password.Text.Length > 8 && password.Text.Any(char.IsUpper) && password.Text.Any(char.IsLower) && password.Text.Any(char.IsDigit)))
            {
                MessageBox.Show("One or more password criteria(s) hasn't been met", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.SelectAll();
                e.Cancel = true;
            }
        }
        
        // Validating each password criteria as the user types.
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

        // Validation for email format
        private void emailTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidEmail(emailTxt.Text))
            {
                MessageBox.Show("Email not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTxt.SelectAll();
                e.Cancel = true;
            }
        }

        // Email validation helper method
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, emailPattern);
        }

        // Button click event for user registration
        private void button1_Click(object sender, EventArgs e)
        {
            // Connecting to the database
            using (cn = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=userRecords; Integrated Security=True;"))
            {
                cn.Open();

                // Checking if passwords match
                if (!string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(rePassword.Text))
                {
                    if (password.Text == rePassword.Text)
                    {
                        // Checking if the username already exists
                        using (cmd = new SqlCommand("Write SQL query to select the username from the 'userInfo' table where it matches the value entered in a textbox. Use a parameterized query with the placeholder @username.", cn))
                        {
                            cmd.Parameters.AddWithValue("@username", username.Text);
                            using (dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    MessageBox.Show("Username already exists, please try another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    dr.Close();

                                    // Inserting user information into the database
                                    using (cmd = new SqlCommand("write an insert into command to add all the fields from your sign up form to the table. If necessary, add new columns to your table.", cn))
                                    {
                                        cmd.Parameters.AddWithValue("@username", username.Text);
                                        cmd.Parameters.AddWithValue("@email", emailTxt.Text);
                                        cmd.Parameters.AddWithValue("@password", password.Text);
                                        cmd.ExecuteNonQuery();

                                        MessageBox.Show("Your Account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Hide();
                                        Form2 login = new Form2();
                                        login.Show();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter both passwords the same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a value in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Click event for navigating to login form
        private void label3_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
