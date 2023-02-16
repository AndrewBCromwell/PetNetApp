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

namespace WpfPresentation.Development.Community
{
    /// <summary>
    /// Interaction logic for RoleManagementPopup.xaml
    /// </summary>
    /// 
    /// <summary>
    /// Barry Mikulas
    /// Created: 2023/02/11
    /// 
    /// 
    /// 
    /// </summary>
    /// Window for managing a single user's roles.
    /// 
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// 
    /// </remarks>
    public partial class RoleManagementPopup : Window
    {
        private RoleManager _roleManager = new RoleManager();
        private List<Role> _roles = new List<Role>(); //for the role list combo box
        private List<Role> _rolesByUser = new List<Role>(); //user's role list
        private MasterManager _manager;
        private Users _users;

        //public RoleManagementPopup()
        //{
        //    InitializeComponent();
        //}

        public RoleManagementPopup(MasterManager manager, Users user)
        {
            InitializeComponent();
            this._manager = manager;
            this._users = user;
        }

        private void btn_AddRole_Click(object sender, RoutedEventArgs e)
        {
            string newRole;
            //check to see if role selected from combo box
            if (string.IsNullOrEmpty(cboChooseRole.Text))
            {
                //if no role selected tell user
                if (PromptWindow.ShowPrompt("Error", "Please select a role to add and try again", ButtonMode.Ok) == PromptSelection.Ok)
                {
                    return;
                }
            }
            else
            {
                newRole = cboChooseRole.Text;
                if (PromptWindow.ShowPrompt("Role to Add", "Click Save to add the role: " + cboChooseRole.Text + " for the user.", ButtonMode.SaveCancel) == PromptSelection.Cancel)
                {
                    return;
                }
            }
            //check to see if role list already has role



            //add role to list

            //reload role list 
        }

        private void btn_Previous_Click(object sender, RoutedEventArgs e)
        {
            if (PromptWindow.ShowPrompt("Previous", "Go to edit user info screen?", ButtonMode.YesNo) == PromptSelection.Yes)
            {
                //navigate back to edit user details
            }
            else
            {
                //do nothing
            }

        }

        private void btn_Finish_Click(object sender, RoutedEventArgs e)
        {
            if (PromptWindow.ShowPrompt("Save", "Confirm, Finished editing user.", ButtonMode.YesNo) == PromptSelection.Yes)
            {
                //save user roles list to database
            }
            else
            {
                //close prompt
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // verify person wants to close the window
            if (PromptWindow.ShowPrompt("Confirm Cancel", "Are you sure you want to cancel?", ButtonMode.YesNo) == PromptSelection.No)
            {
                //return to the window
            }
            else
            {
                //close the page
                this.Close();
            }
        }

        private void btn_RemoveRole(object sender, RoutedEventArgs e)
        {
            //can get the value of the RoleId from using ((Button)sender).Tag
            if (PromptWindow.ShowPrompt("Remove Role?", "Confirm, are you sure you want to remove the role " + ((Button)sender).Tag + "?", ButtonMode.YesNo) == PromptSelection.Yes)
            {
                //attempt to remove role
            }
            else
            {
                //do nothing
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // retrieve role list for combo box
            try
            {
                _roles = _roleManager.RetrieveAllRoles();
                this.cboChooseRole.ItemsSource = from r in _roles
                                                 orderby r.RoleId
                                                 select r.RoleId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PopulateUserRoleGrid();
        }

        private void PopulateUserRoleGrid()
        {
            //retrieve user's roles
            //populate data grid
            try
            {
                _rolesByUser = _roleManager.RetrieveRoleListByUserId(_users.UsersId);
                datUserRoles.ItemsSource = _rolesByUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
