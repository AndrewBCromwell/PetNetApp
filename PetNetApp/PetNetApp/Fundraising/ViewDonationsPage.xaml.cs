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
using WpfPresentation.UserControls;

namespace WpfPresentation.Fundraising
{
    /// <summary>
    /// Interaction logic for ViewDonationsPage.xaml
    /// </summary>
    public partial class ViewDonationsPage : Page
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private static ViewDonationsPage existingViewDonationsPage = null;
        private List<DonationVM> donationVMs = null;

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
            spDonations.Children.Clear();

            try
            {
                donationVMs = masterManager.DonationManager.RetrieveDonationsByShelterId(masterManager.User.ShelterId.Value);

                for (int i = 0; i < donationVMs.Count; i++)
                {
                    donationVMs[i].GivenName = donationVMs[i].UserId != null ? donationVMs[i].User.GivenName : donationVMs[i].GivenName;
                    donationVMs[i].FamilyName = donationVMs[i].UserId != null ? donationVMs[i].User.FamilyName : donationVMs[i].FamilyName;
                    DonationUserControl donationUserControl = new DonationUserControl(donationVMs[i], i % 2 == 1);

                    spDonations.Children.Add(donationUserControl);
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
            }
        }
    }
}
