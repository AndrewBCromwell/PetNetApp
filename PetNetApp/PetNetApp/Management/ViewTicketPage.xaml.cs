using DataObjects;
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

namespace WpfPresentation.Management
{
    /// <summary>
    /// Interaction logic for ViewTicketPage.xaml
    /// </summary>
    public partial class ViewTicketPage : Page
    {
        private TicketVM _ticketVM = null;
        public ViewTicketPage(TicketVM ticketVM)
        {
            _ticketVM = ticketVM;
            InitializeComponent();
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/16
        /// 
        /// closes the view ticket menu when clicked
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnCancel(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/16
        /// 
        /// Creates the view ticket page when
        /// the view ticket button is pressed
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblTicketNumber.Content = "Ticket: " + _ticketVM.TicketId;
            txtTicketTitle.Text = _ticketVM.TicketTitle;
            txtTicketDate.Text = _ticketVM.TicketDate.ToString();
            txtTicketType.Text = _ticketVM.TicketStatusId;
            txtTicketPoster.Text = _ticketVM.Email;
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/16
        /// 
        /// closes the view ticket page when
        /// clicked, navigates back to the viewticketlist page
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/16
        /// 
        /// page closes when pressing "escape"
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                NavigationService.Navigate(null);
            }
        }

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/03/16
        /// 
        /// TODO
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnResolve_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("TODO", "TODO", ButtonMode.Ok);
        }
    }
}
