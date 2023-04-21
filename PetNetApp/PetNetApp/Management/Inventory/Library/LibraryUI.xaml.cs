/// <summary>
/// Brian Collum
/// Created: 2023/03/06
/// 
/// This is the base UI for the Library, which represents the PetNet-wide library of inventory items that exist, and their tags
/// 
/// </summary>
///
/// <remarks>
/// Brian Collum
/// Updated: 2023/04/07
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

namespace WpfPresentation.Management.Inventory.Library
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
        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/24
        /// Refresh the list of library items by loading them from the database
        /// </summary>
        public void refreshLibraryList()
        {
            try
            {
                _libraryItemList = _libraryManager.GetLibraryItemList();
                datLibraryInventory.ItemsSource = _libraryItemList;
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", "Failed to retrieve list of library items " + ex.InnerException.Message, ButtonMode.Ok);
            }
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/24
        /// Displays an explanation of what this UI is for
        /// </summary>
        private void btnLibraryHelp_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("What is this page for?", "PetNet Inventory Library" +
                "\n\nThis is a library of all inventory items in the PetNet Database." +
                "\n\nA PetNet Administrator can add new items to the database." +
                "\n\nA Shelter worker with inventory management privileges may populate their shelter inventory by adding items off of this list." +
                "\n\nIf you manage a shelter's inventory and you need an item added to this list, please use the 'Request a New Item' button, and a PetNet Administrator will review your request.");
        }

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/24
        /// Refresh the list of library items on page load
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_libraryItemList == null)
            {
                refreshLibraryList();
            }
        }

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/04/06
        /// Navigates to the AddResourceItemPage
        /// </summary>
        private void btnAddLibraryItem_Click(object sender, RoutedEventArgs e)
        {
            frmLibrary.Navigate(new AddResourceItemPage(_masterManager.ItemManager, this));
        }

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/04/06
        /// Navigates to the EditResourceItemPage
        /// </summary>
        private void btnEditLibraryItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Item) datLibraryInventory.SelectedItem;
            if(selectedItem == null)
            {
                PromptWindow.ShowPrompt("Error", "Please select an item to edit from the list to edit.", ButtonMode.Ok);
            }
            else
            {
                frmLibrary.Navigate(new AddResourceItemPage(_masterManager.ItemManager, selectedItem, this));
            }
        }

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/04/06
        /// Navigates to the AddCategoryTagPage
        /// </summary>
        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            frmLibrary.Navigate(new AddCategoryTagPage(_masterManager, this));
        }
        /// <summary>
        /// Brian Collum
        /// Created: 2023/04/07
        /// Adds the selected Library item to the currently selected shelter's inventory
        /// </summary>
        private void btnAddToShelterInventory_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Item)datLibraryInventory.SelectedItem;
            var currentShelter = _masterManager.User.ShelterId;
            if (currentShelter != null)
            {
                if (selectedItem == null)
                {
                    PromptWindow.ShowPrompt("Error", "Please select an item from the list to add to your shelter.", ButtonMode.Ok);
                }
                else
                {
                    try
                    {
                        PromptSelection result = PromptWindow.ShowPrompt("Add Item?", "Do you want to add this item to Shelter " + currentShelter, ButtonMode.YesNo);
                        if (result == PromptSelection.Yes)
                        {
                            if(_masterManager.ShelterInventoryItemManager.AddToShelterInventory((int)currentShelter, selectedItem.ItemId))
                            {
                                PromptWindow.ShowPrompt("Item Added", "Added " + selectedItem.ItemId + " to " + currentShelter, ButtonMode.Ok);
                            }
                            else
                            {
                                PromptWindow.ShowPrompt("Item visible", selectedItem.ItemId + " is active in " + currentShelter, ButtonMode.Ok);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        PromptWindow.ShowPrompt("Error", "Failed to add that item to your shelter.", ButtonMode.Ok);
                    }
                }
            }
            else
            {
                PromptWindow.ShowPrompt("Error", "You must have a shelter associated with your account in order to use this feature.", ButtonMode.Ok);
            }
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/04/20
        /// Opens the page where the user can request for a new item to be added to the library
        /// </summary>
        private void btnRequestLibraryAddition_Click(object sender, RoutedEventArgs e)
        {
            frmLibrary.Navigate(new RequestNewLibraryItem(_masterManager));
        }
    }
}
