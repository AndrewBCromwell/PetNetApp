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
using LogicLayer;
using DataObjects;
using PetNetApp;

namespace WpfPresentation.Misc
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        private static LandingPage _existingLanding = null;
        private MainWindow _mainWindow = null;

        public LandingPage()
        {
            InitializeComponent();
        }

        public static LandingPage GetLandingPage(MainWindow mainWindow)
        {
            if (_existingLanding == null)
            {
                _existingLanding = new LandingPage();
            }

            _existingLanding._mainWindow = mainWindow;

            return _existingLanding;
        }

    }
}
