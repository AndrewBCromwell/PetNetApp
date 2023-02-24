using DataObjects;
using LogicLayer;
using PetNetApp;
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

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Alex Oetken
    /// Created: 2023/02/05
    /// 
    /// WPF for deactivate button page within "Account Settings"
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
    public partial class DeactivateButtonPage : Page
    {
        private static DeactivateButtonPage _existingDeactivateButton = null;
        private MasterManager _manager = MasterManager.GetMasterManager();

        public DeactivateButtonPage()
        {
            InitializeComponent();
        }

        public static DeactivateButtonPage GetDeactivateButtonPage()
        {
            if (_existingDeactivateButton == null)
            {
                _existingDeactivateButton = new DeactivateButtonPage();
            }

            return _existingDeactivateButton;
        }

        private void DeactivateButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure? This action cannot be undone.", "Deactivate Account?",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (_manager.UsersManager.DeactivateUserAccount(_manager.User.UsersId))
                    {
                        MessageBox.Show("Account has been deactivated!");
                        _manager.User = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            } else if (result == MessageBoxResult.No)
            {
                
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtblkDeactivateWarning.Text = "WARNING: Clicking the button below will deactivate your account!\nThe only way you can get your account back is having an admin reactivate it for you.\n\nBE SURE THIS IS WHAT YOU WANT TO DO BEFORE PROCEEDING.";
        }
    }
}
