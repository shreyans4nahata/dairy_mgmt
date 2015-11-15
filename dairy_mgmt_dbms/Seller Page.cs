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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM seller AS S , staff_bill AS SB WHERE S.seller_id =" + FormSeller.seller_id_g + " AND SB.seller_id =" + FormSeller.seller_id_g + ";", conn);
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormSeller();
            FormSeller.seller_id_g = null;
            form.Closed += (s, args) => this.Close();
            form.Show();
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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM seller AS S , seller_bill_re AS SR, seller_bill_pl AS SP WHERE S.seller_id =" + FormSeller.seller_id_g + " AND SR.seller_id =" + FormSeller.seller_id_g + " AND SP.seller_id =" + FormSeller.seller_id_g + ";", conn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Formsellerorder();
            
            form.Closed += (s, args) => this.Close();
            form.Show();

        }
    }
}
