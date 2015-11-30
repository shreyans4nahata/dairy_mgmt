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
    public partial class datespec1 : Form
    {
        DataTable datastuff, dstuff;
        int inde = 0;
        public datespec1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormAdminPage();
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
                    string date;
                    //to show data
                    date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    Console.WriteLine("Date : {0}", date);
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM milk_info WHERE milk_info.DOC = '"+date+ "' ;", conn);
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
                    string date1,date2;
                    //to show data
                    date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    Console.WriteLine("Date1 : {0}", date1);
                    Console.WriteLine("Date2 : {0}", date2);
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM milk_info WHERE milk_info.DOC BETWEEN '" + date1 + "' AND '"+ date2 +"' ;", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    
                    string query1 = "SELECT SUM(quantity) FROM `milk_info` WHERE (milk_info.source ='cow') AND (milk_info.DOC BETWEEN '"+ date1 +"' AND '" + date2 +"') AND (milk_info.Fatage BETWEEN 1 AND 50) ";
                    MySqlCommand cmdDatabase = new MySqlCommand(query1, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDatabase);
                    DataSet dSet = new System.Data.DataSet();
                    adapter.Fill(dSet, "stuff");
                    datastuff = dSet.Tables["stuff"];

                    textBox1.Text = (datastuff.Rows[0][0] + "");
                    conn.Close();
                    string query2 = "SELECT SUM(seller_bill_re.price) FROM `seller_bill_re` WHERE (seller_bill_re.date BETWEEN '"+date1+"' AND '"+date2+"') AND (seller_bill_re.r_id = 3) ";
                    MySqlCommand cmdDatabase1 = new MySqlCommand(query2, conn);
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmdDatabase1);
                    adapter1.Fill(dSet, "some");
                    dstuff = dSet.Tables["some"];

                    textBox2.Text = (dstuff.Rows[0][0] + "");
                    textBox3.Text = "cow";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
