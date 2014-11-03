using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class UpdatePackage : CreatePackage
    {
        public readonly IEnumerable<IDataProvider> DataProviders;

        public UpdatePackage(Guid id, string name, string description, double costPrice, double salePrice, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders) : base(id, name, description, costPrice, salePrice, state, owner, createdDate, editedDate, dataProviders)
        {
            DataProviders = dataProviders;
        }
    }
}
