using DataObjects;
using LogicLayer;
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

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for ViewTicketList.xaml
    /// </summary>
    public partial class ViewTicketList : Page
    {
        private MasterManager _manager = MasterManager.GetMasterManager();
        private List<TicketVM> _ticketVMs = null;

        public ViewTicketList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/02/17
        /// 
        /// When page loads, a list of tickets is
        /// retrieved and the data grid is populated
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _ticketVMs = _manager.TicketManager.RetrieveAllTickets();
                if (_ticketVMs.Count > 0)
                {
                    datTickList.ItemsSource = _ticketVMs;
                }
                else
                {
                    PromptWindow.ShowPrompt("Error", "No tickets avaliable.", ButtonMode.Ok);
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.InnerException.Message);
            }
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/02/17
        /// 
        /// When search box is selected, 
        /// "Search..." is removed
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/02/17
        /// 
        /// When search box is not focused,
        /// "Search..." is placed in the search box
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search...";
        }
    }
}
