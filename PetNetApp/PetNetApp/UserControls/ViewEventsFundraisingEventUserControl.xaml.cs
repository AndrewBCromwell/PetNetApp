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
using WpfPresentation.Development.Fundraising;

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for ViewEventsFundraisingEventUserControl.xaml
    /// </summary>
    public partial class ViewEventsFundraisingEventUserControl : UserControl
    {

        public static double TitleSectionWidth { get; set; } = 200;
        public static double StartDateSectionWidth { get; set; } = 150;
        public static double StartTimeSectionWidth { get; set; } = 150;
        public FundraisingEvent FundraisingEvent { get; set; }
        public bool UseAlternateColors { get; set; }

        public ViewEventsFundraisingEventUserControl(FundraisingEvent fundraisingEvent, bool useAlternateColors)
        {
            FundraisingEvent = fundraisingEvent;
            UseAlternateColors = useAlternateColors;
            InitializeComponent();
        }

        private void menuView_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("View", "Viewing " + FundraisingEvent.StartTime.Date + " event for date: " + FundraisingEvent.StartTime.Date);

        }

        private void menuEdit_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Edit", "Editing " + FundraisingEvent.StartTime.Date + " event for date: " + FundraisingEvent.StartTime.Date);

        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Delete", "Are you sure you want to delete " + FundraisingEvent.Description + " event for date: " + FundraisingEvent.StartTime.Date, ButtonMode.DeleteCancel);

        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Update", "Updating " + FundraisingEvent.Description + " event for date: " + FundraisingEvent.StartTime.Date);

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).ContextMenu.IsOpen = true;
        }
    }
}
