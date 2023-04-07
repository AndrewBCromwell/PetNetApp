using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using WpfPresentation.Development.Fundraising;
using WpfPresentation.UserControls;

namespace WpfPresentation.Fundraising
{
    /// <summary>
    /// Interaction logic for ViewFundraisingEventPledgers.xaml
    /// </summary>
    public partial class ViewFundraisingEventPledgers : Page
    {
        private List<PledgeVM> _pledgeVMs = null;
        private FundraisingEvent _fundraisingEvent = null;
        MasterManager _masterManager = null;

        public ViewFundraisingEventPledgers(FundraisingEvent fundraisingEvent, MasterManager masterManager)
        {
            InitializeComponent();
            _fundraisingEvent = fundraisingEvent;
            _masterManager = masterManager;
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/04/04
        /// 
        /// When page loads, a list of PledgeVMs is
        /// retrieved by eventId and the stackpannel is
        /// populated. If there is not data, a message is shown
        /// that says there is no data
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadPledgers();
            if (_pledgeVMs.Count == 1)
            {
                lblHeader.Content = "Pledger from " + "\"" + _fundraisingEvent.Title + "\"" + " on " + _fundraisingEvent.StartTime.Value.ToShortDateString();
            }
            else if (_pledgeVMs.Count > 1)
            {
                lblHeader.Content = "Pledgers from " + "\"" + _fundraisingEvent.Title + "\"" + " on " + _fundraisingEvent.StartTime.Value.ToShortDateString();
            }
            
            if (_pledgeVMs.Count == 0)
            {
                stackPledgers.Visibility = Visibility.Collapsed;
                stackHeader.Visibility = Visibility.Collapsed;
                nothingToShow.Visibility = Visibility.Visible;
            }
            else
            {
                stackPledgers.Visibility = Visibility.Visible;
                stackHeader.Visibility = Visibility.Visible;
                nothingToShow.Visibility = Visibility.Collapsed;
            }
            int i = 0;
            FundraisingEventPledgerHeaderControl header = new FundraisingEventPledgerHeaderControl();
            stackHeader.Children.Add(header);
            foreach (PledgeVM pledge in _pledgeVMs)
            {
                ViewFundraisingEventPledgersControl item = new ViewFundraisingEventPledgersControl(pledge, _fundraisingEvent,i % 2 == 0);
                i++;
                stackPledgers.Children.Add(item);
            }
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/04/04
        /// 
        /// Checks to see if the initial list of 
        /// pledgers is null, if null it gets a list
        /// of pledgers by eventId
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        private void loadPledgers()
        {
            if (_pledgeVMs == null)
            {
                try
                {
                    // Database data
                    _pledgeVMs = _masterManager.PledgeManager.RetrieveAllPledgesByEventId(_fundraisingEvent.FundraisingEventId);

                    // Accessor fake data
                    //PledgeManager _pm = new PledgeManager(new PledgeAccessorFakes());
                    //_pledgeVMs = _pm.RetrieveAllPledgesByEventId(_fundraisingEvent.FundraisingEventId);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", ex.Message);
                }
            }
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/04/04
        /// 
        /// Button to go back to the list of
        /// events
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewFundraisingEventsPage());
        }
    }
}