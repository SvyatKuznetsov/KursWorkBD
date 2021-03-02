
namespace kursWorkBD
{
    partial class Registration
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
            this.components = new System.ComponentModel.Container();
            this.nameReg = new System.Windows.Forms.Label();
            this.passReg = new System.Windows.Forms.Label();
            this.nameTextReg = new System.Windows.Forms.TextBox();
            this.passTextReg = new System.Windows.Forms.TextBox();
            this.typeTextReg = new System.Windows.Forms.ComboBox();
            this.typeReg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.restoranDataSet = new kursWorkBD.restoranDataSet();
            this.positionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.positionsTableAdapter = new kursWorkBD.restoranDataSetTableAdapters.PositionsTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.restoranDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameReg
            // 
            this.nameReg.AutoSize = true;
            this.nameReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameReg.Location = new System.Drawing.Point(350, 164);
            this.nameReg.Name = "nameReg";
            this.nameReg.Size = new System.Drawing.Size(88, 31);
            this.nameReg.TabIndex = 0;
            this.nameReg.Text = "Логин";
            // 
            // passReg
            // 
            this.passReg.AutoSize = true;
            this.passReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passReg.Location = new System.Drawing.Point(350, 217);
            this.passReg.Name = "passReg";
            this.passReg.Size = new System.Drawing.Size(108, 31);
            this.passReg.TabIndex = 1;
            this.passReg.Text = "Пароль";
            // 
            // nameTextReg
            // 
            this.nameTextReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextReg.Location = new System.Drawing.Point(471, 164);
            this.nameTextReg.Name = "nameTextReg";
            this.nameTextReg.Size = new System.Drawing.Size(250, 30);
            this.nameTextReg.TabIndex = 2;
            // 
            // passTextReg
            // 
            this.passTextReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextReg.Location = new System.Drawing.Point(471, 217);
            this.passTextReg.Name = "passTextReg";
            this.passTextReg.Size = new System.Drawing.Size(250, 30);
            this.passTextReg.TabIndex = 3;
            // 
            // typeTextReg
            // 
            this.typeTextReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeTextReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeTextReg.Items.AddRange(new object[] {
            "Клиент",
            "Повар",
            "Шеф-повар"});
            this.typeTextReg.Location = new System.Drawing.Point(471, 272);
            this.typeTextReg.Name = "typeTextReg";
            this.typeTextReg.Size = new System.Drawing.Size(250, 33);
            this.typeTextReg.TabIndex = 4;
            this.typeTextReg.SelectedIndexChanged += new System.EventHandler(this.typeTextReg_SelectedIndexChanged);
            // 
            // typeReg
            // 
            this.typeReg.AutoSize = true;
            this.typeReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeReg.Location = new System.Drawing.Point(350, 272);
            this.typeReg.Name = "typeReg";
            this.typeReg.Size = new System.Drawing.Size(61, 31);
            this.typeReg.TabIndex = 5;
            this.typeReg.Text = "Тип";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(517, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Подтвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // restoranDataSet
            // 
            this.restoranDataSet.DataSetName = "restoranDataSet";
            this.restoranDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // positionsBindingSource
            // 
            this.positionsBindingSource.DataMember = "Positions";
            this.positionsBindingSource.DataSource = this.restoranDataSet;
            // 
            // positionsTableAdapter
            // 
            this.positionsTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.typeReg);
            this.Controls.Add(this.typeTextReg);
            this.Controls.Add(this.passTextReg);
            this.Controls.Add(this.nameTextReg);
            this.Controls.Add(this.passReg);
            this.Controls.Add(this.nameReg);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.restoranDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameReg;
        private System.Windows.Forms.Label passReg;
        private System.Windows.Forms.TextBox nameTextReg;
        private System.Windows.Forms.TextBox passTextReg;
        private System.Windows.Forms.ComboBox typeTextReg;
        private System.Windows.Forms.Label typeReg;
        private System.Windows.Forms.Button button1;
        private restoranDataSet restoranDataSet;
        private System.Windows.Forms.BindingSource positionsBindingSource;
        private restoranDataSetTableAdapters.PositionsTableAdapter positionsTableAdapter;
        private System.Windows.Forms.Button button2;
    }
}