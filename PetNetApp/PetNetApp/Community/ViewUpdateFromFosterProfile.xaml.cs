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
using DataObjects;
using LogicLayer;
using WpfPresentation.Animals;

namespace WpfPresentation.Community
{
    /// <summary>
    /// Interaction logic for ViewUpdateFromFosterProfile.xaml
    /// </summary>
    public partial class ViewUpdateFromFosterProfile : Page
    {
        private List<AnimalVM> _animalList = null;
        private int _userId;
        private MasterManager _masterManager = MasterManager.GetMasterManager();

        public ViewUpdateFromFosterProfile(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        public void DisplayAdoptedAnimal(AnimalVM animal)
        {
            UCAdoptedAnimal ucAdoptedAnimal = new UCAdoptedAnimal();
            ucAdoptedAnimal.lblAnimalName.Content = animal.AnimalName;
            ucAdoptedAnimal.lblAnimalId.Content = animal.AnimalId;
            ucAdoptedAnimal.btnViewAnimalProfile.Click += (obj, arg) => ViewAnimalProfile_MouseClick(animal.AnimalId);
            ucAdoptedAnimal.btnViewAnimalUpdate.Click += (obj, arg) => ViewAnimalUpdate_MouseClick(animal.AnimalId);

            stackPanelAdoptedAnimal.Children.Add(ucAdoptedAnimal);
        }

        private void ViewAnimalUpdate_MouseClick(int animalId)
        {
            FosterPlacementRecord fosterPlacementRecord;

            try
            {
                fosterPlacementRecord = _masterManager.AnimalManager.RetriveFosterPlacementRecordNotes(animalId);
                PromptWindow.ShowPrompt("Animal Update", fosterPlacementRecord.FosterPlacementRecordNotes);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", "Can not get the data. \n\n" + ex.Message);
            }
        }

        private void ViewAnimalProfile_MouseClick(int animalId)
        {
            PromptWindow.ShowPrompt("Message", "Animal Profile");
            PetNetApp.Development.MainWindow window = 
                PetNetApp.Development.MainWindow.GetWindow(this) as PetNetApp.Development.MainWindow;
            AnimalsPage animalsPage = AnimalsPage.GetAnimalsPage();
            window.frameMain.Navigate(animalsPage);
            window.ChangeSelectedButton(window.btnAnimals);
            animalsPage.ChangeSelectedButton(animalsPage.btnAdopt);
            animalsPage.frameAnimals.Navigate(new ViewAdoptableAnimalProfile(animalId));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _animalList = _masterManager.AnimalManager.RetriveAdoptedAnimalByUserId(_userId);

                foreach (AnimalVM animal in _animalList)
                {
                    DisplayAdoptedAnimal(animal);
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", "Can not get the data. \n\n" + ex.Message);
            }
        }
    }
}
