using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagerSystem
{
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");

        }

        private void homePage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getReservation getReservation = new getReservation();
            getReservation.Show();
            this.Hide();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            loginPage loginPage = new loginPage();
            loginPage.Show();
            this.Hide();
        }

        private void managerButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            managerLoginPage loginPage = new managerLoginPage();   
            loginPage.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            editReservation editPage = new editReservation();
            editPage.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            statistics statisctic= new statistics();
            statisctic.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            customerView customerPage = new customerView();
            customerPage.Show();
            this.Hide();
        }
    }
}
