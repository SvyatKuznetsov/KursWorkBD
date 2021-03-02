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
    public partial class CookMenu : Form
    {
        private SqlConnection con;
        private int id;
        private int index = 0;

        public CookMenu(SqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
        }

        private void CookMenu_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        public void LoadMenu()
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

        private void LoadStorage()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string query = "exec get_ingredients_at_storage;";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[3]);
                    string FIO = reader[0].ToString();
                    data[data.Count - 1][0] = FIO;
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                }
                reader.Close();
                foreach (string[] s in data)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void LoadIngredients()
        {
            try
            {
                string str = "select Ingredients.nameOfIngr from Ingredients";
                SqlCommand cmd = new SqlCommand(str, con);
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                for (int i = 0; i < table.Rows.Count; ++i)
                {
                    ingrText.Items.Add(table.Rows[i][0].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void LoadOrders()
        {
            try
            {
                comboBox1.Items.Clear();
                string str = "exec load_waiting_orders";
                SqlCommand cmd = new SqlCommand(str, con);
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                bool first = true;
                StringBuilder s = new StringBuilder();
                for (int i = 0; i < table.Rows.Count; ++i)
                {
                    if (first)
                    {
                        s.Append("№" + Convert.ToInt32(table.Rows[i][0]) + ", " + table.Rows[i][1].ToString() + " " + table.Rows[i][2] + ", ");
                        first = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(table.Rows[i][0]) == Convert.ToInt32(table.Rows[i - 1][0]))
                        {
                            s.Append(table.Rows[i][1].ToString() + " " + table.Rows[i][2] + ", ");
                        }
                        else
                        {
                            comboBox1.Items.Add(s.ToString());
                            s.Clear();
                            s.Append("№" + Convert.ToInt32(table.Rows[i][0]) + ", " + table.Rows[i][1].ToString() + " " + table.Rows[i][2] + ", ");
                        }
                    }
                }
                comboBox1.Items.Add(s.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    LoadOrders();
                    break;
                case 1:
                    LoadStorage();
                    break;
                case 2:
                    LoadIngredients();
                    break;
                case 3:
                    LoadMenu();
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
            AddDish window = new AddDish(con, this);
            window.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить блюдо?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string name = dataGrid.SelectedRows[0].Cells[0].Value.ToString();
                    string str = "exec remove_dish @name='" + name + "';";
                    var cmd = new SqlCommand(str.ToString(), con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Блюдо удалено");
                    LoadMenu();
                }
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int amount = Convert.ToInt32(amountIngrText.Text.ToString());
                if (amount <= 0)
                {
                    MessageBox.Show("Введите положительное число");
                }
                else
                {
                    if (ingrText.SelectedItem.ToString() == "")
                    {
                        MessageBox.Show("Выберите ингредиент");
                    }
                    else
                    {
                        if (MessageBox.Show("Заказать ингредиент?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string name = ingrText.SelectedItem.ToString();
                            string str = "exec update_ingredients_at_storage @amount=" + amount
                                + ", @name='" + name + "';";
                            var cmd = new SqlCommand(str.ToString(), con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ингредиент " + name + " в количестве " + amount + " единиц заказан");
                        }
                    }
                }
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ingredients = new List<string>();
                List<string> dishes = new List<string>();
                List<int> amountDishes = new List<int>();
                List<int> amountInrgs = new List<int>();
                int orderId = -1;
                string order;
                bool findOrder = false;
                if (index == 0)
                {
                    MessageBox.Show("Выберите заказ");
                    order = "";
                }
                else
                {
                    order = comboBox1.SelectedItem.ToString();
                }
                if (MessageBox.Show("Выполнить заказ?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    while (order.Length > 1)
                    {
                        int indexSpace = 0;
                        int index = order.IndexOf(", ");
                        if (!findOrder)
                        {
                            orderId = Convert.ToInt32(order.Substring(1, index - 1));
                            order = order.Substring(index + 2, order.Length - index - 2);
                            index = order.IndexOf(", ");
                            findOrder = true;
                        }
                        for (int i = 0; i < index; ++i)
                        {
                            int k;
                            if (Int32.TryParse(order[i].ToString(), out k))
                            {
                                indexSpace = i - 1;
                                break;
                            }
                        }
                        string dish = order.Substring(0, indexSpace);
                        order = order.Substring(indexSpace + 1, order.Length - indexSpace - 1);
                        index = order.IndexOf(", ");
                        int amount = Convert.ToInt32(order.Substring(0, index));
                        order = order.Substring(index + 2, order.Length - index - 2);
                        dishes.Add(dish);
                        amountDishes.Add(amount);
                    }

                    bool first = true;
                    for (int i = 0; i < dishes.Count; ++i)
                    {
                        string str = "exec get_ingredients_of_dish @nameOfDish='" + dishes[i] + "';";
                        SqlCommand cmd = new SqlCommand(str, con);
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        for (int k = 0; k < table.Rows.Count; ++k)
                        {
                            if (first)
                            {
                                amountInrgs.Add(Convert.ToInt32(table.Rows[k][1].ToString()) * amountDishes[i]);
                                ingredients.Add(table.Rows[k][0].ToString());
                                first = false;
                            }
                            else
                            {
                                bool finded = false;
                                for (int j = 0; j < ingredients.Count; ++j)
                                {
                                    if (ingredients[j] == table.Rows[k][0].ToString())
                                    {
                                        amountInrgs[j] += Convert.ToInt32(table.Rows[k][1].ToString()) * amountDishes[i];
                                        finded = true;
                                    }
                                }
                                if (!finded)
                                {
                                    amountInrgs.Add(Convert.ToInt32(table.Rows[k][1].ToString()) * amountDishes[i]);
                                    ingredients.Add(table.Rows[k][0].ToString());
                                }
                            }

                        }
                    }

                    bool noIngr = false;
                    for (int i = 0; i < ingredients.Count; ++i)
                    {
                        string query = "select Ingredients.countStorage from Ingredients " +
                            "where Ingredients.nameOfIngr='" + ingredients[i] + "';";
                        SqlCommand cmd = new SqlCommand(query, con);
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        int k = Convert.ToInt32(table.Rows[0][0].ToString());
                        if (k < amountInrgs[i])
                        {
                            MessageBox.Show("Недостаточно ингредиента '" + ingredients[i] + "', требуется: " + amountInrgs[i]
                                + ", имеется на складе: " + k);
                            noIngr = true;
                            break;
                        }
                    }

                    if (!noIngr)
                    {
                        for (int i = 0; i < ingredients.Count; ++i)
                        {
                            string str = "exec remove_ingredients_from_storage @amount=" + amountInrgs[i]
                                + ", @name='" + ingredients[i] + "', @orderId=" + orderId + ";";
                            var cmd = new SqlCommand(str.ToString(), con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Заказ выполнен");
                        }
                    }

                    LoadOrders();
                }
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = 1;
        }
    }
}
