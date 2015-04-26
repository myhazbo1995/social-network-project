using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Data;
using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
using SocialNetwork.Core.Common;
using SocialNetwork.Service.Properties;
using SocialNetwork.Data.Repository;
using System;
namespace SocialNetwork.Service
{

    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPostByDefault(string userid);
        IEnumerable<Post> GetPosts(string userid);
        IEnumerable<Post> GetPostsbyPopularity(string userid);
        IEnumerable<Post> GetPostsofFollowingByPopularity(string userid);
        IEnumerable<Post> GetPublicPostsbyPopularity();
        IEnumerable<Post> GetPostsofFollowing(string userid);
        Post GetLastCreatedPost(string userid);
        IEnumerable<Post> GetTop20PostsofFollowing(string userid);
        IEnumerable<Post> GetTop20Posts(string userid);
        IEnumerable<Post> GetMyPosts(string userid);
        Post GetPost(int id);
        void CreatePost(Post post);
        void EditPost(Post postToEdit);
        void DeletePost(int id);
        void SavePost();
        IEnumerable<Post> SearchPost(string post);

        IEnumerable<Post> GetPostsByPage(string userId, int currentPage, int noOfRecords, string sortBy, string filterBy);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IFollowUserRepository followUserrepository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, IFollowUserRepository followUserRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
            this.followUserrepository = followUserRepository;
        }

        #region IPostService Members

        public IEnumerable<Post> GetPosts()
        {
            var post = postRepository.GetAll().OrderByDescending(g => g.CreatedDate);
            return post;
        }

        public IEnumerable<Post> GetPostByDefault(string userid)
        {
            var post = postRepository.GetMany(g => (g.UserId == userid)).OrderByDescending(g => g.CreatedDate);
            return post;
        }

        public IEnumerable<Post> GetPostsofFollowing(string userid)
        {
            var posts = (from g in postRepository.GetAll() where (from f in followUserrepository.GetMany(fol => fol.FromUserId == userid) select f.ToUserId).ToList().Contains(g.UserId) select g).OrderByDescending(g => g.CreatedDate);
            return posts;
        }
        public IEnumerable<Post> GetPostsofFollowingByPopularity(string userid)
        {
            var posts = (from g in postRepository.GetAll() where (from f in followUserrepository.GetMany(fol => fol.FromUserId == userid) select f.ToUserId).ToList().Contains(g.UserId) select g).OrderByDescending(g => g.Viewed);
            return posts;
        }


        public IEnumerable<Post> GetPublicPostsbyPopularity()
        {
            var posts = postRepository.GetAll().OrderByDescending(g => g.Viewed).ToList();
            return posts;
        }
        public Post GetLastCreatedPost(string userid)
        {
            var post = postRepository.GetMany(g => g.UserId == userid).Last();
            return post;
        }
        public IEnumerable<Post> GetPosts(string userid)
        {

            var posts = postRepository.GetMany(g => (g.UserId == userid)).OrderByDescending(g => g.PostId).ToList();
            return posts;
        }
        public IEnumerable<Post> GetPostsbyPopularity(string userid)
        {

            var posts = postRepository.GetMany(g => (g.UserId == userid)).OrderByDescending(g => g.Viewed).ToList();
            return posts;
        }

        public IEnumerable<Post> GetMyPosts(string userid)
        {

            var posts = postRepository.GetMany(g => (g.UserId == userid)).OrderByDescending(g => g.PostId).ToList();
            return posts;
        }

        public IEnumerable<Post> GetTop20PostsofFollowing(string userid)
        {
            var posts = (from g in postRepository.GetAll() where (from f in followUserrepository.GetMany(fol => fol.FromUserId == userid) select f.ToUserId).ToList().Contains(g.UserId) select g);
            return posts;
        }

        public IEnumerable<Post> GetTop20Posts(string userid)
        {

            var posts = postRepository.GetMany(g => g.UserId == userid).OrderByDescending(g => g.CreatedDate).Take(20).ToList();
            return posts;
        }
        public IEnumerable<Post> SearchPost(string Post)
        {
            return postRepository.GetMany(g => g.PostName.ToLower().Contains(Post.ToLower())).OrderBy(g => g.PostName);
        }
        public Post GetPost(int id)
        {
            var post = postRepository.GetById(id);
            return post;
        }

        public void CreatePost(Post post)
        {
            postRepository.Add(post);
            SavePost();
        }

        public void DeletePost(int id)
        {
            var post = postRepository.GetById(id);
            postRepository.Delete(post);
            SavePost();
        }

        public void EditPost(Post postToEdit)
        {
            postRepository.Update(postToEdit);
            SavePost();
        }

        public IEnumerable<Post> GetPostsByPage(string userId, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            return postRepository.GetPostsByPage(userId, currentPage, noOfRecords, sortBy, filterBy);
        }


        public void SavePost()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
