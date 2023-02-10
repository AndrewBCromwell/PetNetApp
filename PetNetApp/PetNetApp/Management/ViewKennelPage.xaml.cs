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
using WpfPresentation.Development.Management;
using WpfPresentation.UserControls;

namespace WpfPresentation.Management
{
    /// <summary>
    /// Interaction logic for ViewKennelPage.xaml
    /// </summary>
    public partial class ViewKennelPage : Page
    {
        private MasterManager masterManager = new MasterManager();
        private List<KennelVM> kennelVMs = null;
        public ViewKennelPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Replace 100000 with User.Shelter.ShelterId when users are made
            try
            {
                kennelVMs = masterManager.KennelManager.RetrieveKennels(100000);

                for (int i = 0; i < kennelVMs.Count / 4; i++)
                {
                    grdKennel.RowDefinitions.Add(new RowDefinition());
                }

                for (int i = 0; i < kennelVMs.Count; i++)
                {

                    KennelUserControl kennelUserControl = new KennelUserControl();

                    kennelUserControl.lblKennelName.Content += kennelVMs[i].KennelName + ": ";
                    if (kennelVMs[i].Animal == null)
                    {
                        UpdateUserControlStyles(kennelUserControl);
                    }
                    else
                    {
                        kennelUserControl.lblKennelName.Content += kennelVMs[i].Animal.AnimalName;
                    }
                    int j = i;
                    kennelUserControl.btnKennel.Click += (obj, arg) => UserControlClick(kennelVMs[j]);

                    Grid.SetRow(kennelUserControl, i / 4);
                    Grid.SetColumn(kennelUserControl, i % 4);
                    grdKennel.Children.Add(kennelUserControl);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
               
            }
        }

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Method navigates to seperate use cases depending on whether
        /// the kennel is occupied
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="kennelVM"></param>
        private void UserControlClick(KennelVM kennelVM)
        {
            if(kennelVM.Animal != null)
            {
                MessageBox.Show(kennelVM.KennelName);
                // Placeholder for ViewIndivisualOccupiedKennel
            } else
            {
                NavigationService.Navigate(new AssignAnimalToKennel(masterManager, kennelVM));
            }
        }

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Method updates the KennelUserControl styles depending on whether the kennel 
        /// is occupied
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="kennelUserControl"></param>
        private void UpdateUserControlStyles(KennelUserControl kennelUserControl)
        {
            kennelUserControl.grdKennelUserControl.Background = new SolidColorBrush(Color.FromRgb(238, 242, 230));
            kennelUserControl.lblKennelName.Content += "Empty";
            kennelUserControl.lblKennelName.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            kennelUserControl.btnKennel.Content = "Add Animal";
            kennelUserControl.btnKennel.Background = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            kennelUserControl.btnKennel.Foreground = new SolidColorBrush(Color.FromRgb(238, 242, 230));
        }
    }
}
