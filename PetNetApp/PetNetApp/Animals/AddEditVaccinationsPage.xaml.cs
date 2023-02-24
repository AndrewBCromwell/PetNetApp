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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;
using DataObjects;
using System.Text.RegularExpressions;

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for AddEditVaccinationsPage.xaml
    /// </summary>
    public partial class AddEditVaccinationsPage : Page
    {
        private VaccinationManager _vaccineManager = new VaccinationManager();
        private Vaccination _vaccine = new Vaccination();
        Animal _currentAnimal = new Animal(); //Used to keep tract of current animal
        bool _addMode; //Used to keep track of if we are inserting or editing data.
        private UsersManager _usersManager = new UsersManager(); //Used to validate if user exists



        //This method is called when the user wants to add a Vaccine
        public AddEditVaccinationsPage(Animal animal)
        {
            _addMode = true;
            _currentAnimal = animal;
            InitializeComponent();
            setAddMode();
        }

        //This method is called when the user wants to edit a vaccine
        public AddEditVaccinationsPage(Vaccination vaccination, Animal animal)
        {
            _addMode = false;
            _vaccine = vaccination;
            _currentAnimal = animal;


            InitializeComponent();
            setEditMode();
        }


        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// This is a helper method that fills in the fields for the edit function
        /// </summary>
        private void populateControls()
        {
            txtVaccineName.Text = _vaccine.VaccineName;
            dpDateAdministered.Text = _vaccine.VaccineAdminsterDate.ToString();
            txtUsersId.Text = _vaccine.UserId.ToString();

        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// Sets the page fields for add
        /// </summary>
        private void setAddMode()
        {
            txtVaccineName.IsEnabled = true;
            txtUsersId.IsEnabled = true;
            dpDateAdministered.IsEnabled = true;

            lblAddEditVaccine.Content = "Add New Vaccine";

            btnSave.Content = "Add";
            btnCancel.Content = "Cancel";
        }


        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// Sets the page fields for edit
        /// </summary>
        private void setEditMode()
        {
            populateControls();


            txtVaccineName.IsEnabled = true;
            txtUsersId.IsEnabled = true;
            dpDateAdministered.IsEnabled = true;

            lblAddEditVaccine.Content = "Edit Vaccine Information";

            btnSave.Content = "Update";
            btnCancel.Content = "Cancel";

        }

        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// When button is pressed, check if add mode, if add mode insert data into database, else update database.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (_addMode)
            {
                setAddMode();


                var dateAdministered = dpDateAdministered.Text;
                DatePicker datePicker = dpDateAdministered;
                int usersId;

                //Validation
                if (dpDateAdministered.Text == "")
                {
                    MessageBox.Show("Please enter the date");
                    dpDateAdministered.Focus();
                    return;
                }
                try
                {
                    usersId = int.Parse(txtUsersId.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter a Valid User ID");
                    return;
                }
                //This if statement calls "RetrieveUserByUsersId" and returns a list of users that matches the Id
                //If it returns 0, the user doesn't exist
                if (_usersManager.RetrieveUserByUsersId(usersId).Count == 0)
                {
                    PromptWindow.ShowPrompt("User Error", "User cannot be found.");
                    return;
                }
                if (txtVaccineName.Text == "")
                {
                    PromptWindow.ShowPrompt("Vaccine Name Error", "Please Enter the Vaccine's Name.");
                    txtVaccineName.Focus();
                    return;
                }
                if (txtUsersId.Text == "")
                {
                    PromptWindow.ShowPrompt("User Error", "Please Enter the ID of who gave the vaccine.");
                    txtUsersId.Focus();
                    return;
                }
                if (dpDateAdministered.Text == "")
                {
                    PromptWindow.ShowPrompt("Date Error", "Please Enter the date the vaccine was given.");
                    dpDateAdministered.Focus();
                    return;
                }
                if (datePicker.SelectedDate > DateTime.Now)
                {
                    PromptWindow.ShowPrompt("Date Error", "Date adminstered cannot be in the future.");
                    return;
                }



                //Create new vaccination
                Vaccination newVaccination = new Vaccination()
                {
                    VaccineName = txtVaccineName.Text,
                    VaccineAdminsterDate = datePicker.SelectedDate.Value,
                    UserId = usersId

                };
                try
                {
                    _vaccineManager.AddVaccination(newVaccination, _currentAnimal.AnimalId);

                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message); 
                    //We have this in case something completely unexpected happens
                    MessageBox.Show("An Error has occured. Please make sure to fill out all information correctly");
                    return;

                }
                //Navigates back to Vaccination page(Will also refresh the list)
                NavigationService.Navigate(new VaccinationsPage(_currentAnimal));


            }//end of if statement
            else if (!_addMode)//Edit Mode
            {
                DatePicker datePicker = dpDateAdministered;

                int usersId;

                try
                {
                    usersId = int.Parse(txtUsersId.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter a Valid User ID");
                    return;
                }
                if (_usersManager.RetrieveUserByUsersId(usersId).Count == 0)
                {

                    MessageBox.Show("User not found");
                    return;
                }

                if (txtVaccineName.Text == "")
                {
                    MessageBox.Show("Please Enter the Vaccine's Name");
                    txtVaccineName.Focus();
                    return;
                }
                if (txtVaccineName.Text == "")
                {
                    MessageBox.Show("Please Enter the ID of who gave the vaccine");
                    txtUsersId.Focus();
                    return;
                }
                if (txtVaccineName.Text == "")
                {
                    MessageBox.Show("Please Enter the date the vaccine was given");
                    dpDateAdministered.Focus();
                    return;
                }
                if (datePicker.SelectedDate > DateTime.Now)
                {
                    MessageBox.Show("Date adminstered cannot be in the future.");
                    return;
                }
                if (datePicker.SelectedDate == null)
                {
                    MessageBox.Show("Date must be input.");
                    return;
                }


                Vaccination newVaccination = new Vaccination()
                {

                    VaccineName = txtVaccineName.Text,
                    VaccineAdminsterDate = datePicker.SelectedDate.Value,
                    UserId = usersId

                };
                _vaccineManager.EditVaccination(_vaccine, newVaccination);

                NavigationService.Navigate(new VaccinationsPage(_currentAnimal));
            }

        } //End of btnSave

        //Goes back to Vaccination list
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VaccinationsPage(_currentAnimal));
        }

        private void txtUsersId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
