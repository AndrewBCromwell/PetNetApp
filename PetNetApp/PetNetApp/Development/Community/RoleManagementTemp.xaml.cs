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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Development.Community
{
    /// <summary>
    /// Interaction logic for RoleManagementTemp.xaml
    /// </summary>
    /// 
    /// <summary>
    /// Barry Mikulas
    /// Created: 2023/02/11
    /// 
    /// 
    /// 
    /// </summary>
    /// Page is placeholder with button that launches the popup for roleManagement.
    /// 
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// 
    /// </remarks>
    public partial class RoleManagementTemp : Page
    {
        private MasterManager manager;
        private Users users;

        public RoleManagementTemp(MasterManager manager, Users user)
        {
            InitializeComponent();
            this.manager = manager;
            this.users = user;
        }

        private void btn_LaunchRoleManagement_Click(object sender, RoutedEventArgs e)
        {
            //RoleManagementPopup roleManagementPopupWindow = new RoleManagementPopup(manager, users);
            //roleManagementPopupWindow.ShowDialog();
        }
    }
}

namespace WpfPresentation.Development.Community
{
    /// <summary>
    /// Interaction logic for RoleManagementTemp.xaml
    /// </summary>
    public partial class RoleManagementTemp : Page
    {
        public RoleManagementTemp()
        {
            InitializeComponent();
        }
    }
}
