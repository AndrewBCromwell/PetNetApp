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

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for AnimalListUserControl.xaml
    /// </summary>
    public partial class AnimalListUserControl : UserControl
    {
        private AnimalVM _animal = null;
        private MasterManager _manager = MasterManager.GetMasterManager();
        
        public AnimalListUserControl(Animal animal)
        {
            InitializeComponent();
            _animal =_manager.AnimalManager.RetrieveAnimalByAnimalId(animal.AnimalId, animal.AnimalShelterId);
        }

        private void btnViewAnimalProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new WpfPresentation.Animals.EditDetailAnimalProfile(_manager, _animal));
        }
    }
}
