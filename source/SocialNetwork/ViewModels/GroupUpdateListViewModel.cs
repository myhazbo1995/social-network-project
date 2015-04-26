using System;
using System.Collections.Generic;
using SocialNetwork.Model.Models;
using System.Linq;
using System.Web;

namespace SocialNetwork.Web.ViewModels
{
    public class GroupUpdateListViewModel
    {
        public IEnumerable<GroupUpdateViewModel> GroupUpdates { get; set; }

        public double? Target { get; set; }

        public Metric Metric { get; set; }
    }
}