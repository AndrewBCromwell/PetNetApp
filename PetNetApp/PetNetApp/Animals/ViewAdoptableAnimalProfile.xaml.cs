using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for ViewAdoptableAnimalProfile.xaml
    /// </summary>
    public partial class ViewAdoptableAnimalProfile : Page
    {
        private int _animalId = 0;
        public AnimalVM animalVM = new AnimalVM();
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<string> imageFiles = new List<string>();
        private int curImageIdx = 0;

        public ViewAdoptableAnimalProfile(int animalId)
        {
            InitializeComponent();
            _animalId = animalId;
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// </summary>
        /// Method that display animal profile
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void DisplayAnimalProfile()
        {
            lblAnimalProfileName.Content = animalVM.AnimalName;
            lblAnimalBreed.Content = animalVM.AnimalBreedId;

            txtAnimalDescription.Text = animalVM.Description;
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// </summary>
        /// Method get the animal images
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void GetImageFile()
        {
            var files = Directory.GetFiles("../../Development/Animals/AnimalImages", "*.*", SearchOption.AllDirectories); 
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @"\.jpg$|\.png$|\.gif$"))
                    imageFiles.Add(filename);
                // Need a if statement to check the file name match with the animal image name when we have image table
            }
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// </summary>
        /// Method load the image to the image frame
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void LoadImage()
        {
            picAnimalImageList.Source = new BitmapImage(new Uri(imageFiles[curImageIdx], UriKind.Relative));
            LoadAnimalNote();
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// </summary>
        /// Method change the animal images to the previous one in the list
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if(curImageIdx > 0)
            {
                curImageIdx--;
                LoadImage();
            }
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// </summary>
        /// Method change the animal images to the next one in the list
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            if (curImageIdx < imageFiles.Count - 1)
            {
                curImageIdx++;
                LoadImage();
            }
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// </summary>
        /// Method load everything in the page when the page is loaded
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
            animalVM = _masterManager.AnimalManager.RetriveAnimalAdoptableProfile(_animalId);
            DisplayAnimalProfile();
            GetImageFile();
            LoadImage();
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/12
        /// 
        /// </summary>
        /// Button that save animal note to database
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPostComment_Click(object sender, RoutedEventArgs e)
        {
            SaveAnimalUpdateToDataBase();
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/12
        /// 
        /// </summary>
        /// Save the animal note to database
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void SaveAnimalUpdateToDataBase()
        {
            string animalRecordNotes = "";
            if (tbxAnimalPostUpdate.Text == "" || tbxAnimalPostUpdate.Text == null)
            {
                PromptWindow.ShowPrompt("Error", "Please enter your note first.");
            }
            else
            {
                animalRecordNotes = tbxAnimalPostUpdate.Text;
                PromptSelection dialogResult = PromptWindow.ShowPrompt("Animal Update Note", "Do you want to record this note?", ButtonMode.YesNo);
                if (dialogResult == PromptSelection.Yes)
                {
                    try
                    {
                        if (_masterManager.AnimalUpdatesManager.AddAnimalUpdatesByAnimalId(_animalId, animalRecordNotes))
                        {
                            PromptWindow.ShowPrompt("", "Update Note Success.");
                            tbxAnimalPostUpdate.Text = "Enter your note here.";
                            LoadAnimalNote();
                        }
                    }
                    catch (Exception ex)
                    {
                        PromptWindow.ShowPrompt("Error", "Failed to Update Note");
                    }
                }
                else
                {
                    PromptWindow.ShowPrompt("Cancel", "Cancel update animal post");
                    tbxAnimalPostUpdate.Text = "Enter your note here.";
                }
            }
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/12
        /// 
        /// </summary>
        /// Show the animal note
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private string LoadAnimalNote()
        {
            string result = "";

            try
            {
                result = _masterManager.AnimalUpdatesManager.RetrieveAnimalUpdatesByAnimal(_animalId);
                if (result != "")
                {
                    tbkAnimalNote.Text = result;
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
            }

            return result;
        }

        private void tbxAnimalPostUpdate_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SaveAnimalUpdateToDataBase();
            }
        }
    }
}
