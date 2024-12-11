using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagerSystem
{
    public partial class getReservation : Form
    {
        public int classicPrice = 21;
        public int suitPrice = 44;
        public getReservation()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");

        }

        SqlConnection Acconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void getReservation_Load(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
            {


                connection.Open();
                string query2 = "SELECT internationalCode FROM country_codes WHERE internationalCode IS NOT null ORDER BY internationalCode ASC";
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string internationalCode = reader["internationalCode"].ToString();
                            comboBox2.Items.Add(internationalCode);
                        }
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = dateTimePicker1.Value;
            DateTime checkOutDate = dateTimePicker2.Value;

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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            homePage.Show();
            this.Hide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int identityNo = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string surname = textBox3.Text;
            string countryCode = comboBox2.Text;
            string phoneNumber = maskedTextBox1.Text;
            string newPhoneNumber = countryCode + " " + phoneNumber;
            string email = textBox4.Text;
            DateTime checkInDate = dateTimePicker1.Value;
            DateTime checkOutDate = dateTimePicker2.Value;
            string roomNumber = comboBox1.SelectedItem.ToString();
            int guest = (int)numericUpDown1.Value;
            string totalPrice = totalPriceText.Text;

            using (SqlConnection connection = new SqlConnection(Acconnection.ConnectionString))
            {


                connection.Open();
                string query = "INSERT INTO customers (identityNumber, cName, cSurname, telNumber, email, startDate, endDate, bedCount, roomNumber, totalPrice) " +
               "VALUES (@IdentityNo, @Name, @Surname, @PhoneNumber, @Email, " +
               "@CheckInDate, @CheckOutDate, @Guest, @RoomNumber, @TotalPrice)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdentityNo", identityNo);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@PhoneNumber", newPhoneNumber);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    command.Parameters.AddWithValue("@Guest", guest);
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);



                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string updateQuery = "UPDATE rooms SET roomIsFull = 1 WHERE roomNumber = @RoomNumber";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@RoomNumber", roomNumber);

                            updateCommand.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data has been successfully added.");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                        comboBox2.Text = null;
                        maskedTextBox1.Text = null;
                        textBox4.Text = null;
                        comboBox1.Text = null;
                        numericUpDown1.Value = 1;
                        totalPriceText = null;
                    }
                    else
                    {
                        MessageBox.Show("Data may not have been added.");

                    }



                }
                connection.Close();


            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void classic_CheckedChanged(object sender, EventArgs e)
        {
            totalPriceText.Text = "0$";
            comboBox1.Items.Clear();
            comboBox1.Text = null;
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
                            comboBox1.Items.Add(roomNumber);
                        }
                        connection.Close();
                    }
                }
            }
        }

        private void suit_CheckedChanged(object sender, EventArgs e)
        {
            totalPriceText.Text = "0$";
            comboBox1.Items.Clear();
            comboBox1.Text = null;
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
                            comboBox1.Items.Add(roomNumber);
                        }
                        connection.Close();
                    }
                }
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void totalPriceText_Click(object sender, EventArgs e)
        {

        }
    }
}