/// <summary>
/// Oleksiy Fedchuk
/// Created: 2023/02/23
/// 
/// These are the small rows that populate the stack pannel on VolunteerListPage
/// </summary>

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

namespace WpfPresentation.Events
{
    /// <summary>
    /// Interaction logic for VolunteerListUserControl.xaml
    /// </summary>
    public partial class VolunteerListUserControl : UserControl
    {
        public static double TitleSectionWidth { get; set; } = 200;
        public VolunteerVM VolunteerVM { get; set; }
        public bool UseAlternateColors { get; set; }
        /// <summary>
        /// Sets the row to be a volunteer and alternates the colors
        /// </summary>
        /// <param name="volunteer"></param>
        /// <param name="useAlternateColors"></param>
        public VolunteerListUserControl(VolunteerVM volunteer, bool useAlternateColors)
        {
            VolunteerVM = volunteer;
            UseAlternateColors = useAlternateColors;
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).ContextMenu.IsOpen = true;
        }

        private void menuView_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("View", "Viewing " + VolunteerVM.GivenName + " " + VolunteerVM.FamilyName);
        }

        private void menuEdit_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Edit", "Editing " + VolunteerVM.GivenName + " " + VolunteerVM.FamilyName);
        }

        private void menuRemove_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Remove", "Are you sure you want to remove " + VolunteerVM.GivenName + " " + VolunteerVM.FamilyName + "?", ButtonMode.DeleteCancel);
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Update", "Updating " + VolunteerVM.GivenName + " " + VolunteerVM.FamilyName);
        }
    }
}
