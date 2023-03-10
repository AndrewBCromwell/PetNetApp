using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfPresentation.UserControls;

namespace WpfPresentation.Fundraising
{
    /// <summary>
    /// Interaction logic for AlterContact.xaml
    /// </summary>
    public partial class AddEditInstitutionalEntity : Window
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private WindowMode2 _windowMode;
        private string _contactType;

        private InstitutionalEntity _institutionalEntity;


        /// <summary>
        /// Used for add entity
        /// </summary>
        /// <param name="entityType">sets the type of institutional being added</param>
        public AddEditInstitutionalEntity(string entityType)
        {
            _windowMode = WindowMode2.Add;
            _contactType = entityType;
            InitializeComponent();
            SetupAddInstitutionalEntity();
        }

        /// <summary>
        /// used to for edit and view entity
        /// </summary>
        /// <param name="institutionalEntity"></param>
        /// <param name="windowMode">sets the window mode to edit or view</param>
        /// <param name="entityType">brings in the type </param>
        public AddEditInstitutionalEntity(InstitutionalEntity institutionalEntity, string windowMode, string entityType)
        {
            _windowMode = windowMode.ToLower() == "edit" ? WindowMode2.Edit : WindowMode2.View;
            _contactType = entityType;
            _institutionalEntity = institutionalEntity;
            InitializeComponent();
            if (_windowMode == WindowMode2.Edit)
            {
                SetupEditInstitutionalEntity();
            }
            else
            {
                SetupViewInstitutionalEntity();
            }
        }

        private void SetupEditInstitutionalEntity()
        {
            lblWindowTitle.Content = _windowMode + " " + _contactType.Substring(0, 1).ToUpper() + _contactType.Substring(1);
            AddEditMode();
            stackEditClose.IsEnabled = false;
            stackEditClose.Visibility = Visibility.Collapsed;
            stackSaveCancel.IsEnabled = true;
            stackSaveCancel.Visibility = Visibility.Visible;
        }

        private void SetupViewInstitutionalEntity()
        {
            lblWindowTitle.Content = _windowMode + " " + _contactType.Substring(0, 1).ToUpper() + _contactType.Substring(1);
            ViewMode();
            stackEditClose.IsEnabled = true;
            stackEditClose.Visibility = Visibility.Visible;
            stackSaveCancel.IsEnabled = false;
            stackSaveCancel.Visibility = Visibility.Collapsed;
        }

        private void SetupAddInstitutionalEntity()
        {
            lblWindowTitle.Content = _windowMode + " " + _contactType.Substring(0, 1).ToUpper() + _contactType.Substring(1);
            AddEditMode();
            stackEditClose.IsEnabled = false;
            stackEditClose.Visibility = Visibility.Collapsed;
            stackSaveCancel.IsEnabled = true;
            stackSaveCancel.Visibility = Visibility.Visible;
        }

        private void ViewMode()
        {
            tbCompanyName.IsReadOnly = true;
            tbGivenName.IsReadOnly = true;
            tbFamilyName.IsReadOnly = true;
            tbEmail.IsReadOnly = true;
            tbPhone.IsReadOnly = true;
            tbAddress.IsReadOnly = true;
            tbAddress2.IsReadOnly = true;
            tbZipcode.IsReadOnly = true;
            tbCity.IsReadOnly = true;
            tbState.IsReadOnly = true;
            btnCancel.IsCancel = false;
            btnClose.IsCancel = true;
            btnSave.IsDefault = false;
            btnEdit.IsDefault = true;
        }

        private void AddEditMode()
        {
            tbCompanyName.IsReadOnly = false;
            tbGivenName.IsReadOnly = false;
            tbFamilyName.IsReadOnly = false;
            tbEmail.IsReadOnly = false;
            tbPhone.IsReadOnly = false;
            tbAddress.IsReadOnly = false;
            tbAddress2.IsReadOnly = false;
            tbZipcode.IsReadOnly = false;
            tbCity.IsReadOnly = true;
            tbState.IsReadOnly = true;
            btnCancel.IsCancel = true;
            btnClose.IsCancel = false;
            btnSave.IsDefault = true;
            btnEdit.IsDefault = false;
        }


        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/09
        /// 
        /// When the page loads and the user arrived from a view or add option 
        /// populate the text boxes
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_windowMode == WindowMode2.View || _windowMode == WindowMode2.Edit)
                {
                    tbCompanyName.Text = _institutionalEntity.CompanyName;
                    tbGivenName.Text = _institutionalEntity.GivenName;
                    tbFamilyName.Text = _institutionalEntity.FamilyName;
                    tbEmail.Text = _institutionalEntity.Email;
                    tbPhone.Text = new string(_institutionalEntity.Phone.Where(c => char.IsDigit(c)).ToArray());
                    tbAddress.Text = _institutionalEntity.Address;
                    tbAddress2.Text = _institutionalEntity.Address2;
                    // check to see if zipcode is 5 digits
                    if (_institutionalEntity.Zipcode.IsValidZipcode())
                    {
                        tbZipcode.Text = _institutionalEntity.Zipcode.Substring(0, 5);
                        LoadCityStateByZipCode();
                    }
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n\n" + ex.InnerException.Message, ButtonMode.Ok);
            }

        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/09
        /// 
        /// When a user types in a textbox this will prevent them from entering anything but a digit
        /// this is based on https://stackoverflow.com/a/12721673
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            switch (_windowMode)
            {
                case WindowMode2.Add:
                    //TODO: confirm the user wants to cancel input
                    if (PromptWindow.ShowPrompt("Cancel", "Are you sure you want to cancel adding?", ButtonMode.YesNo) == PromptSelection.Yes)
                    {
                        this.Close();
                    }
                    break;
                case WindowMode2.View:
                    this.Close();
                    break;
                case WindowMode2.Edit:
                    //TODO: confirm user wants to cancel editing
                    if (PromptWindow.ShowPrompt("Cancel", "Are you sure you want to cancel editing?", ButtonMode.YesNo) == PromptSelection.Yes)
                    {
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: change to edit mode
            PromptWindow.ShowPrompt("Edit", "Edit button clicked", ButtonMode.SaveCancel);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //TODO: attempt to save
            PromptWindow.ShowPrompt("Save", "Save button clicked", ButtonMode.SaveCancel);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //PromptWindow.ShowPrompt("Close", "close button clicked");
            return;
        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/09
        /// 
        /// After the user moves from zipcode field tries to load city and state if is a valid zipcode
        /// </summary>
        private void tbZipcode_LostFocus(object sender, RoutedEventArgs e)
        {
            // if WindowMode.Add or WindowMode.Edit and IsValidZipcode - load city and state
            if ((_windowMode == WindowMode2.Add || _windowMode == WindowMode2.Edit) && tbZipcode.Text.IsValidZipcode())
            {
                LoadCityStateByZipCode();
            }
            else if ((_windowMode == WindowMode2.Add || _windowMode == WindowMode2.Edit) && tbZipcode.Text.Length < 5)
            {
                tbCity.Text = "";
                tbState.Text = "";
            }
        }

        private void LoadCityStateByZipCode()
        {
            Zipcode zipcodeData = new Zipcode();
            try
            {
                zipcodeData = _masterManager.ZipcodeManager.RetrieveCityStateLatLongByZipcode(tbZipcode.Text);
                //TODO: implement this data
                tbCity.Text = zipcodeData.City;
                tbState.Text = zipcodeData.State;
            }
            catch (Exception)
            {
                PromptWindow.ShowPrompt("Zipcode Error", "Please enter a valid zipcode");
                tbCity.Text = "";
                tbState.Text = "";
                tbZipcode.Text = "";
                tbZipcode.Focus();
                tbZipcode.SelectAll();
            }
        }
    }
    enum WindowMode2
    {
        Add,
        Edit,
        View
    }
}
