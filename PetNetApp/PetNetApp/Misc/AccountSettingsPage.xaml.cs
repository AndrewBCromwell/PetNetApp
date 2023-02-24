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
using WpfPresentation.Community;

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Mads Rhea
    /// Created: 2023/02/05
    /// 
    /// WPF for "Account Settings" frame and navigational buttons.
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            frameAccountSettings.Navigate(UserDetailsPage.GetUserDetailsPage(_mainWindow));
        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            frameAccountSettings.Navigate(UserDetailsPage.GetUserDetailsPage(_mainWindow));
        }

        private void btnAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            frameAccountSettings.Navigate(AccountInfoPage.GetAccountInfoPage(_mainWindow));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            frameAccountSettings.Navigate(DeactivateButtonPage.GetDeactivateButtonPage(_mainWindow));
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you'd like to log out?\n\nYou may lose any changes you've made.", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _mainWindow.UpdateOnLogOut();

            }

        }

    }
}
