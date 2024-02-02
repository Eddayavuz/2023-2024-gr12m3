private void button1_Click(object sender, EventArgs e)
{
    cn = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=userRecords; Integrated Security=True;"); // establish SQL Connection with the name of your DB.
    cn.Open(); // open the connection

    if (password.Text != string.Empty || rePassword.Text != string.Empty) //check if the password and retype password fields are not empty.
    {
        if (password.Text == rePassword.Text)
        {
            SqlCommand cmd = new SqlCommand("select * from userInfo where username='" + username.Text + "'", cn); 
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                MessageBox.Show("Username already exists please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dr.Close();
                cmd = new SqlCommand("INSERT INTO userInfo VALUES(@username,@email, @password)", cn);
                cmd.Parameters.AddWithValue("username", username.Text);
                cmd.Parameters.AddWithValue("email", emailTxt.Text);
                cmd.Parameters.AddWithValue("password", password.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your account is created. Please log in now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 login = new Form2();
                login.Show();
            }
        }
        else
        {
            MessageBox.Show("Please enter both passwords same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    else
    {
        MessageBox.Show("Please enter a value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

}
