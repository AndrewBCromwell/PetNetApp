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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for MedProcedurePage.xaml
    /// </summary>
    public partial class MedProcedurePage : Page
    {
        private Animal _procedureAnimal;

        public MedProcedurePage(Animal animal)
        {
            InitializeComponent();
            _procedureAnimal = animal;
            displayProcedureAnimalId();

        }

        private void displayProcedureAnimalId()
        {
            lblProcedureAnimalId.Content = "Animal ID #" + _procedureAnimal.AnimalId;
        }

        private void btnAddMedProcedure_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProcedurePage(_procedureAnimal));
        }

        private void btnMedProcedureCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
