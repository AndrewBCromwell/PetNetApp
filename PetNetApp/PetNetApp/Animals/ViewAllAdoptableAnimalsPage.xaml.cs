/// <summary>
/// Andrew Schneider
/// Created: 2023/04/12
/// 
/// Interaction logic for ViewAllAdoptableAnimalsPage.xaml
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

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
using WpfPresentation.UserControls;

namespace WpfPresentation.Animals
{
    public partial class ViewAllAdoptableAnimalsPage : Page
    {
        private static ViewAllAdoptableAnimalsPage _existingViewAllAdoptableAnimalsPage = null;
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<AnimalVM> _adoptableAnimals = null;
        private List<AnimalVM> _filteredAnimals = new List<AnimalVM>();

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/12
        /// 
        /// Public constructor for ViewAllAdoptableAnimalsPage
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private ViewAllAdoptableAnimalsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/12
        /// 
        /// Gets the existing ViewAllAdoptableAnimalsPage or creates a
        /// new one if it doesn't exist. Refreshes data but maintains page
        /// </summary>
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public static ViewAllAdoptableAnimalsPage GetViewAllAdoptableAnimalsPage()
        {
            if (_existingViewAllAdoptableAnimalsPage == null)
            {
                _existingViewAllAdoptableAnimalsPage = new ViewAllAdoptableAnimalsPage();
            }

            return _existingViewAllAdoptableAnimalsPage;
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/12
        /// 
        /// Window loaded method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _adoptableAnimals = _masterManager.AnimalManager.RetrieveAllAdoptableAnimals();
                DisplayUserControls();
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message + "\n\n" + ex.InnerException, ButtonMode.Ok);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/12
        /// 
        /// Method to create, populate, and display adoptable animal user controls. If
        /// there are no animals in the system a message is displayed informing the user.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void DisplayUserControls()
        {
            if (_adoptableAnimals.Count == 0)
            {
                nothingToShowMessage.Visibility = Visibility.Visible;
            }
            else
            {
                nothingToShowMessage.Visibility = Visibility.Collapsed;

                for (int i = 0; i < _adoptableAnimals.Count / 4; i++)
                {
                    grdAdoptableAnimalsList.RowDefinitions.Add(new RowDefinition());
                }

                for (int i = 0; i < _adoptableAnimals.Count; i++)
                {
                    int j = i;
                    AdoptableAnimalListUserControl adoptableAnimalListUserControl =
                        new AdoptableAnimalListUserControl(_adoptableAnimals[j]);

                    adoptableAnimalListUserControl.imgAdoptableAnimalDisplay.Source = RetrieveImageForUserControl(_adoptableAnimals[i].AnimalId);
                    adoptableAnimalListUserControl.lblAnimalName.Content = _adoptableAnimals[j].AnimalName;
                    adoptableAnimalListUserControl.lblAnimalInfo.Content
                        = _adoptableAnimals[j].AnimalBreedId + GetShelterName(_adoptableAnimals[j].AnimalShelterId);

                    Grid.SetRow(adoptableAnimalListUserControl, i / 4);
                    Grid.SetColumn(adoptableAnimalListUserControl, i % 4);
                    grdAdoptableAnimalsList.Children.Add(adoptableAnimalListUserControl);
                }
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/13
        /// 
        /// Helper method for populating the animal image on the user control. If an error occurs
        /// BrokenImage.png is displayed. Is no image is available no_image.png is displayed.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="animalId">Id of the animal</param>
        /// <returns>A BitmapImage</returns>
        public BitmapImage RetrieveImageForUserControl(int animalId)
        {
            List<Images> imagesList = null;
            if (imagesList == null || imagesList.Count == 0)
            {
                try
                {
                    imagesList = _masterManager.ImagesManager.RetrieveAnimalImagesByAnimalId(animalId);
                }
                catch
                {
                    BitmapImage brokenImage = new BitmapImage(new Uri("..\\Images\\BrokenImage.png", UriKind.Relative));
                    return brokenImage;
                }
            }

            if (imagesList.Count == 0)
            {
                BitmapImage brokenImage = new BitmapImage(new Uri("..\\Images\\no_image.png", UriKind.Relative));
                return brokenImage;
            }
            else
            {
                try
                {
                    return _masterManager.ImagesManager.RetrieveImageByImages(imagesList[0]);
                }
                catch
                {
                    BitmapImage brokenImage = new BitmapImage(new Uri("..\\Images\\BrokenImage.png", UriKind.Relative));
                    return brokenImage;
                }
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/12
        /// 
        /// Helper method for getting the shelter name from the database using the shelter Id
        /// on the AnimalVM object. If the retrieval is successful " | " is prepended to the
        /// name, otherwise the name is an empty string.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="shelterId">The Id of the shelter</param>
        /// <exception cref="Exception">Retrieve shelter object fails</exception>
        /// <returns>Shelter name</returns>
        private string GetShelterName(int shelterId)
        {
            string shelterName;
            try
            {
                shelterName = " | " + _masterManager.ShelterManager.RetrieveShelterVMByShelterID(shelterId).ShelterName;
            }
            catch
            {
                shelterName = "";
            }
            return shelterName;
        }
    }
}
