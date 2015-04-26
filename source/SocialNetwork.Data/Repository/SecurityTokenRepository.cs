using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class SecurityTokenRepository: RepositoryBase<SecurityToken>, ISecurityTokenRepository
        {
        public SecurityTokenRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface ISecurityTokenRepository : IRepository<SecurityToken>
    {
    }
}