namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Base
{
    public abstract class AbstractGetFinanceRequestFactory<T1, T2, T3, T4> : IGetFinanceData<T1, T2, T3,T4>
    {
        public abstract T4 Get(T1 query, T2 request, T3 responseFactory);

        public object Get(object query, object request, object responseFactory)
        {
            return Get((T1)query, (T2)request, (T3)responseFactory);
        }
    }
}
