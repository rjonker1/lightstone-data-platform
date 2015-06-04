using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Test.Api.Data;
using Lim.Test.Api.Dto;
using Lim.Test.Api.Models;
using Lim.Test.Api.Models.Packages;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Lim.Test.Api.Modules
{
    public class PushModule : NancyModule
    {
        private readonly ILog _log;

        public PushModule(IRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _log.Info("In Fake Push API....");

            this.RequiresAuthentication();

            Get["api/push"] = _ => Response.AsJson(new {Hello = "welcome to receiving stuff pushed from all over..."});

            Get["api/push/received/all"] = _ =>
            {
                var transations = repository.GetAll<Transaction>().ToList();
                var model = transations.Any()
                    ? transations.Select(
                        s =>
                            new TransactionDto(s.PackageId, s.UserId, s.Username, s.ContractId, s.AccountNumber, s.ResponseDate, s.RequestId, s.Report,
                                s.HasResponse)).ToList()
                    : new List<TransactionDto>();
                return View["Push/Received", model];
            };

            Get["api/push/received/errors"] = _ =>
            {
                var errors = repository.GetAll<Error>().ToList();
                var model = errors.Any() ? errors.ToList() : new List<Error>();
                return View["Push/Errors", model];
            };

            Post["api/push"] = _ =>
            {
                _log.Info("Importing push item from POST");

                try
                {
                    var model = this.Bind<Transaction>();

                    if (model == null)
                    {
                        _log.Error("Could not bind to package transaction recived from push");
                        repository.Persist(new Error(Guid.NewGuid(), "Could not bind to package transactions received from push", "Receive Pushed Item", DateTime.Now));
                        return HttpStatusCode.BadRequest;
                    }

                    repository.Persist(model);
                }
                catch (Exception ex)
                {
                    repository.Persist(new Error(Guid.NewGuid(), ex.Message, "Receive Pushed Item", DateTime.Now));
                    return HttpStatusCode.BadRequest;
                }
               

                return HttpStatusCode.OK;
            };

            Put["api/push"] = _ =>
            {
                _log.Info("Importing push item from PUT");
                return HttpStatusCode.OK;
            };
        }
    }
}