namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Base
{
    public interface IGetFinanceData
    {
        //IEnumerable<BmwFinanceDto> Get(object query, object request, object responseFactory);
        object Get(object query, object request, object responseFactory);
    }

    public interface IGetFinanceData<in T1, in T2, in T3, out T4> : IGetFinanceData
    {
        //IEnumerable<BmwFinanceDto> Get(T1 query, T2 request, T3 responseFactory);
        T4 Get(T1 query, T2 request, T3 responseFactory);
    }


}
