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
    /// Interaction logic for EditDetailAnimalProfile.xaml
    /// </summary>
    public partial class EditDetailAnimalProfile : Page
    {
        private MasterManager _manager = null;
        private AnimalVM _animalVM = null;

        public EditDetailAnimalProfile(MasterManager manager, AnimalVM animal)
        {
            InitializeComponent();
            _manager = manager;
            _animalVM = animal;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            setDetailMode();
        }

        // Helper methods
        private void populateControls()
        {
            txtAnimalName.Text = _animalVM.AnimalName;
            lblTitle.Content = _animalVM.AnimalName + "'s Profile";
            txtAnimalId.Text = _animalVM.AnimalId.ToString();
            txtAnimalTypeId.Text = _animalVM.AnimalTypeId;
            txtAnimalBreedId.Text = _animalVM.AnimalBreedId;
            txtAnimalGender.Text = _animalVM.AnimalGender;
            txtKennelName.Text = _animalVM.KennelName;

            DateTime receivedDate = new DateTime();
            receivedDate = _animalVM.BroughtIn;
            txtReceivedDate.Text = receivedDate.ToShortDateString();

            txtAnimalStatusId.Text = _animalVM.AnimalStatusId;
            txtDescription.Text = _animalVM.Description;
            txtPersonality.Text = _animalVM.Personality;
            txtMicrochipSerialNumber.Text = _animalVM.MicrochipNumber;
            txtAggressive.Text = (_animalVM.Aggressive) ? "Yes" : "No";
            txtAggressiveDescription.Text = _animalVM.AggressiveDescription;
            txtChildFriendly.Text = (_animalVM.ChildFriendly) ? "Yes" : "No";
            txtNeuterStatus.Text = (_animalVM.NeuterStatus) ? "Yes" : "No";
            txtNotes.Text = _animalVM.Notes;
        }

        private void setDetailMode()
        {
            populateControls();

            txtAnimalName.IsReadOnly = true;
            txtAnimalId.IsReadOnly = true;
            txtAnimalId.IsEnabled = true;
            txtAnimalTypeId.IsReadOnly = true;
            txtAnimalBreedId.IsReadOnly = true;
            txtAnimalGender.IsReadOnly = true;
            txtKennelName.IsReadOnly = true;
            txtReceivedDate.IsReadOnly = true;
            txtAnimalStatusId.IsReadOnly = true;
            txtDescription.IsReadOnly = true;
            txtPersonality.IsReadOnly = true;
            txtMicrochipSerialNumber.IsReadOnly = true;
            txtAggressive.IsReadOnly = true;
            txtAggressiveDescription.IsReadOnly = true;
            txtChildFriendly.IsReadOnly = true;
            txtNeuterStatus.IsReadOnly = true;
            txtNotes.IsReadOnly = true;
        }

        private void setEditMode()
        {
            txtAnimalName.IsReadOnly = false;
            txtAnimalId.IsReadOnly = true;
            txtAnimalId.IsEnabled = false;
            txtAnimalTypeId.IsReadOnly = false;
            txtAnimalBreedId.IsReadOnly = false;
            txtAnimalGender.IsReadOnly = false;
            txtKennelName.IsReadOnly = false;
            txtReceivedDate.IsReadOnly = false;
            txtAnimalStatusId.IsReadOnly = false;
            txtDescription.IsReadOnly = false;
            txtPersonality.IsReadOnly = false;
            txtMicrochipSerialNumber.IsReadOnly = false;
            txtAggressive.IsReadOnly = false;
            txtAggressiveDescription.IsReadOnly = false;
            txtChildFriendly.IsReadOnly = false;
            txtNeuterStatus.IsReadOnly = false;
            txtNotes.IsReadOnly = false;
        }

        private void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditSave.Content.ToString() == "Edit")
            {
                setEditMode();
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
