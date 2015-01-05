using System;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Events;

namespace Monitoring.Test.Helper.Builder.DataProviderEvents
{
    public class DataProviderEvents
    {
        public DataProviderCallEndedEvent ForDataProviderCallEndedEvent(Guid aggreateId, DataProvider dataProvider,
            Category category)
        {
            return new DataProviderCallEndedEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderExecutingEvent ForDataProviderExecutingEvent(Guid aggreateId, DataProvider dataProvider,
            Category category)
        {
            return new DataProviderExecutingEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderHasConfigurationEvent ForDataProviderHasConfigurationEvent(Guid aggreateId,
            DataProvider dataProvider,
            Category category)
        {
            return new DataProviderHasConfigurationEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderHasExecutedEvent ForDataProviderHasExecutedEvent(Guid aggreateId, DataProvider dataProvider,
            Category category)
        {
            return new DataProviderHasExecutedEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderHasFaultEvent ForDataProviderHasFaultEvent(Guid aggreateId, DataProvider dataProvider,
            Category category)
        {
            return new DataProviderHasFaultEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderHasSecurityEvent ForDataProviderHasSecurityEvent(Guid aggreateId, DataProvider dataProvider,
            Category category)
        {
            return new DataProviderHasSecurityEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderasBeenTransformedEvent ForDataProviderasBeenTransformedEvent(Guid aggreateId,
            DataProvider dataProvider,
            Category category)
        {
            return new DataProviderasBeenTransformedEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }

        public DataProviderIsCalledEvent ForDataProviderIsCalledEvent(Guid aggreateId, DataProvider dataProvider,
            Category category)
        {
            return new DataProviderIsCalledEvent(aggreateId, dataProvider, category, "{}", "{}",
                "{}", DateTime.UtcNow, true);
        }
    }
}
