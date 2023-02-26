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
            if (!_users.SuspendEmployee)
            {
                lblSuspendUserTitle.Content = "Suspend User";
                txtSuspendUserMessage.Text = "Are you sure you want to suspend \n" + _users.GivenName + " " + _users.FamilyName + "?";
            }
            else
            {
                lblSuspendUserTitle.Content = "Unsuspend User";
                txtSuspendUserMessage.Text = "Are you sure you want to unsuspend\n" + _users.GivenName + " " + _users.FamilyName + "?";
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

        }
    }
}
