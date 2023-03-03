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

namespace WpfPresentation.Development.Fundraising
{
    /// <summary>
    /// Interaction logic for AddEditViewFundraisingCampaign.xaml
    /// </summary>
    public partial class AddEditViewFundraisingCampaignPage : Page
    {
        private static AddEditViewFundraisingCampaignPage _existingAddEditViewFundraisingCampaignPage = null;

        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private WindowMode _windowMode;

        private FundraisingCampaignVM _oldFundraisingCampaignVM = null;

        public FundraisingCampaignVM FundraisingCampaign
        {
            get { return (FundraisingCampaignVM)GetValue(FundraisingCampaignProperty); }
            set { SetValue(FundraisingCampaignProperty, value); }
        }
        public static readonly DependencyProperty FundraisingCampaignProperty =
            DependencyProperty.Register("FundraisingCampaign", typeof(FundraisingCampaignVM), typeof(AddEditViewFundraisingCampaignPage), new PropertyMetadata(null));


        private AddEditViewFundraisingCampaignPage()
        {
            DataContext = this;
            InitializeComponent();
                
        }

        public static AddEditViewFundraisingCampaignPage GetAddFundraisingCampaignPage()
        {
            if (_existingAddEditViewFundraisingCampaignPage == null)
            {
                _existingAddEditViewFundraisingCampaignPage = new AddEditViewFundraisingCampaignPage();
            }
            _existingAddEditViewFundraisingCampaignPage.SetupNewFundraisingCampaign();
            return _existingAddEditViewFundraisingCampaignPage;
        }

        public static AddEditViewFundraisingCampaignPage GetEditFundraisingCampaignPage(FundraisingCampaignVM fundraisingCampaign)
        {
            if (_existingAddEditViewFundraisingCampaignPage == null)
            {
                _existingAddEditViewFundraisingCampaignPage = new AddEditViewFundraisingCampaignPage();
            }
            _existingAddEditViewFundraisingCampaignPage.SetupEditFundraisingCampaign(fundraisingCampaign);
            return _existingAddEditViewFundraisingCampaignPage;
        }

        public static AddEditViewFundraisingCampaignPage GetViewFundraisingCampaignPage(FundraisingCampaignVM fundraisingCampaign)
        {
            if (_existingAddEditViewFundraisingCampaignPage == null)
            {
                _existingAddEditViewFundraisingCampaignPage = new AddEditViewFundraisingCampaignPage();
            }
            _existingAddEditViewFundraisingCampaignPage.SetupViewFundraisingCampaign(fundraisingCampaign);
            return _existingAddEditViewFundraisingCampaignPage;
        }

        private void SetupNewFundraisingCampaign()
        {
            FundraisingCampaign = new FundraisingCampaignVM()
            {
                UsersId = _masterManager.User.UsersId,
                ShelterId = _masterManager.User.ShelterId.Value,
                Sponsors = new List<Sponsor>()
            };
            dpStartDate.DisplayDateStart = DateTime.Today;
            AddEditMode();
            stackEditClose.IsEnabled = false;
            stackEditClose.Visibility = Visibility.Collapsed;
            stackSaveCancel.IsEnabled = true;
            stackSaveCancel.Visibility = Visibility.Visible;
            _windowMode = WindowMode.Add;
        }

        private void SetupViewFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            FundraisingCampaign = fundraisingCampaign;
            ViewMode();
            stackEditClose.IsEnabled = true;
            stackEditClose.Visibility = Visibility.Visible;
            stackSaveCancel.IsEnabled = false;
            stackSaveCancel.Visibility = Visibility.Collapsed;
            _windowMode = WindowMode.View;
        }

        private void ViewMode()
        {
            tbTitle.IsReadOnly = true;
            tbDescription.IsReadOnly = true;
            dpEndDate.IsEnabled = false;
            dpStartDate.IsEnabled = false;
            btnAddSponsors.IsEnabled = false;
            btnSave.IsDefault = false;
            btnEdit.IsDefault = true;
            btnCancel.IsCancel = false;
            btnClose.IsCancel = true;
        }

        private void AddEditMode()
        {
            tbTitle.IsReadOnly = false;
            tbDescription.IsReadOnly = false;
            dpEndDate.IsEnabled = true;
            dpStartDate.IsEnabled = true;
            btnAddSponsors.IsEnabled = true;
            btnSave.IsDefault = true;
            btnEdit.IsDefault = false;
            btnCancel.IsCancel = true;
            btnClose.IsCancel = false;
        }

        private void SetupEditFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            FundraisingCampaign = fundraisingCampaign.Copy();
            _oldFundraisingCampaignVM = fundraisingCampaign;

            AddEditMode();
            stackEditClose.IsEnabled = false;
            stackEditClose.Visibility = Visibility.Collapsed;
            stackSaveCancel.IsEnabled = true;
            stackSaveCancel.Visibility = Visibility.Visible;
            _windowMode = WindowMode.Edit;
        }

        private void dpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dpEndDate.DisplayDateStart = dpStartDate.SelectedDate;
            if (dpEndDate.SelectedDate <= dpStartDate.SelectedDate)
            {
                dpEndDate.SelectedDate = null;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            switch(_windowMode)
            {
                case WindowMode.Add:
                    NavigationService.Navigate(ViewCampaignsPage.GetViewCampaignsPage());
                    break;
                case WindowMode.Edit:
                    SetupViewFundraisingCampaign(_oldFundraisingCampaignVM);
                    break;
                default:
                    break;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFundraisingCampaign())
            {
                return;
            }
            try
            {
                switch (_windowMode)
                {
                    case WindowMode.Add:
                        if (!_masterManager.FundraisingCampaignManager.AddFundraisingCampaign(FundraisingCampaign))
                        {
                            PromptWindow.ShowPrompt("Error", "The fundraising campaign was not added");
                            break;
                        }
                        SetupViewFundraisingCampaign(FundraisingCampaign);
                        break;
                    case WindowMode.Edit:
                        if (!_masterManager.FundraisingCampaignManager.EditFundraisingCampaign(_oldFundraisingCampaignVM, FundraisingCampaign))
                        {
                            PromptWindow.ShowPrompt("Error", "The fundraising campaign was not changed");
                            // reload data because there was a concurrency issue
                            ReloadFundraisingCampaignData();
                            break;
                        }
                        SetupViewFundraisingCampaign(FundraisingCampaign);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", ex.Message);
            }
            RefreshUI();
        }

        private bool ValidateFundraisingCampaign()
        {
            bool isValid = true;
            if (!FundraisingCampaign.Title.IsValidTitle())
            {
                lblTitleError.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                lblTitleError.Visibility = Visibility.Collapsed;
            }

            if (!FundraisingCampaign.Description.IsValidRequiredShortDescription())
            {
                lblDescriptionError.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                lblDescriptionError.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }

        private void ReloadFundraisingCampaignData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                PromptWindow.ShowPrompt("Error", "Failed to reload campaign data \n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/02
        /// 
        /// fakes a change in the Fundraising campaign property to trigger a redraw on all bindings in wpf
        /// </summary>
        private void RefreshUI()
        {
            var temp = FundraisingCampaign;
            FundraisingCampaign = null;
            FundraisingCampaign = temp;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SetupEditFundraisingCampaign(FundraisingCampaign);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewCampaignsPage.GetViewCampaignsPage());
        }
    }

    enum WindowMode
    {
        Add,
        Edit,
        View
    }
}
