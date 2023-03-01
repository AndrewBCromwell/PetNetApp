/// <summary>
/// John
/// Created: 2023/02/03
/// 
/// Interaction logic for AddAnimalPage.xaml
/// </summary>
///
/// <remarks>
/// Andrew Schneider
/// Updated: 2023/02/22
/// </remarks>
/// 

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

namespace WpfPresentation.Development.Animals
{
    public partial class AddAnimalPage : Page
    {
        private MasterManager _manager = null;
        Dictionary<string, List<string>> _breeds = null;
        List<string> _genders = null;
        List<string> _types = null;
        List<string> _statuses = null;
        List<string> _yesNo = new List<string> { "Yes", "No" };

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/23
        /// 
        /// Constructor for building the AddAnimalProfile page
        /// where the user can add a new animal profile record
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="manager">An instance of the master manager</param>
        public AddAnimalPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/01
        /// </summary>
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dpReceivedDate.SelectedDate = DateTime.Today;
            dpReceivedDate.IsEnabled = false;
            populateComboBoxes();
            wpAnimalImages.Children.Clear();
            for (int i = 0; i < 20; i++)
            {
                var button = new Button();
                button.Width = 300;
                button.Height = 200;
                button.Content = "Button " + i;
                wpAnimalImages.Children.Add(button);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/02
        /// 
        /// Helper method for populating the combo boxes with all
        /// the available data that can be selected when editing
        /// the animal profile record;
        /// The _yesNo list is used to present the user with human
        /// readable Yes/No options that can be coverted to booleans
        /// in the background
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void populateComboBoxes()
        {
            _breeds = _manager.AnimalManager.RetrieveAllAnimalBreeds();
            _types = _manager.AnimalManager.RetrieveAllAnimalTypes();
            cmbAnimalTypeId.ItemsSource = _types;

            _genders = _manager.AnimalManager.RetrieveAllAnimalGenders();
            cmbAnimalGender.ItemsSource = _genders;
            _statuses = _manager.AnimalManager.RetrieveAllAnimalStatuses();
            cmbAnimalStatusId.ItemsSource = _statuses;
            cmbAggressive.ItemsSource = _yesNo;
            cmbChildFriendly.ItemsSource = _yesNo;
            cmbNeuterStatus.ItemsSource = _yesNo;
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/27
        /// 
        /// Click event method for the "Save" button that performs validation
        /// and if it passes inserts an animal record into the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
        
            if (txtAnimalName.Text == "" || cmbAnimalTypeId.SelectedItem == null || cmbAnimalBreedId.SelectedItem == null ||
                cmbAnimalGender.SelectedItem == null || cmbAnimalStatusId.SelectedItem == null || cmbAggressive.SelectedItem == null ||
                cmbChildFriendly.SelectedItem == null || cmbNeuterStatus.SelectedItem == null)
            {
                PromptWindow.ShowPrompt("Error", "Please enter all fields.", ButtonMode.Ok);
            }
            else
            {
                AnimalVM newAnimal = new AnimalVM();

                bool goodData = true;

                // Validate animal name
                if (goodData)
                {
                    if (txtAnimalName.Text.IsValidFirstName())
                    {
                        goodData = true;
                        newAnimal.AnimalName = txtAnimalName.Text;
                    }
                    else
                    {
                        goodData = false;
                        PromptWindow.ShowPrompt("Format Error", "Animal name must be in proper format.",
                                                ButtonMode.Ok);
                        txtAnimalName.Focus();
                        txtAnimalName.SelectAll();
                    }
                }

                // Validate microchip number length
                if (goodData)
                {
                    // Check if anything has been entered (it's nullable so it could be left blank)
                    if (txtMicrochipNumber.Text.Length > 0)
                    {
                        // Check if input will work with the database datatype
                        if (txtMicrochipNumber.Text.Length > 15)
                        {
                            goodData = false;
                            PromptWindow.ShowPrompt("Data Error", "Microchip number can only be\n15 characters long.",
                                                    ButtonMode.Ok);
                            txtMicrochipNumber.Focus();
                            txtMicrochipNumber.SelectAll();
                        }
                        else
                        {
                            goodData = true;
                        }
                    }
                }

                // If validation has passed (goodData is still true) try to update the animal profile record
                if (goodData)
                {
                    newAnimal.AnimalShelterId = _manager.User.ShelterId.Value;
                    newAnimal.AnimalTypeId = cmbAnimalTypeId.SelectedItem.ToString();
                    newAnimal.AnimalBreedId = cmbAnimalBreedId.SelectedItem.ToString();
                    newAnimal.AnimalGender = cmbAnimalGender.SelectedItem.ToString();
                    newAnimal.AnimalStatusId = cmbAnimalStatusId.SelectedItem.ToString();
                    newAnimal.Description = txtDescription.Text;
                    newAnimal.Personality = txtPersonality.Text;
                    newAnimal.MicrochipNumber = txtMicrochipNumber.Text;
                    
                    if (cmbAggressive.SelectedItem.ToString() == "Yes")
                    {
                        newAnimal.Aggressive = true;
                        newAnimal.AggressiveDescription = txtAggressiveDescription.Text;
                    }
                    else
                    {
                        newAnimal.Aggressive = false;
                        newAnimal.AggressiveDescription = "";
                    }

                    if (cmbChildFriendly.SelectedItem.ToString() == "Yes")
                    {
                        newAnimal.ChildFriendly = true;
                    }
                    else
                    {
                        newAnimal.ChildFriendly = false;
                    }
                    if (cmbNeuterStatus.SelectedItem.ToString() == "Yes")
                    {
                        newAnimal.NeuterStatus = true;
                    }
                    else
                    {
                        newAnimal.NeuterStatus = false;
                    }
                    newAnimal.Notes = txtNotes.Text;

                    try
                    {
                        if (_manager.AnimalManager.AddAnimal(newAnimal))
                        {
                            // success
                            PromptWindow.ShowPrompt("Success", "Animal record has been updated", ButtonMode.Ok);
                            NavigationService nav = NavigationService.GetNavigationService(this);
                            nav.Navigate(new WpfPresentation.Animals.EditDetailAnimalProfile(_manager, newAnimal));
                        }
                        else
                        {
                            PromptWindow.ShowPrompt("Error", "An error occured.\nPlease try again.", ButtonMode.Ok);
                        }
                    }
                    catch (Exception ex)
                    {
                        PromptWindow.ShowPrompt("Error", "Saving new record failed.\n" + ex, ButtonMode.Ok);
                    }
                }
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/24
        /// 
        /// Click event method for the "Cancel" button. A popup is shown
        /// to confirm if the user actually intends to stop an animal
        /// record without saving. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = PromptWindow.ShowPrompt("Discard Changes", "Are you sure you want to cancel?\n" +
                                                    "Animal record will not be saved.", ButtonMode.YesNo);
            if (result == PromptSelection.Yes)
            {
                NavigationService.Navigate(null);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/22
        /// 
        /// Helper method that links the breeds and types combo
        /// boxes so that when an animal type is selected only
        /// breeds of that type are available in the breeds box
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void cmbAnimalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbAnimalBreedId.ItemsSource = _breeds[cmbAnimalTypeId.SelectedItem.ToString()];
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/22
        /// 
        /// Helper method that links the Aggressive combo box with
        /// the Aggressive Description textbox, so that a description
        /// can only be entered if "Yes" has been selected in the combo
        /// box.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void cmbAggressive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAggressive.SelectedItem.ToString() == "Yes")
            {
                txtAggressiveDescription.IsEnabled = true;
                txtAggressiveDescription.IsReadOnly = false;
            }
            else
            {
                txtAggressiveDescription.IsEnabled = false;
                txtAggressiveDescription.IsReadOnly = true;
                txtAggressiveDescription.Text = "";
            }
        }
    }
}
