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
using LogicLayer;
using PetNetApp.Development;

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for VolunteerManagment.xaml
    /// </summary>
    /// 
    /// <summary>
    /// Chris Dreismeier
    /// Created: 2023/02/03
    /// 
    /// 
    /// 
    /// </summary>
    /// Page for volunteermanagemnt view and edit volunteers
    /// 
    /// 
    /// <remarks>
    /// Teft Francisco
    /// Updated: 2023/2/24
    /// Added navigation methods to the "Edit Volunteer Information" button.
    /// </remarks>
    public partial class VolunteerManagment : Page
    {
        private List<UsersVM> _users = null;
        private MasterManager _mastermanager = MasterManager.GetMasterManager();
        public VolunteerManagment()
        {
            InitializeComponent();
            // uncomment when login is made
            //int shelterId = _mastermanager.User.ShelterId;
            int shelterId = 100000;


            try
            {
                _users = _mastermanager.UsersManager.RetrieveUserByRole("Volunteer",shelterId);
                datVolunteer.ItemsSource = _users;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtboxsearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = _users.Where(user => user.GivenName.StartsWith(txtboxsearch.Text, StringComparison.CurrentCultureIgnoreCase));
            if (rdbPhone.IsChecked == true)
            {
                filtered = _users.Where(user => user.Phone.StartsWith(txtboxsearch.Text, StringComparison.CurrentCultureIgnoreCase));
            }
            if (rdbAddress.IsChecked == true)
            {
                filtered = _users.Where(user => user.Address.StartsWith(txtboxsearch.Text, StringComparison.CurrentCultureIgnoreCase));
            }


            datVolunteer.ItemsSource = filtered;
        }

        private void btnEditSchedule_Click(object sender, RoutedEventArgs e)
        {
            UsersVM user = (UsersVM)datVolunteer.SelectedItem;
            if(datVolunteer.SelectedItem != null)
            {
                NavigationService.Navigate(new SchedulePage(user));
                var page = ManagementPage.GetManagementPage(_mastermanager);
                page.ChangeSelectedButton(page.btnSchedule);
            }
            else
            {
                PromptWindow.ShowPrompt("No User Selected", "There is no user selected");
            }
            
        }

        private void btnEditVolunteer_Click(object sender, RoutedEventArgs e)
        {
            if (datVolunteer.SelectedItem != null)
            {
                // This needs to nagivate to VolunteerInfoPage.xaml but is within the development folder.
                NavigationService.Navigate(new WpfPresentation.Management.VolunteerInfoPage((UsersVM)datVolunteer.SelectedItem));
            }
            else
            {
                MessageBox.Show("You must select a user to edit their information!", "No user selected.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
