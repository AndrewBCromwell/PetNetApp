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
using WpfPresentation.Fundraising;
using WpfPresentation.UserControls;

namespace WpfPresentation.Development.Fundraising
{
    /// <summary>
    /// Interaction logic for AddEditFundraisingEventPage.xaml
    /// </summary>
    public partial class AddEditViewUpdateFundraisingEventPage : Page
    {
        private static AddEditViewUpdateFundraisingEventPage _existingAddEditViewUpdateFundraisingEventPage = null;

        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private PageMode _pageMode;
        private static decimal _amtRaised = 0.00m;

        private FundraisingEventVM _oldFundraisingEventVM = null;

        public FundraisingEventVM FundraisingEvent
        {
            get { return (FundraisingEventVM)GetValue(FundraisingEventProperty); }
            set { SetValue(FundraisingEventProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FundraisingEvent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FundraisingEventProperty =
            DependencyProperty.Register("FundraisingEvent", typeof(FundraisingEventVM), typeof(AddEditViewUpdateFundraisingEventPage), new PropertyMetadata(null));



        public AddEditViewUpdateFundraisingEventPage()
        {
            DataContext = this;
            //_pageMode = PageMode.New;
            InitializeComponent();
        }
        public AddEditViewUpdateFundraisingEventPage(FundraisingEventVM fundraisingEvent)
        {
            setupViewFundraisingEvent(fundraisingEvent);

        }


        /// <summary>
        /// Barry Mikulas
        /// Created 2023/03/05
        /// </summary>
        /// <param name="fundraisingEvent">The fundraising campaign to view</param>
        /// <returns>a new or existing fundraising campaign page set up to view the event</returns>
        public static AddEditViewUpdateFundraisingEventPage GetViewFundraisingEventPage(FundraisingEventVM fundraisingEvent)
        {
            try
            {
                GetSponsorsContactsHostPets(fundraisingEvent);
                //TODO: get pet list
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
                return null;
            }
            if (_existingAddEditViewUpdateFundraisingEventPage == null)
            {
                _existingAddEditViewUpdateFundraisingEventPage = new AddEditViewUpdateFundraisingEventPage();
            }
            _existingAddEditViewUpdateFundraisingEventPage.setupViewFundraisingEvent(fundraisingEvent);


            return _existingAddEditViewUpdateFundraisingEventPage;
        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/14
        /// 
        /// Update mode only allows changes to all but Event Cost, Number of Attendees, Number of Animals Adopted. These are changed through update.
        /// </summary>
        /// <param name="fundraisingEvent">The fundraising event to edit</param>
        /// <returns>New or exisiting fundraising event set up to edit the event</returns>
        public static AddEditViewUpdateFundraisingEventPage GetEditFundraisingEventPage(FundraisingEventVM fundraisingEvent)
        {
            try
            {
                GetSponsorsContactsHostPets(fundraisingEvent);
                // get pet list

            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
                return null;
            }
            if (_existingAddEditViewUpdateFundraisingEventPage == null)
            {
                _existingAddEditViewUpdateFundraisingEventPage = new AddEditViewUpdateFundraisingEventPage();
            }
            _existingAddEditViewUpdateFundraisingEventPage.setupEditFundraisingEvent(fundraisingEvent);


            return _existingAddEditViewUpdateFundraisingEventPage;
        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/14
        /// 
        /// Update mode only allows changes to  Notes, Event Cost, Number of Attendees, Number of Animals Adopted
        /// </summary>
        /// <param name="fundraisingEvent">The fundraising event to update</param>
        /// <returns>New or exisiting fundraising event set up to update the event</returns>
        public static AddEditViewUpdateFundraisingEventPage GetUpdateFundraisingEventPage(FundraisingEventVM fundraisingEvent)
        {
            try
            {
                GetSponsorsContactsHostPets(fundraisingEvent);
                // get pet list
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
                return null;
            }
            if (_existingAddEditViewUpdateFundraisingEventPage == null)
            {
                _existingAddEditViewUpdateFundraisingEventPage = new AddEditViewUpdateFundraisingEventPage();
            }
            _existingAddEditViewUpdateFundraisingEventPage.setupUpdateFundraisingEvent(fundraisingEvent);


            return _existingAddEditViewUpdateFundraisingEventPage;
        }

        private static void GetSponsorsContactsHostPets(FundraisingEventVM fundraisingEvent)
        {
            // get sponsors
            fundraisingEvent.Sponsors = MasterManager.GetMasterManager().InstitutionalEntityManager.RetrieveFundraisingInstitutionalEntitiesByEventIdAndContactType(fundraisingEvent.FundraisingEventId, "Sponsor");
            // get contacts
            fundraisingEvent.Contacts = MasterManager.GetMasterManager().InstitutionalEntityManager.RetrieveFundraisingInstitutionalEntitiesByEventIdAndContactType(fundraisingEvent.FundraisingEventId, "Contact");
            // get host
            fundraisingEvent.Host = MasterManager.GetMasterManager().InstitutionalEntityManager.RetrieveInstitutionalEntityByEventIdAndContactType(fundraisingEvent.FundraisingEventId, "Host");
            if (fundraisingEvent.Host == null || fundraisingEvent.Host.InstitutionalEntityId == 0)
            {
                fundraisingEvent.Host = new InstitutionalEntity()
                {
                    Address = "Host needs to be added.",
                    CompanyName = "Host needs to be added."
                };
            }
            // get campaign
            if (fundraisingEvent.CampaignId != null)
            {
                fundraisingEvent.Campaign = MasterManager.GetMasterManager().FundraisingCampaignManager.RetrieveFundraisingCampaignByFundraisingCampaignId((int)fundraisingEvent.CampaignId);
            }
            else
            {
                fundraisingEvent.Campaign = new FundraisingCampaignVM();
                fundraisingEvent.Campaign.Title = "Campaign needs to be added.";
            }
            // get animals for the event
            fundraisingEvent.Animals = MasterManager.GetMasterManager().AnimalManager.RetrieveAnimalsByFundrasingEventId((int)fundraisingEvent.FundraisingEventId);

            // get donations for the event
            _amtRaised = MasterManager.GetMasterManager().DonationManager.RetrieveSumDonationsByEventId((int)fundraisingEvent.FundraisingEventId);
        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/14
        /// </summary>
        /// <returns>An empty page to create a new fundraising event</returns>
        public static AddEditViewUpdateFundraisingEventPage GetAddFundraisingEventPage()
        {
            if (_existingAddEditViewUpdateFundraisingEventPage == null)
            {
                _existingAddEditViewUpdateFundraisingEventPage = new AddEditViewUpdateFundraisingEventPage();
            }
            _existingAddEditViewUpdateFundraisingEventPage.setupNewFundraisingEvent();
            return _existingAddEditViewUpdateFundraisingEventPage;
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //PromptWindow.ShowPrompt("Edit", "Edit Clicked");
            setupEditFundraisingEvent(FundraisingEvent);
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            setupUpdateFundraisingEvent(FundraisingEvent);
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewFundraisingEventsPage.GetViewFundraisingEvents());
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            switch (_pageMode)
            {
                case PageMode.New:
                    NavigationService.Navigate(ViewFundraisingEventsPage.GetViewFundraisingEvents());
                    break;
                case PageMode.Edit:
                    setupViewFundraisingEvent(_oldFundraisingEventVM);
                    break;
                case PageMode.Update:
                    setupViewFundraisingEvent(_oldFundraisingEventVM);
                    break;
                default:
                    break;
            }

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Not Implemented", "Save feature is not implemented.");
        }

        private void btnAddHost_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Add Host", "Add Host Not implemented");
        }
        private void btnAddCampaign_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Add Campaign", "Add Campaign Not implemented");
        }
        private void btnAddSponsors_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Not Implemented", "Add sponsor is not fully implemented.");
            // return;
            AddFundraisingCampaignSponsorsWindow addFundraisingCampaignSponsorsWindow = new AddFundraisingCampaignSponsorsWindow(FundraisingEvent.Sponsors, "Sponsor");
            addFundraisingCampaignSponsorsWindow.Owner = Window.GetWindow(this);
            addFundraisingCampaignSponsorsWindow.ShowDialog();
            ClearAndPopulateContactType("Sponsor");

        }
        private void btnAddContacts_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Not Implemented", "Add contact is not fully implemented.");
            //return;
            AddFundraisingCampaignSponsorsWindow addFundraisingCampaignSponsorsWindow = new AddFundraisingCampaignSponsorsWindow(FundraisingEvent.Contacts, "Contact");
            addFundraisingCampaignSponsorsWindow.Owner = Window.GetWindow(this);
            addFundraisingCampaignSponsorsWindow.ShowDialog();
            ClearAndPopulateContactType("Contact");

        }
        private void btnAddPet_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow.ShowPrompt("Not Implemented", "Add pet is not implemented.");

        }



        private void setupNewFundraisingEvent()
        {
            _pageMode = PageMode.New;
            lblHeader.Content = "New Fundraising Event";
            FundraisingEvent = new FundraisingEventVM()
            {
                UsersId = _masterManager.User.UsersId,
                ShelterId = _masterManager.User.ShelterId.Value,
                Sponsors = new List<InstitutionalEntity>(),
                Contacts = new List<InstitutionalEntity>(),
                Host = new InstitutionalEntity(),
                Hidden = false,
                Complete = false,
                Cost = 0m,
                NumOfAttendees = 0,
                NumAnimalsAdopted = 0
            };
            tbAmountRaised.Text = "TBD";
            AddEditMode();
            SaveCloseButtonsEnabled();
        }
        private void setupViewFundraisingEvent(FundraisingEventVM fundraisingEvent)
        {
            _pageMode = PageMode.View;
            lblHeader.Content = "View Fundraising Event #" + fundraisingEvent.FundraisingEventId;
            FundraisingEvent = fundraisingEvent;
            datPets.ItemsSource = fundraisingEvent.Animals;
            tbAmountRaised.Text = _amtRaised == 0.00m ? "N\\A" : _amtRaised.ToString("c");
            ViewMode();
            EditUpdateDeleteButtonsEnabled();
            ClearAndPopulateContactType("Sponsor");
            ClearAndPopulateContactType("Contact");
            //add pets
        }
        private void setupEditFundraisingEvent(FundraisingEventVM fundraisingEvent)
        {
            _pageMode = PageMode.Edit;
            lblHeader.Content = "Edit Fundraising Event #" + fundraisingEvent.FundraisingEventId;
            FundraisingEvent = fundraisingEvent.Copy();
            _oldFundraisingEventVM = fundraisingEvent;
            datPets.ItemsSource = fundraisingEvent.Animals;
            tbAmountRaised.Text = _amtRaised == 0.00m ? "N\\A" : _amtRaised.ToString("c");
            AddEditMode();
            SaveCloseButtonsEnabled();
            ClearAndPopulateContactType("Sponsor");
            ClearAndPopulateContactType("Contact");
            //add pets
        }
        private void setupUpdateFundraisingEvent(FundraisingEventVM fundraisingEvent)
        {
            _pageMode = PageMode.Update;
            lblHeader.Content = "Update Fundraising Event #" + fundraisingEvent.FundraisingEventId;
            FundraisingEvent = fundraisingEvent.Copy();
            _oldFundraisingEventVM = fundraisingEvent;
            datPets.ItemsSource = fundraisingEvent.Animals;
            tbAmountRaised.Text = _amtRaised == 0.00m ? "N\\A" : _amtRaised.ToString("c");
            UpdateMode();
            SaveCloseButtonsEnabled();
            ClearAndPopulateContactType("Sponsor");
            ClearAndPopulateContactType("Contact");
            //add pets
        }

        private void ClearAndPopulateContactType(string contactType)
        {
            switch (contactType)
            {
                case "Sponsor":
                    stackSponsors.Children.Clear();
                    foreach (var sponsor in FundraisingEvent.Sponsors)
                    {
                        var sponsorControl = new InstitutionalEntityUserControl(sponsor, !(_pageMode != PageMode.Edit), false);
                        sponsorControl.btnRemove.Click += (sender, args) => btnRemoveSponsor_Click(sender, args, sponsor);
                        stackSponsors.Children.Add(sponsorControl);
                    }
                    break;
                case "Contact":
                    stackContacts.Children.Clear();
                    foreach (var contact in FundraisingEvent.Contacts)
                    {
                        var sponsorControl = new InstitutionalEntityUserControl(contact, !(_pageMode != PageMode.Edit), false);
                        sponsorControl.btnRemove.Click += (sender, args) => btnRemoveContact_Click(sender, args, contact);
                        stackContacts.Children.Add(sponsorControl);
                    }
                    break;
                default:
                    break;
            }
        }
        private void btnRemoveSponsor_Click(object sender, RoutedEventArgs args, InstitutionalEntity institutionalEntity)
        {
            FundraisingEvent.Sponsors.Remove(institutionalEntity);
            ClearAndPopulateContactType("Sponsor"); ;
        }
        private void btnRemoveContact_Click(object sender, RoutedEventArgs args, InstitutionalEntity institutionalEntity)
        {
            FundraisingEvent.Contacts.Remove(institutionalEntity);
            ClearAndPopulateContactType("Contact"); ;
        }


        private void ViewMode()
        {
            tbEventTitle.IsEnabled = false;
            tbHost.IsEnabled = false;
            tbCampaign.IsEnabled = false;
            btnAddCampaign.IsEnabled = false;
            btnAddCampaign.Visibility = Visibility.Collapsed;
            btnAddHost.IsEnabled = false;
            btnAddHost.Visibility = Visibility.Collapsed;
            tbAddress.IsEnabled = false;
            dpStartTime.IsEnabled = false;
            dpEndTime.IsEnabled = false;
            tbDescription.IsEnabled = false;
            tbNotes.IsEnabled = false;
            tbAmountRaised.IsEnabled = false;
            tbEventCost.IsEnabled = false;
            tbNumAttendees.IsEnabled = false;
            tbNumAnimalsAdopted.IsEnabled = false;
            btnAddContacts.IsEnabled = false;
            btnAddPet.IsEnabled = false;
            btnAddSponsors.IsEnabled = false;
            lblHeader.Focus();
        }
        private void AddEditMode()
        {
            tbEventTitle.IsEnabled = true;
            tbHost.IsEnabled = false;
            tbCampaign.IsEnabled = false;
            btnAddCampaign.IsEnabled = true;
            btnAddCampaign.Visibility = Visibility.Visible;
            btnAddHost.IsEnabled = true;
            btnAddHost.Visibility = Visibility.Visible;
            tbAddress.IsEnabled = false;
            dpStartTime.IsEnabled = true;
            dpEndTime.IsEnabled = true;
            tbDescription.IsEnabled = true;
            tbNotes.IsEnabled = true;
            tbAmountRaised.IsEnabled = false;
            tbEventCost.IsEnabled = false;
            tbNumAttendees.IsEnabled = false;
            tbNumAnimalsAdopted.IsEnabled = false;
            btnAddContacts.IsEnabled = true;
            btnAddPet.IsEnabled = true;
            btnAddSponsors.IsEnabled = true;
            btnAddContacts.Visibility = Visibility.Visible;
            btnAddPet.Visibility = Visibility.Visible;
            btnAddSponsors.Visibility = Visibility.Visible;
            tbEventTitle.Focus();
            tbEventTitle.SelectAll();
        }
        private void UpdateMode()
        {
            tbEventTitle.IsEnabled = false;
            tbHost.IsEnabled = false;
            tbCampaign.IsEnabled = false;
            btnAddCampaign.IsEnabled = false;
            btnAddCampaign.Visibility = Visibility.Collapsed;
            btnAddHost.IsEnabled = false;
            btnAddHost.Visibility = Visibility.Collapsed;
            tbAddress.IsEnabled = false;
            dpStartTime.IsEnabled = false;
            dpEndTime.IsEnabled = false;
            tbDescription.IsEnabled = false;
            tbNotes.IsEnabled = true;
            tbAmountRaised.IsEnabled = false;
            tbEventCost.IsEnabled = true;
            tbNumAttendees.IsEnabled = true;
            tbNumAnimalsAdopted.IsEnabled = true;
            btnAddContacts.IsEnabled = false;
            btnAddPet.IsEnabled = false;
            btnAddSponsors.IsEnabled = false;
            btnAddContacts.Visibility = Visibility.Collapsed;
            btnAddPet.Visibility = Visibility.Collapsed;
            btnAddSponsors.Visibility = Visibility.Collapsed;
            tbEventCost.Focus();
            tbEventCost.SelectAll();
        }


        private void SaveCloseButtonsEnabled()
        {
            stackEditUpdateDelete.IsEnabled = false;
            stackEditUpdateDelete.Visibility = Visibility.Collapsed;
            stackSaveCancel.IsEnabled = true;
            stackSaveCancel.Visibility = Visibility.Visible;
            stackSaveCancelBottom.IsEnabled = true;
            stackSaveCancelBottom.Visibility = Visibility.Visible;
            stackEditCloseBottom.IsEnabled = false;
            stackEditCloseBottom.Visibility = Visibility.Collapsed;
        }
        private void EditUpdateDeleteButtonsEnabled()
        {
            btnAddContacts.Visibility = Visibility.Collapsed;
            btnAddPet.Visibility = Visibility.Collapsed;
            btnAddSponsors.Visibility = Visibility.Collapsed;
            stackEditUpdateDelete.IsEnabled = true;
            stackEditUpdateDelete.Visibility = Visibility.Visible;
            stackSaveCancel.IsEnabled = false;
            stackSaveCancel.Visibility = Visibility.Collapsed;
            stackSaveCancelBottom.IsEnabled = false;
            stackSaveCancelBottom.Visibility = Visibility.Collapsed;
            stackEditCloseBottom.IsEnabled = true;
            stackEditCloseBottom.Visibility = Visibility.Visible;
        }


        private void dpStartTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void dpEndTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void btn_ViewAnimal(object sender, RoutedEventArgs e)
        {
            //not implemented
           return;
            string animalId = ((Button)sender).Tag.ToString();
            AnimalVM animal = FundraisingEvent.Animals.Where(am => am.AnimalId.ToString().Equals(animalId)).FirstOrDefault();
            PromptWindow.ShowPrompt("Animal", "Show animal record?");
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new WpfPresentation.Animals.EditDetailAnimalProfile(_masterManager, animal));
        }

        private void btnPledgers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewFundraisingEventPledgers(FundraisingEvent, _masterManager));
        }
    }
    public enum PageMode
    {
        New,
        Edit,
        Update,
        View
    }
}
