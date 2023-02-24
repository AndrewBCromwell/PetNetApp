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
            // Way to check if the user has the correct roles
            List<string> rolesWithAccess = new List<string>() { "Admin","Manager", "Marketing" };
            if (!MasterManager.GetMasterManager().User.Roles.Exists(role => rolesWithAccess.Contains(role)))
            {
                PromptWindow.ShowPrompt("Inproper Permissions", "You do not have permissions to access this");
                return null;
            }
            if (_existingViewCampaignsPage == null)
            {
                _existingViewCampaignsPage = new ViewCampaignsPage();
                MasterManager.GetMasterManager().UserLogout += () => _existingViewCampaignsPage = null;
            }
            _existingViewCampaignsPage.LoadFundraisingCampaignData();

            _existingViewCampaignsPage._needsReloaded = false;
            return _existingViewCampaignsPage;
        }
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/24
        /// 
        /// Calls the methods to change navigation buttons and show the appropriate campaigns for the selected page
        /// </summary>
        private void UpdateUI()
        {
            PopulateNavigationButtons();
            PopulateCampaignList();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/24
        /// 
        /// Loads the Fundraising campaigns for the shelter of the logged in user and runs the method to filter and sort
        /// </summary>
        private void LoadFundraisingCampaignData()
        {
            try
            {
                _fundraisingCampaigns = _masterManager.FundraisingCampaignManager.RetrieveAllFundraisingCampaignsByShelterId((int)_masterManager.User.ShelterId);
            }
            catch (ApplicationException ex)
            {
                _fundraisingCampaigns = new List<FundraisingCampaign>();
                PromptWindow.ShowPrompt("Error", ex.Message);
            }
            ApplyFundraisingCampaignFilterAndSort(false);
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/24
        /// 
        /// Takes the loaded Fundraising Campaign list and applies filters and sorts it, then updates the navigation
        /// information and finally updates the UI
        /// </summary>
        /// <param name="resetPage"></param>
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

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/24
        /// 
        /// Takes a fundraising campaign and returns true if it contains the search text in its start date, end date, description, or title (case insensitive)
        /// </summary>
        /// <param name="fundraisingCampaign"></param>
        /// <returns>Wether there is any matching data to the Current Search Text</returns>
        private bool SearchForTextInFundraisingCampaign(FundraisingCampaign fundraisingCampaign)
        {
                return fundraisingCampaign.Title?.IndexOf(_currentSearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       fundraisingCampaign.Description?.IndexOf(_currentSearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       (fundraisingCampaign.StartDate != null ? fundraisingCampaign.StartDate.Value.ToString("MM/dd/yyyy").Contains(_currentSearchText) : false) ||
                       (fundraisingCampaign.EndDate != null ? fundraisingCampaign.EndDate.Value.ToString("MM/dd/yyyy").Contains(_currentSearchText) : false);
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Updates the total pages needed for all the campaigns
        /// </summary>
        private void UpdateNavigationInformation()
        {
            _totalPages = (_filteredFundraisingCampaigns.Count - 1) / _itemsPerPage + 1;
        }

        /// <summary>
        /// Stephen Jaurigue
        /// 2023/02/23
        /// 
        /// Updates the controls at the bottom of the page to appear and dissapear as needed.
        /// Also generates the numbered buttons for navigation
        /// </summary>
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

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Changes the active page to the page number and updates the UI
        /// </summary>
        /// <param name="page"></param>
        private void NavigateToPage(int page)
        {
            _currentPage = page;
            UpdateUI();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Shows the selected pages fundraising campaigns or a message if there are now campaigns
        /// </summary>
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
                i++;
                stackCampaigns.Children.Add(item);
            }
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Goes to the next page and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            UpdateUI();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Goes to the previous page and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            UpdateUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Stephen Jaurigue:
        /// Prepared for the add campaign button
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCampaign_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Navigates to the page indicated by the user in the page number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNavigatePage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToTypedPage();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Navigates to the page indicated by the user in the page number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Searches for campaigns with the typed text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            TrySearch();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Updates the display to be in the new selected order and resets the page back to the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboChanged(object sender, RoutedEventArgs e)
        {
            ApplyFundraisingCampaignFilterAndSort();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Changes the Needs Loaded indicator to say that the page needs reloaded when the user refocuses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _needsReloaded = true;
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Loads the data for the campaigns if they haven't already been loaded and don't need reloaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_needsReloaded)
            {
                LoadFundraisingCampaignData();
                _needsReloaded = false;
            }
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Navigates to the first page and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            UpdateUI();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Navigates to the last page and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _totalPages;
            UpdateUI();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Makes sure the typed page is only digits and is within the range of pages
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Navigates to the typed page on enter pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                NavigateToTypedPage();
            }
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Searches for the text inside the campaigns on enter key pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                TrySearch();
            }
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// If the text has changed since last search, searches for the new text
        /// </summary>
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
