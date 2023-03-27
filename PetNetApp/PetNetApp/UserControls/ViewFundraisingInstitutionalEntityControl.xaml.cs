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

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for ViewFundraisingInstitutionalEntityControl.xaml
    /// </summary>
    public partial class ViewFundraisingInstitutionalEntityControl : UserControl
    {
        public static double CompanyNameSectionWidth { get; set; } = 200;
        public static double GivenNameSectionWidth { get; set; } = 125;
        public static double FamilyNameSectionWidth { get; set; } = 125;
        public static double EmailSectionWidth { get; set; } = 125;
        public InstitutionalEntity InstitutionalEntity { get; set; }
        public bool UseAlternateColors { get; set; }


        public ViewFundraisingInstitutionalEntityControl(InstitutionalEntity institutionalEntity, bool useAlternateColors)
        {
            InstitutionalEntity = institutionalEntity;
            UseAlternateColors = useAlternateColors;
            InitializeComponent();
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).ContextMenu.IsOpen = true;
        }

        private void menuEdit_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Edit", "Editing " + InstitutionalEntity.GivenName + " " + InstitutionalEntity.FamilyName);
        }

        private void menuView_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("View", "Viewing " + InstitutionalEntity.GivenName + " " + InstitutionalEntity.FamilyName);
        }
        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Delete", "Are you sure you want to delete " + InstitutionalEntity.GivenName + " " + InstitutionalEntity.FamilyName + "?", ButtonMode.DeleteCancel);

        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Update", "Updating " + InstitutionalEntity.GivenName + " " + InstitutionalEntity.FamilyName);
        }

    }
}
