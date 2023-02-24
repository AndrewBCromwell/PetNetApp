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

//using WpfPresentation.Development.Shelters;

using LogicLayer;

namespace WpfPresentation.Development.Shelters
{
    /// <summary>
    /// Brian Collum, adapted from Stephen's work
    /// Created: 2023/02/23
    /// Shelter navigation bar
    /// </summary>

    public partial class ShelterPage : Page
    {
        private static ShelterPage _existingShelterPage = null;

        private Button[] _shelterTabButtons;
        private MasterManager _manager = null;

        public ShelterPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _shelterTabButtons = new Button[] { btnShelter, btnRescue, btnAnimalControl };
        }

        public static ShelterPage GetShelterPage(MasterManager manager)
        {
            if (_existingShelterPage == null)
            {
                _existingShelterPage = new ShelterPage(manager);
            }
            return _existingShelterPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _shelterTabButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
        }

        private void btnShelter_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // frameShelter.Navigate(ShelterAddEditDelete.GetShelterAddEditDelete(_manager));
            frameShelter.Navigate(ShelterVMListUI.GetShelterVMListUI(_manager));
        }

        private void btnRescue_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameShelter.Navigate(null);
        }

        private void btnAnimalControl_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameShelter.Navigate(null);
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
            if (svShelterPageTabs.HorizontalOffset > svShelterPageTabs.ScrollableWidth - 0.05)
            {
                btnScrollRight.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollRight.Visibility = Visibility.Visible;
            }

            if (svShelterPageTabs.HorizontalOffset < 0.05)
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
            svShelterPageTabs.ScrollToHorizontalOffset(svShelterPageTabs.HorizontalOffset + 130);
        }

        private void btnScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            svShelterPageTabs.ScrollToHorizontalOffset(svShelterPageTabs.HorizontalOffset - 130);
        }

        private void svShelterPageTabs_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            UpdateScrollButtons();
        }
    }
}
