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
    public partial class Formplantorder : Form
    {
        public Formplantorder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id, sid,qty, amt, numberOfRecords;
            string source;
            DateTime date;
            float? fat;
            try
            {
                //id
                id = int.Parse(textBox1.Text);
                if (id == null)
                {
                    MessageBox.Show("Enter Bill number !!");
                }
                Console.WriteLine("id {0}", id);
                //source
                source = (textBox2.Text);
                if (source == null)
                {
                    MessageBox.Show("Enter Source !!");
                }
                Console.WriteLine("source  {0}", source);
                //date
                date = DateTime.Parse(textBox3.Text);
                if (date == null)
                {
                    MessageBox.Show("Enter date !!");
                }
                Console.WriteLine("date  {0}", date);
                //qty
                qty = int.Parse(textBox4.Text);
                if (qty == null)
                {
                    MessageBox.Show("Enter Quantity !!");
                }
                Console.WriteLine("qty  {0}", qty);
                //Price
                amt = int.Parse(textBox5.Text);
                if (amt == null)
                {
                    MessageBox.Show("Enter amount !!");
                }
                Console.WriteLine("amt  {0}", amt);
                //Fat
                fat = float.Parse(textBox6.Text);
                if (fat == null)
                {
                    MessageBox.Show("Enter fat%age !!");
                }
                Console.WriteLine("fat  {0}", fat);
                
                //seller-id
                sid = int.Parse(textBox7.Text);
                if (sid == null)
                {
                    MessageBox.Show("Enter seller-id from which to buy !!");
                }
                Console.WriteLine("seller-id {0}", sid);
                if (id != null && sid != null && amt != null && date != null && qty != null && amt != null && source != null)
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
                        cmd.CommandText = "SELECT * FROM seller WHERE seller_id =" + sid + ";";
                        //cmd.Parameters.AddWithValue("?ssid", sid);
                        Console.WriteLine("in1");
                        try
                        {
                            numberOfRecords = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine("no. of seller : {0}", numberOfRecords);
                            if (numberOfRecords == -1 )
                            {
                                MessageBox.Show("Invalid seller-id!!!");
                            }
                            if (numberOfRecords != -1)
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO seller_bill_pl VALUES (?id,?source,?date,?qty,?amt,?fat, ?sid, ?plid ) ;";
                                cmd.Parameters.AddWithValue("?id", id);
                                cmd.Parameters.AddWithValue("?source", source);
                                cmd.Parameters.AddWithValue("?date", date);
                                cmd.Parameters.AddWithValue("?qty", qty);
                                cmd.Parameters.AddWithValue("?amt", amt);
                                cmd.Parameters.AddWithValue("?fat", fat);
                                cmd.Parameters.AddWithValue("?sid", sid);
                                cmd.Parameters.AddWithValue("?plid", FormPlant.pl_id_g);
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
                var form = new Form4();
                form.Closed += (s, args) => this.Close();
                form.Show();

            }
            catch
            {
                MessageBox.Show("Enter valid Entries !!");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form4();
            form.Closed += (s, args) => this.Close();
            form.Show();

        }
    }
}
