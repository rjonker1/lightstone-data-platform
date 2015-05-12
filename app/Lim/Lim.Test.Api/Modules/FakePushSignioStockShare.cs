using Common.Logging;
using Nancy;
using Nancy.Security;

namespace Lim.Test.Api.Modules
{
    public class FakePushSignioStockShare : NancyModule
    {
        private readonly ILog _log; 

        public FakePushSignioStockShare()
        {
            _log = LogManager.GetLogger(GetType());
            _log.Info("In Sigion Stock Share");

            this.RequiresAuthentication();

            Get["stockshare/api/stock/importStockItem"] = _ =>
            {
                return Response.AsJson(new {Hello = "hello"});
            };

            Post["stockshare/api/stock/importStockItem"] = _ =>
            {
                _log.Info("Importing stock item");
                return HttpStatusCode.OK;
            };

            Put["stockshare/api/stock/importStockItem"] = _ =>
            {
                _log.Info("Importing stock item from put");
                return HttpStatusCode.OK;
            };
        }
    }
}