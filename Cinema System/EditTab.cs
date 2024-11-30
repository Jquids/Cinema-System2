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
        string roomsel;
        byte[] imageBytes;
        DateTime sdate, edate;
        public void GetData()
        {
            // Get the date values from the DateTimePickers
            DateTime sdate = dateTimePicker1.Value.Date;
            DateTime edate = dateTimePicker2.Value.Date;

            // Define the SQL query with parameters to prevent SQL injection
            string query = "SELECT DISTINCT screeningRoom FROM Movies WHERE (screeningDate BETWEEN @sdate AND @edate) OR (endScreen BETWEEN @sdate AND @edate) OR (screeningDate <= @sdate AND endScreen >= @edate)";

            // Create the MySqlCommand with the query and connection
            MySqlCommand command = new MySqlCommand(query, DBHelper.GetConnection());

            try
            {
                // Open the connection if it's not already open
                if (DBHelper.IsConnectionOpen())
                {
                    // Add parameters to the command to safely insert values into the query
                    command.Parameters.AddWithValue("@sdate", sdate);
                    command.Parameters.AddWithValue("@edate", edate);
                    command.Parameters.AddWithValue("@ndate", DateTime.Now.Date);

                    // Execute the query and retrieve data using a MySQL DataReader
                    MySqlDataReader reader = command.ExecuteReader();

                    // Loop through each row of data returned by the query
                    while (reader.Read())
                    {
                        // Get the room name from the database
                        string room = reader["screeningRoom"].ToString();

                        // Use a switch statement to disable the corresponding room button based on the room name
                        switch (room)
                        {
                            case "Room1":
                                Room1.Enabled = false;
                                Room1.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room2":
                                Room2.Enabled = false;
                                Room2.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room3":
                                Room3.Enabled = false;
                                Room3.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room4":
                                Room4.Enabled = false;
                                Room4.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room5":
                                Room5.Enabled = false;
                                Room5.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room6":
                                Room6.Enabled = false;
                                Room6.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room7":
                                Room7.Enabled = false;
                                Room7.BackColor = SystemColors.ActiveCaptionText;
                                break;
                            case "Room8":
                                Room8.Enabled = false;
                                Room8.BackColor = SystemColors.ActiveCaptionText;
                                break;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Display error message if something goes wrong
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void insertMovie()
        {
            try
            {
                // Validate input fields before attempting to insert
                if (string.IsNullOrEmpty(titleTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text) || imageBytes == null)
                {
                    MessageBox.Show("Please make sure all required fields are filled, including selecting an image.",
                                    "Missing Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Exit the method early if validation fails
                }

                // Define the SQL query to insert a new movie
                string transactionQuery = "INSERT INTO Movies (nameMovie, priceMovie, screeningDate, endScreen, screeningRoom, posterLocation) " +
                                          "VALUES (@movieName, @priceMovie, @screeningDate, @endScreen, @screeningRoom, @poster)";

                // Using statement ensures that resources like connection and command are disposed of properly
                using (MySqlConnection connection = DBHelper.GetConnection())
                {

                    // Create the MySqlCommand using the open connection
                    using (MySqlCommand insertCommand = new MySqlCommand(transactionQuery, connection))
                    {
                        // Add parameters for the insert query
                        insertCommand.Parameters.AddWithValue("@movieName", titleTextBox.Text);   // Movie Title
                        insertCommand.Parameters.AddWithValue("@priceMovie", priceTextBox.Text);  // Movie Price
                        insertCommand.Parameters.AddWithValue("@screeningDate", dateTimePicker1.Value.Date);  // Screening Date
                        insertCommand.Parameters.AddWithValue("@endScreen", dateTimePicker2.Value.Date);  // End Screen Date
                        insertCommand.Parameters.AddWithValue("@screeningRoom", roomsel);  // Screening Room
                        insertCommand.Parameters.AddWithValue("@poster", imageBytes);  // Image Bytes for Poster

                        // Execute the insert command
                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // If the query was successful, notify the user
                            MessageBox.Show("Movie inserted successfully!", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            // If no rows were affected, something might have gone wrong
                            MessageBox.Show("Failed to insert the movie. Please try again.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static void selected(Control a)
        {
            if (a.BackColor == SystemColors.Control)
                a.BackColor = SystemColors.ActiveCaption;
            else
                a.BackColor = SystemColors.Control;
        }
        public void roomclicked(Button clickedRoomButton)
        {
            ResetRooms();
            GetData();
            // Check which button was clicked by using its Name property
            switch (clickedRoomButton.Name)
            {
                case "Room1":
                    // Logic for Room1 button clicked
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText; // Change color as feedback
                    clickedRoomButton.Enabled = false; // Disable button
                    roomsel = "Room1";
                    break;

                case "Room2":
                    // Logic for Room2 button clicked
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room2";
                    break;

                case "Room3":
                    // Logic for Room3 button clicked
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room3";
                    break;

                case "Room4":
                    // Logic for Room4 button clicked
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room4";
                    break;

                case "Room5":
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room5";
                    break;

                case "Room6":
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room6";
                    break;

                case "Room7":
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room7";
                    break;

                case "Room8":
                    clickedRoomButton.BackColor = SystemColors.ActiveCaptionText;
                    clickedRoomButton.Enabled = false;
                    roomsel = "Room8";
                    break;

                default:
                    MessageBox.Show("Unknown room.");
                    break;
            }
            roomDisplay.Text = roomsel;
        }
        public EditTab()
        {
            InitializeComponent();
            GetData();
            DBHelper.EstabConnect();
            Room1.Click += RoomButton_Click;
            Room2.Click += RoomButton_Click;
            Room3.Click += RoomButton_Click;
            Room4.Click += RoomButton_Click;
            Room5.Click += RoomButton_Click;
            Room6.Click += RoomButton_Click;
            Room7.Click += RoomButton_Click;
            Room8.Click += RoomButton_Click;
        }
        public void ResetRooms()
        {
            // List of all room buttons
            Button[] roomButtons = new Button[] { Room1, Room2, Room3, Room4, Room5, Room6, Room7, Room8 };

            // Loop through each room button and reset its properties
            foreach (Button roomButton in roomButtons)
            {
                // Re-enable the button
                roomButton.Enabled = true;

                // Restore the original background color (you can customize this as per the original design)
                roomButton.BackColor = SystemColors.Control; // Default color
            }
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
            // Configure the file dialog to accept only image files
            posterFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp";
            posterFileDialog.Title = "Select a Poster Image";
            posterFileDialog.ShowDialog();
        }
        private void posterFileDialog_FileOk(object sender, CancelEventArgs e)
        {

            // Get the selected file path
            string selectedFilePath = posterFileDialog.FileName;

            // Check if the file exists and is not null
            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("No file selected or file doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Define an array of allowed image file extensions
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp" };

            // Get the file extension of the selected file
            string fileExtension = Path.GetExtension(selectedFilePath).ToLower();

            // Check if the file has a valid image extension
            if (allowedExtensions.Contains(fileExtension))
            {
                // The file is a valid image, read it as bytes
                try
                {
                    imageBytes = File.ReadAllBytes(selectedFilePath); // Read the file as byte array

                    // Optionally, show a message indicating that the file has been successfully loaded
                    MessageBox.Show("Image loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // The file is not a valid image
                MessageBox.Show("Please select a valid image file (JPG, PNG, etc.).", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Cancel the file dialog if the file is not a valid image
                e.Cancel = true;
            }
        }
        private void RoomButton_Click(object sender, EventArgs e)
        {
            // Cast sender to a Button
            Button clickedRoomButton = sender as Button;

            // If the clicked button is valid, call roomclicked method
            if (clickedRoomButton != null)
            {
                roomclicked(clickedRoomButton);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ResetRooms();
            GetData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ResetRooms();
            GetData();
        }

    }
}
