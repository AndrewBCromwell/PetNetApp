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

namespace WpfPresentation.Animals.Medical
{
    /// <summary>
    /// Interaction logic for MedicalPage.xaml
    /// </summary>
    public partial class MedicalPage : Page
    {
        private static MedicalPage _existingMedicalPage = null;

        private MasterManager _manager = null;

        private AnimalManager _animalManager = null;
        private List<Animal> _animals = null;

        private Grid grid = null;

        public MedicalPage(MasterManager manager)
        {
            InitializeComponent();
            _animalManager = new AnimalManager();
            _manager = manager;
        }

        public static MedicalPage GetMedicalPage(MasterManager manager)
        {
            if (_existingMedicalPage == null)
            {
                _existingMedicalPage = new MedicalPage(manager);
            }
            return _existingMedicalPage;
        }


        private void pgMedicalAnimalsView_Loaded(object sender, RoutedEventArgs e)
        {
            wrpMedicalAnimalList.Children.Clear(); // this prevents getting dupe animals when loading page a second time
            try
            {
                _animals = _animalManager.RetrieveAllAnimals("");
                foreach (Animal animal in _animals)
                {
                    createAnimalBox(animal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
        private void createAnimalBox(Animal animal)
        {
            grid = new Grid();
            grid.Width = 250;
            grid.Height = 300;

            Border border = new Border();
            border.Margin = new Thickness(22, 22, 0, 0);
            border.CornerRadius = new CornerRadius(10);
            border.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF9EC1B0");

            Button button = new Button();
            button.VerticalAlignment = VerticalAlignment.Bottom;
            button.Margin = new Thickness(48, 42, 25, 25);
            button.Height = 50;

            Border imageBorder = new Border();
            imageBorder.CornerRadius = new CornerRadius(10);
            imageBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#5F987A");
            imageBorder.Margin = new Thickness(48, 42, 25, 85);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/WpfPresentation;component/Development/Images/sampleDogImage.png", UriKind.Relative)); // tempory placeholder image while the lack of an images relation to the animals table is determined
            image.Height = 175;
            image.Width = 175;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.Margin = new Thickness(55, 49, 32, 92);

            grid.Children.Add(border);
            grid.Children.Add(imageBorder);
            grid.Children.Add(image);
            grid.Children.Add(button);

            button.Content = animal.AnimalName;

            button.Click += (s, e) =>
            {
                int animalId = animal.AnimalId;


                // add window to be opened when clicking here, send the AnimalId and animalname or both.
                NavigationService.Navigate(new MedicalNavigationPage(_manager, animal));

                // MessageBox.Show(animalId.ToString()); // for testing purposes
            };

            wrpMedicalAnimalList.Children.Add(grid);
        }
        private void refreshListOfAnimals(String animalName)
        {
            try
            {
                _animals = _animalManager.RetrieveAllAnimals(animalName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

            wrpMedicalAnimalList.Children.Clear();

            foreach (Animal animal in _animals)
            {
                createAnimalBox(animal);
            }
        }

        private void txtSearchMedicalAnimals_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                refreshListOfAnimals(txtSearchMedicalAnimals.Text);
            }
        }
    }
}
