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
using System.Windows.Shapes;

namespace WpfPresentation.Fundraising
{
    /// <summary>
    /// Interaction logic for ViewEventsWin.xaml
    /// </summary>
    public partial class ViewEventsWin : Window
    {
        private MasterManager _manager;
        private List<SponsorEvent> _sponsorEvents;
        private SponsorEvent _sponsorEvent;


        public ViewEventsWin(SponsorEvent sponsorEvent, MasterManager masterManager)
        {
            _sponsorEvent = sponsorEvent;
            _manager = masterManager;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datVeiwEventsGrid.ItemsSource = null;
            try
            {
                _sponsorEvents = _manager.InstitutionalEntityManager.RetrieveSponsorEventByName(_sponsorEvent.CompanyName);

            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
            }
            if (_sponsorEvents.Count != 0)
            {
                datVeiwEventsGrid.ItemsSource = _sponsorEvents;
                try
                {
                    datVeiwEventsGrid.Columns.RemoveAt(4);
                    datVeiwEventsGrid.Columns.RemoveAt(4);
                    datVeiwEventsGrid.Columns[1].Header = "Company Name";
                    datVeiwEventsGrid.Columns[3].Header = "Start Date";
                    datVeiwEventsGrid.Columns[4].Header = "Contact Type";
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                }
                lblEventName.Content = _sponsorEvent.CompanyName + " Events";
            }
            else
            {
                List<string> noRecordMessage = new List<string>();
                datVeiwEventsGrid.ItemsSource = noRecordMessage;
                datVeiwEventsGrid.Columns[0].Header = "No Entities Available";
                lblEventName.Content = _sponsorEvent.CompanyName + " Events";
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
