using System;
using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Specification;

namespace Lace.Domain.Infrastructure.EntryPoint.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> SourceChain
        {
            get
            {
                return DataProviderSpecification.Chain();
            }
        }

        //public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> SourceChain
        //{
        //    get
        //    {
        //        return new DataProviderSpecification().Chain;
        //    }
        //}

        //private readonly IHavePackageForRequest _package;
        //private readonly ILog _log;

        //public CreateSourceChain(IHavePackageForRequest package)
        //{
        //    //_log = LogManager.GetLogger(GetType());
        //    //_package = package;
        //}

        //public void Build()
        //{
        //    SourceChain = new DataProviderSpecification().Chain;

        //    //if (string.IsNullOrEmpty(_package.Action))
        //    //{
        //    //    _log.Error("Package Name for request is empty. Source chain cannot be built");
        //    //    throw new Exception("Action for request is empty");
        //    //}

        //    //_log.ErrorFormat("Building source chain for action {0}", _package.Action);

        //    //SourceChain =
        //    //    new DataProviderSpecification().Specifications.SingleOrDefault(
        //    //        w => w.Key.Equals(_package.Action, StringComparison.CurrentCultureIgnoreCase)).Value;
        //}
    }
}