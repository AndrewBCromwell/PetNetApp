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

namespace WpfPresentation.Community
{
    /// <summary>
    /// Interaction logic for CommunityPage.xaml
    /// </summary>
    public partial class CommunityPage : Page
    {
        private static CommunityPage _existingCommunityPage = null;

        private Button[] _communityTabButtons;
        private MasterManager _manager = MasterManager.GetMasterManager();

        public CommunityPage()
        {
            InitializeComponent();
            _communityTabButtons = new Button[] { btnAbout, btnForum, btnUsers };
        }

        public static CommunityPage GetCommunityPage()
        {
            if (_existingCommunityPage == null)
            {
                _existingCommunityPage = new CommunityPage();
            }
            return _existingCommunityPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _communityTabButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
        }

        private void btnForum_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameCommunity.Navigate(null);
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameCommunity.Navigate(new UserManagementPage());
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameCommunity.Navigate(null);
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
            if (svCommunityPageTabs.HorizontalOffset > svCommunityPageTabs.ScrollableWidth - 0.05)
            {
                btnScrollRight.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollRight.Visibility = Visibility.Visible;
            }

            if (svCommunityPageTabs.HorizontalOffset < 0.05)
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
            svCommunityPageTabs.ScrollToHorizontalOffset(svCommunityPageTabs.HorizontalOffset + 130);
        }

        private void btnScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            svCommunityPageTabs.ScrollToHorizontalOffset(svCommunityPageTabs.HorizontalOffset - 130);
        }

        private void svCommunityPageTabs_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            UpdateScrollButtons();
        }
    }
}
