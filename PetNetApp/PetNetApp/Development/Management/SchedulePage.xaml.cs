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
            populateMonthandDay();
            

        }

        private void populateMonthandDay()
        {
            // creating a list of months to populate the combobox
            List<string> MonthsFull = new List<string>
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            cboMonth.ItemsSource = MonthsFull;    
        }

        private void cboMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // clean up UI when changed month and clear selections
            cboDay.SelectedItem = 1;
            cboDay.Items.Clear();
            datScheduledPerson.ItemsSource = null;

            string selectedMonth = (string)cboMonth.SelectedItem;
            int month;

            if (!selectedMonth.Equals(""))
            {
                month = DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, month); i++)
                {
                    cboDay.Items.Add(i.ToString());
                }
            }
        }

        private void cboDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboDay.SelectedItem != null && cboMonth.SelectedItem != null) // check to make that the selected data isnt null after cleanup
            {
                // get all of the user input from the page
                string selectedMonth = (string)cboMonth.SelectedItem;
                int selectedMonthNum = DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                int selectedDay = Convert.ToInt32(cboDay.SelectedItem);
                DateTime selectedDate = new DateTime(DateTime.Now.Year, selectedMonthNum, selectedDay);

                // run through the manager to retrieve people scheduled for the day
                try
                {
                    datScheduledPerson.ItemsSource = _masterManager.ScheduleManager.RetrieveScheduleByDate(selectedDate);
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", ex.Message, ButtonMode.Ok);                
                }
            }  
        }
    }
}
