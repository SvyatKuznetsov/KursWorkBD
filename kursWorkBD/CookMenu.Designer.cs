
namespace kursWorkBD
{
    partial class CookMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Заказы = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.Склад = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Закупки = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.ingrText = new System.Windows.Forms.ComboBox();
            this.amountIngrText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Меню = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.NameOfDish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Профиль = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.passProfileText = new System.Windows.Forms.TextBox();
            this.loginProfileText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Выход = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.Заказы.SuspendLayout();
            this.Склад.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Закупки.SuspendLayout();
            this.Меню.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.Профиль.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Заказы);
            this.tabControl1.Controls.Add(this.Склад);
            this.tabControl1.Controls.Add(this.Закупки);
            this.tabControl1.Controls.Add(this.Меню);
            this.tabControl1.Controls.Add(this.Профиль);
            this.tabControl1.Controls.Add(this.Выход);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 537);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Заказы
            // 
            this.Заказы.Controls.Add(this.comboBox1);
            this.Заказы.Controls.Add(this.button5);
            this.Заказы.Location = new System.Drawing.Point(4, 22);
            this.Заказы.Name = "Заказы";
            this.Заказы.Padding = new System.Windows.Forms.Padding(3);
            this.Заказы.Size = new System.Drawing.Size(952, 511);
            this.Заказы.TabIndex = 0;
            this.Заказы.Text = "Заказы";
            this.Заказы.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(940, 33);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(414, 88);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 66);
            this.button5.TabIndex = 2;
            this.button5.Text = "Выполнить заказ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Склад
            // 
            this.Склад.Controls.Add(this.dataGridView1);
            this.Склад.Location = new System.Drawing.Point(4, 22);
            this.Склад.Name = "Склад";
            this.Склад.Padding = new System.Windows.Forms.Padding(3);
            this.Склад.Size = new System.Drawing.Size(952, 511);
            this.Склад.TabIndex = 2;
            this.Склад.Text = "Склад";
            this.Склад.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(940, 499);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ингредиент";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "На складе";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Цена за единицу";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Закупки
            // 
            this.Закупки.Controls.Add(this.button4);
            this.Закупки.Controls.Add(this.ingrText);
            this.Закупки.Controls.Add(this.amountIngrText);
            this.Закупки.Controls.Add(this.label4);
            this.Закупки.Controls.Add(this.label3);
            this.Закупки.Location = new System.Drawing.Point(4, 22);
            this.Закупки.Name = "Закупки";
            this.Закупки.Size = new System.Drawing.Size(952, 511);
            this.Закупки.TabIndex = 3;
            this.Закупки.Text = "Закупки";
            this.Закупки.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(461, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 42);
            this.button4.TabIndex = 4;
            this.button4.Text = "Заказать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ingrText
            // 
            this.ingrText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ingrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ingrText.FormattingEnabled = true;
            this.ingrText.Location = new System.Drawing.Point(370, 90);
            this.ingrText.Name = "ingrText";
            this.ingrText.Size = new System.Drawing.Size(380, 39);
            this.ingrText.TabIndex = 3;
            // 
            // amountIngrText
            // 
            this.amountIngrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amountIngrText.Location = new System.Drawing.Point(370, 157);
            this.amountIngrText.Name = "amountIngrText";
            this.amountIngrText.Size = new System.Drawing.Size(380, 38);
            this.amountIngrText.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(182, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(182, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ингредиент";
            // 
            // Меню
            // 
            this.Меню.Controls.Add(this.button3);
            this.Меню.Controls.Add(this.button2);
            this.Меню.Controls.Add(this.dataGrid);
            this.Меню.Location = new System.Drawing.Point(4, 22);
            this.Меню.Name = "Меню";
            this.Меню.Size = new System.Drawing.Size(952, 511);
            this.Меню.TabIndex = 6;
            this.Меню.Text = "Меню";
            this.Меню.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(755, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить блюдо";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(755, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Добавить блюдо";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameOfDish,
            this.Price,
            this.ingredients});
            this.dataGrid.Location = new System.Drawing.Point(5, 6);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(943, 499);
            this.dataGrid.TabIndex = 1;
            // 
            // NameOfDish
            // 
            this.NameOfDish.HeaderText = "Блюдо";
            this.NameOfDish.Name = "NameOfDish";
            this.NameOfDish.ReadOnly = true;
            this.NameOfDish.Width = 200;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // ingredients
            // 
            this.ingredients.HeaderText = "Состав";
            this.ingredients.Name = "ingredients";
            this.ingredients.ReadOnly = true;
            this.ingredients.Width = 400;
            // 
            // Профиль
            // 
            this.Профиль.Controls.Add(this.button1);
            this.Профиль.Controls.Add(this.passProfileText);
            this.Профиль.Controls.Add(this.loginProfileText);
            this.Профиль.Controls.Add(this.label2);
            this.Профиль.Controls.Add(this.label1);
            this.Профиль.Location = new System.Drawing.Point(4, 22);
            this.Профиль.Name = "Профиль";
            this.Профиль.Size = new System.Drawing.Size(952, 511);
            this.Профиль.TabIndex = 4;
            this.Профиль.Text = "Профиль";
            this.Профиль.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(429, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passProfileText
            // 
            this.passProfileText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passProfileText.Location = new System.Drawing.Point(373, 130);
            this.passProfileText.Name = "passProfileText";
            this.passProfileText.Size = new System.Drawing.Size(263, 30);
            this.passProfileText.TabIndex = 8;
            this.passProfileText.UseSystemPasswordChar = true;
            // 
            // loginProfileText
            // 
            this.loginProfileText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginProfileText.Location = new System.Drawing.Point(373, 188);
            this.loginProfileText.Name = "loginProfileText";
            this.loginProfileText.Size = new System.Drawing.Size(263, 30);
            this.loginProfileText.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(250, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(270, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // Выход
            // 
            this.Выход.Location = new System.Drawing.Point(4, 22);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(952, 511);
            this.Выход.TabIndex = 5;
            this.Выход.Text = "Выход";
            this.Выход.UseVisualStyleBackColor = true;
            // 
            // CookMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "CookMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CookMenu";
            this.Load += new System.EventHandler(this.CookMenu_Load);
            this.tabControl1.ResumeLayout(false);
            this.Заказы.ResumeLayout(false);
            this.Склад.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Закупки.ResumeLayout(false);
            this.Закупки.PerformLayout();
            this.Меню.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.Профиль.ResumeLayout(false);
            this.Профиль.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Заказы;
        private System.Windows.Forms.TabPage Склад;
        private System.Windows.Forms.TabPage Закупки;
        private System.Windows.Forms.TabPage Меню;
        private System.Windows.Forms.TabPage Профиль;
        private System.Windows.Forms.TabPage Выход;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginProfileText;
        private System.Windows.Forms.TextBox passProfileText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredients;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox ingrText;
        private System.Windows.Forms.TextBox amountIngrText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}