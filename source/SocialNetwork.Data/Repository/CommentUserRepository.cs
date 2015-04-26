using SocialNetwork.Model.Models;
using SocialNetwork.Data.Infrastructure;

namespace SocialNetwork.Data.Repository
{
    public class CommentUserRepository : RepositoryBase<CommentUser>, ICommentUserRepository
    {
        public CommentUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        
    }
    public interface ICommentUserRepository : IRepository<CommentUser>
    {
        
    }
}
