using System.Text.RegularExpressions; // import regex library

        private void uNameTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (uNameTxt.Text.Length <= 5)
            {
                MessageBox.Show("Username should be at least 5 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uNameTxt.Focus();
                e.Cancel = true;
            }
        }

        private void passwordTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(passwordTxt.Text.Length > 8 && passwordTxt.Text.Any(char.IsUpper) && passwordTxt.Text.Any(char.IsLower) && passwordTxt.Text.Any(char.IsDigit)))
            {
                MessageBox.Show("One or more password criteria(s) hasn't been met", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTxt.SelectAll();
                e.Cancel = true;
            }
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            length.Show(); // label for the password lenght requirement
            capital.Show(); // label for the uppercase letter requirement
            lowercase.Show();
            number.Show();

            if (passwordTxt.Text.Any(char.IsUpper)) //check if a string includes any uppercase letter
                capital.ForeColor = Color.Green; //change the color property of capital label
            else
                capital.ForeColor = Color.Red;
        }

        private void emailTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // REGEX pattern for acceptable email.

            if (string.IsNullOrEmpty(email)) // return false if email is empty.
                return false;

            Regex regex = new Regex(emailPattern); // create an instance of Regex class.
            return regex.IsMatch(email); // call ismatch method and return boolean value.
        }

    }

}


/*

private void Form1_Load(object sender, EventArgs e)
{
    cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\e.yavuz\source\repos\WinFormsDemo\WinFormsDemo\Database1.mdf;Integrated Security=True");
    cn.Open();

}

private void login_Click(object sender, EventArgs e)
{
    this.Hide();
    //Login login = new Login();
    //login.ShowDialog();
}

private void button1_Click(object sender, EventArgs e)
{

    if (passwordTxt.Text != string.Empty || cPasswordTxt.Text != string.Empty)
    {
        if (passwordTxt.Text == cPasswordTxt.Text)
        {
            SqlCommand cmd = new SqlCommand("select * from LoginTable where username='" + uNameTxt.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dr.Close();
                cmd = new SqlCommand("insert into LoginTable values(@username,@password)", cn);
                cmd.Parameters.AddWithValue("username", uNameTxt.Text);
                cmd.Parameters.AddWithValue("password", passwordTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

private void label2_Click(object sender, EventArgs e)
{

}
*/
