using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class Form2 : Form
    {
        SqlConnection sqlCon;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // establish SQL connection
            try
            {
                sqlCon = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=userRecords; Integrated Security=True;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void si_Click(object sender, EventArgs e)
        {
            try
            {
                //make sure the connection is open
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string Query = "SELECT COUNT(1) FROM userInfo Where Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(Query, sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    homePage hp = new homePage();
                    hp.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password or username is incorrect. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
