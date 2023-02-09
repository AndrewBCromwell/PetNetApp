using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPresentation.UserControls;

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for AnimalListPage.xaml
    /// </summary>
    public partial class AnimalListPage : Page
    {
        private MasterManager masterManager = new MasterManager();
        private List<Animal> _animals = null;

        public AnimalListPage()
        {
            InitializeComponent();
        }


        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                _animals = masterManager.AnimalManager.RetrieveAllAnimals();
                // help from gwen, populate AnimalListPage with user controls
                for (int i = 0; i < _animals.Count / 4; i++)
                {
                    grdAnimalList.RowDefinitions.Add(new RowDefinition());
                }

                for (int i = 0; i < _animals.Count; i++)
                {
                    AnimalListUserControl animalListUserControl = new AnimalListUserControl();
                    animalListUserControl.lblAnimalListAnimalName.Content = _animals[i].AnimalName;
                    animalListUserControl.lblAnimalListAnimalID.Content = _animals[i].AnimalId;

                    int j = i;

                    Grid.SetRow(animalListUserControl, i / 4);
                    Grid.SetColumn(animalListUserControl, i % 4);
                    grdAnimalList.Children.Add(animalListUserControl);
                }
            }
            catch (Exception up)
            {
                MessageBox.Show(up.Message);
                return;
            }

        }
    }
}
