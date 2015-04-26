using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class GroupCommentRepository : RepositoryBase<GroupComment>, IGroupCommentRepository
    {
        public GroupCommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IGroupCommentRepository : IRepository<GroupComment>
    {
    }
}