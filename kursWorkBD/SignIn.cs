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
    public partial class SignIn : Form
    {
        private SqlConnection con;

        public SignIn(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private DataTable getUserType(string name, string pass)
        {
            try
            {
                string str = "exec get_user_type @name=" + name + ", @pass=" + pass + ";";
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

        private DataTable getUserId(string name, string pass)
        {
            try
            {
                string str = "exec get_user_id @name=" + name + ", @pass=" + pass + ";";
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

        private void signInButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text == "")
                {
                    MessageBox.Show("Введите имя");
                }
                else if (passTextBox.Text == "")
                {
                    MessageBox.Show("Введите пароль");
                }
                else if (nameTextBox.Text == "" && passTextBox.Text == "")
                {
                    MessageBox.Show("Введите имя и пароль");
                }
                else
                {
                    string str = "select COUNT(*) from Users where Users.name=" + nameTextBox.Text + " and Users.password=" + passTextBox.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(str, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        DataTable tmpTable = getUserType(nameTextBox.Text, passTextBox.Text);
                        int type = Convert.ToInt32(string.IsNullOrEmpty(tmpTable.Rows[0][0].ToString()) ? "0" : tmpTable.Rows[0][0].ToString());
                        DataTable tmpTable2 = getUserId(nameTextBox.Text, passTextBox.Text);
                        int id = Convert.ToInt32(string.IsNullOrEmpty(tmpTable2.Rows[0][0].ToString()) ? "0" : tmpTable2.Rows[0][0].ToString());
                        switch (type)
                        {
                            case 1:
                                this.Hide();
                                UserMenu userMenu = new UserMenu(con, id);
                                userMenu.Show();
                                break;
                            case 2:
                                this.Hide();
                                CookMenu cookMenu = new CookMenu(con, id);
                                cookMenu.Show();
                                break;
                            case 3:
                                this.Hide();
                                ChefMenu chefMenu = new ChefMenu(con, id);
                                chefMenu.Show();
                                break;
                        }
                    }
                    else if (table.Rows[0][0].ToString() == "0")
                    {
                        MessageBox.Show("Вы ввели неправильное имя или пароль");
                    }
                    else
                    {
                        MessageBox.Show("Введите имя и пароль");
                    }
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show("Введите правильные данные");
            }
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration(con);
            reg.Show();
            this.Hide();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartWindow window = new StartWindow();
            window.Show();
            this.Hide();
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
