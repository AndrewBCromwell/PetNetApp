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

namespace WpfPresentation.Management
{
    /// <summary>
    /// Interaction logic for VolunteerInfoPage.xaml
    /// </summary>
    /// <summary>
    /// Teft Francisco
    /// Created: 2023/02/14
    /// 
    /// 
    /// 
    /// </summary>
    /// Page for volunteer info and frame for additional user options.
    /// 
    /// 
    /// <remarks>
    /// </remarks>
    public partial class VolunteerInfoPage : Page
    {
        private UsersVM _user = null;
        private MasterManager _mastermanager = MasterManager.GetMasterManager();

        public VolunteerInfoPage(UsersVM selectedUser)
        {
            _user = selectedUser;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            reloadUI();
        }

        private void reloadUI()
        {
            // Reload info textboxes:
            txtUserName.Text = _user.GivenName + " " + _user.FamilyName;
            txtPronouns.Text = _user.PronounId;
            txtUserGender.Text = _user.GenderId;
            
            // Check if already deactivated:
            if (_user.Active == false)
            {
                // If no; Make sure button is enabled and displays the option to reactivate.
                btnDeactivateUser.IsEnabled = true;
                btnDeactivateUser.Visibility = Visibility.Visible;        
                btnDeactivateUser.Content = "Reactivate User";
            }
            else
            {
                // If yes; make sure button is enabled but displays the option to deactivate.
                btnDeactivateUser.IsEnabled = true;
                btnDeactivateUser.Visibility = Visibility.Visible;
                btnDeactivateUser.Content = "Deactivate User";
            }

            // Check to see if user is already suspended:
            if (_user.SuspendEmployee == true)
            {
                
                // Deactivate and hide the Activate/Deactivate button:
                btnDeactivateUser.IsEnabled = false;
                btnDeactivateUser.Visibility = Visibility.Hidden;
                // Change button to show unsuspension option:
                btnSuspendUser.Content = "Unsuspend User";
            }
            else
            {
                // Activate and show the Activate/Deactivate button:
                btnDeactivateUser.IsEnabled = true;
                btnDeactivateUser.Visibility = Visibility.Visible;
                // Change button to show suspension option:
                btnSuspendUser.Content = "Suspend User";
            }
        }

        private void btnRequestVolunteer_Click(object sender, RoutedEventArgs e)
        {
            // Not implemented; enter your method here. According to the UI design this would use the "frameVolunteerDetails" frame.
        }

        private void btnTransportationManagement_Click(object sender, RoutedEventArgs e)
        {
            // Not implemented; enter your method here. According to the UI design this would use the "frameVolunteerDetails" frame.
        }
        private void btnRoleManagement_Click(object sender, RoutedEventArgs e)
        {
            // Not implemented; enter your method here. According to the UI design this would use the "frameVolunteerDetails" frame.
        }
        private void btnKeyManagement_Click(object sender, RoutedEventArgs e)
        {
            // Not implemented; enter your method here. According to the UI design this would use the "frameVolunteerDetails" frame.
        }

        private void btnSuspendUser_Click(object sender, RoutedEventArgs e)
        {
            if (_user.SuspendEmployee == false)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to suspend this user?", "Suspend user?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                // Navigate to the same page to reload the UI.
                NavigationService.Navigate(new VolunteerInfoPage(_user));

                if (result == MessageBoxResult.Yes)
                {
                    // Not implemented; enter your method here and call the reloadUI and Navigation methods to make sure the UI reflects changes made.
                }
            }
        }

        private void btnDeactivateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check for user's active status.
                if (_user.Active == true)
                {
                    // If user is active give option to deactivate.
                    MessageBoxResult result = MessageBox.Show("Do you want to deactivate this user?", "Deactivate user?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _mastermanager.UsersManager.EditUserActive(_user.UsersId, false);
                    }

                }
                else
                {
                    // If user is NOT active give option to activate.
                    MessageBoxResult result = MessageBox.Show("Do you want to reactivate this user?", "Reactivate user?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _mastermanager.UsersManager.EditUserActive(_user.UsersId, true);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("There has been an error:" + ex, "An error has occured.", MessageBoxButton.OK, MessageBoxImage.Error);             
            }
            // The current select_user_by_user_id stored procedure returns a normal Users object and NOT a UsersVM object, making it incompatibile.
            // Therefore we need to use the method to select a list of UsersVM and choose the user we need.
            // If the procedure gets fixed this can be updated.
            List<UsersVM> workaroundList = _mastermanager.UsersManager.RetrieveUsersByUsersId(_user.UsersId);
            NavigationService.Navigate(new VolunteerInfoPage(workaroundList.First()));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // This will have to be changed when VolunteerManagement.xaml leaves the development folder.
            NavigationService.Navigate(new Development.Management.VolunteerManagment());
        }

        
    }
}
