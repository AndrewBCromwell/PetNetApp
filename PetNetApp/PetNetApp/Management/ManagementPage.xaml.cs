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

namespace WpfPresentation.Management
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
            selectedButton.Style = (Style)Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _managementPageButtons)
            {
                button.Style = (Style)Resources["rsrcUnselectedButton"];
            }
        }

        private void btnShelters_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }

        private void btnKennel_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }

        private void btnVolunteer_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
        }
    }
}
