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


        // Event handler for when the form is loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set default values for ComboBoxes when the form is loaded
            roomType.SelectedIndex = 0;
            availability.SelectedIndex = 0;
            status.SelectedIndex = 0;

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
                    conditions.Add("cleaningStatus = @status");

                if (roomType.SelectedItem != null)
                    conditions.Add("roomType = @roomType");

                if (availability.SelectedItem != null)
                    conditions.Add("roomAvailability = @roomAvailability");

                // combine the conditions into the SQL query
                if (conditions.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                // Set parameters based on selected values
                cmd.Parameters.AddWithValue("@status", status.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@roomType", roomType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@roomAvailability", availability.SelectedItem.ToString());

                // Use SqlDataAdapter to fetch data and populate DataGridView
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            roomType.SelectedIndex = 0;
            availability.SelectedIndex = 0;
            status.SelectedIndex = 0;
        }

        private void checkIn_Click(object sender, EventArgs e)
        {
            using (check_in userInputForm = new check_in())
            {
                // Display the form as a dialog
                userInputForm.ShowDialog();

            }
        }
    }
}
