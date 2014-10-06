using Lace.Domain.Core.Contracts.DataProviders.Metric;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto.Metric
{
    public class Pair<T1, T2> : IPair<T1, T2>
    {
        public Pair()
        {
            Item1 = default(T1);
            Item2 = default(T2);
        }

        public Pair(T1 t1, T2 t2)
        {
            Item1 = t1;
            Item2 = t2;
        }

        public T1 Item1
        {
            get;
            private set;
        }

        public T2 Item2
        {
            get;
            private set;
        }
    }
}
