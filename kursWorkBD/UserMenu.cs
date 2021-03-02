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
    public partial class UserMenu : Form
    {
        private SqlConnection con;
        private int id;
        private int clientId;

        public UserMenu(SqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            LoadMenu();
            DataTable table2 = getClientId();
            this.clientId = Convert.ToInt32(string.IsNullOrEmpty(table2.Rows[0][0].ToString()) ? "0" : table2.Rows[0][0].ToString());
        }

        private void menuButton_Click(object sender, EventArgs e)
        {

        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хотите выйти?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                StartWindow window = new StartWindow();
                window.Show();
            }
        }

        private void LoadMenu()
        {
            try
            {
                dataGrid.Rows.Clear();
                string query = "select Menu.nameOfDish, Menu.price from Menu";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[3]);
                    string nameOfDish = reader[0].ToString();
                    data[data.Count - 1][0] = nameOfDish;
                    data[data.Count - 1][1] = reader[1].ToString();
                }
                reader.Close();
                for (int i = 0; i < data.Count; ++i)
                {
                    DataTable table = getIngredients(data[i][0]);
                    StringBuilder str = new StringBuilder();
                    for (int h = 0; h < table.Rows.Count - 1; ++h)
                    {
                        str.Append(table.Rows[h][0].ToString() + " " + table.Rows[h][1] + ", ");
                    }
                    str.Append(table.Rows[table.Rows.Count - 1][0].ToString() + " " + table.Rows[table.Rows.Count - 1][1]);
                    data[i][2] = str.ToString();
                }
                foreach (string[] s in data)
                {
                    dataGrid.Rows.Add(s);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private DataTable getIngredients(string nameOfDish)
        {
            try
            {
                string str = "exec get_ingredients_of_dish @nameOfDish='" + nameOfDish + "';";
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

        private void LoadProfile()
        {
            DataTable table = getUserData();
            loginProfileText.Text = table.Rows[0][0].ToString();
            passProfileText.Text = table.Rows[0][1].ToString();
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

        public void LoadBookReviews()
        {
            dataGridView1.Rows.Clear();
            string query = "select BookReviews.dateOfReview, BookReviews.review, BookReviews.rating, BookReviews.orderId from BookReviews";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = reader[0].ToString();
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

        private void LoadMenuForOrder()
        {
            dataGridView2.Rows.Clear();
            string query = "select Menu.nameOfDish, Menu.price from Menu";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);
                string nameOfDish = reader[0].ToString();
                data[data.Count - 1][0] = nameOfDish;
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = "0";
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView2.Rows.Add(s);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    LoadMenu();
                    break;
                case 1:
                    LoadMenuForOrder();
                    break;
                case 2:
                    LoadBookReviews();
                    break;
                case 3:
                    LoadProfile();
                    break;
                case 4:
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
            StringBuilder str = new StringBuilder();
            str.Append("exec update_user_info @login=" + loginProfileText.Text + ", @password=" +
                passProfileText.Text + ", @id=" + id);
            var cmd = new SqlCommand(str.ToString(), con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Данные успешно обновлены");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdersOfClient window = new OrdersOfClient(clientId, con);
            window.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddReview window = new AddReview(con, id, this);
            window.Show();
        }

        private void CreateOrder(float totalPrice, List<string> dishes, List<int> amountes, List<float> prices)
        {
            try
            {
                DateTime date = DateTime.Now;
                var cmd = new SqlCommand("exec create_order @date='" + date + "', @totalPrice=" + Convert.ToInt32(totalPrice) +
                    ", @cookId=1, @clientId=" + this.clientId + ", @status=1", con);
                cmd.ExecuteNonQuery();

                string str = "select Orders.id from Orders where Orders.clientId=" + this.clientId +
                    " and Orders.totalPrice=" + Convert.ToInt32(totalPrice) + " and Orders.dateOfOrder='" + date + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(str, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                int orderId = Convert.ToInt32(string.IsNullOrEmpty(table.Rows[0][0].ToString()) ? "0" : table.Rows[0][0].ToString());

                for (int i = 0; i < amountes.Count; ++i)
                {
                    string ss = "select Menu.id from Menu where Menu.nameOfDish='" + dishes[i] + "'";
                    SqlDataAdapter da = new SqlDataAdapter(ss, con);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
                    int dishId = Convert.ToInt32(string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()) ? "0" : dataTable.Rows[0][0].ToString());

                    var command = new SqlCommand("exec create_order_details @orderId=" + orderId + 
                        ", @dishId=" + dishId + ", @amount=" + amountes[i] + ", @price=" + prices[i] + ";", con);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Заказ создан и в скорем времени будет выполнен");
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private DataTable getClientDiscount()
        {
            try
            {
                string str = "exec get_user_discount @id=" + id + ";";
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

        private DataTable getClientId()
        {
            try
            {
                string str = "exec get_client_id @userId=" + id + ";";
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

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> dishes = new List<string>();
            List<int> amountes = new List<int>();
            List<float> prices = new List<float>();
            try
            {
                DataTable table = getClientDiscount();
                int discount = Convert.ToInt32(string.IsNullOrEmpty(table.Rows[0][0].ToString()) ? "0" : table.Rows[0][0].ToString());
                if (discount > 0)
                {
                    float totalPrice = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        string str = dataGridView2[2, i].Value.ToString();
                        int amount = Convert.ToInt32(str);
                        string dish = dataGridView2[0, i].Value.ToString();
                        float price = Convert.ToInt32(dataGridView2[1, i].Value.ToString());
                        if (amount < 0)
                        {
                            MessageBox.Show("Введите положительное число");
                        }
                        else if (amount > 0)
                        {
                            amountes.Add(amount);
                            dishes.Add(dish);
                            prices.Add(price);
                        }
                    }
                    for (int i = 0; i < dishes.Count; ++i)
                    {
                        totalPrice += (prices[i] * amountes[i]);
                    }
                    StringBuilder message = new StringBuilder();
                    message.Append("Итоговая сумма заказа со скидкой: ");
                    float newTotalPrice = totalPrice * (100 - discount) / 100;
                    message.Append(newTotalPrice + "\n");
                    message.Append("Сформировать заказ?");
                    if (MessageBox.Show(message.ToString(), " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (amountes.Count > 0 && dishes.Count > 0)
                        {
                            CreateOrder(newTotalPrice, dishes, amountes, prices);
                        }
                        else
                        {
                            MessageBox.Show("Выберите хотя бы одно блюдо");
                        }
                    }
                }
                else if (discount == 0)
                {
                    float totalPrice = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        string str = dataGridView2[2, i].Value.ToString();
                        int amount = Convert.ToInt32(str);
                        string dish = dataGridView2[0, i].Value.ToString();
                        float price = Convert.ToInt32(dataGridView2[1, i].Value.ToString());
                        if (amount < 0)
                        {
                            MessageBox.Show("Введите положительное число");
                        }
                        else if (amount > 0)
                        {
                            amountes.Add(amount);
                            dishes.Add(dish);
                            prices.Add(price);
                        }
                    }
                    for (int i = 0; i < dishes.Count; ++i)
                    {
                        totalPrice += (prices[i] * amountes[i]);
                    }
                    StringBuilder message = new StringBuilder();
                    message.Append("Итоговая сумма заказа со скидкой: ");
                    message.Append(totalPrice + "\n");
                    message.Append("Сформировать заказ?");
                    if (MessageBox.Show(message.ToString(), " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (amountes.Count > 0 && dishes.Count > 0)
                        {
                            CreateOrder(totalPrice, dishes, amountes, prices);
                        }
                        else
                        {
                            MessageBox.Show("Выберите хотя бы одно блюдо");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Вы ввели не число");
            }
        }
    }
}
