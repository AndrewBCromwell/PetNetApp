using DataObjects;
using LogicLayer;
using PetNetApp;
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

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Mads Rhea
    /// Created: 2023/02/15
    /// 
    /// WPF for User Details within "Account Settings"
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
    public partial class UserDetailsPage : Page
    {
        private static UserDetailsPage _existingUserDetails = null;
        private MasterManager _manager = MasterManager.GetMasterManager();
        private MainWindow _mainWindow = null;

        public UserDetailsPage()
        {
            InitializeComponent();
            LoadUserDetails();
        }

        public static UserDetailsPage GetUserDetailsPage(MainWindow mainWindow)
        {
            if (_existingUserDetails == null)
            {
                _existingUserDetails = new UserDetailsPage();
            }

            _existingUserDetails._mainWindow = mainWindow;

            return _existingUserDetails;
        }

        private void cmboGender_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> genders = _manager.UsersManager.RetrieveGenders();

            foreach (var gender in genders)
            {
                cmboGender.Items.Add(gender);
            }
        }

        private void cmboPronoun_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> pronouns = _manager.UsersManager.RetrievePronouns();

            foreach (var pronoun in pronouns)
            {
                cmboPronoun.Items.Add(pronoun);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtGivenName.Text == _manager.User.GivenName &&
               txtFamilyName.Text == _manager.User.FamilyName &&
               cmboGender.SelectedItem == _manager.User.GenderId &&
               cmboPronoun.SelectedItem == _manager.User.PronounId &&
               txtAddress.Text == _manager.User.Address &&
               txtAddressTwo.Text == _manager.User.AddressTwo &&
               txtPhone.Text == _manager.User.Phone &&
               txtZipcode.Text == _manager.User.Zipcode)
            {
                MessageBox.Show("You haven't changed anything!", "Hey!", MessageBoxButton.OK);
            }
            else
            {
                Users user = new Users()
                {
                    UsersId = _manager.User.UsersId,
                    GivenName = txtGivenName.Text,
                    FamilyName = txtFamilyName.Text,
                    GenderId = (string)cmboGender.SelectedItem,
                    PronounId = (string)cmboPronoun.SelectedItem,
                    Address = txtAddress.Text,
                    AddressTwo = txtAddressTwo.Text,
                    Phone = txtPhone.Text,
                    Zipcode = txtZipcode.Text

                };

                try
                {
                    if (_manager.UsersManager.EditUserDetails(_manager.User, user))
                    {
                        MessageBox.Show("Profile successfully updated!", "Success!", MessageBoxButton.OK);
                        LoadUserDetails();
                    }

                }
                catch (Exception up)
                {
                    MessageBox.Show(up.Message);
                }
            }

        }

        private void LoadUserDetails()
        {
            txtGivenName.Text = _manager.User.GivenName;
            txtFamilyName.Text = _manager.User.FamilyName;
            cmboGender.SelectedItem = _manager.User.GenderId;
            cmboPronoun.SelectedItem = _manager.User.PronounId;
            txtAddress.Text = _manager.User.Address;
            txtAddressTwo.Text = _manager.User.AddressTwo;
            txtPhone.Text = _manager.User.Phone;
            txtZipcode.Text = _manager.User.Zipcode;
        }
    }
}
