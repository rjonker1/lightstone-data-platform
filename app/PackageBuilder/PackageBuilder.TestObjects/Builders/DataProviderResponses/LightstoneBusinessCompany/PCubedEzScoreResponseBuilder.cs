using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class PCubedEzScoreResponseBuilder
    {
        private IEnumerable<IRespondWithEzScore> _ezScoreRecords;
        public IProvideDataFromPCubedEzScore Build()
        {
            return new PCubedEzScoreResponse(_ezScoreRecords);
        }

        public PCubedEzScoreResponseBuilder With(params IRespondWithEzScore[] ezScoreRecords)
        {
            _ezScoreRecords = ezScoreRecords;
            return this;
        }
    }
}