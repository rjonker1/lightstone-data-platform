﻿using System;
using Common.Logging;
using Lace.Toolbox.PCubed.Deserialization;
using Lace.Toolbox.PCubed.Domain;
using Lace.Toolbox.PCubed.Extensions;
using RestSharp;

namespace Lace.Toolbox.PCubed
{
    public class ConsumerViewService : IConsumerViewService
    {
        protected RestClient Client { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        private static readonly ILog Log = LogManager.GetLogger<ConsumerViewService>();

        private static string MonitoringCategory
        {
            get { return "PCubedConnector"; }
        }

        public ConsumerViewService(RestClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client", "The RestClient instance must be injected or initialized manually.");

            // Replace the default deserialization handler
            client.AddHandler("application/json", new PCubedJsonDeserializer());

            Client = client;
            Configuration = new ConfigurationProvider();
        }

        public void AddConfiguration(IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException("config", "The Configuration Provider must be injected or initialized manually.");

            Configuration = config;
        }

        public IRestResponse<ConsumerViewResponse> Search(ConsumerViewQuery query)
        {
            IRestResponse<ConsumerViewResponse> response = new RestResponse<ConsumerViewResponse>();
            //var metadata = new MonitoringMetadata(CreateParameters(query), MonitoringCategory, CreateSubCategory(query), query.AssociationId);
            //var monitors = new Dictionary<Func<IRestResponse<ConsumerViewResponse>, bool>, Func<MonitoringMetadata, IRestResponse<ConsumerViewResponse>, bool>>();

            //monitors.Add(r => r.Data == null, (m, r) =>
            //{
            //    Report.CustomEvent()
            //        .Event(new NoDataReturnedExternalServiceCallEvent())
            //        .InCategory(MonitoringCategory)
            //        .InSubCategory(m.SubCategory)
            //        .RelateTo(query.AssociationId)
            //        .WithDescription(m.Parameters, string.Empty)
            //        .Publish();

            //    return false;
            //});

            //monitors.Add(r => r.Data != null && r.Data.IndividualData == null, (m, r) =>
            //{
            //    Report.CustomEvent()
            //        .Event(new NoDataReturnedExternalServiceCallEvent())
            //        .InCategory(MonitoringCategory)
            //        .InSubCategory(m.SubCategory)
            //        .RelateTo(query.AssociationId)
            //        .WithDescription(m.Parameters, string.Empty)
            //        .Publish();

            //    return false;
            //});

            try
            {
                response = Client.Setup(Configuration).Execute<ConsumerViewResponse>(query.CreateRequest());
            }
            catch (Exception e)
            {
                LogException(CreateParameters(query), e);
            }

            return response;
        }

        public IRestResponse SearchAsString(ConsumerViewQuery query, ConsumerViewQuery.ResponseFormat format)
        {
            IRestResponse response = new RestResponse();
            //var metadata = new MonitoringMetadata(CreateParameters(query), MonitoringCategory, CreateSubCategory(query));

            try
            {
                //response = monitoring.Execute(() => Client.Setup(Configuration).Execute(query.CreateRequest(format)), metadata);
                response = Client.Setup(Configuration).Execute(query.CreateRequest(format));
            }
            catch (Exception e)
            {
                LogException(CreateParameters(query), e);
            }

            return response;
        }

        private static void LogException(string parameters, Exception e)
        {
            Log.ErrorFormat("Failed to complete PCubed lookup. Parameters: '{0}'. Exception message: '{1}'", parameters, e.Message);
        }

        private static string CreateParameters(ConsumerViewQuery query)
        {
            return string.Format("ID Number: {0}, Phone number: {1}, Email address: {2}", query.IdNumber, query.PhoneNumber, query.EmailAddress);
        }

        private static string CreateSubCategory(ConsumerViewQuery query)
        {
            return !string.IsNullOrEmpty(query.IdNumber)
                ? "IdNumber" : !string.IsNullOrEmpty(query.PhoneNumber) ? "PhoneNumber" : !string.IsNullOrEmpty(query.EmailAddress) ? "EmailAddress" : "Unknowm";
        }

    }

}
