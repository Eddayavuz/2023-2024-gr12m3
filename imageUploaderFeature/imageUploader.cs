using System;  // Importing the System namespace
using System.Collections.Generic;  // Importing namespaces for various functionalities
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;  // Importing namespaces for database-related functionalities
using System.Data;

namespace WinFormsDemo
{
    // Declaration of a class named imageUploader
    public class imageUploader
    {
        // Method to upload an image to the database for a specific username
        public static void UploadImage(string username, byte[] image)
        {
            // Establishing a connection to the database
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source= LAB109PC23\SQLEXPRESS; Initial Catalog=userRecords; Integrated Security=True;"))
            {
                sqlCon.Open();  // Opening the database connection

                string uploadImgQ = "UPDATE userInfo SET img=@image WHERE username=@username";  // SQL query to update the image for a specific username

                // Creating a SqlCommand to execute the update query
                using (SqlCommand uploadCmd = new SqlCommand(uploadImgQ, sqlCon))
                {
                    uploadCmd.CommandType = CommandType.Text;  // Setting the command type to text
                    uploadCmd.Parameters.AddWithValue("username", username);  // Adding parameter for the username
                    uploadCmd.Parameters.AddWithValue("image", image);  // Adding parameter for the image byte array

                    uploadCmd.ExecuteNonQuery();  // Executing the update query
                }
            }
        }

        // Method to convert Image to byte array
        public static byte[] ImageToByteArray(Image image)
        {
            // Using MemoryStream to convert Image to byte array
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);  // Saving the image to the MemoryStream in its raw format
                return ms.ToArray();  // Converting MemoryStream to byte array and returning
            }
        }
    }
}
