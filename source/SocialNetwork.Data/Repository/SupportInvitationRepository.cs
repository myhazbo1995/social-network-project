using SocialNetwork.Model.Models;
using SocialNetwork.Data.Infrastructure;

namespace SocialNetwork.Data.Repository
{
    public class SupportInvitationRepository : RepositoryBase<SupportInvitation>, ISupportInvitationRepository
    {
        public SupportInvitationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface ISupportInvitationRepository : IRepository<SupportInvitation>
    {
    }
}
