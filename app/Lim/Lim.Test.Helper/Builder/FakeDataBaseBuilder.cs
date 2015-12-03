using Lim.Core;
using Lim.Domain.EventStore;
using Lim.Test.Helper.Fakes.Repository;

namespace Lim.Test.Helper.Builder
{
    public class FakeDataBaseBuilder
    {
        //public static IWriteOnlyRepository ForDataSetDetailDtoRepository()
        //{
        //    return new FakeDataSetDetailDtoRepository();
        //}

        public static IWriteOnlyRepository ForDataSetDtoRepository()
        {
            return new FakeDataSetRepository();
        }

        public static IEventStoreRepository ForEventStore()
        {
            return new FakeEventStoreRepository();
        }
    }
}
