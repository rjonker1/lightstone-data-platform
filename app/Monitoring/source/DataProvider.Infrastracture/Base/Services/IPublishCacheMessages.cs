namespace DataProvider.Infrastructure.Base.Services
{
    public interface IPublishCacheMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
