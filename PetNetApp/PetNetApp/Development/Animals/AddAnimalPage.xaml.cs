/// <summary>
/// John
/// Created: 2023/02/03
/// 
/// Interaction logic for AddAnimalPage.xaml
/// </summary>
///
/// <remarks>
/// Andrew Schneider
/// Updated: 2023/02/22
/// </remarks>
/// 

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
    public partial class AddAnimalPage : Page
    {
        private static AddAnimalPage _existingAddAnimalPage = null;

        private MasterManager _manager = null;
        private AnimalVM _animal = null;

        public AddAnimalPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        public static AddAnimalPage GetAddAnimalPage(MasterManager manager)
        {
            if (_existingAddAnimalPage == null)
            {
                _existingAddAnimalPage = new AddAnimalPage(manager);
            }
            return _existingAddAnimalPage;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = PromptWindow.ShowPrompt("Discard Changes", "Are you sure you want to cancel?\n" +
                                                    "Animal record will not be saved.", ButtonMode.YesNo);
            if (result == PromptSelection.Yes)
            {
                
            }
        }
    }
}
