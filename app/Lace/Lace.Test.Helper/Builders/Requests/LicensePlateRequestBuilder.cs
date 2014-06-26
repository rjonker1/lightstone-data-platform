﻿using Lace.Request;
using Lace.Test.Helper.Mothers.Requests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateRequestBuilder
    {
        private ILaceRequest _request;
        
        public ILaceRequest ForIvid()
        {
            _request = new LicensePlateNumberIvidOnlyRequest();
            return _request;
        }

        public ILaceRequest ForAudatex()
        {
            _request = new LicensePlateNumberAudatexOnlyRequest();
            return _request;
        }

        public ILaceRequest ForIvidTitleHolder()
        {
            _request = new LicensePlateNumberIvidTitleHolderOnlyRequest();
            return _request;
        }

        public ILaceRequest ForRgtVin()
        {
            _request = new LicensePlateNumberRgtVinOnlyRequest();
            return _request;
        }

        public ILaceRequest ForAllSources()
        {
            _request = new LicensePlateNumberSliverAllServicesRequest();
            return _request;
        }

    }
}