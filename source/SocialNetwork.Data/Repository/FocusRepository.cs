using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class FocusRepository: RepositoryBase<Focus>, IFocusRepository
        {
        public FocusRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IFocusRepository : IRepository<Focus>
    {
    }
}