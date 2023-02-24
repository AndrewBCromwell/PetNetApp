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
using WpfPresentation.Animals;
using WpfPresentation.Community;
using WpfPresentation.Management;
using LogicLayer;
using System.Diagnostics;
using WpfPresentation.Misc;

namespace PetNetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[] _mainTabButtons;
        private MasterManager _manager = MasterManager.GetMasterManager();

        public MainWindow()
        {
            InitializeComponent();
            _mainTabButtons = new Button[] { btnAnimals, btnCommunity, btnDonate, btnEvents, btnShelters, btnDonations, btnManagement };

            if (_manager.User == null)
            {
                mnuLogout.Header = "Log In";
            }

        }

        private void btnDonate_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMain.Navigate(null);
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Resources["rsrcSelectedTabButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _mainTabButtons)
            {
                button.Style = (Style)Resources["rsrcUnselectedTabButton"];
            }
        }

        private void btnShelters_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMain.Navigate(null);
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMain.Navigate(null);
        }

        private void btnCommunity_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMain.Navigate(CommunityPage.GetCommunityPage());
        }

        private void btnAnimals_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMain.Navigate(AnimalsPage.GetAnimalsPage());
        }

        private void btnManagement_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMain.Navigate(ManagementPage.GetManagementPage());
        }

        private void btnDonations_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameMain.Navigate(null);
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            UnselectAllButtons();
            if (_manager.User == null)
            {
                frameMain.Navigate(LogInPage.GetLogInPage(this));
            }
            else
            {
                frameMain.Navigate(UserProfilePage.GetUserProfilePage(this));
            }
        }

        private void btnNotification_Click(object sender, RoutedEventArgs e)
        {
            UnselectAllButtons();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
            }
            e.Handled = true;
        }

        private void UpdateScrollButtons()
        {
            if (svMainTabs.HorizontalOffset > svMainTabs.ScrollableWidth - 0.05)
            {
                btnScrollRight.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollRight.Visibility = Visibility.Visible;
            }

            if (svMainTabs.HorizontalOffset < 0.05)
            {
                btnScrollLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollLeft.Visibility = Visibility.Visible;
            }
        }

        private void btnScrollRight_Click(object sender, RoutedEventArgs e)
        {
            svMainTabs.ScrollToHorizontalOffset(svMainTabs.HorizontalOffset + 160);
        }

        private void btnScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            svMainTabs.ScrollToHorizontalOffset(svMainTabs.HorizontalOffset - 160);
        }

        private void svMainTabs_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            UpdateScrollButtons();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            btnMenu.ContextMenu.IsOpen = true;
        }

        private void mnuLogout_Click(object sender, RoutedEventArgs e)
        {
            if ((string)mnuLogout.Header == "Log In")
            {
                UnselectAllButtons();
                frameMain.Navigate(LogInPage.GetLogInPage(this));
            }
            else if ((string)mnuLogout.Header == "Log Out")
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Stop);

                if (result == MessageBoxResult.Yes)
                {
                    UpdateOnLogOut();
                }
            }
        }

        public void ShowButtonsByRole()
        {
            foreach (var role in _manager.User.Roles)
            {
                switch (role)
                {
                    case "Admin":
                        // Unhide ALL things
                        break;

                    case "Adoption":
                        // Unhide adopter perks
                        break;

                    case "Donation":
                        // Unhide Donation perks
                        break;

                    case "Fosterer":
                        // Unhide Fosterer Abilities
                        break;

                    case "Fundraising":
                        // Unhide Kennel subtabs
                        break;

                    case "Intake":
                        // Unhide Intake privledges
                        break;

                    case "Inventory":
                        // Unhide Inventory subtabs
                        break;

                    case "Kennel":
                        // Unhide Kennel subtabs
                        break;

                    case "Medical":
                        // Unhide manager tabs
                        break;

                    case "Public Relations":
                        // Unhide given volunteer tabs
                        break;

                    case "Social":

                        break;

                    case "Surrender":
                        break;

                    case "Volunteer":
                        break;

                    case "Home Inspector":
                        break;

                    default:
                        // unhide User tabs (Animals,   
                        break;
                }
            }
        }

        private void mnuAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            UnselectAllButtons();
            if (_manager.User == null)
            {
                frameMain.Navigate(LogInPage.GetLogInPage(this));
            }
            else
            {
                frameMain.Navigate(AccountSettingsPage.GetAccountSettingsPage(this));
            }
        }

        private void btnPetNetLogo_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(LandingPage.GetLandingPage(this));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(LandingPage.GetLandingPage(this));

            foreach (var tab in _mainTabButtons)
            {
                tab.Visibility = Visibility.Hidden;
            }
        }

        public void UpdateOnLogOut()
        {
            frameMain.Navigate(LandingPage.GetLandingPage(this));

            _manager.User = null;
            mnuUser.Header = "Hello, Guest";
            mnuLogout.Header = "Log In";
        }
    }
}
