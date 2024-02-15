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
using static WinFormsDemo.authenticate;
using WinFormsDemo;

namespace WinFormsDemo
{
    public partial class Form5 : Form
    {

        private User authenticatedUser;
        public Form5(User user)
        {
            InitializeComponent();
            authenticatedUser = user; // Assign the authenticated user to the local variable

            // Additional initialization or actions based on the authenticated user can be added here
            // For example, you can set labels or perform other operations.
            usernameLabel.Text = $"Welcome, {authenticatedUser.Username}!";
        }
    }
}
