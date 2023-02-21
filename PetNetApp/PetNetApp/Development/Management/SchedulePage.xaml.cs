/// <summary>
/// Chris Dreismeier
/// Created: 2023/02/09
/// 
/// 
/// Class for interationg with the full schedule 
/// </summary>
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Globalization;
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
using LogicLayer;
using DataObjects;

namespace WpfPresentation.Development.Management
{
    /// <summary>
    /// Interaction logic for SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public DateTime _selectedDate;
        public MasterManager _masterManager = MasterManager.GetMasterManager();
        public SchedulePage()
        {
            InitializeComponent();
            loadCmbBox();
        }

        public SchedulePage(UsersVM user)
        {
            InitializeComponent();
            loadCmbBox();
            CboVolunteers.SelectedValue = user.UsersId;
            populateDatGridByUserId(user);
        }

        private void loadCmbBox()
        {
            
            try
            {
                CboVolunteers.ItemsSource = _masterManager.UsersManager.RetrieveUserByRole("Volunteer",100000);
                CboVolunteers.SelectedValuePath = "UsersId";
            }
            catch (Exception ex)
            {

                PromptWindow.ShowPrompt("Error", ex.Message);
            }
            
        }

        private void populateDatGridByUserId(UsersVM user)
        {
            if (CboVolunteers.SelectedItem != null)
            {
                date.SelectedDate = null;
                try
                {
                    datScheduledPerson.ItemsSource = _masterManager.ScheduleManager.RetrieveScheduleByUserId(user.UsersId);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", ex.Message);
                }
            }
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if ( date.SelectedDate != null)
            {
                CboVolunteers.SelectedItem = null;
                try
                {
                    datScheduledPerson.ItemsSource = _masterManager.ScheduleManager.RetrieveScheduleByDate((DateTime)date.SelectedDate);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", ex.Message);
                }
            }
        }

        private void CboVolunteers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsersVM user = (UsersVM)CboVolunteers.SelectedItem;
            populateDatGridByUserId(user);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CboVolunteers.SelectedItem = null;
            datScheduledPerson.ItemsSource = null;
        }
    }
}
