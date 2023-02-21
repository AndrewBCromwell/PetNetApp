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
using LogicLayer;
using DataObjects;
using PetNetApp;
using WpfPresentation.Development.Misc;

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        private static LogInPage _existingLogIn = null;
        private MasterManager _manager = MasterManager.GetMasterManager();
        private MainWindow _mainWindow = null;

        public LogInPage()
        {
            InitializeComponent();
        }

        public static LogInPage GetLogInPage(MainWindow mainWindow)
        {
            if (_existingLogIn == null)
            {
                _existingLogIn = new LogInPage();
            }

            _existingLogIn._mainWindow = mainWindow;

            return _existingLogIn;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            int emailAt = email.Count(f => f == '@');
            int emailPeriod = email.Count(f => f == '.');

            if (emailAt < 1 || emailPeriod < 1)
            {
                ErrorLoading(true);
                ChangeErrorText("Email is not valid.", "Please enter a valid email.");
                lblUserError.Visibility = Visibility.Visible;
                txtEmail.SelectAll();
                txtEmail.Focus();
                if (password == "" || password == null)
                {
                    ChangeErrorText("Email / Password is not valid.", "Please enter a valid email / password.");
                    lblPasswordError.Visibility = Visibility.Visible;
                }
                return;
            }
            else
            {
                ErrorLoading(false);
                lblUserError.Visibility = Visibility.Hidden;
            }

            if (password == "" || password == null)
            {
                ErrorLoading(true);
                ChangeErrorText("Password cannot be empty.", "Please enter a password");
                lblPasswordError.Visibility = Visibility.Visible;
                txtPassword.SelectAll();
                txtPassword.Focus();
                return;
            }
            else
            {
                ErrorLoading(false);
                lblPasswordError.Visibility = Visibility.Hidden;
            }

            try
            {
                _manager.User = _manager.UsersManager.LoginUser(email, password);
                MessageBox.Show("Welcome back, " + _manager.User.GivenName + "\n\nYou're signed in as " + RoleBuilder(_manager.User));
                _mainWindow.mnuUser.Header = "Hello, " + _manager.User.GivenName;
                _mainWindow.mnuLogout.Header = "Log Out";
                NavigationService.Navigate(null);
                _mainWindow.ShowButtonsByRole();
                
            }
            catch (Exception up)
            {
                ChangeErrorText("Email / Password is not valid.", "Please enter a valid email / password.");
                ErrorLoading(true);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = "";
            txtPassword.Password = "";
        }

        private void ErrorLoading(bool onOff)
        {
            if (onOff)
            {
                // hide elements
                lblWelcomeBack.Visibility = Visibility.Hidden;
                lblPleaseLogin.Visibility = Visibility.Hidden;
                rectHeader.Visibility = Visibility.Hidden;

                // show elements
                lblWelcomeBackError.Visibility = Visibility.Visible;
                lblPleaseLoginError.Visibility = Visibility.Visible;
                rectHeaderError.Visibility = Visibility.Visible;
                lblErrorErr.Visibility = Visibility.Visible;
                lblErrorHelp.Visibility = Visibility.Visible;
            }
            else
            {
                // hide elements
                lblWelcomeBack.Visibility = Visibility.Visible;
                lblPleaseLogin.Visibility = Visibility.Visible;
                rectHeader.Visibility = Visibility.Visible;

                // show elements
                lblWelcomeBackError.Visibility = Visibility.Hidden;
                lblPleaseLoginError.Visibility = Visibility.Hidden;
                rectHeaderError.Visibility = Visibility.Hidden;
                lblErrorErr.Visibility = Visibility.Hidden;
                lblErrorHelp.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeErrorText(string error, string help)
        {
            lblErrorErr.Content = error;
            lblErrorHelp.Content = help;
        }

        // testing method to ensure the program is correctly detecting roles
        private string RoleBuilder(UsersVM user)
        {
            string roles = "";
            if (user.Roles.Count == 1)
            {
                roles = user.Roles[0] + ".";
            }
            else if (user.Roles.Count == 2)
            {
                roles = user.Roles[0] + " and " + user.Roles[1] + ".";
            }
            else
            {
                for (int i = 0; i < user.Roles.Count; i++)
                {
                    if (i == user.Roles.Count - 1)
                    {
                        roles += "and " + user.Roles[i] + ".";
                        break;
                    }
                    roles += user.Roles[i] + ", ";
                }
            }
            return roles;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(SignUp.GetSignUpPage(_manager));
        }


    }

}
