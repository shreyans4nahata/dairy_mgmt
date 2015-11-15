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
    public partial class Formsellerorder : Form
    {
        public Formsellerorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form3();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int? id, sid, amt, numberOfRecords;
            try
            {
                //id
                id = int.Parse(textBox1.Text);
                if (id == null)
                {
                    MessageBox.Show("Enter Bill number !!");
                }
                Console.WriteLine("id {0}", id);
                //staff-id
                sid = int.Parse(textBox2.Text);
                if (sid == null)
                {
                    MessageBox.Show("Enter staff-id from which to buy !!");
                }
                Console.WriteLine("st-id {0}", sid);
                //amount
                amt = int.Parse(textBox3.Text);
                if (amt == null)
                {
                    MessageBox.Show("Enter Total amount !!");
                }
                Console.WriteLine("amt  {0}", amt);
                if (id != null && sid != null && amt != null )
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
                        cmd.CommandText = "SELECT * FROM staff WHERE staff_id ="+sid +";";
                        //cmd.Parameters.AddWithValue("?ssid", sid);
                        Console.WriteLine("in1");
                        try
                        {
                            numberOfRecords = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine("no. of staff : {0}", numberOfRecords);
                            if(numberOfRecords != 1){
                                MessageBox.Show("Invalid staff-id!!!");
                            }
                            if (numberOfRecords == 1)
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO staff_bill VALUES (?id, ?sid, ?seid, ?amt) ;";
                                cmd.Parameters.AddWithValue("?id", id);
                                cmd.Parameters.AddWithValue("?sid", sid);
                                cmd.Parameters.AddWithValue("?seid", FormSeller.seller_id_g);
                                cmd.Parameters.AddWithValue("?amt", amt);
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
                    var form = new Form3();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                
            }
            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        }
    }
}
