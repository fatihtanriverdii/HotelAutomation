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
    public partial class staffManage : Form
    {
        public staffManage()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");
        }

        OleDbConnection Aconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\hotelSystem.accdb");


        private void staffManage_Load(object sender, EventArgs e)
        {

        }

        private void showInformation()
        {
            listView1.Items.Clear();
            Aconnection.Open();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Enabled = true;
            textBox4.Clear();
            comboBox1.SelectedItem = null;
            OleDbCommand AccessCommand = new OleDbCommand();
            AccessCommand.Connection = Aconnection;
            AccessCommand.CommandText = ("Select * from staff");
            OleDbDataReader read = AccessCommand.ExecuteReader();

            while (read.Read())
            {
                ListViewItem addNew = new ListViewItem();
                addNew.Text = read["staffID"].ToString();
                addNew.SubItems.Add(read["staffName"].ToString());
                addNew.SubItems.Add(read["staffPhone"].ToString());
                addNew.SubItems.Add(read["position"].ToString());
                addNew.SubItems.Add(read["password"].ToString());
                listView1.Items.Add(addNew);
            }
            Aconnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showInformation();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Aconnection.Open();
            string sqlText = "INSERT INTO staff (staffID, [password], staffName, staffPhone, [position]) " +
                         "VALUES (@staffID, @password, @staffName, @staffPhone, @position)";

            OleDbCommand AccessCommand = new OleDbCommand(sqlText, Aconnection);
            AccessCommand.Parameters.AddWithValue("@staffID", Convert.ToInt32(textBox5.Text));
            AccessCommand.Parameters.AddWithValue("@password", textBox3.Text);
            AccessCommand.Parameters.AddWithValue("@staffName", textBox1.Text);
            AccessCommand.Parameters.AddWithValue("@staffPhone", textBox2.Text);
            AccessCommand.Parameters.AddWithValue("@position", comboBox1.SelectedItem?.ToString() ?? "");

            AccessCommand.ExecuteNonQuery();
            Aconnection.Close();
            showInformation();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Enabled = true;
            textBox5.Clear();
            comboBox1.SelectedItem = null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void getButton_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            string sID = textBox4.Text.ToString();
            int ID = Convert.ToInt32(sID);
            getInfoFunc(ID);
        }

        private void getInfoFunc(int ID)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Aconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM staff WHERE staffID = @staffID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@staffID", ID);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox5.Text = reader["staffID"].ToString();
                                textBox3.Text = reader["password"].ToString();
                                textBox1.Text = reader["staffName"].ToString();
                                textBox2.Text = reader["staffPhone"].ToString();
                                comboBox1.SelectedItem = reader["position"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No member with the specified ID was found.");
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                                comboBox1.SelectedItem = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string sID = textBox4.Text.ToString();
            int ID = Convert.ToInt32(sID);
            Aconnection.Open();

            OleDbCommand AccessCommand = new OleDbCommand();
            AccessCommand.Connection = Aconnection;
            AccessCommand.CommandText = "DELETE FROM staff WHERE staffID = @sID";
            AccessCommand.Parameters.AddWithValue("@sID", ID);
            int rowsAffected = AccessCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully.");
            }
            else
            {
                MessageBox.Show("No record with the specified ID was found.");
            }

            Aconnection.Close();
            showInformation();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Enabled = true;
            textBox5.Clear();
            comboBox1.SelectedItem = null;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string sID = textBox4.Text.ToString();
            int ID = Convert.ToInt32(sID);
            Aconnection.Open();

            string sqlText = "UPDATE staff SET staffID = @staffID, [password] = @password, staffName = @staffName, staffPhone = @staffPhone, [position] = @position WHERE staffID = @staffID";

            OleDbCommand AccessCommand = new OleDbCommand(sqlText, Aconnection);
            AccessCommand.Parameters.AddWithValue("@staffID", ID);
            AccessCommand.Parameters.AddWithValue("@password", textBox3.Text);
            AccessCommand.Parameters.AddWithValue("@staffName", textBox1.Text);
            AccessCommand.Parameters.AddWithValue("@staffPhone", textBox2.Text);
            AccessCommand.Parameters.AddWithValue("@position", comboBox1.SelectedItem?.ToString() ?? "");

            AccessCommand.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfully!");

            Aconnection.Close();
            showInformation();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Enabled = true;
            textBox5.Clear();
            comboBox1.SelectedItem = null;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            managerHome home = new managerHome();
            home.Show();
            this.Hide();
        }
    }
}
