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
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Development.Fundraising
{
    /// <summary>
    /// Interaction logic for UpdateFundraisingCampaign.xaml
    /// </summary>
    public partial class UpdateFundraisingCampaign : Page
    {
        private FundraisingCampaignVM _fundraisingCampaignVM;

        public UpdateFundraisingCampaign(FundraisingCampaignVM fundraisingCampaignVM)
        {
            _fundraisingCampaignVM = fundraisingCampaignVM;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
