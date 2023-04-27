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

namespace WpfPresentation.Development.Events
{
    /// <summary>
    /// Interaction logic for EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        private static EventsPage _existingEventsPage = null;

        private Button[] _eventTabButtons;
        private MasterManager _manager = null;
        public EventsPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _eventTabButtons = new Button[] { btnEvents, btnCreateEvent, btnEventHistory};
        }

        private void svEventPageTabs_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEventHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnScrollLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnScrollRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEventResults_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
