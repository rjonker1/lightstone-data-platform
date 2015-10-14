using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Packages
{
    //public class CriticalDataProvider : IAmDataProvider
    //{
    //    private readonly DataProviderName _name;
    //    private readonly decimal _cost;
    //    private readonly decimal _rsp;
    //    private readonly IAmDataProviderRequest _request;
    //    private readonly IBillStateIndicator _indicator;

    //    public CriticalDataProvider(DataProviderName name, decimal cost, decimal rsp, IAmDataProviderRequest request, IBillStateIndicator indicator)
    //    {
    //        _name = name;
    //        _cost = cost;
    //        _rsp = rsp;
    //        _request = request;
    //        _indicator = indicator;
    //    }

    //    public DataProviderName Name
    //    {
    //        get { return _name; }
    //    }

    //    public decimal CostPrice
    //    {
    //        get { return _cost; }
    //    }

    //    public decimal RecommendedPrice
    //    {
    //        get { return _rsp; }
    //    }


    //    public ICollection<IAmDataProviderRequest> Request
    //    {
    //        get { return new[] {_request}; }
    //    }


    //    public IBillStateIndicator BillablleState
    //    {
    //        get { return _indicator; }
    //    }
    //}

    public class DataProvider : IAmDataProvider
    {
        private readonly DataProviderName _name;
        private readonly decimal _cost;
        private readonly decimal _rsp;
        private readonly IAmDataProviderRequest _request;
        private readonly IBillStateIndicator _indicator;


        public DataProvider(DataProviderName name, decimal cost, decimal rsp, IAmDataProviderRequest request, IBillStateIndicator indicator)
        {
            _name = name;
            _cost = cost;
            _rsp = rsp;
            _request = request;
            _indicator = indicator;
        }

        public DataProviderName Name
        {
            get { return _name; }
        }

        public decimal CostPrice
        {
            get { return _cost; }
        }

        public decimal RecommendedPrice
        {
            get { return _rsp; }
        }

        public ICollection<IAmDataProviderRequest> Request
        {
            get { return new[] {_request}; }
        }

        public IBillStateIndicator BillablleState
        {
            get { return _indicator; }
        }
    }
}