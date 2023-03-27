/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Page containing a list of all items in a shelter
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
using DataObjects;

namespace WpfPresentation.Management.Inventory
{
    /// <summary>
    /// Interaction logic for ViewShelterInventoryPage.xaml
    /// </summary>
    public partial class ViewShelterInventoryPage : Page
    {
        MasterManager _masterManager = MasterManager.GetMasterManager();
        List<ShelterInventoryItemVM> _shelterInventoryItemVMList = null;
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// </summary>
        public ViewShelterInventoryPage()
        {



            InitializeComponent();

        }
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// Sets up datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {



            try
            {
                cboShelter.ItemsSource = _masterManager.ShelterManager.GetShelterList().OrderBy(shelter => shelter.ShelterName);
            }
            catch (Exception)
            {

                PromptWindow.ShowPrompt("Missing Data", "Failed to retrieve shelter list");
                return;
            }

            cboShelter.DisplayMemberPath = "ShelterName";
            Users user;
            try
            {
                user = _masterManager.UsersManager.RetrieveUserByUsersId(MasterManager.GetMasterManager().User.UsersId);
            }
            catch (Exception)
            {
                PromptWindow.ShowPrompt("Missing Data", "Failed to retrieve user's shelter ID");
                return;

            }

            int? shelterId = user.ShelterId;

            if (shelterId != null)
            {
                try
                {
                    cboShelter.SelectedItem = _masterManager.ShelterManager.RetrieveShelterVMByShelterID((int)shelterId);
                }
                catch (Exception)
                {

                    PromptWindow.ShowPrompt("Missing Data", "Failed to retrieve shelter");
                    return;
                }

                try
                {
                    _shelterInventoryItemVMList = _masterManager.ShelterInventoryItemManager.RetrieveInventoryByShelterId((int)shelterId);
                }
                catch (Exception)
                {

                    PromptWindow.ShowPrompt("Missing Data", "Failed to retrieve shelter inventory");
                    return;
                }





                try
                {
                    UpdateFlags();
                    datShelterInventory.ItemsSource = _shelterInventoryItemVMList;

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

        }

        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Populates the flags colum
        /// </summary>
        private void UpdateFlags()
        {

            List<ShelterInventoryItemVM> shelterItems = _shelterInventoryItemVMList;

            //Creates a list of flags in string form
            foreach (ShelterInventoryItemVM shelter in shelterItems)
            {
                List<string> Flags = new List<string>(); //used to collect all flags for a shelter item
                string flagsList = ""; //used later for formating the flags
                if (shelter.InTransit)
                {
                    Flags.Add("In Transit");
                }
                if (shelter.Urgent)
                {
                    Flags.Add("Urgent");
                }
                if (shelter.Processing)
                {
                    Flags.Add("Processing");
                }
                if (shelter.DoNotOrder)
                {
                    Flags.Add("Do Not Order");
                }
                if (shelter.CustomFlag != "")
                {
                    Flags.Add(shelter.CustomFlag);
                }

                //Formating
                for (int i = 0; i < Flags.Count; i++)
                {
                    flagsList += " " + Flags[i];

                    if (i == Flags.Count - 2)
                    {
                        if (Flags.Count > 2)
                        {
                            flagsList += ",";
                        }
                        flagsList += " and";
                    }
                    else if (i < Flags.Count - 2)
                    {
                        flagsList += ",";
                    }
                }
                shelter.DisplayFlags = flagsList; //Using the CustomFlag property as a way to show all flags



            }

        }
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Populates datagrid once the combobox closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboShelter_DropDownClosed(object sender, EventArgs e)
        {
            ShelterVM selectedShelter;
            if (cboShelter.SelectedItem != null)
            {
                selectedShelter = (ShelterVM)cboShelter.SelectedItem;

                try
                {
                    _shelterInventoryItemVMList = _masterManager.ShelterInventoryItemManager.RetrieveInventoryByShelterId(selectedShelter.ShelterId);
                }
                catch (Exception)
                {

                    PromptWindow.ShowPrompt("Missing Data", "Failed to retrieve shelter inventory");
                    return;
                }


                UpdateFlags();
                datShelterInventory.ItemsSource = _shelterInventoryItemVMList;

            }



        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/03/19
        /// 
        /// Directs user to the viewedit page for the inventory item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datShelterInventory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (datShelterInventory.SelectedItem != null)
            {
                var selectedShelterItem = (ShelterInventoryItemVM)datShelterInventory.SelectedItem;
                NavigationService.Navigate(new ViewEditShelterInventoryItem(selectedShelterItem));
            }

        }
    }
}
