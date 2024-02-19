using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsDemo;

namespace WinFormsDemo
{
    // Authentication class
    public class authenticate
    {
/* By having a dedicated User class, it becomes easier to extend and modify user-related properties 
* or methods in the future without directly affecting the authentication logic. 
* This modularity enhances code maintainability. */
        public class User
        {
            public string Username { get; set; } // User's username property
            public byte[] Image { get; set; } // User's image property (binary data)

        }

/* The DatabaseManager class is responsible for handling database operations, including user authentication. 
* This is a good practice in software design, as it allows for better organization and maintainability. */
        public class DatabaseManager
        {
            // Method to authenticate user
            public static User AuthenticateUser(string username, string password)
            {
                User user = RetrieveUserInformation(username, password); // for encapsulation purposes, call the private retrieveUserInformation method.
                return user;
            }

/*The RetrieveUserInformation method encapsulates the logic for querying the database and retrieving user information based on the provided username and password. 
* This method is private, meaning it is intended to be used only within the DatabaseManager class. */
            private static User RetrieveUserInformation(string username, string password)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC23\SQLEXPRESS; Initial Catalog=userRecords; Integrated Security=True;"))
                {
                    sqlCon.Open(); // Open SQL connection

                    string loginQuery = "SELECT COUNT(1) FROM userInfo WHERE Username=@Username AND Password=@Password";
                    string imgQuery = "SELECT img FROM userInfo WHERE Username=@Username AND Password=@Password";

                    using (SqlCommand loginCmd = new SqlCommand(loginQuery, sqlCon))
                    {
                        using (SqlCommand imgCmd = new SqlCommand(imgQuery, sqlCon))
                        {
                            loginCmd.CommandType = CommandType.Text;
                            imgCmd.CommandType = CommandType.Text;

                            loginCmd.Parameters.AddWithValue("@Username", username);
                            loginCmd.Parameters.AddWithValue("@Password", password);
                            imgCmd.Parameters.AddWithValue("@Username", username);
                            imgCmd.Parameters.AddWithValue("@Password", password);

                            int count = Convert.ToInt32(loginCmd.ExecuteScalar());

                            if (count == 1)
                            {
                                using (SqlDataReader reader = imgCmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        byte[] imageData = reader["img"] as byte[];
                                        return new User { Username = username, Image = imageData };
                                    }
                                }
                            }

                            return null; // Return null if no user is found with the specified username and password
                        }
                    }
                }
            }
        }
   
    }
}
