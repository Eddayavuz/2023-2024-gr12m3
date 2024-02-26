// Event handler for when the form is loaded
private void Form1_Load(object sender, EventArgs e)
{
    // Set default values for ComboBoxes when the form is loaded
    roomType.SelectedText = "ROOM TYPE";
    availability.SelectedText = "AVAILABILITY";
    status.SelectedText = "STATUS";
}


// Event handler for when the room type is selected in the ComboBox
private void roomType_SelectedIndexChanged(object sender, EventArgs e)
{
    // Establish a connection to the database
    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=lavandulaDB; Integrated Security=True;"))
    {
        sqlCon.Open(); // Open SQL connection

        // SQL query to select rooms based on the selected room type
        string query = "select * from rooms where roomType = @roomType";

        SqlCommand cmd = new SqlCommand(query, sqlCon);
        cmd.Parameters.AddWithValue("@roomType", roomType.SelectedItem.ToString());

        // Use SqlDataAdapter to fetch data and populate DataGridView
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
