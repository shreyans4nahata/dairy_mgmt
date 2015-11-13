using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_mgmt_dbms
{
    public partial class FormStaff : Form
    {
        public FormStaff()
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormStaffSign();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FormMain();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
