﻿using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Anpr.AnprServiceReference;
using Lace.Domain.DataProviders.Anpr.Core.Contracts;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure.Dto
{
    public class BuildAnprRequest : IBuildTheRequestForAnpr
    {
        private readonly IHaveCoOrdinates _request;

        public AnprSubComplexType AnprRequest { get; private set; }

        public BuildAnprRequest(IHaveCoOrdinates request)
        {
            _request = request;
        }

        public IBuildTheRequestForAnpr Build()
        {
            AnprRequest = new AnprSubComplexType()
            {
                ImagetoAnpr = _request.Image
            };

            return this;
        }
    }
}
