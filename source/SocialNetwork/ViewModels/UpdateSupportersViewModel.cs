using System.Collections.Generic;
using SocialNetwork.Model.Models;

namespace SocialNetwork.Web.ViewModels
{
    public class UpdateSupportersViewModel
    {
        public int UpdateId { get; set; }

        public Update Update { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}