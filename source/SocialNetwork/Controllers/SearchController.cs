using AutoMapper;
using SocialNetwork.Model.Models;
using SocialNetwork.Service;
using SocialNetwork.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IGoalService goalService;
        private readonly IUserService userService;
        private readonly IGroupService groupService;

        public SearchController(IGoalService goalService, IUserService userService, IGroupService groupService)
        {
            this.goalService = goalService;
            this.userService = userService;
            this.groupService = groupService;
        }

        public ViewResult SearchAll(string searchText)
        {
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                Goals = Mapper.Map<IEnumerable<Goal>, IEnumerable<GoalViewModel>>(goalService.SearchGoal(searchText)),
                Users = userService.SearchUser(searchText),
                Groups = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groupService.SearchGroup(searchText)),
                SearchText = searchText
            };
            ViewBag.searchtext = searchText;
            return View("SearchResult", searchViewModel);
        }

    }
}