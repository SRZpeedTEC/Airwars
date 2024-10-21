namespace Airwars
{
    partial class GameWindow
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
            label2 = new Label();
            label3 = new Label();
            GameBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)GameBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 64, 0);
            label1.Font = new Font("Unispace", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 24);
            label1.Name = "label1";
            label1.Size = new Size(285, 25);
            label1.TabIndex = 3;
            label1.Text = "Aviones destruidos: 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(192, 64, 0);
            label2.Font = new Font("Unispace", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(728, 24);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 4;
            label2.Text = "Jugador:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(192, 64, 0);
            label3.Font = new Font("Unispace", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(384, 24);
            label3.Name = "label3";
            label3.Size = new Size(181, 25);
            label3.TabIndex = 5;
            label3.Text = "Carga Cohete:";
            label3.Click += label3_Click;
            // 
            // GameBox
            // 
            GameBox.BackColor = Color.FromArgb(255, 224, 192);
            GameBox.Location = new Point(37, 78);
            GameBox.Name = "GameBox";
            GameBox.Size = new Size(1121, 831);
            GameBox.TabIndex = 6;
            GameBox.TabStop = false;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 64, 0);
            ClientSize = new Size(1192, 907);
            Controls.Add(GameBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Name = "GameWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AirWars Game";
            Load += GameWindow_Load;
            ((System.ComponentModel.ISupportInitialize)GameBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox GameBox;
    }
}