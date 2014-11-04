using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : CreateDataProvider
    {
        public readonly int Version;
        public readonly IEnumerable<IDataField> DataFields;

        public UpdateDataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, State state, int version, string owner, DateTime createdDate, IEnumerable<IDataField> dataFields) : base(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate)
        {
            DataFields = dataFields;
            Version = version;
        }
    }
}
