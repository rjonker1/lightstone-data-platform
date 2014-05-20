using System;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.Common;
using Lace.Source.Enums;

namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockHandleRgtVinServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.IvidTitleHolder;
            }
        }

        private bool _canHandle;
        public bool CanHandle(ILaceRequest request, ILaceResponse response)
        {
           _canHandle =
               CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageDataSourceRequiresService(
                   request.Package,
                   (int)Service);

            if (!_canHandle)
            {
                NotHandledResponse(response);
            }

            return _canHandle;
        }

        public void Request(Action<IRequestDataFromService> action)
        {
            action(new MockRequestDataFromRgtVinHolderService());
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new IvidTitleHolderResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
