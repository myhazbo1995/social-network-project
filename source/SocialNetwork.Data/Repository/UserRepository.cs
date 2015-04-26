using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Data.Models;
using SocialNetwork.Model.Models;
using System;
using System.Linq.Expressions;
namespace SocialNetwork.Data.Repository
{
    public class UserRepository: RepositoryBase<ApplicationUser>, IUserRepository
        {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        
    }
}