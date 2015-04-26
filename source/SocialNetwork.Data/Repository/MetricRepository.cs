using SocialNetwork.Data.Infrastructure;
using SocialNetwork.Model.Models;
namespace SocialNetwork.Data.Repository
{
    public class MetricRepository: RepositoryBase<Metric>, IMetricRepository
        {
        public MetricRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IMetricRepository : IRepository<Metric>
    {
    }
}