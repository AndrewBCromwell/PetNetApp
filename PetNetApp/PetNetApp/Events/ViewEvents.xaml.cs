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


namespace WpfPresentation.Events
{
    /// <summary>
    /// Interaction logic for ViewEvents.xaml
    /// </summary>
    public partial class ViewEvents : Page
    {
        private MasterManager _manager;
        private List<Event> _events;

        public ViewEvents( MasterManager masterManager)
        {
            InitializeComponent();
            _manager = masterManager;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datVeiwEventsGrid.ItemsSource = null;
            try
            {
                _events = _manager.EventManager.SelectAllEvent();

            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
            }
            if (_events.Count != 0)
            {
                datVeiwEventsGrid.ItemsSource = _events;
                try
                {
                    datVeiwEventsGrid.Columns.RemoveAt(0);
                    datVeiwEventsGrid.Columns.RemoveAt(0);
                    datVeiwEventsGrid.Columns.RemoveAt(0);
                    datVeiwEventsGrid.Columns.RemoveAt(4);
                    datVeiwEventsGrid.Columns.RemoveAt(4);
                    datVeiwEventsGrid.Columns.RemoveAt(4);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("An Error occurred", ex.Message + "\n" + ex.InnerException, ButtonMode.Ok);
                }
            }
            else
            {
                List<string> noRecordMessage = new List<string>();
                datVeiwEventsGrid.ItemsSource = noRecordMessage;
                datVeiwEventsGrid.Columns[0].Header = "No Entitys Available";
            }

        }
    }
}
