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
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Cinema_System
{
    public partial class AdminTab : Form
    {
        private void deleteMovie()
        {
            try
            {
                // Ensure that the movie ID text box is not empty
                if (string.IsNullOrEmpty(movIDTextBox.Text))
                {
                    MessageBox.Show("Please enter a movie ID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Define the SQL query to delete the movie from the database
                string transactionQuery = "DELETE FROM Movies WHERE idMovies = @movieID";

                // Create the MySqlCommand using the DBHelper connection
                using (MySqlCommand deleteCommand = new MySqlCommand(transactionQuery, DBHelper.GetConnection()))
                {
                    // Add the movie ID parameter
                    deleteCommand.Parameters.AddWithValue("@movieID", movIDTextBox.Text);

                    // Execute the DELETE command
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No movie found with the given ID.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AdminTab()
        {
            InitializeComponent();
            DBHelper.EstabConnect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EditTab edittab = new EditTab();

            // Show the EditMovieTab form
            edittab.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            deleteMovie();
        }

        private void AdminTab_Load(object sender, EventArgs e)
        {

        }
    }
}
