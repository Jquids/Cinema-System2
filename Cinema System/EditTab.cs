using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cinema_System
{
    public partial class EditTab : Form
    {
        private void insertMovie()
        {
            try
            {
                // Define the SQL query to insert a new movie
                string transactionQuery = "INSERT INTO Movies (nameMovie, priceMovie, screeningDate, endScreen, screeningRoom) " +
                                          "VALUES (@movieName, @priceMovie, @screeningDate, @endScreen, @screeningRoom)";

                // Create the MySqlCommand using the DBHelper connection
                using (MySqlCommand insertCommand = new MySqlCommand(transactionQuery, DBHelper.GetConnection()))
                {
                    // Add parameters for the insert query
                    insertCommand.Parameters.AddWithValue("@movieName", titleTextBox.Text);   // Movie Title
                    insertCommand.Parameters.AddWithValue("@priceMovie", priceTextBox.Text);  // Movie Price
                    insertCommand.Parameters.AddWithValue("@screeningDate", dateTimePicker1.Value.Date);  // Screening Date
                    insertCommand.Parameters.AddWithValue("@endScreen", dateTimePicker2.Value.Date);  // End Screen Date
                    insertCommand.Parameters.AddWithValue("@screeningRoom", screeningRoomTextBox.Text);  // Screening Room

                    // Execute the insert command
                    insertCommand.ExecuteNonQuery();

                    // Optionally, show a success message
                    MessageBox.Show("Movie inserted successfully!", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public EditTab()
        {
            InitializeComponent();
            DBHelper.EstabConnect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminTab admin = new AdminTab();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertMovie();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void movieIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
