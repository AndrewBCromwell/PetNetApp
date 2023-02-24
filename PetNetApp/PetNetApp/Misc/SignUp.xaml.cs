using DataObjects;
using LogicLayer;
using PetNetApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WpfPresentation.Misc;

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Created By: Alex Oetken [2023/02/15]
    /// 
    /// Last Updated By: Mads Rhea [2023/02/19]
    /// 
    /// Notes: -
    /// </summary>
    public partial class SignUp : Page
    {
        private static SignUp _existingSignUp = null;
        private MasterManager _manager = MasterManager.GetMasterManager();
        private MainWindow _mainWindow = null;
        private Users _user = null;


        public SignUp()
        {
            InitializeComponent();
        }

        public static SignUp GetSignUpPage(MainWindow mainWindow)
        {
            if (_existingSignUp == null)
            {
                _existingSignUp = new SignUp();
            }

            _existingSignUp._mainWindow = mainWindow;

            return _existingSignUp;
        }



        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string givenName = txtGivenName.Text;
            string familyName = txtFamilyName.Text;
            string phoneNumber = txtPhone.Text;
            string zipCode = txtZipCode.Text;
            string password = txtPassword.Password;
            string confirmPassword = txtPasswordConfirm.Password;
            string genderId = genderSelection.Text;
            string pronounId = pronounSelection.Text;

            if (email == "")
            {
                MessageBox.Show("Please enter your email.");
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            if (givenName == "" || givenName == null || givenName.Length >= 50)
                {
                MessageBox.Show("Please enter a valid first Name.");
                txtGivenName.Focus();
                txtGivenName.SelectAll();
                return; 
            }

            if (familyName == "" || familyName == null || givenName.Length >= 50)
            {
                MessageBox.Show("Please enter a valid last name.");
                txtFamilyName.Focus();
                txtFamilyName.SelectAll();
                return;
            }

            if (phoneNumber.Length != 11)
            {
                MessageBox.Show("Please enter a valid phone number with area code.");
                txtPhone.Focus();
                txtPhone.SelectAll();
                return; 
            }

            if (zipCode.Length > 11)
            {
                MessageBox.Show("Please enter a valid zip code.");
                txtZipCode.Focus();
                txtZipCode.SelectAll();
                return; 
            }

            if (password == "" || password.Length < 8)
            {
                MessageBox.Show("Please enter a password with at least 8 characters.");
                txtPassword.Focus();
                txtPassword.SelectAll();
                return; 
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Please match passwords.");
                txtPassword.Clear();
                txtPasswordConfirm.Clear();
                txtPassword.Focus(); 
                return; 
            }

            if (genderId == "")
            {
                MessageBox.Show("Please enter your gender");
                genderSelection.Focus();
                return; 
            }

            if (pronounId == "")
            {
                MessageBox.Show("Please enter your preferred pronouns.");
                pronounSelection.Focus();
                return; 
            }


            _user = new Users()
            {
                Email = email,
                GivenName = givenName,
                FamilyName = familyName,
                Phone = phoneNumber,
                Zipcode = zipCode,
                GenderId = genderId,
                PronounId = pronounId
            };

            try
            {
                if(_manager.UsersManager.AddUser(_user, password))
                {
                    MessageBox.Show("Account has been created! Please log in using your new credentials.");
                    NavigationService.Navigate(new LogInPage());
                   
                }
            } 
            catch (Exception)
            {
                MessageBox.Show("Uh oh! Something bad happened. Let's try that again.");
                txtPassword.Clear();
                txtPasswordConfirm.Clear();
                txtEmail.Clear();
                txtFamilyName.Clear();
                txtGivenName.Clear();
                txtZipCode.Clear();
                txtPhone.Clear(); 

            }


        }
        private void btnSignUpCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure? You will lose your progress.", "Really Cancel?",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                txtPassword.Clear();
                txtPasswordConfirm.Clear();
                txtEmail.Clear();
                txtFamilyName.Clear();
                txtGivenName.Clear();
                txtZipCode.Clear();
                txtPhone.Clear();
                NavigationService.Navigate(new LogInPage());

            }
            else
            {
                
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> genders = _manager.UsersManager.RetrieveGenders();
            List<string> pronouns = _manager.UsersManager.RetrievePronouns();

            genderSelection.SelectedIndex = 0;
            pronounSelection.SelectedIndex = 0;

            foreach (var gender in genders)
            {
                genderSelection.Items.Add(gender);
            }

            foreach(var pronoun in pronouns)
            {
                pronounSelection.Items.Add(pronoun);
            }
        }
    }
}
