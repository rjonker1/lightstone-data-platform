using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Monitoring.Projection.Core.Models.DataProviders;
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
            var dataProviders =
                _repository.GetMonitoringFromDataProviders()
                    .Select(
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
        public HttpResponseMessage DataProvidersByCategory(int categoryId)
        {
            var dataProviders = _repository.GetMonitoringFromDataProvidersByCategory(categoryId).Select(
                s =>
                    new DataProviderDto(s.DataProvider, s.DataProviderId, s.Category, s.CategoryId, s.Payload,
                        s.Message, s.Metadata, s.Date,
                        s.AggregateId, s.TimeStamp)).ToList();

            foreach (var provider in dataProviders)
            {
                if (provider.IsPerformance) provider.GetElapsedTime();
            }

            var totalRecords = dataProviders.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, dataProviders);
        }

        [HttpGet]
        public HttpResponseMessage DataProvidersByType(int dataProviderId)
        {
            var dataProviders = _repository.GetMonitoringFromDataProvidersByType(dataProviderId).Select(
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
        public HttpResponseMessage DataProviderByAggregate(Guid aggregateId)
        {
            var dataProviders = _repository.GetMonitoringFromDataProviderByAggregate(aggregateId).Select(
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
    }
}
