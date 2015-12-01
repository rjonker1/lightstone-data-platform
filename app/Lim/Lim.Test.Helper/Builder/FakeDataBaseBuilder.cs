using Lim.Core;
using Lim.Test.Helper.Fakes.Repository;

namespace Lim.Test.Helper.Builder
{
    public class FakeDataBaseBuilder
    {
        public static IWriteOnlyRepository ForDataSetDetailDtoRepository()
        {
            return new FakeDataSetDetailDtoRepository();
        }

        public static IWriteOnlyRepository ForDataSetDtoRepository()
        {
            return new FakeDataSetDtoRepository();
        }
    }
}
