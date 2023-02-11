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

namespace WpfPresentation.Management
{
    /// <summary>
    /// Interaction logic for AddKennelPage.xaml
    /// </summary>
    public partial class AddKennelPage : Page
    {
        private MasterManager masterManager;
        public AddKennelPage(MasterManager masterManager)
        {
            InitializeComponent();
            this.masterManager = masterManager;
            try
            {
                var dropDownList = masterManager.KennelManager.RetrieveAnimalTypes();
                cbAnimalType.ItemsSource = dropDownList;
                
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewKennelPage(masterManager));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs()) 
            {
                return;
            };

            Kennel kennel = new Kennel();

            // Replace with masterManager.User.Shelter.ShelterId when users are made
            kennel.ShelterId = 100000;
            kennel.KennelName = txtKennelName.Text;
            kennel.AnimalTypeId = cbAnimalType.SelectedItem.ToString();

            try
            {
                masterManager.KennelManager.AddKennel(kennel);
                NavigationService.Navigate(new ViewKennelPage(masterManager));
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);
            }
        }

        private bool ValidateInputs()
        {
            if (txtKennelName.Text.Equals("") || cbAnimalType.SelectedItem == null)
            {
                PromptWindow.ShowPrompt("Error", "Please fill out all fields", ButtonMode.Ok);
                return false;
            }
            if (txtKennelName.Text.Length > 50)
            {
                PromptWindow.ShowPrompt("Error", "Kennel Name can not be longer than 50 characters", ButtonMode.Ok);
                return false;
            }
            return true;
        }
    }
}
