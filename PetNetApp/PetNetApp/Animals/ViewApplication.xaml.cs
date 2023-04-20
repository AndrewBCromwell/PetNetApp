/// <summary>
/// Molly Meister
/// Created: 04/14/2023
/// 
/// ViewApplication class
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
using DataObjects;
using PetNetApp;

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for ViewApplication.xaml
    /// </summary>
    public partial class ViewApplication : Page
    {
        private AdoptionApplicationVM _application = null;
        private Applicant _applicant = null;
        private AnimalVM _animal = null;

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Custom constructor for ViewApplication that requires an AdoptionApplicationVM, Applicant and AnimalVM object.
        /// </summary>
        ///
        /// <param name="application"></param>
        /// <param name="applicant"></param>
        /// <param name="animal"></param>
        public ViewApplication(AdoptionApplicationVM application, Applicant applicant, AnimalVM animal)
        {
            _application = application;
            _applicant = applicant;
            _animal = animal;
            InitializeComponent();
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Custom constructor for ViewApplication that will take in parameters for Foster Application logic vs Adoption Application. Not yet implemented.
        /// </summary>
        public ViewApplication()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Logic to populate the view with the AdoptionApplication and Applicant objects passed to the constructor.
        /// </summary>
        public void PopulateApplication()
        {

            if(_applicant != null && _application != null && _animal != null)
            {
                lblTitle.Content = _applicant.ApplicantGivenName + "'s Application For " + _animal.AnimalName;
                txtApplicationStatus.Text = _application.ApplicationStatusId;
                txtApplicationDate.Text = _application.AdoptionApplicationDate.ToShortDateString();
                txtApplicantGivenName.Text = _applicant.ApplicantGivenName;
                txtApplicantFamilyName.Text = _applicant.ApplicantFamilyName;
                txtApplicantEmail.Text = _applicant.ApplicantEmail;
                txtApplicantPhoneNumber.Text = _applicant.ApplicantPhoneNumber;
                txtApplicantAddress1.Text = _applicant.ApplicantAddress;
                txtApplicantAddress2.Text = _applicant.ApplicantAddress2;
                txtApplicantZipCode.Text = _applicant.ApplicantZipCode;
                txtApplicantHomeType.Text = _applicant.HomeTypeId;
                txtApplicantHomeType.Text = _applicant.HomeOwnershipId;
                txtApplicantPets.Text = _applicant.NumberOfPets.ToString();
                txtApplicantChildren.Text = _applicant.NumberOfChildren.ToString();
            }
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Logic for page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateApplication();
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Click handler to return to the animal profile from the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackToAnimalProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.frameMain.Navigate(AnimalsPage.GetAnimalsPage().frameAnimals.Content = new ViewAdoptableAnimalProfile(_animal.AnimalId));
        }

        /// <summary>
        /// Molly Meister
        /// Created: 04/14/2023
        /// 
        /// Button handler to open the ApplicationResponseWindow to approve or deny the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            ApplicationResponseWindow win = new ApplicationResponseWindow(_application);
            win.Show();
        }
    }
}
