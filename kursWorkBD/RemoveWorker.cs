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
    public partial class RemoveWorker : Form
    {
        private SqlConnection con;
        private string fio;
        private string position;
        private int hours;

        public RemoveWorker(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void RemoveWorker_Load(object sender, EventArgs e)
        {
            try
            {
                string str = "exec get_workers;";
                SqlCommand cmd = new SqlCommand(str, con);
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                for (int i = 0; i < table.Rows.Count; ++i)
                {
                    StringBuilder s = new StringBuilder();
                    s.Append(table.Rows[i][0].ToString());
                    s.Append(", " + table.Rows[i][2].ToString());
                    s.Append(", " + table.Rows[i][1].ToString());
                    s.Append(" часов в день, з/п " + table.Rows[i][3].ToString());
                    s.Append(" руб.");
                    worker.Items.Add(s.ToString());
                }
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = worker.SelectedItem.ToString();
                int index = str.IndexOf(",");
                this.fio = str.Substring(0, index);
                str = str.Substring(index + 2, str.Length - index - 2);
                index = str.IndexOf(",");
                this.position = str.Substring(0, index);
                str = str.Substring(index + 2, str.Length - index - 2);
                index = str.IndexOf("часов");
                this.hours = Convert.ToInt32(str.Substring(0, index - 1));
                str = str.Substring(index + 2, str.Length - index - 2);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Уволить работника?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("exec remove_worker @name='" + fio + "', @hours=" +
                        hours + ", @position='" + position + "';");
                    var cmd = new SqlCommand(query.ToString(), con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Работник уволен");
                    this.Hide();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
