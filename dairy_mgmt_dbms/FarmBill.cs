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
    public partial class FarmBill : Form
    {
        public static int? staff_bill_id, seller_id,amt;
        public FarmBill()
        {
            InitializeComponent();
        }
        DataTable Bills;
        int billIndex = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Bills != null && Bills.Rows.Count > 0 && billIndex < Bills.Rows.Count - 1)
            {
                billIndex++;
                refreshValues();
            }
            else
            {
                MessageBox.Show("No more Entries!!");
            }
        }
        private void refreshValues()
        {
            try
            {
                textBox1.Text = (Bills.Rows[billIndex]["st_b_id"] + "");
                textBox2.Text = (FormStaff.staff_id_g + "");
                textBox3.Text = Bills.Rows[billIndex]["seller_id"] + "";
                textBox4.Text = Bills.Rows[billIndex]["amt"] + "";
            }
            catch (Exception ex) {
                Console.WriteLine("{0}", ex);
                this.Hide();
                var form = new Form1();
                form.Closed += (s, args) => this.Close();
                form.Show();
        
            }
        }

        private void FarmBill_Load(object sender, EventArgs e)
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

                    string query = "SELECT st_b_id,seller_id,amt FROM staff_bill AS SB WHERE SB.staff_id =" + FormStaff.staff_id_g + ";";
                    MySqlCommand cmdDatabase = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDatabase);
                    DataSet dSet = new System.Data.DataSet();
                    adapter.Fill(dSet, "Bills");
                    Bills = dSet.Tables["Bills"];
                    billIndex = 0;
                    refreshValues();
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
            catch(MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show("Error");
            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (billIndex > 0 && Bills != null && Bills.Rows.Count > 0)
            {
                billIndex--;
                refreshValues();
            }
            else
            {
                MessageBox.Show("No more Entries!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();
        
        }
    }
}
