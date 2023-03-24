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
    /// Interaction logic for DonorInfoPage.xaml
    /// </summary>
    public partial class DonorInfoPage : Page
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private List<DonationVM> donorDonationVMs = null;
        private Users user = null;

        public DonorInfoPage()
        {
            InitializeComponent();
        }

        public DonorInfoPage(int usersId)
        {
            InitializeComponent();
            try
            {
                user = masterManager.UsersManager.RetrieveUserByUsersId(usersId);
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Unable to retrieve the user list.", ex.Message);
            }
        }
        /// <summary>
        /// Teft Francisco
        /// Created: 2023/03/14
        /// 
        /// Populates information on page load.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate donor information:
            lblName.Content = lblName.Content + user.GivenName + " " + user.FamilyName;
            lblEmail.Content = lblEmail.Content + user.Email;


            // Populate list of donations from viewed donor:
            spDonationList.Children.Clear();
            try
            {
                donorDonationVMs = masterManager.DonationManager.RetrieveDonationsByUserId(user.UsersId);

                for (int i = 0; i < donorDonationVMs.Count; i++)
                {
                    donorDonationVMs[i].GivenName = donorDonationVMs[i].UserId != null ? donorDonationVMs[i].User.GivenName : donorDonationVMs[i].GivenName;
                    donorDonationVMs[i].FamilyName = donorDonationVMs[i].UserId != null ? donorDonationVMs[i].User.FamilyName : donorDonationVMs[i].FamilyName;
                    DonationUserControl donationUserControl = new DonationUserControl(donorDonationVMs[i], i % 2 == 1);

                    spDonationList.Children.Add(donationUserControl);
                }

                if (spDonationList.Children.Count == 0)
                {
                    nothingToShowMessage.Visibility = Visibility.Visible;
                    spDonationList.Visibility = Visibility.Hidden;
                    scrlBar.Visibility = Visibility.Hidden;
                }
                else
                {
                    nothingToShowMessage.Visibility = Visibility.Hidden;
                    spDonationList.Visibility = Visibility.Visible;
                    scrlBar.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Unable to retrieve the donation list.", ex.Message);
            }
        }
        /// <summary>
        /// Teft Francisco
        /// Created: 2023/03/14
        /// 
        /// Navigates back to the donor list when clicked.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewDonationsPage());
        }
    }
}
