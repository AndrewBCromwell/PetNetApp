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
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for VaccinationsPage.xaml
    /// </summary>
    public partial class VaccinationsPage : Page
    {
        private Animal _animal = new Animal();
        private List<Vaccination> _animalVaccines = null; //Contains all of the vaccines for the current animal selected
        private VaccinationManager _vaccinationManager = new VaccinationManager();

        //Method takes in an Animal object
        public VaccinationsPage(Animal animal)
        {
            _animal = animal;
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            lblAnimalID.Content = "Animal ID #: " + _animal.AnimalId;
            try
            {
                if (_animalVaccines == null)
                {
                    _animalVaccines = _vaccinationManager.RetrieveVaccinationsByAnimalId(_animal.AnimalId);
                    datVaccinations.ItemsSource = _animalVaccines;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //Activates Add Mode
        private void btnAddVaccine_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditVaccinationsPage(_animal));
        }
        //Activates Edit Mode
        private void datVaccinations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (datVaccinations.SelectedItem == null)
            {
                NavigationService.Navigate(new AddEditVaccinationsPage(_animal)); //If there are no records selected, create a new one
            }
            else
            {
                var vaccine = (Vaccination)datVaccinations.SelectedItem;

                NavigationService.Navigate(new AddEditVaccinationsPage(vaccine, _animal));
            }

        }
    }
}