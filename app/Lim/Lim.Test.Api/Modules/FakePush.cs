using System.Collections.Generic;
using Common.Logging;
using Lim.Domain.Models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Lim.Test.Api.Modules
{
    public class FakePush : NancyModule
    {
        private readonly ILog _log;

        public FakePush()
        {
            _log = LogManager.GetLogger(GetType());
            _log.Info("In Fake Push API....");

            this.RequiresAuthentication();

            Get["api/push"] = _ =>
            {
                return Response.AsJson(new {Hello = "welcome to the pushing stuff..."});
            };

            Post["api/push"] = _ =>
            {
                _log.Info("Importing push item from POST");

                var model = this.Bind<List<PackageTransaction>>();
                foreach (var transaction in model)
                {
                    _log.InfoFormat("Contract Id {0}", transaction.ContractId);
                }

                return Response.AsJson(new {Successfull = true});
            };

            Put["api/push"] = _ =>
            {
                _log.Info("Importing push item from PUT");
                return HttpStatusCode.OK;
            };
        }
    }
}