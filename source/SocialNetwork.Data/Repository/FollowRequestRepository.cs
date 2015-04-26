using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class FollowRequestRepository : RepositoryBase<FollowRequest>, IFollowRequestRepository
    {
        public FollowRequestRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IFollowRequestRepository : IRepository<FollowRequest>
    {
    }
}