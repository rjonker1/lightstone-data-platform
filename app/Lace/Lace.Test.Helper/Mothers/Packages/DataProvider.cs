using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class DataProvider : IAmDataProvider
    {
        private readonly DataProviderName _name;
        private readonly decimal _cost;
        private readonly decimal _rsp;
        private readonly IAmDataProviderRequest _request;

        //public DataProvider(DataProviderName name, decimal cost, decimal rsp)
        //{
        //    _name = name;
        //    _cost = cost;
        //    _rsp = rsp;
        //}

        public DataProvider(DataProviderName name, decimal cost, decimal rsp, IAmDataProviderRequest request)
        {
            _name = name;
            _cost = cost;
            _rsp = rsp;
            _request = request;
        }

        public DataProviderName Name
        {
            get { return _name; }
        }

       // public IEnumerable<IAmRequestField> RequestFields { get; private set; }

        public decimal CostPrice
        {
            get { return _cost; }
        }

        public decimal RecommendedPrice
        {
            get { return _rsp; }
        }


        //public IAmDataProviderRequest Request
        //{
        //    get
        //    {
        //        return _request;
        //    }
        //}


        public ICollection<IAmDataProviderRequest> Request
        {
            get
            {
                return new[] {_request};
            }
        }
    }
}
