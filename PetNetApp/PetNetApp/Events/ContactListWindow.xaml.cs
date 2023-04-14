using DataObjects;
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
using System.Windows.Shapes;

namespace WpfPresentation.Events
{
    /// <summary>
    /// Interaction logic for ContactListWindow.xaml
    /// </summary>
    public partial class ContactListWindow : Window
    {
        private List<InstitutionalEntity> _contactList;
        private List<InstitutionalEntity> contactSelectedList;
        private InstitutionalEntity returnValue;

        public ContactListWindow(List<InstitutionalEntity> contacts)
        {
            InitializeComponent();
            _contactList = contacts;
            returnValue = null;
        }

        private void btnCanle_Click(object sender, RoutedEventArgs e)
        {
            returnValue = null;
            this.DialogResult = false;
        }

        private void DisplayContact(InstitutionalEntity contact)
        {
            UCEventContact ucEventContact = new UCEventContact();
            ucEventContact.lblContactName.Content = contact.CompanyName;
            ucEventContact.btnView.Click += (obj, arg) => BtnView_Click(contact);
            ucEventContact.btnAdd.Click += (obj, arg) => BtnAdd_Click(contact);
            ucEventContact.Margin = new Thickness(0, 0, 0, 10);
            stpContactList.Children.Add(ucEventContact);
        }

        private void PopulateContacts()
        {
            stpContactList.Children.Clear();
            foreach (InstitutionalEntity contact in contactSelectedList)
            {
                DisplayContact(contact);
            }
        }

        private void ContactSearching()
        {
            contactSelectedList = new List<InstitutionalEntity>();
            if (txtSearchContact.Text == "")
            {
                foreach (InstitutionalEntity contact in _contactList)
                {
                    contactSelectedList.Add(contact);
                }
            }
            else
            {
                foreach (InstitutionalEntity contact in _contactList)
                {
                    if (contact.CompanyName.ToLower().Contains(txtSearchContact.Text.ToLower()))
                    {
                        contactSelectedList.Add(contact);
                    }
                }
            }
            PopulateContacts();
        }

        private void BtnAdd_Click(InstitutionalEntity contact)
        {
            returnValue = contact;
            this.DialogResult = false;
        }

        private void BtnView_Click(InstitutionalEntity contact)
        {
            PromptWindow.ShowPrompt("Sponsor Detail", "Name: " + contact.CompanyName + "\n\n"
                + "Email: " + contact.Email + "\n\n" + "Phone Number: " + contact.Phone);
        }

        private void txtSearchContact_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public InstitutionalEntity GetReturnValue()
        {
            return returnValue;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ContactSearching();
        }
    }
}
