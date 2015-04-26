using SocialNetwork.Model.Models;
using SocialNetwork.Data.Infrastructure;


namespace SocialNetwork.Data.Repository
{
    public class GroupGoalRepository : RepositoryBase<GroupGoal>, IGroupGoalRepository
    {
        public GroupGoalRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IGroupGoalRepository : IRepository<GroupGoal>
    {
    }
}
