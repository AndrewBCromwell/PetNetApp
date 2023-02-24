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
        private static MedicalNavigationPage _existingMedicalNavigationPage = null;

        private Animal _medicalProfileAnimal = null;
        // the page needs to have an animal associated with it for the Use Cases it relates to 
        // too work properly. However, that can not happen until there is a way to select an animal.

        // private static int CURRENTANIMALISNULL = -1

        private MasterManager _manager = null;
        private Button[] _medicalTabButtons;



        public MedicalNavigationPage(MasterManager manager, Animal animal)
        {
            InitializeComponent();
            _manager = manager;
            _medicalTabButtons = new Button[] { btnMedProfile, btnVaccinations, btnTreatment, btnTests, btnMedNotes, btnMedProcedures };
            _medicalProfileAnimal = animal;
            displayMedProfileAnimalName();

            LoadMedicalProfileTab();
        }

        /// <summary>
        /// Andrew & Barry
        /// Created: 2023/02/21
        /// 
        /// Helper method that allows the medical navigation page to
        /// load defaulted to the Medical Profile tab
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void LoadMedicalProfileTab()
        {
            ChangeSelectedButton(btnMedProfile);
            frameMedical.Navigate(new AnimalMedicalProfile(_medicalProfileAnimal.AnimalId));
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
            ChangeSelectedButton((Button)sender);
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
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(new MedProcedurePage(_medicalProfileAnimal, _manager));
        }

        private void btnMedBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MedicalPage.GetMedicalPage(_manager));
        }
    }
}
