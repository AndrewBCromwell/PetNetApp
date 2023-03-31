/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Navigation for Inventory features
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

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
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Management.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        MasterManager _masterManager = MasterManager.GetMasterManager();
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// </summary>
        public InventoryPage()
        {
            InitializeComponent();

            List<Role> userRoles;
            try
            {
                userRoles = _masterManager.RoleManager.RetrieveRoleListByUserId(MasterManager.GetMasterManager().User.UsersId);
            }
            catch (Exception)
            {

                PromptWindow.ShowPrompt("Missing Data", "Failed to retrieve roles list");
                return;
            }

            if (userRoles == null)
            {
                btnViewShelterInventory.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Navigates to the ViewShelterInventory page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewShelterInventory_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new ViewShelterInventoryPage());
        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/03/19
        /// Created: 2023/03/19
        /// 
        /// Navigates to the ViewInventoryChanges page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewInventoryChanges_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewInventoryChangesPage(_masterManager));
        }
    }
}
