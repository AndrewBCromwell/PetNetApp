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
using WpfPresentation.Management;

namespace WpfPresentation.Development.Fundraising
{
    /// <summary>
    /// Interaction logic for ManagementPage.xaml
    /// </summary>
    public partial class FundraisingPage : Page
    {
        private static FundraisingPage _existingFundraisingPage = null;

        private MasterManager _manager = null;
        private Button[] _fundraisingPageButtons;
        private FundraisingPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _fundraisingPageButtons = new Button[] { btnCampaigns, btnDonations, btnEvents, btnViewContacts };
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/20
        /// 
        /// Returns existing FundraisingPage or new if none exists
        /// </summary>
        /// <param name="manager">The existing instance of the master manager that the program is using</param>
        public static FundraisingPage GetFundraisingPage(MasterManager manager)
        {
            if (_existingFundraisingPage == null)
            {
                _existingFundraisingPage = new FundraisingPage(manager);
            }
            return _existingFundraisingPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _fundraisingPageButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
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

        private void svManagementPageTabs_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            UpdateScrollButtons();
        }
        private void UpdateScrollButtons()
        {
            if (svManagementPageTabs.HorizontalOffset > svManagementPageTabs.ScrollableWidth - 0.05)
            {
                btnScrollRight.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollRight.Visibility = Visibility.Visible;
            }

            if (svManagementPageTabs.HorizontalOffset < 0.05)
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
            svManagementPageTabs.ScrollToHorizontalOffset(svManagementPageTabs.HorizontalOffset + 130);
        }

        private void btnScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            svManagementPageTabs.ScrollToHorizontalOffset(svManagementPageTabs.HorizontalOffset - 130);
        }

        private void btnCampaigns_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameFundraising.Navigate(ViewCampaignsPage.GetViewCampaignsPage());
        }

        private void btnDonations_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameFundraising.Navigate(WpfPresentation.Fundraising.ViewDonationsPage.ExistingDonationPage);
        }


        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/01
        /// 
        /// Show contacts button if user has appropriate permissions
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public void ShowContactsButtonByRole()
        {
            string[] allowedRoles = { "Admin", "Manager", "Marketing" };
            if (_manager.User.Roles.Exists(role => allowedRoles.Contains(role)))
            {
                btnViewContacts.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/01
        /// 
        /// Show contacts button if user has appropriate permissions
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public void ShowEventsButtonByRole()
        {
            string[] allowedRoles = { "Admin", "Manager", "Marketing" };
            if (_manager.User.Roles.Exists(role => allowedRoles.Contains(role)))
            {
                btnEvents.Visibility = Visibility.Visible;
            }
        }

        private void btnViewContacts_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameFundraising.Navigate(ViewFundraisingEventContacts.GetViewEventContacts());
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameFundraising.Navigate(ViewFundraisingEventsPage.GetViewEventsPage());
        }
    }
}
