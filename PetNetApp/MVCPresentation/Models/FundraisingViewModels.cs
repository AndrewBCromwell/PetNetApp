using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;
using System.ComponentModel.DataAnnotations;

namespace MVCPresentation.Models
{
    public class CampaignsViewModel
    {
        public PagingInfo PagingInfo { get; private set; }
        public SortingMethod SortingMethod { get; set; }
        public FilterMethod FilterMethod { get; set; }
        public IEnumerable<FundraisingCampaignVM> Campaigns { get; set; }
        public string Search { get; set; }
        public int? Shelter { get; set; }
        public CampaignsViewModel()
        {
            PagingInfo = new PagingInfo();
        }
    }

    public enum SortingMethod
    {
        [Display(Name = "Start Date")]
        StartDate,
        Title
    }
    public enum FilterMethod
    {
        Ongoing,
        Completed,
        Both,
        Deleted
    }
}