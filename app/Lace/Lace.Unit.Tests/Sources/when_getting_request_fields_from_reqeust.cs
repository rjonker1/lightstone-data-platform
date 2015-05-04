using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_getting_request_fields_from_reqeust : Specification
    {

        private ICollection<IAmRequestField> requestFields;
        private IAmDataProvider[] dataProviders;
        public override void Observe()
        {
            requestFields = new Collection<IAmRequestField>();
            dataProviders = LicensePlateNumberAllRequestPackage.LicenseNumberPackage("xmc167gp", "licensnumberpackage").DataProviders;
            var dataProvider = dataProviders.Single(w => w.Name == DataProviderName.Ivid);
            var request = dataProvider.GetRequest<IAmIvidStandardRequest>();
         //   requestFields.Add(request.EngineNumber);
        //    requestFields.Add(request.VinNumber);
            requestFields.Add(request.LicenceNumber);
            requestFields.Add(request.ApplicantName);
            requestFields.Add(request.Label);
            requestFields.Add(request.RequesterEmail);
        }

        [Observation]
        public void then_ivid_request_fields_should_be_available()
        {
            var license = GetRequestField<IAmLicenceNumberRequestField>(requestFields);
            var vinNumber = GetRequestField<IAmVinNumberRequestField>(requestFields);
            
        }

        public static T GetRequestField<T>(ICollection<IAmRequestField> requests)
        {
            return requests.OfType<T>().Any() ? requests.OfType<T>().First() : default(T);
        }
    }
}
