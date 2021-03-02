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
    public partial class ChefMenu : Form
    {
        private SqlConnection con;
        private int id;

        public ChefMenu(SqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
        }

        private void ChefMenu_Load(object sender, EventArgs e)
        {
            LoadWorkers();
        }

        private void LoadProfile()
        {
            try
            {
                DataTable table = getUserData();
                loginProfileText.Text = table.Rows[0][0].ToString();
                passProfileText.Text = table.Rows[0][1].ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private DataTable getUserData()
        {
            try
            {
                string str = "select Users.name, Users.password from Users where Users.id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
                return null;
            }
        }

        private DataTable getProfit()
        {
            try
            {
                string str = "exec get_profit;";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
                return null;
            }
        }

        private void LoadProfit()
        {
            try
            {
                DataTable table = getProfit();
                int prodano = Convert.ToInt32(string.IsNullOrEmpty(table.Rows[0][0].ToString()) ? "0" : table.Rows[0][0].ToString());
                int potracheno = Convert.ToInt32(string.IsNullOrEmpty(table.Rows[0][1].ToString()) ? "0" : table.Rows[0][1].ToString());
                int profit = Convert.ToInt32(string.IsNullOrEmpty(table.Rows[0][2].ToString()) ? "0" : table.Rows[0][2].ToString());
                prodanoText.Text = prodano.ToString();
                potrachenoText.Text = potracheno.ToString();
                profitText.Text = profit.ToString();
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void LoadWorkers()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string query = "exec get_workers;";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[4]);
                    string FIO = reader[0].ToString();
                    data[data.Count - 1][0] = FIO;
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                }
                reader.Close();
                foreach (string[] s in data)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    LoadWorkers();
                    break;
                case 1:
                    
                    break;
                case 2:
                    LoadProfit();
                    break;
                case 3:
                    
                    break;
                case 4:
                    LoadProfile();
                    break;
                case 5:
                    if (MessageBox.Show("Хотите выйти?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Hide();
                        StartWindow window = new StartWindow();
                        window.Show();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("update Users set name='" + loginProfileText.Text + "', password='" +
                    passProfileText.Text + "' where id=" + id);
                var cmd = new SqlCommand(str.ToString(), con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddWorker window = new AddWorker(con);
            window.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveWorker window = new RemoveWorker(con);
            window.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChooseDate window = new ChooseDate(con);
            window.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AllDishes window = new AllDishes(con);
            window.Show();
        }
    }
}
