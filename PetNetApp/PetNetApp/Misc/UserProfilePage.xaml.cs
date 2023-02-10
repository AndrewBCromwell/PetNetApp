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

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        private static UserProfilePage _existingProfilePage = null;
        private MainWindow _mainWindow = null;

        public UserProfilePage()
        {
            InitializeComponent();
        }

        public static UserProfilePage GetUserProfilePage(MainWindow mainWindow)
        {
            if (_existingProfilePage == null)
            {
                _existingProfilePage = new UserProfilePage();
            }

            _existingProfilePage._mainWindow = mainWindow;

            return _existingProfilePage;
        }
    }
}
