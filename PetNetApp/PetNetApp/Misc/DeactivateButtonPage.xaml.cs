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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Development.Misc
{
    /// <summary>
    /// Interaction logic for DeactivateButton.xaml
    /// </summary>
    public partial class DeactivateButton : Page
    {
        private MasterManager _manager = MasterManager.GetMasterManager(); 
        private Users _user = new Users();

        public DeactivateButton()
        {
            InitializeComponent();
        }

        private void DeactivateButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure? This action cannot be undone.", "Deactivate Account?",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (_manager.UsersManager.DeactivateUserAccount(_user.UsersId))
                    {
                        MessageBox.Show("Account has been deactivated!");
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
    }
}
