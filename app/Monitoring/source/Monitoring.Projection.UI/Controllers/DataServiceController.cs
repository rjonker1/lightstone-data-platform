using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Monitoring.Projection.UI.Repository;

namespace Monitoring.Projection.UI.Controllers
{
    public class DataServiceController : ApiController
    {
        private readonly DataProviderRepository _repository;

        public DataServiceController()
        {
            _repository = new DataProviderRepository();
        }

        [HttpGet]
        public HttpResponseMessage DataProviders()
        {
            var dataProviders = _repository.GetMDataProviders();
            var totalRecords = dataProviders.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, dataProviders);
        }

    }
}
