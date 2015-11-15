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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form4();

            form.Closed += (s, args) => this.Close();
            form.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int? amt, type;
            try
            {
                //Type
                type = int.Parse(textBox1.Text);
                if (type == null)
                {
                    MessageBox.Show("Enter Type !!");
                }
                Console.WriteLine("type {0}", type);
                //amt
                amt = int.Parse(textBox2.Text);
                if (amt == null)
                {
                    MessageBox.Show("Enter Amount !!");
                }
                Console.WriteLine("Amount {0}", amt);

                if (type != null && amt != null)
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
                        cmd.CommandText = "INSERT INTO prod_type VALUES (?date, ?fat) ;";
                        cmd.Parameters.AddWithValue("?date", type);
                        cmd.Parameters.AddWithValue("?fat",amt );
                        Console.WriteLine("in1");
                        try
                        {
                            cmd.ExecuteScalar();
                        }
                        catch (Exception ex) { Console.WriteLine("Exception : {0}", ex); }

                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO plant_prod VALUES (?id, ?da) ;";
                        cmd.Parameters.AddWithValue("?id", FormPlant.pl_id_g);
                        cmd.Parameters.AddWithValue("?da", type);
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
                var form = new Form4();
                form.Closed += (s, args) => this.Close();
                form.Show();

            }

            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
