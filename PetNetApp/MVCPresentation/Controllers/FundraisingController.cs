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
        public ActionResult Campaigns(int page = 1, int? shelter = 100000, SortingMethod sort = SortingMethod.StartDate, FilterMethod filter = FilterMethod.Ongoing, string search = null)
        {
            CampaignsViewModel campaignsViewModel = new CampaignsViewModel();
            PagingInfo pagingInfo = campaignsViewModel.PagingInfo;
            campaignsViewModel.FilterMethod = filter;
            campaignsViewModel.SortingMethod = sort;
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = 1;
            campaignsViewModel.Shelter = shelter;
            campaignsViewModel.Search = search;

            List<FundraisingCampaignVM> campaigns = null;
            if (shelter != null)
            {
                try
                {
                    campaigns = _masterManger.FundraisingCampaignManager.RetrieveAllFundraisingCampaignsByShelterId(shelter.Value);


                    Func<FundraisingCampaignVM, string> sortMethod = null;
                    switch (sort)
                    {
                        case SortingMethod.Title:
                            sortMethod = new Func<FundraisingCampaign, string>(fc => fc.Title);
                            break;
                        case SortingMethod.StartDate:
                            sortMethod = new Func<FundraisingCampaign, string>(fc => fc.StartDate != null ? fc.StartDate.Value.Ticks.ToString() : DateTime.MaxValue.Ticks.ToString());
                            break;
                    }

                    Func<FundraisingCampaignVM, bool> filterMethod = null;
                    switch (filter)
                    {
                        case FilterMethod.Completed:
                            filterMethod = new Func<FundraisingCampaign, bool>(fc => fc.Complete && fc.Active);
                            break;
                        case FilterMethod.Both:
                            filterMethod = new Func<FundraisingCampaign, bool>(fc => fc.Active);
                            break;
                        case FilterMethod.Deleted:
                            filterMethod = new Func<FundraisingCampaignVM, bool>(fc => !fc.Active);
                            break;
                        case FilterMethod.Ongoing:
                            filterMethod = new Func<FundraisingCampaign, bool>(fc => !fc.Complete && fc.Active);
                            break;
                    }

                    Func<FundraisingCampaignVM, bool> searchForTextInFundraisingCampaign = (campaign) => true;

                    if (search != null && search.Trim() != "")
                    {
                        search = search.Trim();
                        searchForTextInFundraisingCampaign = (fundraisingCampaign) =>
                        {
                            return fundraisingCampaign.Title?.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    fundraisingCampaign.Description?.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    (fundraisingCampaign.StartDate != null ? fundraisingCampaign.StartDate.Value.ToString("MM/dd/yyyy").Contains(search) : false) ||
                                    (fundraisingCampaign.EndDate != null ? fundraisingCampaign.EndDate.Value.ToString("MM/dd/yyyy").Contains(search) : false) ||
                                    (fundraisingCampaign.StartDate != null ? fundraisingCampaign.StartDate.Value.ToString("M/d/yyyy").Contains(search) : false) ||
                                    (fundraisingCampaign.EndDate != null ? fundraisingCampaign.EndDate.Value.ToString("M/d/yyyy").Contains(search) : false);
                        };
                    }


                    campaigns = campaigns.OrderBy(sortMethod).Where(filterMethod).Where(searchForTextInFundraisingCampaign).ToList();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            else
            {
                return new ViewResult();
            }
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