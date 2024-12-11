using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagerSystem
{
    public partial class editReservation : Form
    {
        public int classicPrice = 21;
        public int suitPrice = 44;
        public editReservation()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");

        }

        SqlConnection Acconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private void editReservation_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void getInfo_Click_1(object sender, EventArgs e)
        {
            string identityNumber = textBox1.Text;
            getInfoFunct(identityNumber);
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            homePage.Show();
            this.Hide();
        }
        private void getInfoFunct(string identityNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM customers WHERE identityNumber = @IdentityNumber";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdentityNumber", identityNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                identityNoText.Text = reader["identityNumber"].ToString();
                                nameText.Text = reader["cName"].ToString();
                                surnameText.Text = reader["cSurname"].ToString();
                                phoneText.Text = reader["telNumber"].ToString();
                                emailText.Text = reader["email"].ToString();
                                inDateText.Text = reader["startDate"].ToString();
                                outText.Text = reader["endDate"].ToString();
                                guestsText.Text = reader["bedCount"].ToString();
                                roomText.Text = reader["roomNumber"].ToString();
                                totalPriceText.Text = reader["totalPrice"].ToString();

                                identityNoText.Visible = true;
                                nameText.Visible = true;
                                surnameText.Visible = true;
                                phoneText.Visible = true;
                                emailText.Visible = true;
                                inDateText.Visible = true;
                                outText.Visible = true;
                                guestsText.Visible = true;
                                roomText.Visible = true;
                                totalPriceText.Visible = true;
                                update.Visible = true;
                                cancel.Visible = true;
                                delete.Visible = true;

                                string updateQuery = "UPDATE rooms SET roomIsFull = 0 WHERE roomNumber = @RoomNumberC", roomNumberC = reader["roomNumber"].ToString();
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@RoomNumberC", roomNumberC);

                                    updateCommand.ExecuteNonQuery();
                                }


                                string queryRoom = "SELECT * FROM rooms WHERE roomNumber = @RoomNumber", roomNumber = reader["roomNumber"].ToString();
                                using (SqlCommand commandRoom = new SqlCommand(queryRoom, connection))
                                {
                                    commandRoom.Parameters.AddWithValue("@RoomNumber", roomNumber);

                                    using (SqlDataReader readerR = commandRoom.ExecuteReader())
                                    {
                                        if (readerR.Read())
                                        {
                                            string roomType = readerR["roomType"].ToString();
                                            if (roomType.Equals("classic"))
                                            {
                                                classic.Checked = true;
                                            }
                                            else if (roomType.Equals("suit"))
                                            {
                                                suit.Checked = true;
                                            }
                                            classic.Visible = true;
                                            suit.Visible = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Müşteri bulunamadı");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }


        private void editReservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Acconnection.State == ConnectionState.Open)
            {
                Acconnection.Close();
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void classic_CheckedChanged_1(object sender, EventArgs e)
        {
            if (classic.Checked == true)
            {
                roomText.Items.Clear();
                using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT roomNumber FROM rooms WHERE roomIsFull = 0 AND roomType = 'classic' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string roomNumber = reader["RoomNumber"].ToString();
                                roomText.Items.Add(roomNumber);
                            }
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void suit_CheckedChanged_1(object sender, EventArgs e)
        {
            if (suit.Checked == true)
            {
                roomText.Items.Clear();
                using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT roomNumber FROM rooms WHERE roomIsFull = 0 AND roomType = 'suit' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string roomNumber = reader["RoomNumber"].ToString();
                                roomText.Items.Add(roomNumber);
                            }
                            connection.Close();
                        }
                    }
                }
            }
        }


        private void update_Click_1(object sender, EventArgs e)
        {
            string customerId = textBox1.Text.ToString();
            int Id = Convert.ToInt32(customerId);

            string name = nameText.Text;
            string surname = surnameText.Text;
            string phoneNumber = phoneText.Text;
            string email = emailText.Text;
            DateTime checkInDate = inDateText.Value;
            DateTime checkOutDate = outText.Value;
            string roomNumber = roomText.SelectedItem.ToString();
            int guest = (int)guestsText.Value;
            string totalPrice = totalPriceText.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "UPDATE customers SET identityNumber = @CustomerId, cName = @Name, cSurname = @Surname, telNumber = @TelNumber, email = @Email, startDate = @StartDate, endDate = @EndDate, bedCount = @BedCount, roomNumber = @RoomNumber, totalPrice = @TotalPrice WHERE identityNumber = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@CustomerId", OleDbType.Integer).Value = Id;
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@TelNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@StartDate", checkInDate);
                        command.Parameters.AddWithValue("@EndDate", checkOutDate);
                        command.Parameters.AddWithValue("@BedCount", guest);
                        command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                        command.Parameters.AddWithValue("@TotalPrice", totalPrice);

                        int rowsAffected = command.ExecuteNonQuery();


                        string updateQuery = "UPDATE rooms SET roomIsFull = 1 WHERE roomNumber = @RoomNumberC";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@RoomNumberC", roomNumber);

                            updateCommand.ExecuteNonQuery();
                        }

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Müşteri bilgileri güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme yapılamadı. Müşteri bulunamadı veya hiçbir şey değiştirilmedi. Rows Affected: " + rowsAffected);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }



        private void delete_Click_1(object sender, EventArgs e)
        {
            string customerId = textBox1.Text.ToString();
            int Id = Convert.ToInt32(customerId);


            try
            {
                using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM customers WHERE identityNumber = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@CustomerId", OleDbType.Integer).Value = Id;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record with the specified ID was found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            homePage.Show();
            this.Hide();
        }

        private void roomText_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = inDateText.Value;
            DateTime checkOutDate = outText.Value;

            if (checkInDate != null && checkOutDate != null)
            {
                TimeSpan span = checkOutDate - checkInDate;
                int dayDifference = span.Days;
                int totalPrice = 0;
                if (classic.Checked)
                {
                    totalPrice = dayDifference * classicPrice;
                }

                if (suit.Checked)
                {
                    totalPrice = dayDifference * suitPrice;
                }

                totalPriceText.Text = totalPrice.ToString() + "$";

            }
        }

        private void inDateText_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = inDateText.Value;
            DateTime checkOutDate = outText.Value;

            if (checkInDate != null && checkOutDate != null)
            {
                TimeSpan span = checkOutDate - checkInDate;
                int dayDifference = span.Days;
                int totalPrice = 0;
                if (classic.Checked)
                {
                    totalPrice = dayDifference * classicPrice;
                }

                if (suit.Checked)
                {
                    totalPrice = dayDifference * suitPrice;
                }

                totalPriceText.Text = totalPrice.ToString() + "$";

            }
        }

        private void outText_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = inDateText.Value;
            DateTime checkOutDate = outText.Value;

            if (checkInDate != null && checkOutDate != null)
            {
                TimeSpan span = checkOutDate - checkInDate;
                int dayDifference = span.Days;
                int totalPrice = 0;
                if (classic.Checked)
                {
                    totalPrice = dayDifference * classicPrice;
                }

                if (suit.Checked)
                {
                    totalPrice = dayDifference * suitPrice;
                }

                totalPriceText.Text = totalPrice.ToString() + "$";

            }
        }
    }
}
