using SocialNetwork.Model.Models;
using SocialNetwork.Data.Infrastructure;

namespace SocialNetwork.Data.Repository
{
    public class GroupCommentUserRepository : RepositoryBase<GroupCommentUser>, IGroupCommentUserRepository
    {
        public GroupCommentUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        
    }
    public interface IGroupCommentUserRepository : IRepository<GroupCommentUser>
    {
        
    }
}
