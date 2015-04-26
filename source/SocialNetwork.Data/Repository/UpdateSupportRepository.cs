using System;
using SocialNetwork.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetwork.Data.Infrastructure;

namespace SocialNetwork.Data.Repository
{
    class UpdateSupportRepository : RepositoryBase<UpdateSupport>, IUpdateSupportRepository
    {
        public UpdateSupportRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IUpdateSupportRepository : IRepository<UpdateSupport>
    {
    }
}
