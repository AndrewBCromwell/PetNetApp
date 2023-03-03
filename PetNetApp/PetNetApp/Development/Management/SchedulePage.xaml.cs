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
            LoadCmbBox();
        }

        public SchedulePage(UsersVM user)
        {
            InitializeComponent();
            LoadCmbBox();
            CboVolunteers.SelectedValue = user.UsersId;
            PopulateDatGridByUserId(user);
        }

        private void LoadCmbBox()
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
        private void PopulateDatGridByUserId(UsersVM user)
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
            PopulateDatGridByUserId(user);
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            CboVolunteers.SelectedItem = null;
            datScheduledPerson.ItemsSource = null;
        }
        private void btnAddSchedule_Click(object sender, RoutedEventArgs e)
        {
            UsersVM selectedUser = (UsersVM)CboVolunteers.SelectedItem;

            if(CboVolunteers.SelectedItem == null)
            {
                PromptWindow.ShowPrompt("Error", "No user selected \n please select a user.");

            }
            else
            {
                var addEditSchedule = new AddEditSchedule(selectedUser);
                addEditSchedule.Owner = Window.GetWindow(this);
                if ((bool)addEditSchedule.ShowDialog())
                {
                    PopulateDatGridByUserId(selectedUser);
                }

            }
            
        }
    }
}
