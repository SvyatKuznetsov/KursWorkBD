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
    public partial class OrdersOfClient : Form
    {
        private int id;
        private SqlConnection con;

        public OrdersOfClient(int id, SqlConnection con)
        {
            InitializeComponent();
            this.id = id;
            this.con = con;
        }

        private void OrdersOfClient_Load(object sender, EventArgs e)
        {
            string query = "exec get_orders_of_user @id=" + id + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                if (data.Count > 0 /*&& id == Convert.ToInt32(reader[0].ToString()) */
                    && data[data.Count - 1][2] == reader[4].ToString())
                {
                    string dishes = ", " + reader[2].ToString() + " " + reader[3].ToString();
                    data[data.Count - 1][1] += dishes;
                }
                else
                {
                    int id = Convert.ToInt32(reader[0].ToString());
                    data.Add(new string[4]);
                    string dataOfOrder = reader[1].ToString();
                    string dishes = reader[2].ToString() + " " + reader[3].ToString();
                    data[data.Count - 1][0] = dataOfOrder;
                    data[data.Count - 1][1] = dishes;
                    data[data.Count - 1][2] = reader[4].ToString();
                    data[data.Count - 1][3] = reader[5].ToString();
                }
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
    }
}
