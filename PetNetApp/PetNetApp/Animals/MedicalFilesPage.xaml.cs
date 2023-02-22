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
    /// Interaction logic for MedicalFilesPage.xaml
    /// </summary>
    public partial class MedicalFilesPage : Page
    {
        private Animal _animal = null;
        private List<Images> _imagesList;
        private MasterManager _manager = MasterManager.GetMasterManager();


        public MedicalFilesPage(Animal animal, MasterManager masterManager)
        {
            _animal = animal;
            _manager = masterManager;
            InitializeComponent();
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            PopulatePage();
            
        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            var uploadAdditionalFileWindow = new UploadAdditionalFileWindow(_animal, _manager);
            uploadAdditionalFileWindow.Owner = Window.GetWindow(this);
            uploadAdditionalFileWindow.ShowDialog();
            NavigationService.Navigate(new MedicalFilesPage(_animal, _manager));
            
            
            
        }

        private void PopulatePage()
        {
            if (_imagesList == null || _imagesList.Count == 0)
            {
                try
                {
                    lblNoFiles.Visibility = Visibility.Hidden;
                    _imagesList = _manager.ImagesManager.RetrieveImagesByAnimalId(_animal.AnimalId);
                    datAdditionalFiles.ItemsSource = _imagesList;
                    datAdditionalFiles.Columns[0].Header = "Image ID";
                    datAdditionalFiles.Columns[1].Header = "Image File Name";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }
    }
}
