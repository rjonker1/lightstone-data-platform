namespace Lace.Shared.Monitoring.Messages.Core
{

    internal interface IMonitorDataProviderMessages
    {
        void SendToBus<T>(T message) where T : class;
    }

    //internal interface IMonitorDataProviderAccounting : IMonitorDataProviderMessages
    //{
    //}

    //internal interface IMonitorDataProviderConfiguration : IMonitorDataProviderMessages
    //{
    //}

    //internal interface IMonitorDataProviderFault : IMonitorDataProviderMessages
    //{
    //}

    //internal interface IMonitorDataProviderPerformance : IMonitorDataProviderMessages
    //{
    //}

    //internal interface IMonitorDataProviderSecurity : IMonitorDataProviderMessages
    //{
    //}
}
