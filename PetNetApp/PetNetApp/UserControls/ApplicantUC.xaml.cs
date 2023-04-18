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
using WpfPresentation.Animals;

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for ApplicantUC.xaml
    /// </summary>
    public partial class ApplicantUC : UserControl
    {
        private Applicant _applicant = null;
        private AdoptionApplicationVM _application = null;
        private AnimalVM _animal = null;

        public ApplicantUC(Applicant applicant, AdoptionApplicationVM application, AnimalVM animal)
        {
            _application = application;
            _applicant = applicant;
            _animal = animal;
            InitializeComponent();
        }

        private void btnViewApplication_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();

            // to get back to mainwindow from uc on a new window
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.frameMain.Navigate(AnimalsPage.GetAnimalsPage().frameAnimals.Content = new ViewApplication(_application, _applicant, _animal));
        }

        private void btnViewProfile_Click(object sender, RoutedEventArgs e)
        {
            // once user profile created will pass user id
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new WpfPresentation.Animals.);
        }
    }
}
