using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class UpdateRepository: RepositoryBase<Update>, IUpdateRepository
        {
        public UpdateRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IUpdateRepository : IRepository<Update>
    {
    }
}