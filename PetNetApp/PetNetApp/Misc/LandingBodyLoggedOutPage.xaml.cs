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
    /// Created: 2023/02/24
    /// 
    /// WPF for the body section of the "Landing Page" (user logged out)
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
    public partial class LandingBodyLoggedOutPage : Page
    {
        private MainWindow _mainWindow = null;
        private static LandingBodyLoggedOutPage _existingLandingBodyLoggedOut = null;

        public LandingBodyLoggedOutPage()
        {
            InitializeComponent();
        }

        public static LandingBodyLoggedOutPage GetLandingBodyLoggedOutPage(MainWindow mainWindow)
        {
            if (_existingLandingBodyLoggedOut == null)
            {
                _existingLandingBodyLoggedOut = new LandingBodyLoggedOutPage();
            }

            _existingLandingBodyLoggedOut._mainWindow = mainWindow;

            return _existingLandingBodyLoggedOut;
        }
    }
}
