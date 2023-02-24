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
    /// Mads Rhea
    /// Created: 2023/02/05
    /// 
    /// WPF for Account Info Page tab within "Account Settings"
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
    public partial class AccountInfoPage : Page
    {
        private static AccountInfoPage _existingAccountInfo = null;
        private MasterManager _manager = MasterManager.GetMasterManager();
        private MainWindow _mainWindow = null;

        public AccountInfoPage()
        {
            InitializeComponent();
            RefreshOnAccountUpdate();

            lblCurrentEmail.Content = "Current Email: " + _manager.User.Email;
        }

        public static AccountInfoPage GetAccountInfoPage(MainWindow mainWindow)
        {
            if (_existingAccountInfo == null)
            {
                _existingAccountInfo = new AccountInfoPage();
            }

            _existingAccountInfo._mainWindow = mainWindow;

            return _existingAccountInfo;
        }

        private void btnPasswordSave_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = txtOldPassword.Password;
            string newPassword = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (oldPassword == "")
            {
                MessageBox.Show("You must confirm your old password.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtOldPassword.Focus();
                return;
            }

            if (newPassword == "")
            {
                MessageBox.Show("You must enter a new password.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNewPassword.Focus();

                return;
            }

            if (newPassword == oldPassword)
            {
                MessageBox.Show("This matches a password previously used.\n\nPlease choose a different password.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                txtNewPassword.Focus();

                return;
            }

            if (confirmPassword == "")
            {
                MessageBox.Show("You did not confirm your new password.\n\nPlease confirm before continuing.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtConfirmPassword.Focus();

                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.\n\nPlease try again.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                txtNewPassword.Focus();

                return;
            }

            try
            {

                if (_manager.UsersManager.ResetPassword(_manager.User.Email, oldPassword, newPassword))
                {
                    MessageBox.Show("Password was reset!", "Success!", MessageBoxButton.OK);
                    RefreshOnAccountUpdate();
                }
                else
                {
                    throw new ApplicationException("Password reset failed.\n\nPlease try again later.");
                }
            }
            catch (Exception up)
            {
                throw;
            }

            Keyboard.ClearFocus();

        }

        private void btnEmailSave_Click(object sender, RoutedEventArgs e)
        {
            string email = txtNewEmail.Text;
            string password = passConfirmEmail.Password;
            int emailAt = email.Count(f => f == '@');
            int emailPeriod = email.Count(f => f == '.');

            if (emailAt < 1 || emailPeriod < 1)
            {
                MessageBox.Show("Please enter a valid Email.", "Email Error", MessageBoxButton.OK);
                txtNewEmail.SelectAll();
                txtNewEmail.Focus();
                return;
            }

            if (email == _manager.User.Email)
            {
                MessageBox.Show("Email is the same as your current email.\n\nPlease enter a different email if you wish to change it.", "Email Error", MessageBoxButton.OK);
                txtNewEmail.SelectAll();
                txtNewEmail.Focus();
                return;
            }

            if (password == "" || password == null)
            {
                MessageBox.Show("Password cannot be left empty.\n\nPlease enter your password.", "Password Error", MessageBoxButton.OK);
                passConfirmEmail.Focus();
                return;
            }

            try
            {
                if (_manager.UsersManager.UpdateEmail(_manager.User.Email, email, password))
                {
                    MessageBox.Show("Email was updated!", "Success!", MessageBoxButton.OK);
                    lblCurrentEmail.Content = "Current Email: " + email;
                    RefreshOnAccountUpdate();
                }
                else
                {
                    MessageBox.Show("Password was incorrect.\n\nPlease retype your password and try again.", "Password Error", MessageBoxButton.OK);
                    passConfirmEmail.Clear();
                    passConfirmEmail.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured.\n\nPlease try again later.", "Error", MessageBoxButton.OK);
            }

            Keyboard.ClearFocus();

        }

        private void txtOldPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                txtNewPassword.Focus();
            }
        }

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                txtConfirmPassword.Focus();
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                btnPasswordSave_Click(sender, e);
            }
        }

        private void RefreshOnAccountUpdate()
        {
            txtNewEmail.Clear();
            passConfirmEmail.Clear();

            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void txtNewEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                passConfirmEmail.Focus();
            }
        }

        private void passConfirmEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                btnEmailSave_Click(sender, e);
            }
        }
    }
}
