using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_System
{
    public partial class CashierTab : Form
    {
        string movieName; // Replace this with actual movie name from your context
        int[] mprice = new int[8];
        DateTime[] mdate = new DateTime[8];
        string[] seat = new string[32];
        DateTime[] edate = new DateTime[8];
        string[] mroom = new string[8];
        string selmroom;
        int selmprice, totalprice;
        DateTime selmdate;
        int selseatcounter = 0;
        int[] selectedRows = new int[32];
        int[] selectedColumns = new int[32];



        private void Seat_Click(object sender, EventArgs e)
        {
            // Define a 2D array for seats with button references
            Button[,] seats = new Button[8, 4]
            {
                { SeatA1, SeatA2, SeatA3, SeatA4 },
                { SeatB1, SeatB2, SeatB3, SeatB4 },
                { SeatC1, SeatC2, SeatC3, SeatC4 },
                { SeatD1, SeatD2, SeatD3, SeatD4 },
                { SeatE1, SeatE2, SeatE3, SeatE4 },
                { SeatF1, SeatF2, SeatF3, SeatF4 },
                { SeatG1, SeatG2, SeatG3, SeatG4 },
                { SeatH1, SeatH2, SeatH3, SeatH4 }
            };

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Check if the Text property of the clicked button is null or empty
                if (string.IsNullOrEmpty(clickedButton.Text))
                {
                    MessageBox.Show("This seat does not have a valid label. Please check the seat configuration.", "Invalid Seat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find the index (row and column) of the clicked seat in the 2D array
                int row = -1, col = -1;

                // Loop through the 2D array to find the button
                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        if (seats[i, j] == clickedButton)
                        {
                            row = i;
                            col = j;
                            break;
                        }
                    }
                    if (row != -1) break;
                }

                // Ensure seat is not already selected (disabled)
                if (clickedButton.Enabled && row != -1 && col != -1 && selseatcounter < selectedRows.Length)
                {
                    // Store the selected seat's row, column, and seat name
                    selectedRows[selseatcounter] = row;  // Store the row index
                    selectedColumns[selseatcounter] = col;  // Store the column index
                    seat[selseatcounter] = clickedButton.Text;  // Store seat name or identifier

                    // Check if seat is correctly assigned (optional validation)
                    if (seat[selseatcounter] == null)
                    {
                        MessageBox.Show("Failed to assign seat value. Please check seat configuration.", "Seat Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update the total price
                    totalprice += selmprice;
                    priceTotaDisplay.Text = totalprice.ToString();  // Display the updated total price

                    // Disable the button to mark it as selected and change its appearance
                    clickedButton.Enabled = false;
                    clickedButton.BackColor = SystemColors.ActiveCaptionText;  // Mark the selected seat

                    // Increment the seat counter for the next selection
                    selseatcounter++;
                }
                else
                {
                    // Optionally, notify the user if the seat is already selected or if no seats are available
                    MessageBox.Show("This seat is already selected or unavailable.", "Seat Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void resetseat()
        {
            totalprice = 0;
            priceTotaDisplay.Text = totalprice.ToString();
            selseatcounter = 0;
            // Array of all seat buttons to reset
            Button[,] Seat = new Button[8, 4]
            {
                { SeatA1, SeatA2, SeatA3, SeatA4 },
                { SeatB1, SeatB2, SeatB3, SeatB4 },
                { SeatC1, SeatC2, SeatC3, SeatC4 },
                { SeatD1, SeatD2, SeatD3, SeatD4 },
                { SeatE1, SeatE2, SeatE3, SeatE4 },
                { SeatF1, SeatF2, SeatF3, SeatF4 },
                { SeatG1, SeatG2, SeatG3, SeatG4 },
                { SeatH1, SeatH2, SeatH3, SeatH4 }
            };

            // Iterate through all the seat buttons and reset their states
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    // Enable the button (i.e., make it selectable again)
                    Seat[x, y].Enabled = true;

                    // Reset the button color to default (Control color is the default gray background)
                    Seat[x, y].BackColor = SystemColors.Control;
                }
            }
        }
        public void checkroom(string mroom)
        {
            // Validate mroom for allowed values to avoid SQL injection
            if (!IsValidRoomName(mroom))
            {
                MessageBox.Show("Invalid room name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM " + mroom; // Dynamically add the table name
            MySqlCommand command = new MySqlCommand(query, DBHelper.GetConnection()); // Use DBHelper to get the connection

            try
            {
                if (DBHelper.IsConnectionOpen())
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    Button[,] Seat = new Button[8, 4]
                    {
                        { SeatA1, SeatA2, SeatA3, SeatA4 },
                        { SeatB1, SeatB2, SeatB3, SeatB4 },
                        { SeatC1, SeatC2, SeatC3, SeatC4 },
                        { SeatD1, SeatD2, SeatD3, SeatD4 },
                        { SeatE1, SeatE2, SeatE3, SeatE4 },
                        { SeatF1, SeatF2, SeatF3, SeatF4 },
                        { SeatG1, SeatG2, SeatG3, SeatG4 },
                        { SeatH1, SeatH2, SeatH3, SeatH4 }
                    };

                    while (reader.Read())
                    {
                        DateTime seatdate = Convert.ToDateTime(reader["dateScreen"]);

                        // Compare only the date part of seatdate with the current date
                        if (seatdate.Date == DateTime.Now.Date)
                        {
                            // Handle seat data if necessary
                            int seatnum = Convert.ToInt32(reader["seatNo"]);
                            int seatLet = Convert.ToInt32(reader["seatLet"]);

                            // Disable the seat and change its color
                            Seat[seatLet, seatnum].Enabled = false;
                            Seat[seatLet, seatnum].BackColor = SystemColors.ActiveCaptionText;
                        }
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Database connection is not open.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidRoomName(string roomName)
        {
            string[] validRooms = { "Room1", "Room2", "Room3", "Room4", "Room5", "Room6", "Room7", "Room8" };
            return validRooms.Contains(roomName);
        }
private void finalizeTransac()
{
            try
            {
                decimal totalPrice = 0; // Initialize total price

                for (int i = 0; i < seat.Length; i++)
                {
                    if (seat[i] != null)
                    {
                        // First, insert into the Transaction table
                        string transactionQuery = "INSERT INTO Transactions (dateTransac, seat, dateShowing) VALUES (@datenow, @seat, @dateshow)";
                        MySqlCommand transactionCommand = new MySqlCommand(transactionQuery, DBHelper.GetConnection());

                        // Add parameters for the Transaction table
                        transactionCommand.Parameters.AddWithValue("@datenow", DateTime.Now.Date);
                        transactionCommand.Parameters.AddWithValue("@seat", seat[i]);
                        transactionCommand.Parameters.AddWithValue("@dateshow", dateTimePicker1.Value.Date);

                        // Execute the insert command for the Transaction table
                        transactionCommand.ExecuteNonQuery();

                        // Now, insert into the dynamic room table (selmroom)
                        string roomQuery = "INSERT INTO " + selmroom + " (seatLet, seatNo, dateScreen) VALUES (@seatLet, @seatNo, @dateScreen)";
                        MySqlCommand roomCommand = new MySqlCommand(roomQuery, DBHelper.GetConnection());

                        // Add parameters for the dynamic room table
                        roomCommand.Parameters.AddWithValue("@seatLet", selectedRows[i]);
                        roomCommand.Parameters.AddWithValue("@seatNo", selectedColumns[i]);
                        roomCommand.Parameters.AddWithValue("@dateScreen", dateTimePicker1.Value.Date);

                        // Execute the insert command for the room table
                        roomCommand.ExecuteNonQuery();

                        // Assuming the price per seat is a fixed value
                        totalPrice += Convert.ToInt32(priceTotaDisplay.Text); // Add the price for each seat
                    }

                }
                // Display a message box with the total price, movie name, and the number of selected seats
                string seatsDetails = string.Join(" ", seat); // Concatenate the selected seat numbers
                MessageBox.Show($"Movie: {movieName}\nSeats: {seatsDetails}\nTotal Price: ${totalPrice}",
                                "Transaction Finalized", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        public void GetData()
        {
            // Define the SQL query to get all movie details from the Movies table
            string query = "SELECT * FROM Movies";
            MySqlCommand command = new MySqlCommand(query, DBHelper.GetConnection()); // Create a command to interact with the database
            try
            {
                // Check if the database connection is open
                if (DBHelper.IsConnectionOpen())
                {
                    // Execute the query and retrieve the data using a MySQL DataReader
                    MySqlDataReader reader = command.ExecuteReader();

                    // Create an array of buttons that will be used to display movie information
                    Button[] ButtMoves = { ButtMove1, ButtMove2, ButtMove3, ButtMove4, ButtMove5, ButtMove6, ButtMove7, ButtMove8 };
                    // Create an array of labels to display price
                    Label[] priceDisplayArray = { priceDisplay1, priceDisplay2, priceDisplay3, priceDisplay4, priceDisplay5, priceDisplay6, priceDisplay7, priceDisplay8 };

                    // Initialize the index variable to 0, which will be used to populate the buttons
                    int i = 0;

                    // Loop through each row of data returned by the query and assign it to the buttons
                    while (reader.Read() && i < ButtMoves.Length)
                    {
                        // Retrieve screening dates from the database
                        DateTime chesdate = Convert.ToDateTime(reader["screeningDate"]);
                        DateTime cheedate = Convert.ToDateTime(reader["endScreen"]);

                        // Check if the movie is currently showing (i.e., within the valid date range)
                        if (chesdate.Date <= DateTime.Now.Date && DateTime.Now.Date <= cheedate.Date)
                        {
                            // Set the Button's Text to the movie name
                            ButtMoves[i].Text = reader["nameMovie"].ToString();
                            // Set text to display price
                            priceDisplayArray[i].Text = "₱" + (reader["priceMovie"]).ToString();

                            // Store other movie details in arrays for later use
                            mprice[i] = Convert.ToInt32(reader["priceMovie"]);
                            mdate[i] = Convert.ToDateTime(reader["screeningDate"]);
                            edate[i] = Convert.ToDateTime(reader["endScreen"]);
                            mroom[i] = reader["screeningRoom"].ToString();

                            // Handle the movie poster image (if available)
                            if (reader["posterLocation"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["posterLocation"];  // Retrieve the poster image as a byte array

                                // Use MemoryStream to convert the byte array into an image
                                using (MemoryStream ms = new MemoryStream(imageBytes))  // Ensure MemoryStream is disposed properly
                                {
                                    // Set the BackgroundImage of the button using the movie poster image
                                    ButtMoves[i].BackgroundImage = Image.FromStream(ms);
                                    ButtMoves[i].BackgroundImageLayout = ImageLayout.Stretch; // Stretch the image to fit the button
                                }
                            }
                            else
                            {
                            }

                            // Increment the index to process the next movie and button
                            i++;
                        }
                    }

                    // If there are any remaining buttons without data, set their text to "No Movie" as a fallback
                    for (; i < ButtMoves.Length; i++)
                    {
                        ButtMoves[i].Text = "No Movie";  // Set default text for empty buttons
                        ButtMoves[i].BackgroundImage = null;  // Optionally clear background image for empty buttons
                    }

                    // Always close the reader to release database resources
                    reader.Close();
                }
                else
                {
                    // If the database connection is not open, show an error message
                    MessageBox.Show("Database connection is not open.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, display an error message with the exception details
                MessageBox.Show("Error executing query: " + ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public CashierTab()
        {
            InitializeComponent();
            DBHelper.EstabConnect();
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }





        private void ButtMove1_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[0];
            selmroom = mroom[0];
            selmdate = mdate[0];
            checkroom(selmroom);
            movieName = ButtMove1.Text;
        }

        private void ButtMove2_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[1];
            selmroom = mroom[1];
            selmdate = mdate[1];
            checkroom(selmroom);
            movieName = ButtMove2.Text;
        }

        private void ButtMove3_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[2];
            selmroom = mroom[2];
            selmdate = mdate[2];
            checkroom(selmroom);
            movieName = ButtMove3.Text;
        }

        private void ButtMove4_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[3];
            selmroom = mroom[3];
            selmdate = mdate[3];
            checkroom(selmroom);
            movieName = ButtMove4.Text;
        }

        private void ButtMove5_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[4];
            selmroom = mroom[4];
            selmdate = mdate[4];
            checkroom(selmroom);
            movieName = ButtMove5.Text;
        }

        private void ButtMove6_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[5];
            selmroom = mroom[5];
            selmdate = mdate[5];
            checkroom(selmroom);
            movieName = ButtMove6.Text;
        }

        private void ButtMove7_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[6];
            selmroom = mroom[6];
            selmdate = mdate[6];
            checkroom(selmroom);
            movieName = ButtMove7.Text;
        }

        private void ButtMove8_Click(object sender, EventArgs e)
        {
            resetseat();
            selmprice = mprice[7];
            selmroom = mroom[7];
            selmdate = mdate[7];
            checkroom(selmroom);
            movieName = ButtMove8.Text;
        }

        private void FinalButt_Click(object sender, EventArgs e)
        {
            finalizeTransac();
        }

    }
}
