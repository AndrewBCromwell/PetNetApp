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

namespace WpfPresentation.Community
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
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<Role> _roles = new List<Role>(); //for the role list combo box
        private List<Role> _rolesByUser = new List<Role>(); //user's role list
        private Users _users;

        public RoleManagementPopup(MasterManager manager, Users user)
        {
            InitializeComponent();
            this._masterManager = manager;
            this._users = user;
        }

        /// Barry Mikulas
        /// Created: 2023/02/15
        private void btn_AddRole_Click(object sender, RoutedEventArgs e)
        {
            Role newUserRole = new Role();
            bool success = false;
            newUserRole.RoleId = cboChooseRole.Text;
            //check to see if role selected from combo box
            if (cboChooseRole.SelectedItem == null)
            {
                //if no role selected tell user
                PromptWindow.ShowPrompt("Error", "Please select a role to add and try again", ButtonMode.Ok);
                return;

            }
            else
            {
                //check to see if role list already has role
                for (int i = 0; i < _rolesByUser.Count(); i++)
                {
                    if (_rolesByUser[i].RoleId == newUserRole.RoleId)
                    {
                        PromptWindow.ShowPrompt("Error", "User already has the role: " + newUserRole.RoleId + ". Please choose another.", ButtonMode.Ok);
                        return;
                    }
                }
                if (PromptWindow.ShowPrompt("Role to Add", "Click Save to add the role: " + newUserRole.RoleId + " for the user.", ButtonMode.SaveCancel) == PromptSelection.Cancel)
                {
                    return;
                }
                //add role to list
                try
                {
                    success = _masterManager.RoleManager.AddRoleByUsersId(newUserRole, _users.UsersId);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
                    return;
                }

                //reload role list 
                PopulateUserRoleGrid();
            }

        }
        /// Barry Mikulas
        /// Created: 2023/02/11
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
        /// Barry Mikulas
        /// Created: 2023/02/11
        private void btn_Finish_Click(object sender, RoutedEventArgs e)
        {
            if (PromptWindow.ShowPrompt("Save", "Are you finished editing roles for: " + _users.GivenName + " " + _users.FamilyName + "?", ButtonMode.YesNo) == PromptSelection.Yes)
            {
                //save user roles list to database this is no longer need as the add and remove roles updates the database
                this.Close();
            }
            else
            {
                //close prompt
            }
        }
        /// Barry Mikulas
        /// Created: 2023/02/11
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
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// Modified:
        /// by:
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

        /// Barry Mikulas
        /// Created: 2023/02/11
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // retrieve role list for combo box
            try
            {
                _roles = _masterManager.RoleManager.RetrieveAllRoles();
                //this.cboChooseRole.ItemsSource = from r in _roles
                //                                 orderby r.RoleId
                //                                 select r.RoleId; 
                this.cboChooseRole.ItemsSource = _roles;
                cboChooseRole.DisplayMemberPath = "RoleId";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PopulateUserRoleGrid();
        }

        /// Barry Mikulas
        /// Created: 2023/02/11
        private void PopulateUserRoleGrid()
        {
            //retrieve user's roles
            //populate data grid
            try
            {
                _rolesByUser = _masterManager.RoleManager.RetrieveRoleListByUserId(_users.UsersId);
                datUserRoles.ItemsSource = _rolesByUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
