using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagerSystem
{
    public partial class managerLoginPage : Form
    {
        public managerLoginPage()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");

        }

        OleDbConnection Acconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\hotelSystem.accdb");

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool IsValidUser(string username, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(Acconnection.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM manager WHERE managerID = @Username AND password = @Password";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        private void Login_Click(object sender, EventArgs e)
        {
            string enteredUsername = adminIDText.Text;
            string enteredPassword = adminPasswordText.Text;

            if (IsValidUser(enteredUsername, enteredPassword))
            {
                managerHome managerHome= new managerHome();
                managerHome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!");
                adminIDText.Clear();
                adminPasswordText.Clear();
            }
        }

        private void adminIDText_TextChanged(object sender, EventArgs e)
        {
            string text = adminIDText.Text;
            adminIDText.Text = new string(text.Where(char.IsDigit).ToArray());
            adminIDText.SelectionStart = adminIDText.Text.Length;
        }

        private void adminPasswordText_TextChanged(object sender, EventArgs e)
        {
            adminPasswordText.UseSystemPasswordChar = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            homePage homePage= new homePage();
            homePage.Show();
            this.Hide();
        }

        private void managerLoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
