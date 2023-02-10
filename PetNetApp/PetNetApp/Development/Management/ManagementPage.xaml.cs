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

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for ManagementPage.xaml
    /// </summary>
    public partial class ManagementPage : Page
    {
        private static ManagementPage _existingManagementPage = null;

        private MasterManager _manager = null;
        private Button[] _managementPageButtons;
        public ManagementPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _managementPageButtons = new Button[] { btnInventory, btnKennel, btnShelters, btnTickets, btnVolunteer };
        }

        public static ManagementPage GetManagementPage(MasterManager manager)
        {
            if (_existingManagementPage == null)
            {
                _existingManagementPage = new ManagementPage(manager);
            }
            return _existingManagementPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _managementPageButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
        }

        private void btnShelters_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(null);
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(null);
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(null);
        }

        private void btnKennel_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameAnimals.Navigate(new ViewKennelPage());
        }

        private void btnVolunteer_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(new VolunteerManagment());
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(new SchedulePage());
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

        
    }
}
