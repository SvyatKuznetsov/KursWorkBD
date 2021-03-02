using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kursWorkBD
{
    public partial class StartWindow : Form
    {
        private SqlConnection con;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-BPLJ4GV\SQLEXPRESS;Initial Catalog=restoran;Integrated Security=True");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIn form = new SignIn(con);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration(con);
            reg.Show();
            this.Hide();
        }
    }
}
