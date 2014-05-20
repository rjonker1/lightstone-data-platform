using System;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Common;
using Lace.Source.Enums;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class HandleAudatexServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.Audatex;
            }
        }

        private bool _canHandle;

        public bool CanHandle(ILaceRequest request, ILaceResponse response)
        {
            _canHandle =
                CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageDataSourceRequiresService(
                    request.Package,
                    (int) Service);

            if (!_canHandle)
            {
                NotHandledResponse(response);
            }

            return _canHandle;
        }

        public void Request(Action<IRequestDataFromService> action)
        {
            action(new RequestDataFromAudatexService());
        }


        private static void NotHandledResponse(ILaceResponse response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasNotBeenHandled();
        }
    }
}
