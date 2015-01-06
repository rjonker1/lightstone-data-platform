using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Monitoring.Projection.Core.Models.DataProviders;
using Monitoring.Projection.UI.Repository;
using Monitoring.Projection.UI.Repository.Framework.Connections;
using Monitoring.Read.ReadModel.Models.DataProviders;

namespace Monitoring.Projection.UI.Controllers
{
    public class DataServiceController : ApiController
    {
        private readonly DataProviderRepository _repository;

        public DataServiceController()
        {
            _repository = new DataProviderRepository(ConnectionFactory.ForReadDatabase());
        }

        private HttpResponseMessage BuildHttpResponseMessage(MonitoringDataProviderModel[] results)
        {
            var dataProviders =
                results.Select(
                    s =>
                        new DataProviderDto(s.DataProvider, s.DataProviderId, s.Category, s.CategoryId, s.Payload,
                            s.Message, s.Metadata, s.Date,
                            s.AggregateId, s.TimeStamp))
                    .ToList();

            foreach (var provider in dataProviders)
            {
                if (provider.IsPerformance) provider.GetElapsedTime();
            }

            var totalRecords = dataProviders.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, dataProviders);
        }

        [HttpGet]
        public HttpResponseMessage DataProviders()
        {
            var results = _repository.GetMonitoringFromDataProviders();
            return BuildHttpResponseMessage(results);
        }

        [HttpGet]
        public HttpResponseMessage DataProvidersByCategory(int categoryId)
        {
            var results = _repository.GetMonitoringFromDataProvidersByCategory(categoryId);
            return BuildHttpResponseMessage(results);
        }

        [HttpGet]
        public HttpResponseMessage DataProvidersByType(int dataProviderId)
        {
            var results = _repository.GetMonitoringFromDataProvidersByType(dataProviderId);
            return BuildHttpResponseMessage(results);
        }

        [HttpGet]
        public HttpResponseMessage DataProviderByAggregate(Guid aggregateId)
        {
            var results = _repository.GetMonitoringFromDataProviderByAggregate(aggregateId);
            return BuildHttpResponseMessage(results);
        }
    }
}
