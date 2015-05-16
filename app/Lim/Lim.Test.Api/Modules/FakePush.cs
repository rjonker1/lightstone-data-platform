using Common.Logging;
using Nancy;
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