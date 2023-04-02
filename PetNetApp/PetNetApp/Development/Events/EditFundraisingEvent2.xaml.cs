﻿using System;
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
using WpfPresentation.Development.Community;

namespace WpfPresentation.Development.Events
{
    /// <summary>
    /// Interaction logic for EditFundraisingEvent2.xaml
    /// </summary>
    public partial class EditFundraisingEvent2 : Page
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<InstitutionalEntity> _sponsorList;
        private List<InstitutionalEntity> sponsorSelected;
        private List<InstitutionalEntity> _contactList;
        private List<InstitutionalEntity> contactSelected;
        private List<Animal> _animalsList;
        private List<Animal> animalsSelected;
        private FundraisingEvent _fundraisingEvent;
        private FundraisingEventVM _fundraisingEventVM;
        private Images eventImage;

        public EditFundraisingEvent2(FundraisingEvent fundraisingEvent)
        {
            InitializeComponent();
            _fundraisingEvent = fundraisingEvent;
            try
            {
                sponsorSelected = _masterManager.FundraisingEventManager.RetrieveSponsorByEventId(_fundraisingEvent.FundraisingEventId);
                animalsSelected = _masterManager.FundraisingEventManager.RetrieveAnimalByEventId(_fundraisingEvent.FundraisingEventId, _fundraisingEvent.ShelterId);
                contactSelected = _masterManager.FundraisingEventManager.RetrieveContactByEventId(_fundraisingEvent.FundraisingEventId);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", "Failed to get data. \n\n" + ex);
            }
        }

        private void DisplaySponsor(InstitutionalEntity sponsor)
        {
            UCSponsor ucSponsor = new UCSponsor();
            ucSponsor.lblSponsorName.Content = sponsor.CompanyName;
            ucSponsor.btnRemove.Click += (obj, arg) => RemoveSponsor_MouseClick(sponsor);
            ucSponsor.Margin = new Thickness(0, 0, 10, 5);
            stpSponsorList.Children.Add(ucSponsor);
        }

        private void DisplayContact(InstitutionalEntity contact)
        {
            UCContact ucContact = new UCContact();
            ucContact.lblContactName.Content = contact.CompanyName;
            ucContact.btnRemove.Click += (obj, arg) => RemoveContact_MouseClick(contact);
            ucContact.Margin = new Thickness(0, 0, 10, 5);
            stpContactList.Children.Add(ucContact);
        }

        private void DisplayAnimal(Animal animal)
        {
            UCAnimalTakeToEvent ucAnimalTakeToEvent = new UCAnimalTakeToEvent();
            ucAnimalTakeToEvent.lblAnimalName.Content = animal.AnimalName;
            ucAnimalTakeToEvent.btnRemove.Click += (obj, arg) => RemoveAnimal_MouseClick(animal);
            ucAnimalTakeToEvent.Margin = new Thickness(0, 0, 10, 5);
            stpAnimalList.Children.Add(ucAnimalTakeToEvent);
        }

        private void RemoveAnimal_MouseClick(Animal animal)
        {
            animalsSelected.Remove(animal);
            PopulateAnimalList();
        }

        private void RemoveContact_MouseClick(InstitutionalEntity contact)
        {
            contactSelected.Remove(contact);
            PopulateContactList();
        }

        private void RemoveSponsor_MouseClick(InstitutionalEntity sponsor)
        {
            sponsorSelected.Remove(sponsor);
            PopulateSponsorList();
        }

        private void PopulateSponsorList()
        {
            stpSponsorList.Children.Clear();
            foreach (InstitutionalEntity sponsor in sponsorSelected)
            {
                DisplaySponsor(sponsor);
            }
        }

        private void PopulateContactList()
        {
            stpContactList.Children.Clear();
            foreach (InstitutionalEntity contact in contactSelected)
            {
                DisplayContact(contact);
            }
        }

        private void PopulateAnimalList()
        {
            stpAnimalList.Children.Clear();
            foreach (Animal animal in animalsSelected)
            {
                DisplayAnimal(animal);
            }
        }

        private void btnSponsorContact_Click(object sender, RoutedEventArgs e)
        {
            var sponsorContactWindow = new SponsorListWindow(_sponsorList);
            sponsorContactWindow.ShowDialog();

            if (sponsorContactWindow.GetReturnValue() != null)
            {
                InstitutionalEntity sponsor = sponsorContactWindow.GetReturnValue();
                if (!sponsorSelected.Exists(spon => sponsor.InstitutionalEntityId == spon.InstitutionalEntityId))
                {
                    sponsorSelected.Add(sponsor);
                }
                else
                {
                    PromptWindow.ShowPrompt("Warning", "This sponsor has been selected");
                }
            }
            PopulateSponsorList();
        }

        private void btnChooseContact_Click(object sender, RoutedEventArgs e)
        {
            var contactWindow = new ContactListWindow(_contactList);
            contactWindow.ShowDialog();
            if (contactWindow.GetReturnValue() != null)
            {
                InstitutionalEntity contact = contactWindow.GetReturnValue();
                if (!contactSelected.Exists(c => contact.InstitutionalEntityId == c.InstitutionalEntityId))
                {
                    contactSelected.Add(contact);
                }
                else
                {
                    PromptWindow.ShowPrompt("Warning", "This contact has been selected");
                }
            }
            PopulateContactList();
        }

        private void btnChooseAnimal_Click(object sender, RoutedEventArgs e)
        {
            var animalTakeToEventWindow = new AnimalListWindow(_animalsList);
            animalTakeToEventWindow.ShowDialog();
            if (animalTakeToEventWindow.GetReturnValuen() != null)
            {
                Animal selectedAnimal = animalTakeToEventWindow.GetReturnValuen();
                if (!animalsSelected.Exists(animal => selectedAnimal.AnimalId == animal.AnimalId))
                {
                    animalsSelected.Add(selectedAnimal);
                }
                else
                {
                    PromptWindow.ShowPrompt("Warning", "This animal has been selected");
                }
            }
            PopulateAnimalList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                int shelterId = _fundraisingEvent.ShelterId; // Need to change later
                _sponsorList = _masterManager.InstitutionalEntityManager.RetrieveAllSponsors();
                _contactList = _masterManager.InstitutionalEntityManager.RetrieveAllContact();
                _animalsList = _masterManager.AnimalManager.RetrieveAllAnimals(shelterId);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
            }
            PopulateSponsorList();
            PopulateContactList();
            PopulateAnimalList();
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            var uploadImage = new UploadEventImageWindow();
            uploadImage.ShowDialog();
            if (uploadImage.GetImage() != null)
            {
                eventImage = uploadImage.GetImage();
            }
        }

        private bool PageValidation()
        {
            bool isSuccess = true;

            lblContactError.Visibility = Visibility.Hidden;
            if (contactSelected.Count == 0)
            {
                lblContactError.Visibility = Visibility.Visible;
                return isSuccess = false;
            }
            else
            {
                if (eventImage != null)
                {
                    _fundraisingEvent.ImageId = eventImage.ImageId;
                }
                _fundraisingEvent.Hidden = (bool)cbIsHidden.IsChecked;
                _fundraisingEvent.NumOfAttendees = animalsSelected.Count();
            }

            _fundraisingEventVM = new FundraisingEventVM()
            {
                FundraisingEventId = _fundraisingEvent.FundraisingEventId,
                UserId = _fundraisingEvent.UserId,
                CampaignId = _fundraisingEvent.CampaignId == null ? null : _fundraisingEvent.CampaignId,
                ShelterId = _fundraisingEvent.ShelterId,
                ImageId = _fundraisingEvent.ImageId,
                Hidden = _fundraisingEvent.Hidden,
                Title = _fundraisingEvent.Title,
                StartTime = _fundraisingEvent.StartTime,
                EndTime = _fundraisingEvent.EndTime,
                Description = _fundraisingEvent.Description,
                NumOfAttendees = _fundraisingEvent.NumOfAttendees,
                AdditionalInfo = _fundraisingEvent.AdditionalInfo
            };
            _fundraisingEventVM.Sponsors = sponsorSelected;
            _fundraisingEventVM.Contacts = contactSelected;
            _fundraisingEventVM.Animals = new List<AnimalVM>();
            foreach (Animal animal in animalsSelected)
            {
                AnimalVM animalVM = new AnimalVM()
                {
                    AnimalId = animal.AnimalId
                };
                _fundraisingEventVM.Animals.Add(animalVM);
            }

            return isSuccess;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = false;
            if (PageValidation())
            {
                try
                {
                    isSuccess = _masterManager.FundraisingEventManager.UpdateFundraisingEvent(_fundraisingEventVM);
                    if (isSuccess)
                    {
                        PromptWindow.ShowPrompt("Message", "Successful to update fundraising event");
                        CommunityPage communityPage = CommunityPage.GetCommunityPage(_masterManager);
                        communityPage.frameCommunity.Navigate(new AddFundraisingEvent());
                    }
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", "Can not update fundraising event \n\n" + ex);
                }
            }
        }
    }
}
