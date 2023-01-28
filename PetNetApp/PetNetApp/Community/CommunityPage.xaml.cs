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
        private MasterManager _manager = null;

        public CommunityPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _communityTabButtons = new Button[] { btnAbout, btnForum, btnUsers };
        }

        public static CommunityPage GetCommunityPage(MasterManager manager)
        {
            if (_existingCommunityPage == null)
            {
                _existingCommunityPage = new CommunityPage(manager);
            }
            return _existingCommunityPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _communityTabButtons)
            {
                button.Style = (Style)Resources["rsrcUnselectedButton"];
            }
        }

        private void btnForum_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }
    }
}
