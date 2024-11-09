namespace Airwars
{
    partial class InformacionExtra
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label3 = new Label();
            listBox3 = new ListBox();
            listBox4 = new ListBox();
            label4 = new Label();
            label5 = new Label();
            listBox5 = new ListBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 96);
            label1.Name = "label1";
            label1.Size = new Size(245, 14);
            label1.TabIndex = 0;
            label1.Text = "Caminos Calculados por los Aviones";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(18, 268);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(139, 23);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(394, 96);
            label2.Name = "label2";
            label2.Size = new Size(133, 14);
            label2.TabIndex = 3;
            label2.Text = "Pesos de las rutas";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(18, 125);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(250, 94);
            listBox1.TabIndex = 4;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(394, 125);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(250, 94);
            listBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 241);
            label3.Name = "label3";
            label3.Size = new Size(126, 14);
            label3.TabIndex = 6;
            label3.Text = "Atributos Aviones";
            label3.Click += label3_Click;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(18, 297);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(250, 94);
            listBox3.TabIndex = 7;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 15;
            listBox4.Location = new Point(349, 297);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(250, 94);
            listBox4.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(349, 241);
            label4.Name = "label4";
            label4.Size = new Size(140, 14);
            label4.TabIndex = 9;
            label4.Text = "Atributos Ordenados";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 417);
            label5.Name = "label5";
            label5.Size = new Size(266, 14);
            label5.TabIndex = 10;
            label5.Text = "Lista de aviones destruidos ordenados";
            label5.Click += label5_Click;
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 15;
            listBox5.Location = new Point(18, 445);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(665, 124);
            listBox5.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Perpetua Titling MT", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(219, 37);
            label6.Name = "label6";
            label6.Size = new Size(224, 25);
            label6.TabIndex = 12;
            label6.Text = "Panel de Control";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(349, 268);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(139, 23);
            comboBox2.TabIndex = 13;
            // 
            // InformacionExtra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(209, 231, 254);
            ClientSize = new Size(714, 591);
            Controls.Add(comboBox2);
            Controls.Add(label6);
            Controls.Add(listBox5);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(listBox4);
            Controls.Add(listBox3);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "InformacionExtra";
            Text = "InformacionExtra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label3;
        private ListBox listBox3;
        private ListBox listBox4;
        private Label label4;
        private Label label5;
        private ListBox listBox5;
        private Label label6;
        private ComboBox comboBox2;
    }
}