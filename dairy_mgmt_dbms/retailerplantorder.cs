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
    public partial class retailerplantorder : Form
    {
        public retailerplantorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form2();
            form.Closed += (s, args) => this.Close();
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id, sid,type, amt, numberOfRecords;
            try
            {
                //id
                id = int.Parse(textBox1.Text);
                if (id == null)
                {
                    MessageBox.Show("Enter Bill number !!");
                }
                Console.WriteLine("id {0}", id);
                //Type
                type = int.Parse(textBox5.Text);
                if (type == null)
                {
                    MessageBox.Show("Enter type !!");
                }
                Console.WriteLine("type  {0}", type);
                //Fat
                amt = int.Parse(textBox6.Text);
                if (amt == null)
                {
                    MessageBox.Show("Enter Amount !!");
                }
                Console.WriteLine("amt  {0}", amt);

                //Plant-id
                sid = int.Parse(textBox7.Text);
                if (sid == null)
                {
                    MessageBox.Show("Enter planr-id from which to buy !!");
                }
                Console.WriteLine("plant-id {0}", sid);
                if (id != null && sid != null && amt != null  && type != null)
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
                        cmd.CommandText = "SELECT * FROM plant WHERE pl_id =" + sid + ";";
                        //cmd.Parameters.AddWithValue("?ssid", sid);
                        Console.WriteLine("in1");
                        try
                        {
                            numberOfRecords = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine("no. of plants : {0}", numberOfRecords);
                            if (numberOfRecords == -1)
                            {
                                MessageBox.Show("Invalid seller-id!!!");
                            }
                            if (numberOfRecords != -1)
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO plant_sold_re VALUES (?reid, ?type, ?amt, ?sid, ?id ) ;";
                                cmd.Parameters.AddWithValue("?reid", FormRetailer.r_id_g);
                                cmd.Parameters.AddWithValue("?type", type);
                                cmd.Parameters.AddWithValue("?amt", amt);
                                cmd.Parameters.AddWithValue("?sid", sid);
                                cmd.Parameters.AddWithValue("?id", id);
                                
                                Console.WriteLine("in2");
                                try
                                {
                                    cmd.ExecuteScalar();
                                }
                                catch (Exception ex) { Console.WriteLine("Exception : {0}", ex); }
                            }
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
                var form = new Form2();
                form.Closed += (s, args) => this.Close();
                form.Show();

            }
            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        
        }

        private void retailerplantorder_Load(object sender, EventArgs e)
        {

        }
    }
}
