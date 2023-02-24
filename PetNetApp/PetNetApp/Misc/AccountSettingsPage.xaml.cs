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
using PetNetApp;

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Interaction logic for AccountSettingsPage.xaml
    /// </summary>
    public partial class AccountSettingsPage : Page
    {
        private static AccountSettingsPage _existingAccountSettings = null;
        private MasterManager _manager = MasterManager.GetMasterManager();
        private MainWindow _mainWindow = null;

        public AccountSettingsPage()
        {
            InitializeComponent();
        }

        public static AccountSettingsPage GetAccountSettingsPage(MainWindow mainWindow)
        {
            if (_existingAccountSettings == null)
            {
                _existingAccountSettings = new AccountSettingsPage();
            }

            _existingAccountSettings._mainWindow = mainWindow;

            return _existingAccountSettings;
        }

        private void cmboGender_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> genders;
            try
            {
                 genders = _manager.UsersManager.RetrieveGenders();
            }
            catch(Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
                return;
            }

            foreach (var gender in genders)
            {
                cmboGender.Items.Add(gender);
            }
        }

        private void cmboPronoun_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> pronouns;
            try
            {
                pronouns = _manager.UsersManager.RetrievePronouns();
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
                return;
            }

            foreach (var pronoun in pronouns)
            {
                cmboPronoun.Items.Add(pronoun);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // 2 lines added by Stephen Jaurigue, when exiting and reentering the editaccount page the lists would get longer and longer
            cmboGender.Items.Clear();
            cmboPronoun.Items.Clear();

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
