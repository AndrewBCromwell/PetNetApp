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

namespace WpfPresentation.Development.Animals
{
    /// <summary>
    /// Interaction logic for MedicalNavigationPage.xaml
    /// </summary>
    public partial class MedicalNavigationPage : Page
    {
        private static MedicalNavigationPage _existingMedicalNavigationPage = null;
        
        // private Animal _medicalProfileAnimal = null;
        // the page needs to have an animal associated with it for the Use Cases it relates to 
        // too work properly. However, that can not happen until there is a way to select an animal.

        // private static int CURRENTANIMALISNULL = -1

        private MasterManager _manager = null;
        private Button[] _medicalTabButtons;

        public MedicalNavigationPage(MasterManager manager) // if there is no way to get to this page without selecting an animal, only the other constructor will be needed, else both will be needed
        {
            InitializeComponent();
            _manager = manager;
            _medicalTabButtons = new Button[] { btnMedProfile, btnVaccinations, btnTreatment, btnTests, btnMedNotes, btnMedProcedures };
        }

        // public MedicalNavigationPage(MasterManager manager, Animal animal) // this is commented out because  it would cause syntax errors untill there is such an Object as Animal is defined.
        // {
        //    InitializeComponent();
        //    _manager = manager;
        //    _medicalTabButtons = new Button[] { btnMedProfile, btnVaccinations, btnTreatment, btnTests, btnMedNotes, btnMedProcedures };
        //    _medicalProfileAnimal = animal;
        //    displayMedProfileAnimalName();
        //}

        public static MedicalNavigationPage GetMedicalNavigationPage(MasterManager manager) // if there is no way to get to this page without selecting an animal, only the other GetMedicalNavigationPage will be needed, else both will be needed
        {
            if (_existingMedicalNavigationPage == null)
            {
                _existingMedicalNavigationPage = new MedicalNavigationPage(manager); 
            }
            return _existingMedicalNavigationPage;
        }

        //public static MedicalNavigationPage GetMedicalNavigationPage(MasterManager manager, Animal animal) // this is commented out because  it would cause syntax errors untill there is such an Object as Animal is defined.
        //{
        //    if (_existingMedicalNavigationPage == null)
        //    {
        //        _existingMedicalNavigationPage = new MedicalNavigationPage(manager, animal); 
        //    }
        //    else if (_existingMedicalNavigationPage.GetMedProfileAnimalId() != animal.AnimalId)
        //    {
        //        _existingMedicalNavigationPage = new MedicalNavigationPage(manager, animal); // Would it work to just change which animal the existing page refers to, or would we also need to create a new page when a different animal is selected?
        //    {
        //    return _existingMedicalNavigationPage;
        //}

        //private void displayMedProfileAnimalName()            This will make the animal's name appear at the top of the side navigation bar, it is commented because it will cause syntaxs errors until such an Object as an animal is defined.
        //{
        //    this.lblMedProfileAnimal.Content = _medicalProfileAnimal.Name;
        //}

        //public int GetMedProfileAnimalId() 
        //{
        
        //  result = _medicalProfileAnimal.AnimalId;
      
        //  return result;
        //}

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
            frameMedical.Navigate(null);
        }

        private void btnMedBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }
    }
}
