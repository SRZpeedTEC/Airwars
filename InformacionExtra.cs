using Airwars.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airwars.AlgoritmosDeOrdenamiento;
using Airwars.Models.AirplaneModuls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Airwars
{
    public partial class InformacionExtra : Form
    {
        public static InformacionExtra Instance = null;
        public List<Airplane> AirplaneSortedList = new List<Airplane>();
        public List<AirPlaneModul> AirplaneModuleSortedList = new List<AirPlaneModul>();
        public Airplane SelectedAirplane;

        public static InformacionExtra GetInstance()
        {
            if (Instance == null)
            {
                Instance = new InformacionExtra();
            }
            return Instance;
        }

        public InformacionExtra()
        {
            InitializeComponent();
        }

        public void UpdateData()
        {
            AirplaneSortedList = MergeSort.MergeSortAvionesDerribados(AirplaneSortedList);
            AvionesDestruidosOrdenados.Items.Clear();
            AvionesDestruidosOrdenados.Items.Add("ID Avion");
            foreach (Airplane airplane in AirplaneSortedList)
            {
                AvionesDestruidosOrdenados.Items.Add(airplane.Guid);
            }
            selectAirplaneOptions();
        }

        public void clearData()
        {
            AvionesDestruidosOrdenados.Items.Clear();
            AirplaneSortedList.Clear();
        }

        public void selectAirplaneOptions()
        {
            clearAirplaneOptions();
            foreach (Airplane airplane in AirplaneSortedList)
            {
                selectAirplane.Items.Add(airplane.Guid);
            }
        }

        public void clearAirplaneOptions()
        {
            selectAirplane.Items.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void selectAirplane_SelectedIndexChanged(object sender, EventArgs e)
        {

            AirplaneModulesInformation.Items.Clear();
            clearSelectSortCriterio();

            string selectedAirplaneCombobox = selectAirplane.SelectedItem.ToString();
            SelectedAirplane = AirplaneSortedList.Find(airplane => airplane.Guid.ToString() == selectedAirplaneCombobox);

            foreach (AirPlaneModul AirplaneModule in SelectedAirplane.Tripulacion)
            {
                AirplaneModulesInformation.Items.Add($"{AirplaneModule.GetType().Name}: {AirplaneModule.ID}");
            }
        }

        private void SelectSortCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            AirPlanesModulesSorted.Items.Clear();

            switch (SelectSortCriterio.SelectedItem.ToString())
            {
                case "ID":
                    AirplaneModuleSortedList = SelectionSort.SelectionSortTripulacion(SelectedAirplane.Tripulacion, "id");
                    foreach (AirPlaneModul Module in AirplaneModuleSortedList)
                    {
                        AirPlanesModulesSorted.Items.Add($"{Module.GetType().Name}: {Module.ID}");
                    }
                    break;
                case "Rol":
                    AirplaneModuleSortedList = SelectionSort.SelectionSortTripulacion(SelectedAirplane.Tripulacion, "rol");
                    foreach (AirPlaneModul Module in AirplaneModuleSortedList)
                    {
                        AirPlanesModulesSorted.Items.Add($"{Module.GetType().Name}: {Module.Rol}");
                    }
                    break;
                case "Flighthours":
                    AirplaneModuleSortedList = SelectionSort.SelectionSortTripulacion(SelectedAirplane.Tripulacion, "flighthours");
                    foreach (AirPlaneModul Module in AirplaneModuleSortedList)
                    {
                        AirPlanesModulesSorted.Items.Add($"{Module.GetType().Name}: {Module.flightHours}");
                    }
                    break;
            }
        }

        private void clearSelectSortCriterio()
        {
            SelectSortCriterio.SelectedItem = -1;
            SelectSortCriterio.Text = String.Empty;
            AirPlanesModulesSorted.Items.Clear();
        }

        private void AirPlanesModulesSorted_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
