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

namespace WpfPresentation.Fundraising
{
    /// <summary>
    /// Interaction logic for ViewCampaignsPage.xaml
    /// </summary>
    public partial class ViewCampaignsPage : Page
    {
        private static ViewCampaignsPage _existingViewCampaignsPage = null;

        // setup
        private string _currentSearchText = "";
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private bool _needsReloaded = true;
        private List<FundraisingCampaign> _fundraisingCampaigns = null;
        private List<FundraisingCampaign> _filteredFundraisingCampaigns = null;
        private static Regex _isDigit = new Regex(@"^\d+$");

        // page navigation
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int _itemsPerPage = 10;


        private ViewCampaignsPage()
        {
            InitializeComponent();
            cbFilter.SelectionChanged += comboChanged;
            cbSort.SelectionChanged += comboChanged;
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/20
        /// 
        /// Gets the existing CampaignsPage or new if it doesn't exist. Refreshes data but maintains page
        /// </summary>
        public static ViewCampaignsPage GetViewCampaignsPage()
        {
            if (_existingViewCampaignsPage == null)
            {
                _existingViewCampaignsPage = new ViewCampaignsPage();
            }
            _existingViewCampaignsPage.LoadFundraisingCampaignData();

            _existingViewCampaignsPage._needsReloaded = false;
            return _existingViewCampaignsPage;
        }
        private void UpdateUI()
        {
            PopulateNavigationButtons();
            PopulateCampaignList();
        }

        private void LoadFundraisingCampaignData()
        {
            try
            {
                _fundraisingCampaigns = _masterManager.FundraisingCampaignManager.RetrieveAllFundraisingCampaignsByShelterId(_masterManager.User.ShelterId);
            }
            catch (ApplicationException ex)
            {
                _fundraisingCampaigns = new List<FundraisingCampaign>();
                PromptWindow.ShowPrompt("Error", ex.Message);
            }
            ApplyFundraisingCampaignFilterAndSort(false);
        }
        private void ApplyFundraisingCampaignFilterAndSort(bool resetPage = true)
        {
            Func<FundraisingCampaign, string> sortMethod = null;
            switch (((string)((ComboBoxItem)cbSort.SelectedValue).Content).ToLower())
            {
                case "title":
                    sortMethod = new Func<FundraisingCampaign, string>(fc => fc.Title);
                    break;
                case "start date":
                    sortMethod = new Func<FundraisingCampaign, string>(fc => fc.StartDate != null ? fc.StartDate.Value.ToString("yyyy MM dd") : "");
                    break;
                default:
                    sortMethod = new Func<FundraisingCampaign, string>(fc => fc.FundraisingCampaignId.ToString());
                    break;
            }
            Func<FundraisingCampaign,bool> filterMethod = null;
            switch (((string)((ComboBoxItem)cbFilter.SelectedValue).Content).ToLower())
            {
                case "completed":
                    filterMethod = new Func<FundraisingCampaign, bool>(fc => fc.Complete);
                    break;
                case "both":
                    filterMethod = new Func<FundraisingCampaign, bool>(fc => true);
                    break;
                case "ongoing":
                default:
                    filterMethod = new Func<FundraisingCampaign, bool>(fc => !fc.Complete);
                    break;
            }
            _filteredFundraisingCampaigns = _fundraisingCampaigns.Where(filterMethod).Where(SearchForTextInFundraisingCampaign).OrderBy(sortMethod).ToList();
            UpdateNavigationInformation();
            _currentPage = resetPage ? 1 : _currentPage > _totalPages ? _totalPages : _currentPage;
            UpdateUI();
        }
        private bool SearchForTextInFundraisingCampaign(FundraisingCampaign fundraisingCampaign)
        {
                return fundraisingCampaign.Title?.IndexOf(_currentSearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       fundraisingCampaign.Description?.IndexOf(_currentSearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       (fundraisingCampaign.StartDate != null ? fundraisingCampaign.StartDate.Value.ToString("MM/dd/yyyy").Contains(_currentSearchText) : false) ||
                       (fundraisingCampaign.EndDate != null ? fundraisingCampaign.EndDate.Value.ToString("MM/dd/yyyy").Contains(_currentSearchText) : false);
        }
        private void UpdateNavigationInformation()
        {
            _totalPages = (_filteredFundraisingCampaigns.Count - 1) / _itemsPerPage + 1;
        }
        private void PopulateNavigationButtons()
        {
            btnPreviousPage.Visibility = _currentPage == 1 ? Visibility.Collapsed : Visibility.Visible;
            btnNextPage.Visibility = _currentPage == _totalPages ? Visibility.Collapsed : Visibility.Visible;
            if (_totalPages <= 5)
            {
                btnFirstPage.Visibility = Visibility.Collapsed;
                btnLastPage.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnFirstPage.Visibility = _currentPage > 3 ? Visibility.Visible : Visibility.Collapsed;
                btnLastPage.Visibility = _currentPage <= _totalPages - 3 ? Visibility.Visible : Visibility.Collapsed;
            }
            // Populate Number Buttons
            stackInnerButtons.Children.Clear();
            int startPage = _currentPage - 2;
            int endPage = _currentPage + 2;
            if (endPage > _totalPages)
            {
                startPage -= endPage - _totalPages;
                endPage = _totalPages;
            }
            if (startPage < 1)
            {
                endPage += 1 - startPage;
                startPage = 1;
            }
            if (endPage > _totalPages)
            {
                endPage = _totalPages;
            }
            if (startPage < 1)
            {
                startPage = 1;
            }
            for (int currentPage = startPage; currentPage <= endPage; currentPage++)
            {
                Button currentPageButton = new Button();
                currentPageButton.Content = currentPage.ToString();
                currentPageButton.Width = 40;
                currentPageButton.Height = 40;
                currentPageButton.Margin = new Thickness(2);
                if (currentPage == _currentPage)
                {
                    currentPageButton.IsEnabled = false;
                }
                int page = currentPage;
                currentPageButton.Click += (obj, args) => NavigateToPage(page);
                stackInnerButtons.Children.Add(currentPageButton);
            }

        }
        private void NavigateToPage(int page)
        {
            _currentPage = page;
            UpdateUI();
        }
        private void PopulateCampaignList()
        {
            stackCampaigns.Children.Clear();
            if (_filteredFundraisingCampaigns.Count == 0)
            {
                stackCampaigns.Visibility = Visibility.Collapsed;
                nothingToShowMessage.Visibility = Visibility.Visible;
            }
            else
            {
                stackCampaigns.Visibility = Visibility.Visible;
                nothingToShowMessage.Visibility = Visibility.Collapsed;
            }
            int i = 0;
            foreach (FundraisingCampaign fundraisingCampaign in _filteredFundraisingCampaigns.Skip(_itemsPerPage * (_currentPage - 1)).Take(_itemsPerPage))
            {
                ViewCampaignsFundraisingCampaignUserControl item = new ViewCampaignsFundraisingCampaignUserControl(fundraisingCampaign, i % 2 == 0);
                //if (i % 2 == 0)
                //{
                //    item.BackgroundColor = new SolidColorBrush(Color.FromRgb(61, 131, 97));
                //    item.Foreground = new SolidColorBrush(Color.FromRgb(238, 242, 230));
                //}
                //else
                //{
                //    item.BackgroundColor = new SolidColorBrush(Color.FromRgb(214, 205, 164));
                //    item.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));
                //}
                i++;
                stackCampaigns.Children.Add(item);
            }
        }
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            UpdateUI();
        }
        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            UpdateUI();
        }
        private void btnAddCampaign_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnNavigatePage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToTypedPage();
        }
        private void NavigateToTypedPage()
        {
            if (IsValidPage(tbPage.Text))
            {
                _currentPage = int.Parse(tbPage.Text);
                UpdateUI();
            }
            else
            {
                tbPage.Text = _currentPage.ToString();
            }
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            TrySearch();
        }
        private void comboChanged(object sender, RoutedEventArgs e)
        {
            ApplyFundraisingCampaignFilterAndSort();
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _needsReloaded = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_needsReloaded)
            {
                LoadFundraisingCampaignData();
                _needsReloaded = false;
            }
        }
        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            UpdateUI();
        }
        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _totalPages;
            UpdateUI();
        }
        private bool IsValidPage(string page)
        {
            if (page.Length < 8 && _isDigit.IsMatch(page))
            {
                int selectedPage = int.Parse(page);
                if (selectedPage >= 1 && selectedPage <= _totalPages)
                {
                    return true;
                }
            }
            return false;
        }
        private void tbPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                NavigateToTypedPage();
            }
        }
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                TrySearch();
            }
        }
        private void TrySearch()
        {
            string newSearchText = tbSearch.Text.ToLower().Trim();
            if (newSearchText != _currentSearchText)
            {
                _currentSearchText = newSearchText;
                ApplyFundraisingCampaignFilterAndSort();
            }
        }
    }
}
