using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.PCubed.Domain;
using RestSharp;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure.Management
{
    public class TransformPCubedEzScoreResponse : ITransformResponseFromDataProvider
    {
        private readonly ConsumerViewResponse _response;
        public TransformPCubedEzScoreResponse(IRestResponse<ConsumerViewResponse> response)
        {
            Continue = response != null && response.Data != null && response.Data.ResponseStatusCode == HttpStatusCode.OK;
            Result = Continue ? null : PCubedEzScoreResponse.Empty();
            _response = Continue ? response.Data : new ConsumerViewResponse();
        }


        public void Transform()
        {
            Result = PCubedEzScoreResponse.Empty();

            GetIndividual();

            

            //foreach (Individual individual in reponse.IndividualData.Individuals.Individual)
            //{
            //    var record = new EZScoreRecord();
            //    foreach (PropertyInfo propertyInfo in individual.PCubed.Header.GetType().GetProperties())
            //    {
            //        var propValue = propertyInfo.GetValue(individual.PCubed.Header);

            //        var _propertyInfo = record.GetType().GetProperty(propertyInfo.Name);
            //        _propertyInfo.SetValue(record, propValue);
            //    }

            //    if (individual.PCubed.Detail != null)
            //    {
            //        foreach (PropertyInfo propertyInfo in individual.PCubed.Detail.GetType().GetProperties())
            //        {
            //            var propValue = propertyInfo.GetValue(individual.PCubed.Detail);

            //            var _propertyInfo = record.GetType().GetProperty(propertyInfo.Name);
            //            _propertyInfo.SetValue(record, propValue);
            //        }
            //    }
            //    searchResults.Add(record);
            //}
        }

        private void GetIndividual()
        {
            foreach (var individual in _response.IndividualData.Individuals.Individual)
            {

            }
        }

       

        public bool Continue { get; private set; }
        public IProvideDataFromPCubedEzScore Result { get; private set; }
    }
}
