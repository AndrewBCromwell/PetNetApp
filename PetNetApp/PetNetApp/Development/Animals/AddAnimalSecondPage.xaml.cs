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

namespace WpfPresentation.Development.Animals
{
    /// <summary>
    /// Interaction logic for AddAnimalSecondPage.xaml
    /// </summary>
    public partial class AddAnimalSecondPage : Page
    {
        private static AddAnimalSecondPage _existingAddAnimalSecondPage = null;

        private MasterManager _manager = null;
        private Animal animal = null;

        public AddAnimalSecondPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        public static AddAnimalSecondPage GetAddAnimaSecondlPage(MasterManager manager)
        {
            if (_existingAddAnimalSecondPage == null)
            {
                _existingAddAnimalSecondPage = new AddAnimalSecondPage(manager);
            }
            return _existingAddAnimalSecondPage;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
