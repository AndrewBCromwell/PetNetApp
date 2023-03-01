﻿using System;
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
using System.Windows.Shapes;

using LogicLayer;
using DataObjects;

namespace WpfPresentation.Shelters
{
    /// <summary>
    /// Brian Collum
    /// Created: 2023/02/23
    /// Multi-use window for viewing, adding, and editing shelters
    /// </summary>
    public partial class AlterShelter : Window
    {
        private MasterManager _manager = null;
        private ShelterManager _shelterManager = null;
        private string _windowMode = null;  // Sets whether this is View, Add, or Edit shelter
        private ShelterVM _currentShelter = null;

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Constructor for adding a shelter
        /// </summary>
        /// <param name="manager">The MasterManager from the parent UI</param>
        public AlterShelter(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _shelterManager = new ShelterManager();
            _windowMode = "addshelter";
            _currentShelter = new ShelterVM();
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Constructor for viewing or editing a shelter
        /// </summary>
        /// <param name="manager">The MasterManager from the parent UI</param>
        /// <param name="selectedShelter">The shelter to open and view or edit</param>
        /// <param name="windowMode">string that determines whether this window opens as a view or as an edit window</param>
        public AlterShelter(MasterManager manager, ShelterVM selectedShelter, string windowMode)
        {
            InitializeComponent();
            _manager = manager;
            _shelterManager = new ShelterManager();
            _windowMode = windowMode;
            _currentShelter = selectedShelter;
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Loads the Alter Shelter window and selects the mode that the window opens into
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Select window type based on _windowMode
            if (_windowMode.Equals("addshelter"))
            {
                loadAddShelterWindow();
            }
            else if (_windowMode.Equals("viewshelter"))
            {
                loadViewShelterWindow();
            }
            else if (_windowMode.Equals("editshelter"))
            {
                loadEditShelterWindow();
            }
        }
        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Initialized the Alter Shelter window for Add Shelter mode
        /// </summary>
        private void loadAddShelterWindow()
        {
            lblAddEditMainLabel.Content = "Add Shelter";

            lblShelterName.Content += " (Required)";
            txtShelterName.IsReadOnly = false;
            txtShelterName.Text = _currentShelter.ShelterName;
            lblShelterMissionStatement.Content += " (Optional)";
            txtShelterMissionStatement.IsReadOnly = false;
            txtShelterMissionStatement.Text = "DISABLED";
            // lblShelterState.Content
            txtShelterState.IsReadOnly = false;
            txtShelterState.Text = "DISABLED";
            // lblShelterCity.Content
            txtShelterCity.IsReadOnly = false;
            txtShelterCity.Text = "DISABLED";

            lblShelterAreasOfNeed.Content += " (Optional)";
            txtShelterAreasOfNeed.IsReadOnly = false;
            txtShelterAreasOfNeed.Text = _currentShelter.AreasOfNeed;
            lblShelterZipCode.Content += " (Required)";
            txtShelterZipCode.IsReadOnly = false;
            txtShelterZipCode.Text = _currentShelter.ZipCode;

            radioActivate.IsEnabled = true;
            radioActivate.Visibility = Visibility.Visible;
            radioActivate.IsChecked = true;

            radioDectivate.IsEnabled = true;
            radioDectivate.Visibility = Visibility.Visible;

            lblShelterAddress.Content += " (Required)";
            txtShelterAddress.IsReadOnly = false;
            txtShelterAddress.Text = _currentShelter.Address;
            lblShelterAddressTwo.Content += " (Optional)";
            txtShelterAddressTwo.IsReadOnly = false;
            txtShelterAddressTwo.Text = _currentShelter.AddressTwo;
            lblShelterPhone.Content += " (Optional)";
            txtShelterPhone.IsReadOnly = false;
            txtShelterPhone.Text = _currentShelter.Phone;
            lblShelterEmail.Content += " (Optional)";
            txtShelterEmail.IsReadOnly = false;
            txtShelterEmail.Text = _currentShelter.Email;
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Initializes the Alter Shelter window for View Shelter mode
        /// </summary>
        private void loadViewShelterWindow()
        {
            lblAddEditMainLabel.Content = "View Shelter";
            txtShelterName.IsReadOnly = true;
            txtShelterName.Text = _currentShelter.ShelterName;
            // Disabled fields
            txtShelterMissionStatement.IsReadOnly = true;
            txtShelterMissionStatement.Text = "DISABLED";
            txtShelterState.IsReadOnly = true;
            txtShelterState.Text = "DISABLED";
            txtShelterCity.IsReadOnly = true;
            txtShelterCity.Text = "DISABLED";
            // Enabled fields again
            txtShelterAreasOfNeed.IsReadOnly = true;
            txtShelterAreasOfNeed.Text = _currentShelter.AreasOfNeed;
            txtShelterZipCode.IsReadOnly = true;
            txtShelterZipCode.Text = _currentShelter.ZipCode;

            if (_currentShelter.ShelterActive)
            {
                lblShelterActive.Content = "This shelter is currently active.";
            }
            else
            {
                lblShelterActive.Content = "This shelter is currently inactive.";
            }
            radioActivate.IsEnabled = false;
            radioActivate.Visibility = Visibility.Collapsed;
            radioDectivate.IsEnabled = false;
            radioDectivate.Visibility = Visibility.Collapsed;

            txtShelterAddress.IsReadOnly = true;
            txtShelterAddress.Text = _currentShelter.Address;
            txtShelterAddressTwo.IsReadOnly = true;
            txtShelterAddressTwo.Text = _currentShelter.AddressTwo;
            txtShelterPhone.IsReadOnly = true;
            txtShelterPhone.Text = _currentShelter.Phone;
            txtShelterEmail.IsReadOnly = true;
            txtShelterEmail.Text = _currentShelter.Email;

            btnNext.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Initializes the Alter Shelter window in Edit Shelter mode
        /// </summary>
        private void loadEditShelterWindow()
        {
            lblAddEditMainLabel.Content = "Edit Shelter";
            txtShelterName.IsReadOnly = false;
            txtShelterName.Text = _currentShelter.ShelterName;
            lblShelterMissionStatement.Content += " (Optional)";
            txtShelterMissionStatement.IsReadOnly = false;
            txtShelterMissionStatement.Text = "DISABLED";
            // lblShelterState.Content
            txtShelterState.IsReadOnly = false;
            txtShelterState.Text = "DISABLED";
            // lblShelterCity.Content
            txtShelterCity.IsReadOnly = false;
            txtShelterCity.Text = "DISABLED";

            lblShelterAreasOfNeed.Content += " (Optional)";
            txtShelterAreasOfNeed.IsReadOnly = false;
            txtShelterAreasOfNeed.Text = _currentShelter.AreasOfNeed;
            lblShelterZipCode.Content += " (Required)";
            txtShelterZipCode.IsReadOnly = false;
            txtShelterZipCode.Text = _currentShelter.ZipCode;

            if (_currentShelter.ShelterActive)
            {
                radioActivate.IsChecked = true;
                radioDectivate.IsChecked = false;
                lblShelterActive.Content = "This shelter is currently active.";
                radioActivate.Content = "Keep this shelter active";
                radioDectivate.Content = "Deactivate this shelter";
            }
            else
            {
                radioActivate.IsChecked = false;
                radioDectivate.IsChecked = true;
                lblShelterActive.Content = "This shelter is currently inactive.";
                radioActivate.Content = "Activate this shelter";
                radioDectivate.Content = "Keep this shelter deactivated";
            }

            lblShelterAddress.Content += " (Required)";
            txtShelterAddress.IsReadOnly = false;
            txtShelterAddress.Text = _currentShelter.Address;
            lblShelterAddressTwo.Content += " (Optional)";
            txtShelterAddressTwo.IsReadOnly = false;
            txtShelterAddressTwo.Text = _currentShelter.AddressTwo;
            lblShelterPhone.Content += " (Optional)";
            txtShelterPhone.IsReadOnly = false;
            txtShelterPhone.Text = _currentShelter.Phone;
            lblShelterEmail.Content += " (Optional)";
            txtShelterEmail.IsReadOnly = false;
            txtShelterEmail.Text = _currentShelter.Email;
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Cancel button closes window without changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// X button in the corner closes window without changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseWindowX_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Next button
        /// Submits all valid fields in Add or Edit window, commits changes to logic layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string shelterError = "Unexpected error";
            try
            {
                // Validate input
                string validationCheck = reportInvalidFields();
                if (validationCheck.Equals("No error"))
                {
                    if (_windowMode.Equals("addshelter"))
                    {
                        shelterError = "Failed to add shelter.";
                        bool sucessfullyAddedShelter = _shelterManager.AddShelter(
                            txtShelterName.Text, txtShelterAddress.Text, txtShelterAddressTwo.Text,
                            txtShelterZipCode.Text, txtShelterPhone.Text, txtShelterEmail.Text, txtShelterAreasOfNeed.Text,
                            (bool)radioActivate.IsChecked
                            );
                        if (sucessfullyAddedShelter)
                        {
                            this.DialogResult = false;
                        }
                    }
                    if (_windowMode.Equals("editshelter"))
                    {
                        shelterError = "Failed to edit shelter.";
                        // Null/empty validation in ShelterManager

                        // ShelterName
                        bool updatedShelterName = _shelterManager.EditShelterName(_currentShelter, txtShelterName.Text);
                        // Address
                        bool updatedAddress = _shelterManager.EditAddress(_currentShelter, txtShelterAddress.Text);
                        // AddressTwo
                        bool updatedAddressTwo = _shelterManager.EditAddressTwo(_currentShelter, txtShelterAddressTwo.Text);
                        // Zipcode
                        bool updatedZipcode = _shelterManager.EditZipCode(_currentShelter, txtShelterZipCode.Text);
                        // Phone
                        bool updatedPhone = _shelterManager.EditPhone(_currentShelter, txtShelterPhone.Text);
                        // Email
                        bool updatedEmail = _shelterManager.EditEmail(_currentShelter, txtShelterEmail.Text);
                        // Areasofneed
                        bool updatedAreasOfNeed = _shelterManager.EditAreasOfNeed(_currentShelter, txtShelterAreasOfNeed.Text);
                        // ActiveStatus
                        bool updateActiveStatus = _shelterManager.EditActiveStatus(_currentShelter, (bool)radioActivate.IsChecked);

                        this.DialogResult = false;
                    }
                }
                else
                {
                    PromptWindow.ShowPrompt("Unexpected Shelter error", validationCheck);
                }

            }
            catch (Exception ex)    // This is only thrown if the validation passes
            {
                PromptWindow.ShowPrompt("An error occurred", shelterError + "\n\n" + ex.InnerException.Message, ButtonMode.Ok);
            }
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Reports what fields of the current shelter cannot be committed to the Database
        /// Appends failed fields to an error message
        /// </summary>
        /// <returns>A string containing the invalid shelter fields</returns>
        private string reportInvalidFields()
        {
            StringBuilder errorMessage = new StringBuilder("Failed to update shelter:");
            if (!txtShelterName.Text.IsValidShelterName())
            {
                errorMessage.Append("\n\nInvalid Shelter Name");
            }
            if (!txtShelterAddress.Text.IsValidAddress())
            {
                errorMessage.Append("\n\nInvalid Shelter Address");
            }
            if (!txtShelterAddressTwo.Text.IsValidAddress2())   // This field is optional
            {
                if (!txtShelterAddressTwo.Text.Equals("") && txtShelterAddressTwo.Text != null)
                {
                    errorMessage.Append("\n\nInvalid Shelter Address Two");
                }
            }
            if (!txtShelterZipCode.Text.IsValidZipcode())
            {
                errorMessage.Append("\n\nInvalid Shelter Zip Code");
            }
            if (!txtShelterPhone.Text.IsValidPhone())   // This field is optional
            {
                if (!txtShelterPhone.Text.Equals("") && txtShelterPhone.Text != null)
                {
                    errorMessage.Append("\n\nInvalid Shelter Phone Number");
                }
            }
            if (!txtShelterEmail.Text.IsValidEmail())   // This field is optional
            {
                if (!txtShelterEmail.Text.Equals("") && txtShelterEmail.Text != null)
                {
                    errorMessage.Append("\n\nInvalid Shelter Email Address");
                }
            }
            // In theory nvarchar(MAX) can be larger, but for working with strings I will cap it at max integer value
            if (txtShelterAreasOfNeed.Text.Length > Int32.MaxValue)
            {
                errorMessage.Append("\n\nInvalid Shelter Areas of Need");
            }
            if (radioActivate.IsChecked == null)
            {
                errorMessage.Append("\n\nInvalid Shelter Active Status");
            }
            if (errorMessage.ToString().Equals("Failed to update shelter:"))
            {
                errorMessage.Clear();
                errorMessage.Append("No error");
            }
            return errorMessage.ToString();
        }
    }
}