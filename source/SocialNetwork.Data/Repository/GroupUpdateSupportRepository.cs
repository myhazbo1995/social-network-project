using System;
using SocialNetwork.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetwork.Data.Infrastructure;

namespace SocialNetwork.Data.Repository
{
    class GroupUpdateSupportRepository : RepositoryBase<GroupUpdateSupport>, IGroupUpdateSupportRepository
    {
        public GroupUpdateSupportRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IGroupUpdateSupportRepository : IRepository<GroupUpdateSupport>
    {
    }
}
