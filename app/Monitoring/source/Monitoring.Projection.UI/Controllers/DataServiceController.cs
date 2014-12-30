using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Monitoring.Projection.UI.Repository;
using Monitoring.Projection.UI.Repository.Framework.Connections;

namespace Monitoring.Projection.UI.Controllers
{
    public class DataServiceController : ApiController
    {
        private readonly DataProviderRepository _repository;

        public DataServiceController()
        {
            _repository = new DataProviderRepository(ConnectionFactory.ForReadDatabase());
        }

        [HttpGet]
        public HttpResponseMessage DataProviders()
        {
            var dataProviders = _repository.GetMonitoringFromDataProviders();
            var totalRecords = dataProviders.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, dataProviders);
        }

        [HttpGet]
        public HttpResponseMessage DataProvidersByCategory(int categoryId)
        {
            var dataProviders = _repository.GetMonitoringFromDataProvidersByCategory(categoryId);
            var totalRecords = dataProviders.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, dataProviders);
        }

        [HttpGet]
        public HttpResponseMessage DataProvidersByType(int dataProviderId)
        {
            var dataProviders = _repository.GetMonitoringFromDataProvidersByType(dataProviderId);
            var totalRecords = dataProviders.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, dataProviders);
        }
    }
}
