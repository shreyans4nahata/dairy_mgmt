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
    public partial class adminadd : Form
    {
        public adminadd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass, name;
            int? id;
            try
            {
                //id
                id = int.Parse(textBox1.Text);
                if (id == null)
                {
                    MessageBox.Show("Enter Id !!");
                }
                Console.WriteLine("id {0}", id);
                //password
                pass = textBox3.Text;
                if (pass == null)
                {
                    MessageBox.Show("Enter Password !!");
                }
                Console.WriteLine("password {0}", pass);
                //name
                name = textBox3.Text;
                if (name == null)
                {
                    MessageBox.Show("Enter Name !!");
                }
                Console.WriteLine("name {0}", name);
                
                if (id != null && pass != null && name != null)
                {
                    string cs = @"server=localhost;userid=root;password=1234;database=dairy_mgmt";
                    Console.WriteLine("inside");
                    MySqlConnection conn = null;

                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO admin VALUES (?admin_id, ?name, ?pwd) ;";
                        cmd.Parameters.AddWithValue("?admin_id", id);
                        cmd.Parameters.AddWithValue("?name", name);
                        cmd.Parameters.AddWithValue("?pwd", pass);
                        Console.WriteLine("in1");
                        Console.WriteLine("MySQL version : {0}", conn.ServerVersion);
                        try
                        {
                            cmd.ExecuteScalar();
                            MessageBox.Show("New Admin Added!!");
                        }
                        catch (Exception ex) { Console.WriteLine("Exception : {0}", ex); }
                        
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Failed!!");
                        Console.WriteLine("Error: {0}", ex.ToString());

                    }
                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                    this.Hide();
                    var form = new FormAdminPage();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                
                }
            }
            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormAdminPage();
            form.Closed += (s, args) => this.Close();
            form.Show();
                
        }
    }
}
