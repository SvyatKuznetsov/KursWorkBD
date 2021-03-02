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
    public partial class DishesAtDay : Form
    {
        private string date;
        private SqlConnection con;

        public DishesAtDay(string date, SqlConnection con)
        {
            InitializeComponent();
            this.date = date;
            this.con = con;
        }

        private void DishesAtDay_Load(object sender, EventArgs e)
        {
            List<string> dishes = new List<string>();
            List<int> amountes = new List<int>();
            List<float> prices = new List<float>();
            try
            {
                dataGridView1.Rows.Clear();
                string query = "exec load_orders_per_day @date='" + date + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string[]> data = new List<string[]>();
                int i = 0;
                dishes.Add("");
                amountes.Add(0);
                prices.Add(0);
                bool first = true;
                while (reader.Read())
                {
                    if (first)
                    {
                        dishes[0] = reader[0].ToString();
                        amountes[0] = Convert.ToInt32(reader[1].ToString());
                        prices[0] = Convert.ToInt32(reader[2].ToString());
                        first = false;
                    }
                    else
                    {
                        bool finded = false;
                        int index = -1;
                        for (int k = 0; k < dishes.Count; ++k)
                        {
                            if (dishes[k] == reader[0].ToString())
                            {
                                finded = true;
                                index = k;
                            }
                        }
                        if (finded)
                        {
                            amountes[index] += Convert.ToInt32(reader[1].ToString());
                        }
                        else
                        {
                            dishes.Add(reader[0].ToString());
                            amountes.Add(Convert.ToInt32(reader[1].ToString()));
                            prices.Add(Convert.ToInt32(reader[2].ToString()));
                        }
                    }
                    ++i;
                }
                for (int k = 0; k < dishes.Count; ++k)
                {
                    prices[k] = prices[k] * amountes[k];
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = dishes[k];
                    data[data.Count - 1][1] = prices[k].ToString();
                    data[data.Count - 1][2] = amountes[k].ToString();
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
    }
}
