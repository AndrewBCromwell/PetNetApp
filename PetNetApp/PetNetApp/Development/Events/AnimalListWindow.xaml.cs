using DataObjects;
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

namespace WpfPresentation.Development.Events
{
    /// <summary>
    /// Interaction logic for AnimalListWindow.xaml
    /// </summary>
    public partial class AnimalListWindow : Window
    {
        private List<Animal> _animalList;
        private List<Animal> selectedAnimal;
        private Animal returnValue;

        public AnimalListWindow(List<Animal> animals)
        {
            InitializeComponent();
            _animalList = animals;
            returnValue = null;
        }

        public Animal GetReturnValuen()
        {
            return returnValue;
        }

        private void btnCanle_Click(object sender, RoutedEventArgs e)
        {
            returnValue = null;
            this.DialogResult = false;
        }

        private void DisplayAnimal(Animal animal)
        {
            UCAnimalCanTakeToEvent ucAnimal = new UCAnimalCanTakeToEvent();
            ucAnimal.lblAnimalName.Content = animal.AnimalName;
            ucAnimal.btnAdd.Click += (obj, arg) => BtnAdd_Click(animal);
            ucAnimal.btnView.Click += (obj, arg) => BtnView_Click(animal);
            ucAnimal.Margin = new Thickness(0, 0, 10, 0);
            stpAnimalList.Children.Add(ucAnimal);
        }

        private void BtnView_Click(Animal animal)
        {
            PromptWindow.ShowPrompt("Animal Detail", "Name: " + animal.AnimalName + "\n\n"
                + "Type: " + animal.AnimalTypeId + "\n\n" + "Breed: " + animal.AnimalBreedId);
        }

        private void BtnAdd_Click(Animal animal)
        {
            returnValue = animal;
            this.DialogResult = false;
        }

        private void PopulateAnimals()
        {
            stpAnimalList.Children.Clear();
            foreach (Animal animal in selectedAnimal)
            {
                DisplayAnimal(animal);
            }
        }

        private Animal GetReturnValue()
        {
            return returnValue;
        }

        private void AnimalSearching()
        {
            selectedAnimal = new List<Animal>();
            if (txtSearchAnimal.Text == "")
            {
                foreach (Animal animal in _animalList)
                {
                    selectedAnimal.Add(animal);
                }
            }
            else
            {
                foreach (Animal animal in _animalList)
                {
                    if (animal.AnimalName.ToLower().Contains(txtSearchAnimal.Text.ToLower()))
                    {
                        selectedAnimal.Add(animal);
                    }
                }
            }
            PopulateAnimals();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AnimalSearching();
        }

        private void txtSearchAnimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            AnimalSearching();
        }
    }
}
