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
    public partial class AddDish : Form
    {
        private SqlConnection con;
        private CookMenu cookMenu;

        public AddDish(SqlConnection con, CookMenu cookMenu)
        {
            InitializeComponent();
            this.con = con;
            this.cookMenu = cookMenu;
        }

        private void AddDish_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Добавить блюдо?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int price = Convert.ToInt32(priceText.Text.ToString());
                    string name = nameText.Text.ToString();
                    StringBuilder str = new StringBuilder();
                    str.Append("exec add_dish @price=" + price + ", @name='" + name + "';");
                    var cmd = new SqlCommand(str.ToString(), con);
                    cmd.ExecuteNonQuery();

                    List<string> ingr = new List<string>();
                    List<int> amountes = new List<int>();
                    string ingredients = ingrText.Text;
                    while (ingredients.Length > 1)
                    {
                        int index = ingredients.IndexOf(" ");
                        string s = ingredients.Substring(0, index);
                        ingredients = ingredients.Substring(index + 1, ingredients.Length - index - 1);
                        ingr.Add(s);
                        index = ingredients.IndexOf(",");
                        int amount = Convert.ToInt32(ingredients.Substring(0, index));
                        amountes.Add(amount);
                        ingredients = ingredients.Substring(index + 2, ingredients.Length - index - 2);
                    }

                    if (ingr.Count == 0)
                    {
                        MessageBox.Show("Вы не ввели ингредиенты");
                    }
                    else
                    {
                        for (int i = 0; i < ingr.Count; ++i)
                        {
                            str.Clear();
                            str.Append("exec add_dish_description @amount=" + amountes[i]
                                + ", @ingr='" + ingr[i] + "';");
                            var command = new SqlCommand(str.ToString(), con);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Блюдо добавлено");
                        this.Hide();
                        cookMenu.LoadMenu();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка в описании ингредиентов или неправильно указана цена");
            }
        }
    }
}
