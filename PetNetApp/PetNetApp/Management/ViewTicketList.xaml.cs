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
using WpfPresentation.Development.Management;

namespace WpfPresentation.Management
{
    /// <summary>
    /// Interaction logic for ViewTicketList.xaml
    /// </summary>
    public partial class ViewTicketList : Page
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<TicketVM> _ticketVMs = null;

        public ViewTicketList(MasterManager manager)
        {
            InitializeComponent();
            _masterManager = manager;
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
                _ticketVMs = _masterManager.TicketManager.RetrieveAllTickets();
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
            if(txtSearch.Text == "" || txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
            }
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
            if(txtSearch.Text == "")
            {
                txtSearch.Text = "Search...";
            }
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/01
        /// 
        /// refreshes the list of tickets with the passed in list of
        /// TicketVM
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: 
        /// </remarks>
        private void refreshTickets(List<TicketVM> ticketVM)
        {
            datTickList.ItemsSource = ticketVM;
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/01
        /// 
        /// calls one of two refreshTickets methods based on the content of txtSearch
        /// 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: 
        /// </remarks>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                if (txtSearch.Text.Length != 0)
                {
                    refreshTickets(searchResults(_ticketVMs));
                }
                else
                {
                    refreshTickets(_ticketVMs);
                }
            }

        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/01
        /// 
        /// searches the provided list of TicketVM for the provided search query
        /// in txtSearch
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: 
        /// </remarks>
        private List<TicketVM> searchResults(List<TicketVM> tickets)
        {
            List<TicketVM> ticketVM = new List<TicketVM>();

            foreach(TicketVM ticket in tickets)
            {
                // implements similar functionality to the sql "like" keyword.
                if (ticket.TicketTitle.IndexOf(txtSearch.Text, 0, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    ticketVM.Add(ticket);
                }

            }

            return ticketVM;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Length != 0 && txtSearch.Text != "Search...")
            {
                refreshTickets(searchResults(_ticketVMs));
            }
            else
            {
                refreshTickets(_ticketVMs);
            }
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/03/03
        /// 
        /// When button is clicked,
        /// create a ticket page is opened
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnNewTicket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateNewTicket(_masterManager));
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/16
        /// 
        /// Opens ticket information when ticket
        /// button is clicked
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnTicket_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = datTickList;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            string CellValue = ((TextBlock)RowAndColumn.Content).Text;

            foreach (TicketVM ticketVM in _ticketVMs)
            {
                if (ticketVM.TicketId == Int32.Parse(CellValue))
                {
                    frmTicketViewPage.Navigate(new ViewTicketPage(ticketVM));
                }
            }
        }
    }
}
