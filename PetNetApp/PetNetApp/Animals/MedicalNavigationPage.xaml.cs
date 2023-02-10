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
using WpfPresentation.Development.Animals.Medical;

namespace WpfPresentation.Development.Animals
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
            frameMedical.Navigate(null);
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
            // replace with page name and then delete comment
            frameMedical.Navigate(null);
        }

        private void btnTests_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(null);
        }

        private void btnMedNotes_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(null);
        }

        private void btnMedProcedures_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMedical.Navigate(new MedProcedurePage(_medicalProfileAnimal));
        }

        private void btnMedBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MedicalPage.getMedicalPage(_manager ));
        }
    }
}
