using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : CreateDataProvider
    {
        public readonly IEnumerable<IDataField> DataFields;

        public UpdateDataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, IEnumerable<IDataField> dataFields) : base(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate)
        {
            DataFields = dataFields;
        }
    }
}
