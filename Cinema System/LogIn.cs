using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_System
{
    public partial class LogIn : Form
    {
        private string urole;
        private string pass;
        private string usern;

        public LogIn()
        {
            InitializeComponent();
            DBHelper.EstabConnect(); // Ensure DBHelper establishes the connection
        }

        // Method to get user role based on credentials
        public void GetData()
        {
            string query = "SELECT roleUsers FROM Users WHERE nameUsers = @username AND passwordUsers = @password";
            MySqlCommand command = new MySqlCommand(query, DBHelper.GetConnection()); // Use DBHelper to get the connection

            // Safely add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@username", usern);
            command.Parameters.AddWithValue("@password", pass);

            try
            {
                // Check if the connection is open
                if (DBHelper.IsConnectionOpen())
                {
                    // Execute the query and retrieve data
                    MySqlDataReader reader = command.ExecuteReader();

                    // Check if data is returned
                    if (reader.Read())
                    {
                        // Get the roleUsers value from the reader
                        urole = reader["roleUsers"].ToString();
                    }
                    else
                    {
                        urole = ""; // Set to empty if no user found
                    }

                    // Always close the reader
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Database connection is not open.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Log the error (you can change this to a better logging mechanism for production)
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the login button click
        private void logInButt_Click(object sender, EventArgs e)
        {
            // Get the username and password from the textboxes
            usern = textBox1.Text;
            pass = textBox2.Text;

            // Get the user data (including role) from the database
            GetData();

            // Check if the role is "Cashier" and proceed accordingly
            if (urole == "Cashier")
            {
                CashierTab cashier = new CashierTab();
                cashier.Show();
                this.Hide(); // Hide the login form
            }
            else if (urole == "Admin")
            {
                AdminTab admin = new AdminTab();
                admin.Show();
                this.Hide();
            }
            else if (string.IsNullOrEmpty(urole)) // Handle the case where the user is not found
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Access denied. Invalid role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler for the back button click (to close the form)
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}