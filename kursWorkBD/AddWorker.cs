using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursWorkBD
{
    public partial class AddWorker : Form
    {
        private SqlConnection con;
        private int positionId;

        public AddWorker(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void AddWorker_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fio = fioText.Text;
                int hours = Convert.ToInt32(hoursText.Text);
                if (hours <= 0)
                {
                    MessageBox.Show("Введите положительное число часов");
                }
                else
                {
                    if (MessageBox.Show("Добавить работника?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        StringBuilder str = new StringBuilder();
                        str.Append("exec add_worker @nameOfWorker='" + fio + "', @workTimeDayInHours=" +
                            hours + ", @positionId=" + positionId);
                        var cmd = new SqlCommand(str.ToString(), con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Работник добавлен");
                        this.Hide();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void positionText_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = positionText.SelectedIndex;
            switch (t)
            {
                case 0:
                    positionId = 3;
                    break;
                case 1:
                    positionId = 1;
                    break;
            }
        }
    }
}
