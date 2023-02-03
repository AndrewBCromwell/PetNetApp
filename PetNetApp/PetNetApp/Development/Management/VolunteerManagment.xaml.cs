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
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
    public partial class VolunteerManagment : Page
    {
        private List<UsersVM> _users = null;
        private MasterManager _mastermanager = new MasterManager();
        public VolunteerManagment()
        {
            InitializeComponent();
            
            try
            {
                _users = _mastermanager.UserManager.RetrieveUserByRole("Volunteer");
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
    }
}
