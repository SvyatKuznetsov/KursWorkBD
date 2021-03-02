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
    public partial class ChooseDate : Form
    {
        private SqlConnection con;

        public ChooseDate(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void ChooseDate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            DishesAtDay window = new DishesAtDay(date, con);
            window.Show();
        }
    }
}
