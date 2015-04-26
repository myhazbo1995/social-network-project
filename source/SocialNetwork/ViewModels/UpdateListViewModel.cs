using System.Collections.Generic;
using SocialNetwork.Model.Models;

namespace SocialNetwork.Web.ViewModels
{
    public class UpdateListViewModel
    {
        public IEnumerable<UpdateViewModel> Updates { get; set; }

        public double? Target { get; set; }

        public Metric Metric { get; set; }

    }
}