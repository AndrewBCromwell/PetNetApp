/// <summary>
/// Barry Mikulas
/// Created: 2023/02/26
/// 
/// Window is used for processing of a user suspension
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
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
    /// Barry Mikulas
    /// 2023/02/26
    public partial class SuspendUserPopup : Window
    {

        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private Users _users;

        public SuspendUserPopup(MasterManager manager, Users user)
        {
            InitializeComponent();
            this._masterManager = manager;
            this._users = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //populate window based on user's suspend status
            if (!_users.Suspend)
            {
                lblSuspendUserTitle.Content = "Suspend User";
                txtSuspendUserMessage.Text = "Are you sure you want to suspend \n" + _users.GivenName + " " + _users.FamilyName + "?";
            }
            else
            {
                lblSuspendUserTitle.Content = "Unsuspend User";
                txtSuspendUserMessage.Text = "Are you sure you want to unsuspend \n" + _users.GivenName + " " + _users.FamilyName + "?";
            }
            txtSuspendUserMessage2.Text = "To confirm, please type your password below and the select 'Confirm'";

        }

        /// Barry Mikulas
        /// Created: 2023/02/26
        /// Prompts user for confirmation of cancelation, closes window if confirmed
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // verify person wants to close the window
            if (PromptWindow.ShowPrompt("Confirm Cancel", "Are you sure you want to cancel?", ButtonMode.YesNo) == PromptSelection.Yes)
            {
                this.Close(); //close the window
            }
        }

        /// Barry Mikulas
        /// Created: 2023/02/26
        /// Prompts user for confirmation of user suspension
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            bool userSuspendStatus = _users.Suspend;
            int adminCount = 0;
            string password = txtConfirmPassword.Password;
            UsersVM testPasswordUser;
            List<Role> userRoles = _masterManager.RoleManager.RetrieveRoleListByUserId(_users.UsersId);

            //check to see if user is trying to suspend own account
            if (_masterManager.User.UsersId == _users.UsersId)
            {
                PromptWindow.ShowPrompt("Error", "You cannot suspend your own account, please ask another Admin or Manager to complete this action.");
                return;
            }

            //check password
            if (password == "" || password == null)
            {
                PromptWindow.ShowPrompt("Try Again", "Please enter a valid password\n and try again");
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
                return;
            }

            //this part attempts to login again with the logged in user's email and the password they entered
            try
            {
                testPasswordUser = _masterManager.UsersManager.LoginUser(_masterManager.User.Email, password);
            }
            catch (Exception up)
            {
                PromptWindow.ShowPrompt("Try Again", "Please enter a valid password and try again");
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
                return;
            }
            //check to see if user to be suspended is an admin if they are then
            //check to make sure there will be at least 2 active admin accounts
            var matches = userRoles.Any(p => p.RoleId == "Admin");
            if (matches && !userSuspendStatus)
            {
                adminCount = _masterManager.UsersManager.RetrieveCountActiveUnsuspendUserAccountsByRoleId("Admin");
                if (adminCount < 2)
                {
                    PromptWindow.ShowPrompt("Suspend Error", "There must be at least one active 'Admin' acount. \n Another user must be given the Admin role before this account can be suspended.");
                    return;
                }
            }

            //attempt to suspend the user's account
            try
            {
                if (userSuspendStatus)
                {
                    if (_masterManager.UsersManager.UnsuspendUserAccount(_users.UsersId))
                    {
                        PromptWindow.ShowPrompt("User Unsuspended", _users.GivenName + " " + _users.FamilyName + "'s account has been unsuspended. \n Click OK to continue.");
                    }
                    else
                    {
                        throw new ApplicationException("User not unsuspended.");
                    }
                }
                else
                {
                    if (_masterManager.UsersManager.SuspendUserAccount(_users.UsersId))
                    {
                        PromptWindow.ShowPrompt("User Suspended", _users.GivenName + " " + _users.FamilyName + "'s account has been suspended. \n Click OK to continue.");
                    }
                    else
                    {
                        throw new ApplicationException("User not suspended.");
                    }
                }

            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", "" + ex.Message);
            }

            //close popup
            //this.Close();
            this.DialogResult = true;
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }

        private void btnCloseWindowX_Click(object sender, RoutedEventArgs e)
        {
            btnCancel_Click(sender, e);
        }
    }
}
