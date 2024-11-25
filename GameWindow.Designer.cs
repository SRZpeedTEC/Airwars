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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            label1 = new Label();
            GameBox = new PictureBox();
            lbltimer = new Label();
            btnInfoAdicional = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)GameBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 64);
            label1.Font = new Font("Unispace", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(515, 39);
            label1.Name = "label1";
            label1.Size = new Size(285, 25);
            label1.TabIndex = 3;
            label1.Text = "Aviones destruidos: 0";
            label1.Click += label1_Click_1;
            // 
            // GameBox
            // 
            GameBox.BackColor = Color.FromArgb(255, 224, 192);
            GameBox.Image = (Image)resources.GetObject("GameBox.Image");
            GameBox.Location = new Point(97, 97);
            GameBox.Name = "GameBox";
            GameBox.Size = new Size(1400, 811);
            GameBox.TabIndex = 6;
            GameBox.TabStop = false;
            GameBox.Click += GameBox_Click;
            // 
            // lbltimer
            // 
            lbltimer.AutoSize = true;
            lbltimer.BackColor = Color.FromArgb(0, 0, 64);
            lbltimer.Font = new Font("Unispace", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltimer.ForeColor = SystemColors.ControlLightLight;
            lbltimer.Location = new Point(77, 39);
            lbltimer.Name = "lbltimer";
            lbltimer.Size = new Size(220, 25);
            lbltimer.TabIndex = 7;
            lbltimer.Text = "Tiempo Restante:";
            lbltimer.Click += label4_Click;
            // 
            // btnInfoAdicional
            // 
            btnInfoAdicional.BackColor = Color.FromArgb(84, 142, 252);
            btnInfoAdicional.Location = new Point(1081, 34);
            btnInfoAdicional.Name = "btnInfoAdicional";
            btnInfoAdicional.Size = new Size(188, 41);
            btnInfoAdicional.TabIndex = 8;
            btnInfoAdicional.Text = "Informacion Adicional";
            btnInfoAdicional.UseVisualStyleBackColor = false;
            btnInfoAdicional.Click += btnInfoAdicional_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(84, 142, 252);
            button1.Location = new Point(1309, 34);
            button1.Name = "button1";
            button1.Size = new Size(188, 41);
            button1.TabIndex = 9;
            button1.Text = "Ver Pesos";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1595, 907);
            Controls.Add(button1);
            Controls.Add(btnInfoAdicional);
            Controls.Add(lbltimer);
            Controls.Add(GameBox);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            MaximumSize = new Size(1611, 946);
            MinimumSize = new Size(1611, 946);
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
        public PictureBox GameBox;
        private Label lbltimer;
        private Button btnInfoAdicional;
        private Button button1;
    }
}