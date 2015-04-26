using SocialNetwork.Model.Models;
using SocialNetwork.Data.Infrastructure;

namespace SocialNetwork.Data.Repository
{
    public class GroupUpdateUserRepository : RepositoryBase<GroupUpdateUser>, IGroupUpdateUserRepository
    {
        public GroupUpdateUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        
    }
    public interface IGroupUpdateUserRepository : IRepository<GroupUpdateUser>
    {
       
    }
}
