using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
/*
 Shreyansh Nahata
 */
namespace dairy_mgmt_dbms
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime result = dateTimePicker1.Value;
            
            string  name ;
            DateTime date;
            float? fat;
            int? qty; 
            try
            {
                //date
                date = dateTimePicker1.Value;
                //date = DateTime.Parse(textBox1.Text);
                if (date == null)
                {
                    MessageBox.Show("Enter Date !!");
                }
                Console.WriteLine("date {0}", date);
                //fat
                fat = float.Parse(textBox2.Text);
                if (fat == null)
                {
                    MessageBox.Show("Enter Fat percentage !!");
                }
                Console.WriteLine("Fat {0}", fat);
                //source
                name = textBox3.Text;
                if (name == null)
                {
                    MessageBox.Show("Enter Source !!");
                }
                Console.WriteLine("name {0}", name);
                //qty
                qty = int.Parse(textBox4.Text);
                if (qty == null)
                {
                    MessageBox.Show("Enter Quantity !!");
                }
                Console.WriteLine("quantity {0}", qty);

                if (date != null && fat != null && name != null && qty != null)
                {
                    string cs = @"server=localhost;userid=root;password=1234;database=dairy_mgmt";
                    Console.WriteLine("inside");
                    MySqlConnection conn = null;

                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();
                        //to insert data or run commands
                        //string sql = "SELECT admin_id FROM admin WHERE admin_id = id AND pwd = pass ;";
                        //MySqlScript script = new MySqlScript(conn, sql);
                        // Create Command 
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO milk_info VALUES (?date, ?fat, ?name, ?qty) ;";
                        cmd.Parameters.AddWithValue("?date", date);
                        cmd.Parameters.AddWithValue("?fat", fat);
                        cmd.Parameters.AddWithValue("?name", name);
                        cmd.Parameters.AddWithValue("?qty", qty);
                        Console.WriteLine("in1");
                        try
                        {
                            cmd.ExecuteScalar();
                        }
                        catch (Exception ex) { Console.WriteLine("Exception : {0}", ex); }
                        
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO staff_collects VALUES (?id, ?da) ;";
                        cmd.Parameters.AddWithValue("?id", FormStaff.staff_id_g);
                        cmd.Parameters.AddWithValue("?da", date);
                        Console.WriteLine("in2");
                        try
                        {
                            cmd.ExecuteScalar();
                        }
                        catch (Exception ex) { Console.WriteLine("Exception : {0}", ex); }

                        Console.WriteLine("MySQL version : {0}", conn.ServerVersion);

                        //to show data
                        //MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM admin;", conn);
                        //DataSet ds = new DataSet();
                        //da.Fill(ds);
                        //dataGridView1.DataSource = ds.Tables[0];


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
                this.Hide();
                var form = new Form1();
                form.Closed += (s, args) => this.Close();
                form.Show();
    
            }

            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            var form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();

        }

        private void Form16_Load(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
