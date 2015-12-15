using Lim.Domain.EventStore;
using Lim.Test.Helper.Fakes.Repository;

namespace Lim.Test.Helper.Builder
{
    public class FakeDataBaseBuilder
    {
        public static IEventStoreRepository ForEventStore()
        {
            return new FakeEventStoreRepository();
        }
    }
}
