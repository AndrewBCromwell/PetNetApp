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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for AnimalMedicalProfile.xaml
    /// </summary>
    public partial class AnimalMedicalProfile : Page
    {
        private int _animalId;
        Kennel _kennel = new Kennel();
        AnimalVM _animalVM = new AnimalVM();
        MasterManager _masterManager = MasterManager.GetMasterManager();

        public AnimalMedicalProfile(int animalId)
        {
            InitializeComponent();
            _animalId = animalId;
        }

        public void disableControls()
        {
            txtAnimalBreed.IsEnabled = false;
            txtAnimalId.IsEnabled = false;
            txtAnimalKennelNum.IsEnabled = false;
            txtAnimalMicrochipNum.IsEnabled = false;
            txtAnimalName.IsEnabled = false;
            txtAnimalNotes.IsEnabled = false;
            rdbAnimalAlteredNo.IsEnabled = false;
            rdbAnimalAlteredYes.IsEnabled = false;
            rdbAnimalGenderFemale.IsEnabled = false;
            rdbAnimalGenderMale.IsEnabled = false;
            btnSave.Visibility = Visibility.Hidden;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            disableControls();
            try
            {
                _animalVM = _masterManager.AnimalManager.RetrieveAnimalMedicalProfileByAnimalId(_animalId);
                _kennel = _masterManager.KennelManager.RetrieveKennelIdByAnimalId(_animalId);
                lblProfileName.Content = _animalVM.AnimalName + "'s Medical Profile";
                txtAnimalBreed.Text = _animalVM.AnimalBreedId;
                txtAnimalId.Text = _animalVM.AnimalId.ToString();
                txtAnimalMicrochipNum.Text = _animalVM.MicrochipNumber.ToString();
                txtAnimalName.Text = _animalVM.AnimalName;
                txtAnimalNotes.Text = _animalVM.Notes;
                txtAnimalKennelNum.Text = _kennel.KennelId.ToString();
                if (_animalVM.AnimalGender == "Male")
                {
                    rdbAnimalGenderMale.IsChecked = true;
                }
                else if (_animalVM.AnimalGender == "Female")
                {
                    rdbAnimalGenderFemale.IsChecked = true;
                }
                if (_animalVM.NeuterStatus == true)
                {
                    rdbAnimalAlteredYes.IsChecked = true;
                }
                else if (_animalVM.NeuterStatus == false)
                {
                    rdbAnimalAlteredYes.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n\n" + ex.InnerException.Message, ButtonMode.Ok);
            }
            
        }
    }
}
