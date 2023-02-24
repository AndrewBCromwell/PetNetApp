/// <summary>
/// Andrew Cromwell
/// Created: 2023/02/01
/// 
/// Interaction logic for MedicalNavigationPage.xaml
/// </summary>

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
using LogicLayer;
using DataObjects;
using WpfPresentation.Animals.Medical;

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for MedicalNavigationPage.xaml
    /// </summary>
    public partial class MedicalNavigationPage : Page
    {
        private Animal _medicalProfileAnimal = null;

        private MasterManager _manager = null;
        private Button[] _medicalTabButtons;

        public MedicalNavigationPage(MasterManager manager, Animal animal)
        {
            InitializeComponent();
            _manager = manager;
            _medicalTabButtons = new Button[] { btnMedProfile, btnVaccinations, btnTreatment, btnTests, btnMedNotes, btnMedProcedures };
            _medicalProfileAnimal = animal;
            displayMedProfileAnimalName();

            // modified by Stephen: Modified the MedicalNavigationPage to show Profile by default
            btnMedProfile_Click(this, new RoutedEventArgs());
        }

        private void displayMedProfileAnimalName()
        {
            this.lblMedProfileAnimal.Content = _medicalProfileAnimal.AnimalName;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _medicalTabButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
        }

        private void btnMedProfile_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnMedProfile);
            // replace with page name and then delete comment
            frameMedical.Navigate(new AnimalMedicalProfile(_medicalProfileAnimal.AnimalId));
        }

        private void btnVaccinations_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(null);
        }

        private void btnTreatment_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMedical.Navigate(new MedicalTreatmentPage(_medicalProfileAnimal));
        }

        private void btnTests_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(AnimalMedicalTestsPage.GetAnimalMedicalTestsPage(_medicalProfileAnimal));
        }

        private void btnMedNotes_Click(object sender, RoutedEventArgs e) 
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(new MedicalFilesPage(_medicalProfileAnimal, _manager));
        }

        private void btnMedProcedures_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnMedProcedures);
            // replace with page name and then delete comment
            frameMedical.Navigate(new MedProcedurePage(_medicalProfileAnimal, _manager));
        }

        private void btnMedBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MedicalPage.GetMedicalPage(_manager));
        }
    }
}
