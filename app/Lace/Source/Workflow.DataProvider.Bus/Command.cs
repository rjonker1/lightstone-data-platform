using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Workflow.DataProvider.Bus.Domain.Publisher;
using Workflow.DataProvider.Bus.Domain.Repository;

namespace Workflow.DataProvider.Bus
{
    [Queue("DataPlatform.DataProvider.Commands", ExchangeName = "DataPlatform.DataProvider.Commands")]
    [DataContract]
    public class SendRequestToDataProviderCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        public SendRequestToDataProviderCommand(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

    }

    public class Request
    {
        //private readonly ICommandRepository _repository;
        private readonly IAdvancedBus _bus;
        private Request(Guid id)
        {
            
        }

        public Request(IAdvancedBus bus)
        {
            //_repository = repository;
            _bus = bus;
        }

        public Request(Guid requestId, DateTime date)
            : this(requestId)
        {
            new DataProviderEventBus(BusFactory.CreateAdvancedBus("workflow/dataprovider/queue")).Send(new RequestToDataProvider(Guid.NewGuid(), requestId, date), "DataPlatform.DataProvider.Events", "DataPlatform.DataProvider.Events");
        }

        public static Request ReceiveRequest(Guid requestId, DateTime date)
        {
            return new Request(requestId, date);
        } 
    }

    [Queue("DataPlatform.DataProvider.Events", ExchangeName = "DataPlatform.DataProvider.Events")]
    [DataContract]
    public class RequestToDataProvider : IPublishableMessage
    {
        public RequestToDataProvider(Guid id, Guid requestId, DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
