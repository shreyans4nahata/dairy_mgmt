using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dairy_mgmt_dbms
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formadmin = new FormAdmin();
            formadmin.Closed += (s, args) => this.Close();
            formadmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormStaff();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormSeller();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormRetailer();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormPlant();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}