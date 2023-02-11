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
using WpfPresentation.Animals.Medical;

namespace WpfPresentation.Development.Animals
{
    /// <summary>
    /// Interaction logic for AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        private static AnimalsPage _existingAnimalsPage = null;

        private MasterManager _manager = null;
        private Button[] _animalsTabButtons;

        private AnimalsPage(MasterManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _animalsTabButtons = new Button[] { btnAdopt, btnFoster, btnSurrender, btnAnimalList, btnMedical };
        }

        public static AnimalsPage GetAnimalsPage(MasterManager manager)
        {
            if (_existingAnimalsPage == null)
            {
                _existingAnimalsPage = new AnimalsPage(manager);
            }
            return _existingAnimalsPage;
        }

        private void ChangeSelectedButton(Button selectedButton)
        {
            UnselectAllButtons();
            selectedButton.Style = (Style)Application.Current.Resources["rsrcSelectedButton"];
        }

        private void UnselectAllButtons()
        {
            foreach (Button button in _animalsTabButtons)
            {
                button.Style = (Style)Application.Current.Resources["rsrcUnselectedButton"];
            }
        }

        private void btnAdopt_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(null);
        }

        private void btnFoster_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(null);
        }

        private void btnSurrender_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(null);
        }

        private void btnAnimalList_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);

            frameAnimals.Navigate(new MedicalNavigationPage(_manager, new Animal() { AnimalId = 100000, AnimalName="Stephen"}));
        }

        private void btnMedical_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedButton((Button)sender);
            // replace with page name and then delete comment
            frameAnimals.Navigate(MedicalPage.GetMedicalPage(_manager));
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
            }
            e.Handled = true;
        }
        private void UpdateScrollButtons()
        {
            if (svAnimalTabs.HorizontalOffset > svAnimalTabs.ScrollableWidth - 0.05)
            {
                btnScrollRight.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollRight.Visibility = Visibility.Visible;
            }

            if (svAnimalTabs.HorizontalOffset < 0.05)
            {
                btnScrollLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                btnScrollLeft.Visibility = Visibility.Visible;
            }
        }

        private void svAnimalTabs_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            UpdateScrollButtons();
        }

        private void btnScrollRight_Click(object sender, RoutedEventArgs e)
        {
            svAnimalTabs.ScrollToHorizontalOffset(svAnimalTabs.HorizontalOffset + 130);
        }

        private void btnScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            svAnimalTabs.ScrollToHorizontalOffset(svAnimalTabs.HorizontalOffset - 130);
        }
    }
}
