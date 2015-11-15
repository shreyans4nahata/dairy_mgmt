using System;
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
    public partial class FormPlant : Form
    {
        public static int? pl_id_g;
        public FormPlant()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormMain();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormPlantSign();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pass;
            int? id;

            try
            {
                id = int.Parse(textBox1.Text);
                if (id == null)
                {
                    MessageBox.Show("Enter Id !!");
                }
                Console.WriteLine("id {0}", id);
                pass = textBox2.Text;
                if (pass == null)
                {
                    MessageBox.Show("Enter Password !!");
                }
                Console.WriteLine("password {0}", pass);
                if (id != null && pass != null)
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
                        cmd.CommandText = "SELECT pl_id FROM plant WHERE pl_id = ?id AND pwd = ?pass ;";
                        cmd.Parameters.AddWithValue("?id", id);
                        cmd.Parameters.AddWithValue("?pass", pass);
                        Console.WriteLine("in1");
                        try
                        {
                            pl_id_g = (int)(cmd.ExecuteScalar());
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
                if (pl_id_g == null)
                {
                    MessageBox.Show("INVALID USER!!");
                }
                else
                {
                    this.Hide();
                    var form = new Form4();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                }
            }
            catch
            {
                MessageBox.Show("Enter valid Id !!");
            }
        }
    }
}
