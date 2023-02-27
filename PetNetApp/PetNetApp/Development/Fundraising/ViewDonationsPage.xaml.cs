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
    }
}
