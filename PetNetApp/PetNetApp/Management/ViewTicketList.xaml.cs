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

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search...";
        }
    }
}
