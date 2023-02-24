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

namespace WpfPresentation.Animals
{
    /// <summary>
    /// Interaction logic for UploadAdditionalFileWindow.xaml
    /// </summary>
    public partial class UploadAdditionalFileWindow : Window
    {
        private Animal _animal = null;
        private MasterManager _manager = MasterManager.GetMasterManager();

        public UploadAdditionalFileWindow(Animal animal, MasterManager masterManager)
        {
            _animal = animal;
            _manager = masterManager;
            InitializeComponent();
        }

        private void btnBrowseFiles_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog _fileDialog = new Microsoft.Win32.OpenFileDialog();

            //_fileDialog.DefaultExt = ".png";
            _fileDialog.Filter = "JPG (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";

            bool? result = _fileDialog.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = _fileDialog.SafeFileName;
                txtFileUpload.Text = filename;
            }
        }

        private void btnCancelUpload_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = txtFileUpload.Text;
            if(fileName == "")
            {
                PromptWindow.ShowPrompt("Error", "You must select a file to upload.");
                return;
            }

            try
            {
                if (_manager.ImagesManager.AddMedicalImageByAnimalId(_animal.AnimalId, fileName))
                {
                    PromptWindow.ShowPrompt("Success", "Image added!");
                    this.Close();
                }
                else
                {
                    PromptWindow.ShowPrompt("Error", "Image failed to add.");
                }
            }
            catch (Exception up)
            {
                PromptWindow.ShowPrompt("Error", "Image add failed. \n\n" + up.InnerException.Message);
            }
        }
    }
}
