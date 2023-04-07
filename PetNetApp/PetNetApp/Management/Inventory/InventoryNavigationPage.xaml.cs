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

namespace WpfPresentation.Management.Inventory
{
    /// <summary>
    /// Andrew Cromwell
    /// Created: 2023/03/27
    /// 
    /// Interaction logic for InventoryNavigationPage.xaml
    /// </summary>
    public partial class InventoryNavigationPage : Page
    {
        public static InventoryNavigationPage _existingInventoryNavigationPage = null;

        private MasterManager _manager = null;
        private Button[] _inventoryTabButtons;

        public InventoryNavigationPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _inventoryTabButtons = new Button[] { btnShelterInventory, btnItemLibrary, btnViewRequests, btnViewResourceAddRequest, btnCheckIn, btnInventoryChanges, btnAnimalSpecialNeeds, btnRequestFromShelter };
            btnShelterInventory_Click(this, new RoutedEventArgs());
        }

        public static InventoryNavigationPage GetInventoryNavigationPage(MasterManager manager)
        {
            if(_existingInventoryNavigationPage == null)
            {
                _existingInventoryNavigationPage = new InventoryNavigationPage(manager);
            }
            return _existingInventoryNavigationPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _inventoryTabButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
        }

        private void btnShelterInventory_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnShelterInventory);
            frameInventory.Navigate(new ViewShelterInventoryPage());
        }

        private void btnItemLibrary_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnItemLibrary);
            frameInventory.Navigate(new Library.LibraryUI(_manager));
        }

        private void btnViewRequests_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnViewRequests);
            frameInventory.Navigate(ViewRequestListPage.GetViewRequestListPage(_manager));
        }

        private void btnViewResourceAddRequest_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnViewResourceAddRequest);
            // replace with page name and then delete comment
            frameInventory.Navigate(ViewNewItemRequestsPage.GetViewNewItemRequestsPage());
        }

        private void btnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnCheckIn);
            // replace with page name and then delete comment
            frameInventory.Navigate(null);
        }

        private void btnInventoryChanges_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnInventoryChanges);
            frameInventory.Navigate(ViewInventoryChangesPage.GetViewInventoryChangesPage(_manager));
        }

        private void btnAnimalSpecialNeeds_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnAnimalSpecialNeeds);
            // replace with page name and then delete comment
            frameInventory.Navigate(null);
        }

        private void btnRequestFromShelter_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton(btnRequestFromShelter);
            // replace with page name and then delete comment
            frameInventory.Navigate(null);
        }
    }
}
