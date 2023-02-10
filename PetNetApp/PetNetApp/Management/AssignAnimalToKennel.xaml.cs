using DataObjects;
using LogicLayer;
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
using WpfPresentation.Animals;
using WpfPresentation.Management;

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for AssignAnimalToKennel.xaml
    /// </summary>
    public partial class AssignAnimalToKennel : Page
    {
        MasterManager _masterManager = new MasterManager();
        Kennel _kennel = new Kennel();

        public AssignAnimalToKennel(MasterManager masterManager, Kennel kennel)
        {
            InitializeComponent();
            _masterManager = new MasterManager();
            _kennel = kennel;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblKennelNumber.Content = "Kennel " + _kennel.KennelId;
            lblKennelTitle.Content = "Add Animal to Kennel " + _kennel.KennelId;
            txtAnimalID.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string animalId = txtAnimalID.Text;

            if (!animalId.All(char.IsDigit))
            {
                PromptWindow.ShowPrompt("Error", "Animal Id can only contain numbers", ButtonMode.Ok);
                txtAnimalID.Focus();
                return;
            }
            if (animalId == "")
            {
                PromptWindow.ShowPrompt("Error", "Animal Id cannot be empty", ButtonMode.Ok);
                txtAnimalID.Focus();
                return;
            }

            try
            {
                if (_masterManager.KennelManager.AddAnimalIntoKennelByAnimalId(_kennel.KennelId, Int32.Parse(animalId)))
                {
                    PromptWindow.ShowPrompt("Success", "Animal added to kennel", ButtonMode.Ok);
                    NavigationService.Navigate(new ViewKennelPage());
                }
                else
                {
                    PromptWindow.ShowPrompt("Error", "Failed to insert animal into kennel.", ButtonMode.Ok);
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n\n" + ex.InnerException.Message, ButtonMode.Ok);
            }

        }

        private void btnViewAnimalList_Click(object sender, RoutedEventArgs e)
        {
            //open window to select an animal
            var animalListWindow = new ViewAnimalsForKennel();
            animalListWindow.ShowDialog();

            //populate text box with animal object selected from list
            try
            {
                if (animalListWindow.SelectedAnimal != null)
                {
                    txtAnimalID.Text = animalListWindow.SelectedAnimal.AnimalId.ToString();
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n\n" + ex.InnerException.Message, ButtonMode.Ok);
            }
            
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewKennelPage());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (PromptWindow.ShowPrompt("Question", "Go back?", ButtonMode.YesNo) == PromptSelection.Yes)
            {
                NavigationService.Navigate(new ViewKennelPage());
            }
        }
    }
}
