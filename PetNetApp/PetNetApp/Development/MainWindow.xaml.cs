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
using WpfPresentation.Development.Animals;
using WpfPresentation.Development.Community;
using WpfPresentation.Development.Management;
using WpfPresentation.Development.Shelters;
using LogicLayer;
using System.Diagnostics;
using WpfPresentation.Development.Fundraising;

namespace PetNetApp.Development
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
            _mainTabButtons = new Button[] { btnAnimals, btnCommunity, btnDonate, btnEvents, btnShelters, btnManagement, btnFundraising };
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
            
            frameMain.Navigate(ShelterPage.GetShelterPage(_manager));
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
            frameMain.Navigate(CommunityPage.GetCommunityPage(_manager));
        }

        private void btnAnimals_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMain.Navigate(AnimalsPage.GetAnimalsPage(_manager));
        }

        private void btnManagement_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMain.Navigate(ManagementPage.GetManagementPage(_manager));
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            UnselectAllButtons();
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

        private void btnFundraising_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            frameMain.Navigate(FundraisingPage.GetFundraisingPage(_manager));
        }
    }
}
