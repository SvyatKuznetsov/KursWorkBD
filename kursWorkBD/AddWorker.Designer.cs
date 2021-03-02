
namespace kursWorkBD
{
    partial class AddWorker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fioText = new System.Windows.Forms.TextBox();
            this.hoursText = new System.Windows.Forms.TextBox();
            this.positionText = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(392, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(477, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кол-во рабочих часов в день";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(295, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Должность";
            // 
            // fioText
            // 
            this.fioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fioText.Location = new System.Drawing.Point(506, 80);
            this.fioText.Name = "fioText";
            this.fioText.Size = new System.Drawing.Size(296, 38);
            this.fioText.TabIndex = 3;
            // 
            // hoursText
            // 
            this.hoursText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hoursText.Location = new System.Drawing.Point(506, 160);
            this.hoursText.Name = "hoursText";
            this.hoursText.Size = new System.Drawing.Size(296, 38);
            this.hoursText.TabIndex = 4;
            // 
            // positionText
            // 
            this.positionText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.positionText.Items.AddRange(new object[] {
            "Оффициант",
            "Повар"});
            this.positionText.Location = new System.Drawing.Point(506, 247);
            this.positionText.Name = "positionText";
            this.positionText.Size = new System.Drawing.Size(296, 39);
            this.positionText.TabIndex = 5;
            this.positionText.SelectedIndexChanged += new System.EventHandler(this.positionText_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(563, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 63);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.positionText);
            this.Controls.Add(this.hoursText);
            this.Controls.Add(this.fioText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddWorker";
            this.Load += new System.EventHandler(this.AddWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fioText;
        private System.Windows.Forms.TextBox hoursText;
        private System.Windows.Forms.ComboBox positionText;
        private System.Windows.Forms.Button button1;
    }
}