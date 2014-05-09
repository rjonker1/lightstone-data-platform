using System;
using System.Linq;
using Lace;
using Lace.Request;
using Nancy;
using Nancy.Security;

namespace Api.NancyFx.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Post["/"] = parameters =>
            {
                this.RequiresAuthentication();

                return Response.AsJson("Authenticated!");
            };

            Post["/license/{licenseNo}"] = parameters =>
            {
                this.RequiresAuthentication();

                var request = new LicensePlateNumberRequest(parameters.licenseNo, new[] { "Ivid", "IvidTitleHolder", "RgtVin", "Audatex" });

                var init = new Initialize(request);
                return Response.AsJson(init.LaceResponses.First().Response);
            };
        }
    }

    public class LicensePlateNumberRequest : ILaceRequest
    {
        public LicensePlateNumberRequest(string licenceNo, string[] sources)
        {
            LicenceNo = licenceNo;
            Sources = sources;
            Vin = "WAUZZZ8K8DA074674";
        }

        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public string UserEmail { get; private set; }
        public string UserPhone { get; private set; }
        public string CompanyId { get; private set; }
        public string ContractId { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string EngineNo { get; private set; }
        public string VinOrChassis { get; private set; }
        public string Make { get; private set; }
        public string RegisterNo { get; private set; }
        public string LicenceNo { get; private set; }
        public string Product { get; private set; }
        public string ReasonForApplication { get; private set; }
        public string Vin { get; private set; }
        public string SecurityCode { get; private set; }
        public string[] Sources { get; private set; }
    }
}