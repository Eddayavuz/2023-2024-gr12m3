using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.ComponentModel.DataAnnotations;

namespace LavandulaHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=lavandulaDB; Integrated Security=True;"))
            {
                sqlCon.Open(); // Open SQL connection

                // Start with a base SQL query
                string query = "SELECT * FROM rooms WHERE 1 = 1";
                    // Create a list to store the conditions for filtering
                    List<string> conditions = new List<string>();

                    // Check each ComboBox and add a condition if an item is selected
                    if (status.SelectedItem != null)
                    {
                        conditions.Add("cleaningStatus = @status");
                    }

                    if (roomType.SelectedItem != null)
                    {
                        conditions.Add("roomType = @roomType");
                    }

                    if (availability.SelectedItem != null)
                    {
                        conditions.Add("roomAvailability = @roomAvailability");
                    }

                    // Combine the conditions into the SQL query
                    if (conditions.Count > 0)
                    {
                        query += " AND " + string.Join(" AND ", conditions);
                    }

                    SqlCommand cmd = new SqlCommand(query, sqlCon);

                    // Set parameters based on selected values, handling the case where ComboBox is empty
                    if (status.SelectedItem != null)
                    {
                        cmd.Parameters.AddWithValue("@status", status.SelectedItem.ToString());
                    }

                    if (roomType.SelectedItem != null)
                    {
                        cmd.Parameters.AddWithValue("@roomType", roomType.SelectedItem.ToString());
                    }

                    if (availability.SelectedItem != null)
                    {
                        cmd.Parameters.AddWithValue("@roomAvailability", availability.SelectedItem.ToString());
                    }

                    // Use SqlDataAdapter to fetch data and populate DataGridView
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                    }
                }
            }
    }
}
