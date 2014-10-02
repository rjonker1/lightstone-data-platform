using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Helpers.Cqrs.Events;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.DataProviders.Commands.Handlers;
using IHandleMessages = PackageBuilder.Domain.MessageHandling.IHandleMessages;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {

		public readonly string Name;
        public readonly Type ResponseType;
        public readonly string State;
        public readonly double Cos;
        public readonly DateTime Date;
        public readonly string Owner;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, int version, string name, Type responseType, IEnumerable<IDataField> dataFields)
        {
			Id = id;
            Version = version;
			Name = name;
            ResponseType = responseType;
            State = null;
            Cos = 0.00;

            //DateTime dt = DateTime.Now;
            Date = DateTime.Now;//dt.ToString("dd/MM/yyyy");
            Owner = null;
            DataFields = dataFields;

           
            UpdateModel(id, name, version);
        }

        private void UpdateModel(Guid id, string name, int version)
        {
            
           IHandleMessages handler = new UpdateReadModelHandler();           
           handler.Handle(new UpdateReadModel(id, name, version));

        }

        
    }
}