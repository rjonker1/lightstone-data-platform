using System;
using System.Collections.Generic;
using System.Data;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Management
{
    public class TransformLightstoneBusinessResponse : ITransformResponseFromDataProvider
    {
        public DataSet Response { get; private set; }
        public IProvideDataFromLightstoneBusiness Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformLightstoneBusinessResponse(DataSet response)
        {
            Response = response;
            Continue = Response != null && Response.Tables.Count > 0;
        }

        public void Transform()
        {
            var results = new List<IRespondWithBusiness>();

            // TODO: 

            //var Business = Response.Tables["Business"].AsEnumerable()
            //    .Select(s => new BusinessModel(
            //        // TODO: the rest of the fields
            //        GetStringRowValue(s, "Result")
                   
            //        ));

            //results.AddRange(Business);
            Result = new LightstoneBusinessResponse(results);
        }

        private static string GetStringRowValue(DataRow row, string value)
        {
            return row[value].ToString();
        }

        private static decimal GetDecimalRowValue(DataRow row, string value)
        {
            decimal @decimal;
            return decimal.TryParse(row[value].ToString(), out @decimal) ? @decimal : 0;
        }

        private static int GetIntRowValue(DataRow row, string value)
        {
            int @int;
            return int.TryParse(row[value].ToString(), out @int) ? @int : 0;
        }

        private static Guid GetGuidRowValue(DataRow row, string value)
        {
            Guid @guid;
            return Guid.TryParse(row[value].ToString(), out @guid) ? @guid : Guid.Empty;
        }

        private static double GetDoubleRowValue(DataRow row, string value)
        {
            double @double;
            return double.TryParse(row[value].ToString(), out @double) ? @double : 0.0;
        }

        private static bool GetBoolRowValue(DataRow row, string value)
        {
            bool @bool;
            return bool.TryParse(row[value].ToString(), out @bool) ? @bool : false;
        }
    }
}
