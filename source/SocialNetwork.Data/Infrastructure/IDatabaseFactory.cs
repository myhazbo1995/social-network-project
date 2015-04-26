using System;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        SocialNetworkEntities Get();
    }
}
