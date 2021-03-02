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
    public partial class AddReview : Form
    {
        private SqlConnection con;
        private int id;
        private UserMenu userMenu;

        public AddReview(SqlConnection con, int id, UserMenu menu)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
            this.userMenu = menu;
        }

        private void AddReview_Load(object sender, EventArgs e)
        {
            try
            {
                string str = "exec get_user_orders_without_review @id=" + id + ";";
                SqlCommand cmd = new SqlCommand(str, con);
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                for (int i = 0; i < table.Rows.Count; ++i)
                {
                    StringBuilder s = new StringBuilder();
                    s.Append(table.Rows[i][0].ToString());
                    s.Append(" " + table.Rows[i][1].ToString());
                    s.Append(", " + table.Rows[i][2].ToString());
                    s.Append("руб., №" + table.Rows[i][3].ToString());
                    s.Append(", " + table.Rows[i][4].ToString());
                    comboBox2.Items.Add(s.ToString());
                }
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("insert into BookReviews(dateOfReview, review, clientId, rating, orderId) " +
                    "values(@dateOfReview, @review, @clientId, @rating, @orderId)", con);
                cmd.Parameters.AddWithValue("@dateOfReview", DateTime.Now);
                cmd.Parameters.AddWithValue("@review", reviewText.Text);
                cmd.Parameters.AddWithValue("@clientId", id);
                cmd.Parameters.AddWithValue("@rating", comboBox1.SelectedIndex + 1);
                string str = comboBox2.SelectedItem.ToString();
                int index = str.IndexOf("№");
                str = str.Substring(0, index + 7);
                str = str.Substring(index + 1, 6);
                index = str.IndexOf(",");
                str = str.Substring(0, index);
                int orderId = Convert.ToInt32(str);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Отзыв успешно оставлен");
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void AddReview_FormClosing(object sender, FormClosingEventArgs e)
        {
            userMenu.LoadBookReviews();
        }
    }
}
