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
            selectAirplane = new ComboBox();
            InformacionRutas = new ListBox();
            label3 = new Label();
            AirplaneModulesInformation = new ListBox();
            AirPlanesModulesSorted = new ListBox();
            label4 = new Label();
            label5 = new Label();
            AvionesDestruidosOrdenados = new ListBox();
            label6 = new Label();
            SelectSortCriterio = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 43);
            label1.Name = "label1";
            label1.Size = new Size(245, 14);
            label1.TabIndex = 0;
            label1.Text = "Caminos Calculados por los Aviones";
            // 
            // selectAirplane
            // 
            selectAirplane.FormattingEnabled = true;
            selectAirplane.Location = new Point(18, 268);
            selectAirplane.Name = "selectAirplane";
            selectAirplane.Size = new Size(139, 23);
            selectAirplane.TabIndex = 1;
            selectAirplane.SelectedIndexChanged += selectAirplane_SelectedIndexChanged;
            // 
            // InformacionRutas
            // 
            InformacionRutas.FormattingEnabled = true;
            InformacionRutas.ItemHeight = 15;
            InformacionRutas.Location = new Point(18, 69);
            InformacionRutas.Name = "InformacionRutas";
            InformacionRutas.Size = new Size(671, 154);
            InformacionRutas.TabIndex = 4;
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
            // AirplaneModulesInformation
            // 
            AirplaneModulesInformation.FormattingEnabled = true;
            AirplaneModulesInformation.ItemHeight = 15;
            AirplaneModulesInformation.Location = new Point(18, 297);
            AirplaneModulesInformation.Name = "AirplaneModulesInformation";
            AirplaneModulesInformation.Size = new Size(250, 94);
            AirplaneModulesInformation.TabIndex = 7;
            // 
            // AirPlanesModulesSorted
            // 
            AirPlanesModulesSorted.FormattingEnabled = true;
            AirPlanesModulesSorted.ItemHeight = 15;
            AirPlanesModulesSorted.Location = new Point(349, 297);
            AirPlanesModulesSorted.Name = "AirPlanesModulesSorted";
            AirPlanesModulesSorted.Size = new Size(250, 94);
            AirPlanesModulesSorted.TabIndex = 8;
            AirPlanesModulesSorted.SelectedIndexChanged += AirPlanesModulesSorted_SelectedIndexChanged;
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
            // AvionesDestruidosOrdenados
            // 
            AvionesDestruidosOrdenados.FormattingEnabled = true;
            AvionesDestruidosOrdenados.ItemHeight = 15;
            AvionesDestruidosOrdenados.Location = new Point(18, 445);
            AvionesDestruidosOrdenados.Name = "AvionesDestruidosOrdenados";
            AvionesDestruidosOrdenados.Size = new Size(665, 124);
            AvionesDestruidosOrdenados.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Perpetua Titling MT", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(221, 9);
            label6.Name = "label6";
            label6.Size = new Size(224, 25);
            label6.TabIndex = 12;
            label6.Text = "Panel de Control";
            // 
            // SelectSortCriterio
            // 
            SelectSortCriterio.FormattingEnabled = true;
            SelectSortCriterio.Items.AddRange(new object[] { "ID", "Rol", "Flighthours" });
            SelectSortCriterio.Location = new Point(349, 268);
            SelectSortCriterio.Name = "SelectSortCriterio";
            SelectSortCriterio.Size = new Size(139, 23);
            SelectSortCriterio.TabIndex = 13;
            SelectSortCriterio.SelectedIndexChanged += SelectSortCriterio_SelectedIndexChanged;
            // 
            // InformacionExtra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(209, 231, 254);
            ClientSize = new Size(714, 591);
            Controls.Add(SelectSortCriterio);
            Controls.Add(label6);
            Controls.Add(AvionesDestruidosOrdenados);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(AirPlanesModulesSorted);
            Controls.Add(AirplaneModulesInformation);
            Controls.Add(label3);
            Controls.Add(InformacionRutas);
            Controls.Add(selectAirplane);
            Controls.Add(label1);
            Name = "InformacionExtra";
            Text = "InformacionExtra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox selectAirplane;
        private ListBox InformacionRutas;
        private Label label3;
        private ListBox AirplaneModulesInformation;
        private ListBox AirPlanesModulesSorted;
        private Label label4;
        private Label label5;
        private ListBox AvionesDestruidosOrdenados;
        private Label label6;
        private ComboBox SelectSortCriterio;
    }
}