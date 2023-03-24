/// <summary>
/// Nathan Zumsande
/// Created: 2023/02/28
/// 
/// Presentation layer methods for the Shelter Network Page
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

namespace WpfPresentation.Shelters
{
    /// <summary>
    /// Interaction logic for ShelterNetworkPage.xaml
    /// </summary>
    public partial class ShelterNetworkPage : Page
    {
        private MasterManager _masterManger = null;
        private ShelterManager _shelterManager = null;
        private List<Shelter> _shelters = null;
        private static ShelterNetworkPage _page = null;

        public ShelterNetworkPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/02/07
        /// 
        /// Initalization of the Shelter Network Page 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="masterManager"></param>
        public ShelterNetworkPage(MasterManager masterManager)
        {
            _masterManger = masterManager;
            _shelterManager = new ShelterManager();
            InitializeComponent();
        }


        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/02/07
        /// 
        /// Static method that helps to call the initalization of the page
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="masterManager"></param>
        public static ShelterNetworkPage GetShelterNetworkPage(MasterManager manager)
        {
            if (_page == null)
            {
                _page = new ShelterNetworkPage(manager);
            }
            return _page;
        }

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/02/28
        /// Retrieves the shelters fro the database a populates the datagrid
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void refreshShelters()
        {
            try
            {
                _shelters = _shelterManager.GetShelterList();
                datShelter.ItemsSource = _shelters;
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Select Failed", "Failed to retrieve shelter data." + "\n" + ex.Message, ButtonMode.Ok);
            }
        }


        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/02/28
        /// Sets page when loaded
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShelterNetwork_Loaded(object sender, RoutedEventArgs e)
        {
            if (_shelters == null)
            {
                refreshShelters();
            }
        }


        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/02/28
        /// Opens a new Contact Page for the selected shelter
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            //PromptWindow.ShowPrompt("Todo", "Todo", ButtonMode.Ok);
            Shelter shelter = (Shelter)((Button)e.Source).DataContext;
            frameShelterNetwork.Navigate(new ContactPage(_masterManger, shelter));
        }

    }
}
