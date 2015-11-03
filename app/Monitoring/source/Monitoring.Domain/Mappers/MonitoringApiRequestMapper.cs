using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Mappers
{
    public class MonitoringApiRequestMapper : TypeMapper
    {
        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "RequestId", "RequestDate", "UserHostAddress", "Authorization", "Method", "BasePath", "HostName", "IsSecure", "Port", "Query",
                    "SiteBase", "Scheme", "Host", "UserAgent", "ContentType", "JsonRequest"
                };
            }
        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var request = instance as MonitoringApiRequest;
            var sql = GenerateInsertStatement();
            var values = new
            {
                RequestId = request.Request.RequestId,
                RequestDate = request.Request.RequestDate,
                UserHostAddress = request.Request.UserHostAddress,
                Authorization = request.Request.Header.Authorization,
                Method = request.Request.Method,
                BasePath = request.Request.Url.BasePath,
                HostName = request.Request.Url.HostName,
                IsSecure = request.Request.Url.IsSecure,
                Port = request.Request.Url.Port,
                Query = request.Request.Url.Query,
                SiteBase = request.Request.Url.SiteBase,
                Scheme = request.Request.Url.Scheme,
                Host = request.Request.Header.Host,
                UserAgent = request.Request.Header.UserAgent,
                ContentType = request.Request.Header.ContentType,
                JsonRequest = request.Request.JsonRequest
            };

            connection.Execute(sql, values);
        }

        protected override string TableName
        {
            get { return "ApiRequestMonitoring"; }
        }
    }
}
