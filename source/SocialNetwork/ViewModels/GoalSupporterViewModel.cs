using System.Collections.Generic;
using SocialNetwork.Model.Models;

namespace SocialNetwork.Web.ViewModels
{
    public class GoalSupporterViewModel
    {
        public int GoalId { get; set; }

        public Goal Goal { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}