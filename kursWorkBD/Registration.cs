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
    public partial class Registration : Form
    {
        private int type = 0;
        private SqlConnection con;
        public Registration(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "restoranDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.restoranDataSet.Positions);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "select count(*) from Users where Users.name=" + nameTextReg.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(str, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show("Пользователь с таким именем уже существует");
                }
                else
                {
                    var cmd = new SqlCommand("insert into Users(name, password, type) values(@name, @pass, @type)", con);
                    cmd.Parameters.AddWithValue("@name", nameTextReg.Text);
                    cmd.Parameters.AddWithValue("@pass", passTextReg.Text);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Регистрация прошла успешно");
                    this.Hide();
                    SignIn signIn = new SignIn(con);
                    signIn.Show();
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void typeTextReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = typeTextReg.SelectedIndex;
            switch (t)
            {
                case 0:
                    type = 1;
                    break;
                case 1:
                    type = 2;
                    break;
                case 2:
                    type = 3;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartWindow window = new StartWindow();
            window.Show();
            this.Hide();
        }
    }
}
