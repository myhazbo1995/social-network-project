using System.Collections.Generic;
using SocialNetwork.Model.Models;

namespace SocialNetwork.Web.ViewModels
{
    public class GroupUpdateSupportersViewModel
    {
        public int GroupUpdateId { get; set; }

        public GroupUpdate GroupUpdate { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}