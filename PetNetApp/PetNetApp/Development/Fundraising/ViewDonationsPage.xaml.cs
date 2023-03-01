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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPresentation.UserControls;

namespace WpfPresentation.Development.Fundraising
{
    /// <summary>
    /// Interaction logic for ViewDonationsPage.xaml
    /// </summary>
    public partial class ViewDonationsPage : Page
    {
        private static ViewDonationsPage existingViewDonationsPage = null;

        public static ViewDonationsPage ExistingDonationPage 
        {
            get 
            {
                if (existingViewDonationsPage == null)
                {
                    return existingViewDonationsPage = new ViewDonationsPage();
                }
                return existingViewDonationsPage;
            }
             private set { }
        }

        public ViewDonationsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Donation donation = new Donation()
            //{
            //    DonationId = 1,
            //    ShelterId = 1,
            //    HasInKindDonation = false,
            //    Anonymous = false,
            //    Target = "",
            //    PaymentMethod = "",
            //    ScheduledDonationId = 1,
            //    FundraisingEventId = 1,
            //    GivenName = "Gwen",
            //    FamilyName = "Arman",
            //    Amount = 99.99M,
            //    DateDonated = DateTime.Today,
            //    Message = "I donated today"
            //};
            //DonationUserControl donationUserControl = new DonationUserControl(donation, false);
            //DonationUserControl donationUserControl2 = new DonationUserControl(donation, true);
            //DonationUserControl donationUserControl3 = new DonationUserControl(donation, false);
            //spDonations.Children.Add(donationUserControl);
            //spDonations.Children.Add(donationUserControl2);
            //spDonations.Children.Add(donationUserControl3);
        }
    }
}
