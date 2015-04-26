using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class GoalStatusRepository : RepositoryBase<GoalStatus>, IGoalStatusRepository
    {
        public GoalStatusRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IGoalStatusRepository : IRepository<GoalStatus>
    {
    }
}