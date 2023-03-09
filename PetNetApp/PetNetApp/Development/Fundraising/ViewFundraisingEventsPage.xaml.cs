using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ViewFundraisingEventPage.xaml
    /// </summary>
    public partial class ViewFundraisingEventsPage : Page
    {

        private static ViewFundraisingEventsPage _existingViewFundraisingEventsPage = null;

        // setup
        private string _currentSearchText = "";
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private bool _needsReloaded = true;
        private List<FundraisingEvent> _fundraisingEvents = null;
        private List<FundraisingEvent> _filteredFundraisingEvents = null;
        private static Regex _isDigit = new Regex(@"^\d+$");

        // page navigation
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int _itemsPerPage = 10;

        public ViewFundraisingEventsPage()
        {
            InitializeComponent();
            //cbFilter.SelectionChanged += comboChanged;
            //cbSort.SelectionChanged += comboChanged;
        }

        /// <summary>
        /// Barry Mikulas
        /// Created 2023/03/05
        /// 
        /// Gets the existing FundraisingEventsPage or new if it doesn't exist.
        /// </summary>
        /// <returns></returns>
        public static ViewFundraisingEventsPage GetViewEventsPage()
        {
            if (_existingViewFundraisingEventsPage == null)
            {
                _existingViewFundraisingEventsPage = new ViewFundraisingEventsPage();
            }
            _existingViewFundraisingEventsPage.LoadFundraisingEventsData();

            _existingViewFundraisingEventsPage._needsReloaded = false;

            return _existingViewFundraisingEventsPage;
        }

        private void LoadFundraisingEventsData()
        {
           // throw new NotImplementedException();
        }

        private void UpdateUI()
        {

        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Label_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbPage_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnNavigatePage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
