using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class GroupRequestRepository: RepositoryBase<GroupRequest>, IGroupRequestRepository
        {
        public GroupRequestRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IGroupRequestRepository : IRepository<GroupRequest>
    {
    }
}