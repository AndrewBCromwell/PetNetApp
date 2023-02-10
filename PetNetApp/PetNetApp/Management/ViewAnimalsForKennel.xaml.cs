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
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for ViewAnimalsForKennel.xaml
    /// </summary>
    public partial class ViewAnimalsForKennel : Window
    {
        private List<Animal> _animals = null;
        MasterManager _masterManger = new MasterManager();
        public Animal SelectedAnimal { get; set; }

        public ViewAnimalsForKennel()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _animals = _masterManger.KennelManager.RetrieveAllAnimalsForKennel();
                if (_animals.Count > 0)
                {
                    datAnimals.ItemsSource = _animals;
                } 
                else
                {
                    PromptWindow.ShowPrompt("Error", "No animals avaliable for kenneling.", ButtonMode.Ok);
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n\n" + ex.InnerException.Message, ButtonMode.Ok);
            }
                
        }

        private void datAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedAnimal = (Animal)(datAnimals.SelectedItem);
            this.Close();
        }
    }
}
