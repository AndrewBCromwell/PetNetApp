﻿using System;
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
using WpfPresentation.Development.Fundraising;

namespace WpfPresentation.UserControls
{
    /// <summary>
    /// Interaction logic for ViewCampaignsFundraisingCampaignUserControl.xaml
    /// </summary>
    public partial class ViewCampaignsFundraisingCampaignUserControl : UserControl
    {
        public delegate void DeletedAction();
        public event DeletedAction CampaignDeleted;
        public static double TitleSectionWidth { get; set; } = 200;
        public static double StartDateSectionWidth { get; set; } = 200;
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        public FundraisingCampaignVM FundraisingCampaign { get; set; }
        public bool UseAlternateColors { get; set; }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/20
        /// 
        /// </summary>
        /// <param name="fundraisingCampaign">The campaign associated with this control</param>
        /// <param name="useAlternateColors">Whether or not to use the alternate color pattern</param>
        public ViewCampaignsFundraisingCampaignUserControl(FundraisingCampaignVM fundraisingCampaign, bool useAlternateColors)
        {
            FundraisingCampaign = fundraisingCampaign;
            UseAlternateColors = useAlternateColors;
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).ContextMenu.IsOpen = true;
        }

        private void menuEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(Development.Fundraising.AddEditViewFundraisingCampaignPage.GetEditFundraisingCampaignPage(FundraisingCampaign));
        }

        private void menuView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(Development.Fundraising.AddEditViewFundraisingCampaignPage.GetViewFundraisingCampaignPage(FundraisingCampaign));
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (PromptWindow.ShowPrompt("Delete", "Are you sure you want to delete " + FundraisingCampaign.Title+"?",ButtonMode.DeleteCancel) == PromptSelection.Delete)
            {
                try
                {
                    _masterManager.FundraisingCampaignManager.RemoveFundraisingCampaign(FundraisingCampaign);
                    OnCampaignDeleted();
                }
                catch (Exception ex)
                {
                    PromptWindow.ShowPrompt("Error", ex.Message);
                }
            }
        }

        protected virtual void OnCampaignDeleted()
        {
            DeletedAction deletedAction = CampaignDeleted;
            deletedAction?.Invoke();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new WpfPresentation.Fundraising.UpdateFundraisingCampaign(FundraisingCampaign));
        }
    }
}
