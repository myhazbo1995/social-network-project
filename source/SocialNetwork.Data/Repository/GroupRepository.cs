using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;

namespace SocialNetwork.Data.Repository
{
    public class GroupRepository:RepositoryBase<Group>, IGroupRepository
        {
        public GroupRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IGroupRepository : IRepository<Group>
    {
    }
   
}
