/// <summary>
/// Brian Collum
/// Created: 2023/03/06
/// 
/// This is the base UI for the Library, which represents the PetNet-wide library of inventory items that exist, and their tags
/// 
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

using LogicLayer;
using LogicLayerInterfaces;
using DataObjects;

namespace WpfPresentation.Development.Management.Library
{
    public partial class LibraryUI : Page
    {
        private static LibraryUI _existingLibraryUI = null;
        private MasterManager _masterManager = null;
        private LibraryManager _libraryManager = null;

        private List<Item> _libraryItemList = null;

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Constructor for the ShelterVM List UI
        /// </summary>
        /// <param name="manager">The MasterManager from the parent UI</param>
        public LibraryUI(MasterManager manager)
        {
            InitializeComponent();
            _masterManager = manager;
            _libraryManager = new LibraryManager();
        }
        public static LibraryUI GetLibraryUI(MasterManager manager)
        {
            if (_existingLibraryUI == null)
            {
                _existingLibraryUI = new LibraryUI(manager);
            }
            return _existingLibraryUI;
        }

        public LibraryUI()
        {
            InitializeComponent();
        }
        private void refreshLibraryList()
        {
            _libraryItemList = _libraryManager.GetLibraryItemList();
            datLibraryInventory.ItemsSource = _libraryItemList;
        }

        private void btnLibraryHelp_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("What is this page for?", "PetNet Inventory Library" +
                "\n\nThis is a library of all inventory items in the PetNet Database." +
                "\n\nA PetNet Administrator can add new items to the database." +
                "\n\nA Shelter worker with inventory management privileges may populate their shelter inventory by adding items off of this list." +
                "\n\nIf you manage a shelter's inventory and you need an item added to this list, please use the 'Request a New Item' button, and a PetNet Administrator will review your request.");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_libraryItemList == null)
            {
                refreshLibraryList();
            }
        }
    }
}
