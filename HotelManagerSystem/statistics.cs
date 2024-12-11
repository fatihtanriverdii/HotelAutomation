using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagerSystem
{
    public partial class statistics : Form
    {
        public statistics()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");
            DrawRoomChart();

        }

        int occupiedCount;
        int emptyCount;
        SqlConnection Aconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private void statistics_Load(object sender, EventArgs e)
        {
            int suitCount = 0;
            int classicCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(Aconnection.ConnectionString))
                {
                    connection.Open();

                    // Suit odalarda bulunan müşteri sayısı
                    string suitQuery = "SELECT COUNT(*) FROM customers WHERE roomNumber IN (SELECT roomNumber FROM rooms WHERE roomType = 'suit')";
                    using (SqlCommand suitCommand = new SqlCommand(suitQuery, connection))
                    {
                        suitCount = Convert.ToInt32(suitCommand.ExecuteScalar());
                    }

                    // Classic odalarda bulunan müşteri sayısı
                    string classicQuery = "SELECT COUNT(*) FROM customers WHERE roomNumber IN (SELECT roomNumber FROM rooms WHERE roomType = 'classic')";
                    using (SqlCommand classicCommand = new SqlCommand(classicQuery, connection))
                    {
                        classicCount = Convert.ToInt32(classicCommand.ExecuteScalar());
                    }
                }

                // İlgili sayıları kullanabilirsiniz (suitCount ve classicCount)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }


            chart1.Series["Classic"].Points.Add(classicCount);
            chart1.Series["Suit"].Points.Add(suitCount);
        }
       
        private void DrawRoomChart()
        {
            occupiedCount = GetRoomCount(true);
            emptyCount = GetRoomCount(false);

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);

                DrawPieChart(g, occupiedCount, emptyCount);
            }

            pictureBox1.Image = bitmap;
        }

        private int GetRoomCount(Boolean status)
        {
            int count = 0;

            try
            {
                Aconnection.Open();

                string sqlText = "SELECT COUNT(*) FROM rooms WHERE roomIsFull = @status";
                SqlCommand AccessCommand = new SqlCommand(sqlText, Aconnection);
                AccessCommand.Parameters.AddWithValue("@status", status);

                count = (int)AccessCommand.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                Aconnection.Close();
            }

            return count;
        }

        private void DrawPieChart(Graphics g, int occupiedCount, int emptyCount)
        {
            Rectangle rect = new Rectangle(10, 10, pictureBox1.Width - 20, pictureBox1.Height - 20);
        
            float occupiedAngle = 360f * occupiedCount / (occupiedCount + emptyCount);
            using (SolidBrush brush = new SolidBrush(Color.MediumPurple))
            {
                g.FillPie(brush, rect, 0, occupiedAngle);
            }

            
            float emptyAngle = 360f * emptyCount / (occupiedCount + emptyCount);
            using (SolidBrush brush = new SolidBrush(Color.Yellow))
            {
                g.FillPie(brush, rect, occupiedAngle, emptyAngle);
            }
        }

       

        private void label21_Click(object sender, EventArgs e)
        {

        }
       
        private void backButton_Click(object sender, EventArgs e)
        {
            homePage home = new homePage();
            home.Show();
            this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            double occupiedPercentage = (double)occupiedCount / (occupiedCount + emptyCount) * 100;
            double emptyPercentage = (double)emptyCount / (occupiedCount + emptyCount) * 100;

            string tooltipText = $"Occupied Rooms: {occupiedCount} (%{occupiedPercentage:F2})\nEmpty Rooms: {emptyCount} (%{emptyPercentage:F2})";
            toolTip1.SetToolTip(pictureBox1, tooltipText);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {


        }
    }
}

