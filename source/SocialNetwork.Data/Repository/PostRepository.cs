using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Data.Repository;
using SocialNetwork.Data.Models;
using System.Data.Entity;
using System;
namespace SocialNetwork.Data.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {

        public PostRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }


        public IEnumerable<Post> GetPostsByPage(string userId, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            var skipPosts = noOfRecords * currentPage;

            var Posts = this.GetAll();

            //for filter options
            //Following Posts
            //if (filterBy == "My Followings Posts")
            //{
            //    Posts = from g in Posts
            //            where (from f in this.DataContext.FollowUser.Where(fol => fol.FromUserId == userId) select f.ToUserId).ToList().Contains(g.UserId)
            //            select g;
            //}
            ////User Posts
            //else if (filterBy == "My Posts")
            //{
            //    Posts = Posts.Where(g => g.UserId == userId);
            //}
            ////Followed Posts
            //else if (filterBy =="My Followed Posts")
            //{
            //    Posts = from g in Posts
            //            join s in this.DataContext.Support on g.PostId equals s.PostId
            //            where s.UserId == userId
            //            select g;
            //}

            //for sorting based on date and popularity
            Posts = (sortBy == "Date") ? Posts.OrderByDescending(g => g.CreatedDate) : Posts;
            Posts = (sortBy == "Popularity") ? Posts.OrderByDescending(g => g.Viewed) : Posts;

            Posts = Posts.Skip(skipPosts).Take(noOfRecords);

            return Posts.ToList();
        }
    }

    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// /// Method will return Posts as different page with specified number of records ,filter condition and sort criteria
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        IEnumerable<Post> GetPostsByPage(string userId, int currentPage, int noOfRecords, string sortBy, string filterBy);
    }
}