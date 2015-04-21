using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class DataProvider : IAmDataProvider
    {
        private readonly DataProviderName _name;
        private readonly decimal _cost;
        private readonly decimal _rsp;

        public DataProvider(DataProviderName name, decimal cost, decimal rsp)
        {
            _name = name;
            _cost = cost;
            _rsp = rsp;
        }

        public DataProvider(DataProviderName name, decimal cost, decimal rsp, IAmRequest request)
        {
            _name = name;
            _cost = cost;
            _rsp = rsp;
            Request = request;
        }

        public DataProviderName Name
        {
            get { return _name; }
        }

        public IAmRequest Request { get; private set; }

        public decimal CostPrice
        {
            get { return _cost; }
        }

        public decimal RecommendedPrice
        {
            get { return _rsp; }
        }
    }
}
