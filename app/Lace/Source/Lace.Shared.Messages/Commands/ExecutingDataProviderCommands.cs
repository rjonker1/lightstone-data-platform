using System;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class ExecutingDataProviderCommand
    {
        public Guid Id { get; private set; }
        public DataProvider DataProvider { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public DateTime Date { get; private set; }
        public Category Category { get; private set; }
        public string MetaData { get; private set; }
        public bool IsJson { get; private set; }

        public ExecutingDataProviderCommand()
        {

        }

        public ExecutingDataProviderCommand(Guid id, DataProvider dataProvider, string message, string payload,
            string metadata,
            DateTime date, Category category, bool isJson)
        {
            Id = id;
            DataProvider = dataProvider;
            Message = message;
            Payload = payload;
            Date = date;
            Category = category;
            MetaData = metadata;
            IsJson = isJson;
        }
    }



    //[Serializable]
    //public class StartExecutingDataProviderCommand
    //{
    //    public Guid Id { get; private set; }
    //    public string DataProvider { get; private set; }
    //    public int DataProviderId { get; private set; }
    //    public string Message { get; private set; }
    //    public string Payload { get; private set; }
    //    public DateTime Date { get; private set; }
    //    public string Category { get; private set; }
    //    public int CategoryId { get; private set; }

    //    private readonly DataProviderStopWatch _stopWatch;

    //    public StartExecutingDataProviderCommand()
            
    //    {

    //    }

    //    public StartExecutingDataProviderCommand(Guid id, DataProvider dataProvider, string message, string payload,
    //        DateTime date, DataProviderStopWatch stopWatch)
    //    {
    //        Id = id;
    //        DataProvider = dataProvider.ToString();
    //        DataProviderId = (int) dataProvider;
    //        Message = message;
    //        Payload = payload;
    //        Date = date;
    //        _stopWatch = stopWatch;
    //    }

    //    public void StartTimer()
    //    {
    //        _stopWatch.Start();
    //    }

    //}
}
