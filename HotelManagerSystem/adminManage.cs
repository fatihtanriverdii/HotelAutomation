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
    public partial class adminManage : Form
    {
        public adminManage()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#162d55");
        }

        OleDbConnection Aconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\hotelSystem.accdb");

        private void backButton_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            managerHome home = new managerHome();
            home.Show();
            this.Hide();
        }

        private void adminManage_Load(object sender, EventArgs e)
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
            AccessCommand.CommandText = ("Select * from manager");
            OleDbDataReader read = AccessCommand.ExecuteReader();

            while (read.Read())
            {
                ListViewItem addNew = new ListViewItem();
                addNew.Text = read["managerID"].ToString();
                addNew.SubItems.Add(read["mName"].ToString());
                addNew.SubItems.Add(read["mPhone"].ToString());
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
            string sqlText = "INSERT INTO manager (managerID, [password], mName, mPhone, [position]) " +
                         "VALUES (@managerID, @password, @mName, @mPhone, @position)";

            OleDbCommand AccessCommand = new OleDbCommand(sqlText, Aconnection);
            AccessCommand.Parameters.AddWithValue("@managerID", Convert.ToInt32(textBox5.Text));
            AccessCommand.Parameters.AddWithValue("@password", textBox3.Text);
            AccessCommand.Parameters.AddWithValue("@mName", textBox1.Text);
            AccessCommand.Parameters.AddWithValue("@mPhone", textBox2.Text);
            AccessCommand.Parameters.AddWithValue("@position", comboBox1.SelectedItem?.ToString() ?? "");

            AccessCommand.ExecuteNonQuery();
            Aconnection.Close();
            showInformation();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedItem = null;
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            textBox5.Enabled= false;
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

                    string query = "SELECT * FROM manager WHERE managerID = @managerID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@managerID", ID);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox5.Text = reader["managerID"].ToString();
                                textBox3.Text = reader["password"].ToString();
                                textBox1.Text = reader["mName"].ToString();
                                textBox2.Text = reader["mPhone"].ToString();
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
            AccessCommand.CommandText = "DELETE FROM manager WHERE managerID = @managerID";
            AccessCommand.Parameters.AddWithValue("@managerID", ID);
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
            textBox5.Clear();
            textBox5.Enabled = true;

            comboBox1.SelectedItem = null;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string sID = textBox4.Text.ToString();
            int ID = Convert.ToInt32(sID);
            Aconnection.Open();

            string sqlText = "UPDATE manager SET managerID = @managerID, [password] = @password, mName = @mName, mPhone = @mPhone, [position] = @position WHERE managerID = @managerID";

            OleDbCommand AccessCommand = new OleDbCommand(sqlText, Aconnection);
            AccessCommand.Parameters.AddWithValue("@managerID", ID);
            AccessCommand.Parameters.AddWithValue("@password", textBox3.Text);
            AccessCommand.Parameters.AddWithValue("@mName", textBox1.Text);
            AccessCommand.Parameters.AddWithValue("@mPhone", textBox2.Text);
            AccessCommand.Parameters.AddWithValue("@position", comboBox1.SelectedItem?.ToString() ?? "");

            AccessCommand.ExecuteNonQuery();
            MessageBox.Show("Record updated successfully!");

            Aconnection.Close();
            showInformation();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox5.Enabled = true;
            comboBox1.SelectedItem = null;
        }
    }
    
}
