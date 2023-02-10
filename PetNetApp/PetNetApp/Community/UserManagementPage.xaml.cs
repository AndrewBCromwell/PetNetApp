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
using WpfPresentation.Community.UsersControl;
using LogicLayer;
using DataObjects;

namespace WpfPresentation.Community
{
    /// <summary>
    /// Interaction logic for UserManagementPage.xaml
    /// </summary>

    public partial class UserManagementPage : Page
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();

        List<UsersVM> _employeeList = null;
        public UserManagementPage()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/01
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="user"></param>
        /// <param name="index"></param>

        public void DisplayUsers(Users user, int index)
        {
            UCPreviewUser ucPreviewUser = new UCPreviewUser();
            if (user.Active)
            {
                var bc = new BrushConverter();
                ucPreviewUser.elsIsActive.Fill = (Brush)bc.ConvertFrom("#3D8361");
            }
            else
            {
                var bc = new BrushConverter();
                ucPreviewUser.elsIsActive.Fill = (Brush)bc.ConvertFrom("#F54242");
            }
            ucPreviewUser.lblUserAccountName.Content = user.GivenName + " " + user.FamilyName;
            ucPreviewUser.lblUserEmailName.Content = user.Email;
            ucPreviewUser.btnUsersProfile.Click += (obj, arg) => usersProfile_MouseClick();
            ucPreviewUser.btnUsersMoreDetails.Click += (obj, arg) =>
                    {
                        ucPreviewUser.btnUsersMoreDetails.ContextMenu = new ContextMenu();
                        MenuItem menuItemUpdate = new MenuItem()
                        { Header = "Update"};
                        menuItemUpdate.Click += (object1, args) => menuItem_Update_Click();
                        ucPreviewUser.btnUsersMoreDetails.ContextMenu.Items.Add(menuItemUpdate);

                        MenuItem menuItemSuspend = new MenuItem()
                        { Header = "Suspend" };
                        menuItemSuspend.Click += (object1, args) => menuItem_Suspend_Click();
                        ucPreviewUser.btnUsersMoreDetails.ContextMenu.Items.Add(menuItemSuspend);

                        MenuItem menuItemDeactivate = new MenuItem()
                        { Header = "Deactivate" };
                        MenuItem menuItemActivate = new MenuItem()
                        { Header = "Activate" };
                        if (user.Active)
                        {
                            menuItemDeactivate.Click += (object1, args) => menuItem_Deactivate_Click();
                            ucPreviewUser.btnUsersMoreDetails.ContextMenu.Items.Add(menuItemDeactivate);
                        }
                        else
                        {
                            menuItemActivate.Click += (object1, args) => menuItem_Activate_Click();
                            ucPreviewUser.btnUsersMoreDetails.ContextMenu.Items.Add(menuItemActivate);
                        }
                        
                        ucPreviewUser.btnUsersMoreDetails.ContextMenu.IsOpen = true;
                        return;
                    };
            if(index % 2 == 0)
            {
                var bc = new BrushConverter();
                ucPreviewUser.Background = (Brush)bc.ConvertFrom("#D6CDA4");
            }
            else
            {
                var bc = new BrushConverter();
                ucPreviewUser.Background = (Brush)bc.ConvertFrom("#EEF2E6");
            }
            stpUsersList.Children.Add(ucPreviewUser);
        }

        private void usersProfile_MouseClick()
        {
            MessageBox.Show("User's profile");
        }

        // MenuItem Click
        private void menuItem_Update_Click()
        {
            MessageBox.Show("Update");
        }

        private void menuItem_Suspend_Click()
        {
            MessageBox.Show("Suspend");
        }

        private void menuItem_Deactivate_Click()
        {
            MessageBox.Show("Deativate");
        }

        private void menuItem_Activate_Click()
        {
            MessageBox.Show("Deativate");
        }
        // End menu item click



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_employeeList == null)
            {
                try
                {
                    _employeeList = _masterManager.UsersManager.RetriveAllEmployees();
                    int index = 0;
                    foreach (Users user in _employeeList)
                    {
                        DisplayUsers(user, index);
                        index++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
                }
            }
        }
    }

}
