using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace dairy_mgmt_dbms
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formadmin = new FormAdminPage();
            formadmin.Closed += (s, args) => this.Close();
            formadmin.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int? id;
                id = int.Parse(textBox1.Text);
                if (id != null)
                {
                    string cs = @"server=localhost;userid=root;password=1234;database=dairy_mgmt";
                    Console.WriteLine("inside");
                    MySqlConnection conn = null;
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();
                        Console.WriteLine("MySQL version : {0}", conn.ServerVersion);
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "DELETE FROM staff WHERE staff_id = ?id ;";
                        cmd.Parameters.AddWithValue("?id", id);
                        Console.WriteLine("in1");
                        try
                        {
                            cmd.ExecuteScalar();
                            MessageBox.Show("Staff deleted.");
                        }
                        catch (Exception ex) { Console.WriteLine("Exception : {0}", ex); }


                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.ToString());
                    }
                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }

                }
                else {
                    MessageBox.Show("no id given..!");
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Invalid entry");
                Console.WriteLine("Exception : {0}", ex);
            }
        }
    }
}
