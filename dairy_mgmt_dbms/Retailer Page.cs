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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormRetailer();
            FormRetailer.r_id_g = null;
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new retailersellerordercs();

            form.Closed += (s, args) => this.Close();
            form.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new retailerplantorder();
            form.Closed += (s, args) => this.Close();
            form.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=1234;database=dairy_mgmt";
                Console.WriteLine("inside");
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    Console.WriteLine("MySQL version : {0}", conn.ServerVersion);
                    //to show data
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM retailer AS R , seller_bill_re AS SB WHERE R.r_id =" + FormRetailer.r_id_g + " AND SB.r_id =" + FormRetailer.r_id_g + ";", conn);
                    //MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM staff;", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
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
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=1234;database=dairy_mgmt";
                Console.WriteLine("inside");
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    Console.WriteLine("MySQL version : {0}", conn.ServerVersion);
                    //to show data
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM plant_sold_re AS PB , retailer AS R WHERE R.r_id =" + FormRetailer.r_id_g + " AND PB.r_id =" + FormRetailer.r_id_g + ";", conn);
                    //MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM staff;", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
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
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
