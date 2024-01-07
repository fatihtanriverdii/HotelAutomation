using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagerSystem
{
   public partial class loginPage : Form
{
    OleDbConnection Acconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\hotelSystem.accdb");

    public loginPage()
    {
        InitializeComponent();
        this.BackColor = ColorTranslator.FromHtml("#162d55");
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void AdminPasswordText_TextChanged(object sender, EventArgs e)
    {
        staffPasswordText.UseSystemPasswordChar = true;
    }

    private void adminIDText_TextChanged(object sender, EventArgs e)
    {
        string text = staffIDText.Text;
        staffIDText.Text = new string(text.Where(char.IsDigit).ToArray());
        staffIDText.SelectionStart = staffIDText.Text.Length;
    }

    private void Login_Click(object sender, EventArgs e)
    {
        string enteredUsername = staffIDText.Text;
        string enteredPassword = staffPasswordText.Text;

        if (IsValidUser(enteredUsername, enteredPassword))
        {
            homePage home = new homePage();
            home.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Invalid Username or Password!");
            staffIDText.Clear();
            staffPasswordText.Clear();
        }
    }

    private bool IsValidUser(string username, string password)
    {
            Acconnection.Open();
            OleDbCommand AccessCommand = new OleDbCommand();
            AccessCommand.Connection = Acconnection;
          
            AccessCommand.CommandText = ("SELECT * FROM staff WHERE staffID = @Username AND password = @Password");
            AccessCommand.Parameters.AddWithValue("@Username", username);
            AccessCommand.Parameters.AddWithValue("@Password", password);
            OleDbDataReader reader = AccessCommand.ExecuteReader();
       
            if (reader.Read())
            {
                Acconnection.Close();
                return true;
            }

            Acconnection.Close();
            return false;

            
    }

        private void loginPage_Load(object sender, EventArgs e)
        {

        }

        private void adminID_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }
    }

}
