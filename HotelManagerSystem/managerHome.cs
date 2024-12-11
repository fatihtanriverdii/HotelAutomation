using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagerSystem
{
    public partial class managerHome : Form
    {
        public managerHome()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");
        }


        private void managerHome_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            managerLoginPage managerLoginPage = new managerLoginPage();
            managerLoginPage.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            staffManage staffPage = new staffManage();
            staffPage.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            adminManage adminManage = new adminManage();
            adminManage.Show();
            this.Hide();
        }
    }
}
