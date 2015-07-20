namespace PackageBuilder.Core.Repositories
{
    public interface ICacheRepository <T>
    {
        T CacheGet(object key);
        T CacheSave(object key);
        T CacheDelete(object key);
    }
}