using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LavandulaHotel
{
    public partial class check_in : Form
    {
        public check_in()
        {
            InitializeComponent();
        }

        private void reserve_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=lavandulaDB; Integrated Security=True;"))
            {
                sqlCon.Open(); // Open SQL connection

                // Check if the room is available
                string availabilityQuery = "SELECT roomAvailability FROM rooms WHERE roomNo = @rNumber";

                SqlCommand availabilityCmd = new SqlCommand(availabilityQuery, sqlCon);
                availabilityCmd.Parameters.AddWithValue("@rNumber", roomNumber.Text);
                string availabilityResult = availabilityCmd.ExecuteScalar().ToString().Trim();
               
                if (availabilityResult.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    // Room is available, proceed with booking
                    string insertQuery = "INSERT INTO checkedIn VALUES (@rNumber, @gName, @pNumber, @ciDate, @coDate)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, sqlCon);

                    // Set parameters based on selected values
                    insertCmd.Parameters.AddWithValue("@rNumber", roomNumber.Text);
                    insertCmd.Parameters.AddWithValue("@gName", guestName.Text);
                    insertCmd.Parameters.AddWithValue("@pNumber", phoneNumber.Text);
                    insertCmd.Parameters.AddWithValue("@ciDate", checkInDate.Value);
                    insertCmd.Parameters.AddWithValue("@coDate", checkOutDate.Value);

                    insertCmd.ExecuteNonQuery();

                    // Update room availability status
                    string updateAvailabilityQuery = "UPDATE rooms SET roomAvailability = 'Occupied' WHERE roomNo = @rNumber";
                    SqlCommand updateAvailabilityCmd = new SqlCommand(updateAvailabilityQuery, sqlCon);
                    updateAvailabilityCmd.Parameters.AddWithValue("@rNumber", roomNumber.Text);
                    updateAvailabilityCmd.ExecuteNonQuery();

                    MessageBox.Show("Booking Successful!");
                }
                else
                {
                    // Room is not available
                    MessageBox.Show("Sorry, the room is not available for booking.");
                }
            }
        }
    }
}
// ADD ANOTHER TABLE INTO YOUR DATABASE, THAT MAKES SENSE.
// CREATE ANOTHER DIALOG IN YOUR PROGRAM TO COLLECT INFORMATION FROM YOUR USERS
// INSERT THE INFORMATION INTO YOUR NEW TABLE.
