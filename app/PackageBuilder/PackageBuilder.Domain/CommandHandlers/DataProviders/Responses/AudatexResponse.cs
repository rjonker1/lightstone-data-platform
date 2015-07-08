using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class AudatexResponse
    {
        public IPointToLaceProvider DefaultAudatexResponse()
        {
            var audatex =
                new Lace.Domain.Core.Entities.AudatexResponse(new List<IProvideAccidentClaim>()
                {
                    new AccidentClaim(DateTime.MinValue, string.Empty, string.Empty, DateTime.MinValue, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                        0.0M, 0.0M, DateTime.MinValue, string.Empty, string.Empty, string.Empty, string.Empty)
                });

            return audatex;
        } 
    }
}