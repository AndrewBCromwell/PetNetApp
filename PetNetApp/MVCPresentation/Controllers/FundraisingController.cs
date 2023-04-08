using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using LogicLayerInterfaces;
using DataObjects;
using MVCPresentation.Models;
using System.Threading.Tasks;

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

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/04/08
        /// 
        /// Controller method for /Fundraising/Campaign to view a single campaign
        /// </summary>
        /// <param name="campaign">the id of the campaign to view</param>
        /// <param name="partial">whether to render this view as a whole page or for a modal</param>
        /// <returns></returns>
        public async Task<ActionResult> Campaign(int? campaign, bool partial = false)
        {
            await Task.Delay(2000);
            FundraisingCampaignVM fundraisingCampaign = null;
            try
            {

                if (campaign == null
                    || (fundraisingCampaign = _masterManger.FundraisingCampaignManager.RetrieveFundraisingCampaignByFundraisingCampaignId(campaign.Value)) == null
                    || !fundraisingCampaign.Active)
                {
                    return RedirectToAction("Campaigns");
                }
                fundraisingCampaign.Sponsors = _masterManger.InstitutionalEntityManager.RetrieveFundraisingSponsorsByCampaignId(campaign.Value);
                fundraisingCampaign.FundraisingEventList = _masterManger.FundraisingEventManager.RetrieveAllFundraisingEventsByCampaignId(campaign.Value).Cast<FundraisingEvent>().ToList();

                if (partial)
                {
                    return PartialView(fundraisingCampaign);
                }
                else
                {
                    return View(fundraisingCampaign);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + ex.InnerException.Message;

                if (partial)
                {
                    return PartialView("Error");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/04/08
        /// 
        /// Controller method for /Fundraising/Campaigns to view all public campaigns
        /// </summary>
        /// <param name="campaignsViewModel">The model holding the different parameters for searching and campaign data</param>
        /// <param name="Page">The current page were on</param>
        /// <returns></returns>
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