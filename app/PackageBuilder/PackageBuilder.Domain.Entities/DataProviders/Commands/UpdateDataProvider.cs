using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : CreateDataProvider
    {
        public readonly int Version;

        public UpdateDataProvider(Guid id, DataProviderName name, string description, double costOfSale, string sourceUrl, Type responseType, State state, int version, string owner, DateTime createdDate, IEnumerable<IDataField> dataFields)
            : base(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate, dataFields)
        {
            Version = version;
        }
    }
}
