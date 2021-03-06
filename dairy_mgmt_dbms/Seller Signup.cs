﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
/*
 Shreyansh Nahata
 */
namespace dairy_mgmt_dbms
{
    public partial class FormSellerSign : Form
    {
        public FormSellerSign()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormSeller();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pass, name, addr;
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
                pass = textBox2.Text;
                if (pass == null)
                {
                    MessageBox.Show("Enter Password !!");
                }
                Console.WriteLine("password {0}", pass);
                //name
                name = textBox4.Text;
                if (name == null)
                {
                    MessageBox.Show("Enter Name !!");
                }
                Console.WriteLine("name {0}", name);
                //address
                addr = (textBox3.Text);
                if (addr == null)
                {
                    MessageBox.Show("Enter Address !!");
                }
                Console.WriteLine("address {0}", addr);

                if (id != null && pass != null && name != null && addr != null)
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
                        cmd.CommandText = "INSERT INTO seller VALUES (?id, ?name, ?addr, ?pass) ;";
                        cmd.Parameters.AddWithValue("?id", id);
                        cmd.Parameters.AddWithValue("?name", name);
                        cmd.Parameters.AddWithValue("?addr", addr);
                        cmd.Parameters.AddWithValue("?pass", pass); 
                        Console.WriteLine("in1");
                        try
                        {
                            cmd.ExecuteScalar();
                            FormSeller.seller_id_g = id;
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
                if (FormSeller.seller_id_g == null)
                {
                    MessageBox.Show("INVALID USER!!");
                }
                else
                {
                    this.Hide();
                    var form = new Form3();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                }
            }
            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        }
    }
}
