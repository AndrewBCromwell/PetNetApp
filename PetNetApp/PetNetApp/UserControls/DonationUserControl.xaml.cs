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

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for DonationUserControl.xaml
    /// </summary>
    public partial class DonationUserControl : UserControl
    {
        public Donation Donation { get; set; }
        public DonationUserControl(Donation donation, bool isEven)
        {
            Donation = donation;
            InitializeComponent();
            if (isEven)
            {
                UpdateAlternativeTheme();
            }
        }

        public void UpdateAlternativeTheme()
        {
            gdDonation.Background = new SolidColorBrush(Color.FromRgb(214, 205, 164));
            lblFirstName.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblLastName.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblAmount.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblDate.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblMessage.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            sepDonation.Background = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblFirstNameContent.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblLastNameContent.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblAmountContent.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblDateContent.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            lblMessageContent.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            btnView.Style = (Style)this.FindResource("rsrcDefaultButton");
        }
    }
}
