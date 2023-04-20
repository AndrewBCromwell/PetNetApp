/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// </summary>
///
/// <remarks>
/// Oleksiy Fedchuk
/// Updated: 2023/04/20
/// 
/// Final QA
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

namespace WpfPresentation.Management.Inventory
{
    /// <summary>
    /// Interaction logic for ViewEditCartPage.xaml
    /// </summary>
    public partial class ViewEditCartPage : Page
    {
        List<ShelterInventoryItemVM> _shelterInventoryItemVMCart = new List<ShelterInventoryItemVM>();
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/20
        /// 
        /// Final QA
        /// </remarks>
        /// <param name="shelterInventoryItemVMs"></param>
        public ViewEditCartPage(List<ShelterInventoryItemVM> shelterInventoryItemVMs)
        {
            _shelterInventoryItemVMCart = shelterInventoryItemVMs;
            InitializeComponent();
        }
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/20
        /// 
        /// Final QA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datCartList.ItemsSource = _shelterInventoryItemVMCart;
        }
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/20
        /// 
        /// Final QA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewShelterInventoryPage(_shelterInventoryItemVMCart));
        }
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/20
        /// 
        /// Final QA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCart_Click(object sender, RoutedEventArgs e)
        {
            _shelterInventoryItemVMCart.Clear();
            NavigationService.Navigate(new ViewEditCartPage(_shelterInventoryItemVMCart));
        }
    }
}
