using System;
using DataPlatform.Shared.Entities;
using Lace.Builder.Specifications;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        // private static readonly IRequestUsingLicensePlateNumber _requestUsingLicensePlateNumber;

        public void Default(
            IAction action)
        {
            // return new SourceSpecification().LicenseNumberRequestSpecification();
           // SourceChain = new SourceSpecification().LicenseNumberRequestSpecification();
            SourceChain = new SourceSpecification().LicenseNumberRequestSpecification();
        }

        //public static
        //    Func<ILaceRequest, IEnumerable<KeyValuePair<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>>>
        //    ForLicensePlateNumberRequest =
        //        (request) =>
        //            new SourceSpecification().GetSpecificationForRequestType(_requestUsingLicensePlateNumber);


        //public IEnumerable<KeyValuePair<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> SourceChain { get;
        //    private set; }


        public Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; private set; }
    }

}
