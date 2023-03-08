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

namespace WpfPresentation.Fundraising
{
    /// <summary>
    /// Interaction logic for ViewSpecificDonationPage.xaml
    /// </summary>
    public partial class ViewSpecificDonationPage : Page
    {
        public static Donation Donation { get; set; }
        private MasterManager masterManager = MasterManager.GetMasterManager();
        public ViewSpecificDonationPage(Donation donation)
        {
            Donation = donation;
            InitializeComponent();
        }
    }
}
