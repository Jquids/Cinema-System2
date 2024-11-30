using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cinema_System
{
    public static class DBHelper
    {
        private static MySqlConnection connection;

        // Method to establish the connection
        public static void EstabConnect()
        {
            // Connection string (adjust with your credentials)
            string connectionString = "Server=127.0.0.1;Database=mydb;User ID=root;"; // Replace 'my_password' with your actual MySQL password

            // Create the connection object
            connection = new MySqlConnection(connectionString);

            try
            {
                // Open the connection if it's not already open
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                // If there is an error, show a message box and log the exception
                MessageBox.Show("Error connecting to the database: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }
        }

        // Method to close the connection
        public static void CloseConnection()
        {
            // Ensure the connection is open before closing it
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    MessageBox.Show("Connection closed successfully.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.WriteLine("Connection closed.");
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during closing
                    MessageBox.Show("Error closing the database connection: " + ex.Message, "Close Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Error closing the database connection: " + ex.Message);
                }
            }
        }

        // Method to get the connection object (useful for other classes to execute queries)
        public static MySqlConnection GetConnection()
        {
            return connection;
        }

        // Method to check if the connection is open
        public static bool IsConnectionOpen()
        {
            return connection != null && connection.State == System.Data.ConnectionState.Open;
        }
    }
}