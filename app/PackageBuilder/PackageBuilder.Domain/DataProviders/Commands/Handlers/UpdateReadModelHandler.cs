using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    class UpdateReadModelHandler : AbstractMessageHandler<DataProviderReadModel>
    {



        public override void Handle(DataProviderReadModel command)
        {
            throw new NotImplementedException();
        }
    }
}
