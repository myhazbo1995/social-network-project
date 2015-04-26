using SocialNetwork.Data.Models;

namespace SocialNetwork.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private SocialNetworkEntities dataContext;
    public SocialNetworkEntities Get()
    {
        return dataContext ?? (dataContext = new SocialNetworkEntities());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
