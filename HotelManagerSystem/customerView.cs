﻿using System;
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
    public partial class customerView : Form
    {

        OleDbConnection Acconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\hotelSystem.accdb");
        public customerView()
        {
            InitializeComponent();
        }

        private void customerView_Load(object sender, EventArgs e)
        {
            LoadCustomerDataToListView();
        }

        private void LoadCustomerDataToListView()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Acconnection.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM customers";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["identityNumber"].ToString());
                                item.SubItems.Add(reader["cName"].ToString());
                                item.SubItems.Add(reader["cSurname"].ToString());
                                item.SubItems.Add(reader["telNumber"].ToString());
                                item.SubItems.Add(reader["email"].ToString());
                                item.SubItems.Add(reader["startDate"].ToString());
                                item.SubItems.Add(reader["endDate"].ToString());
                                item.SubItems.Add(reader["bedCount"].ToString());
                                item.SubItems.Add(reader["roomNumber"].ToString());
                                item.SubItems.Add(reader["totalPrice"].ToString());

                                listView1.Items.Add(item);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void backButton_Click_1(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            homePage.Show();
            this.Hide();
        }
    }
}