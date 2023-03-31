using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using LogicLayerInterfaces;
using DataObjects;
using MVCPresentation.Models;

namespace MVCPresentation.Controllers
{
    public class FundraisingController : Controller
    {
        private MasterManager _masterManger = MasterManager.GetMasterManager();
        // GET: Fundraising
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Campaign(int? campaign)
        {
            return View(new FundraisingCampaign());
        }

        public ActionResult Campaigns(CampaignsViewModel campaignsViewModel, int Page = 1)
        {
            PagingInfo pagingInfo = campaignsViewModel.PagingInfo;
            pagingInfo.CurrentPage = Page;
            pagingInfo.ItemsPerPage = 10;

            List<FundraisingCampaignVM> campaigns = null;
            try
            {
                campaignsViewModel.Shelters = _masterManger.ShelterManager.GetShelterList().Where(shelter => shelter.ShelterActive).OrderBy(sh => sh.ShelterName);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }

            try
            {
                if (campaignsViewModel.Shelter != null)
                {
                    campaigns = _masterManger.FundraisingCampaignManager.RetrieveAllActiveFundraisingCampaignsByShelterId(campaignsViewModel.Shelter.Value);
                }
                else
                {
                    campaigns = _masterManger.FundraisingCampaignManager.RetrieveAllActiveFundraisingCampaigns();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + "\n\n" + ex.InnerException.Message;
                return View("Error");
            }

            Func<FundraisingCampaignVM, string> sortMethod = null;
            switch (campaignsViewModel.Sort)
            {
                case null:
                case SortingMethod.StartDate:
                    sortMethod = new Func<FundraisingCampaign, string>(fc => fc.StartDate != null ? fc.StartDate.Value.Ticks.ToString() : DateTime.MaxValue.Ticks.ToString());
                    break;
                case SortingMethod.Title:
                    sortMethod = new Func<FundraisingCampaign, string>(fc => fc.Title);
                    break;
            }

            Func<FundraisingCampaignVM, bool> filterMethod = null;
            switch (campaignsViewModel.Filter)
            {
                case null:
                case FilterMethod.Ongoing:
                    filterMethod = new Func<FundraisingCampaign, bool>(fc => !fc.Complete && fc.Active);
                    break;
                case FilterMethod.Completed:
                    filterMethod = new Func<FundraisingCampaign, bool>(fc => fc.Complete && fc.Active);
                    break;
                case FilterMethod.Both:
                    filterMethod = new Func<FundraisingCampaign, bool>(fc => fc.Active);
                    break;
            }

            Func<FundraisingCampaignVM, bool> searchForTextInFundraisingCampaign = (campaign) => true;

            if (campaignsViewModel.Search != null && campaignsViewModel.Search.Trim() != "")
            {
                campaignsViewModel.Search = campaignsViewModel.Search.Trim();
                searchForTextInFundraisingCampaign = (fundraisingCampaign) =>
                {
                    return fundraisingCampaign.Title?.IndexOf(campaignsViewModel.Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            fundraisingCampaign.Description?.IndexOf(campaignsViewModel.Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            (fundraisingCampaign.StartDate != null ? fundraisingCampaign.StartDate.Value.ToString("MM/dd/yyyy").Contains(campaignsViewModel.Search) : false) ||
                            (fundraisingCampaign.EndDate != null ? fundraisingCampaign.EndDate.Value.ToString("MM/dd/yyyy").Contains(campaignsViewModel.Search) : false) ||
                            (fundraisingCampaign.StartDate != null ? fundraisingCampaign.StartDate.Value.ToString("M/d/yyyy").Contains(campaignsViewModel.Search) : false) ||
                            (fundraisingCampaign.EndDate != null ? fundraisingCampaign.EndDate.Value.ToString("M/d/yyyy").Contains(campaignsViewModel.Search) : false);
                };
            }


            campaigns = campaigns.OrderBy(sortMethod).Where(filterMethod).Where(searchForTextInFundraisingCampaign).ToList();
            pagingInfo.TotalItems = campaigns.Count;

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }
            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            campaignsViewModel.Campaigns = campaigns.Skip(pagingInfo.ItemsPerPage * (pagingInfo.CurrentPage - 1)).Take(pagingInfo.ItemsPerPage);
            return View(campaignsViewModel);
        }
    }
}