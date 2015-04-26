using PagedList;
using SocialNetwork.Service;

namespace SocialNetwork.Web.ViewModels
{
    public class GroupsPageViewModel
    {
        public IPagedList<GroupsItemViewModel> GroupList { get; set; }

        public GroupFilter Filter { get; set; }
    }
}