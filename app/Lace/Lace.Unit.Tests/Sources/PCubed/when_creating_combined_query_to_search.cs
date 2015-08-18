using Lace.Toolbox.PCubed;
using RestSharp;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.PCubed
{
    public class when_creating_combined_query_to_search : Specification
    {
        private readonly ConsumerViewQuery query;
        private IRestRequest request;

        public when_creating_combined_query_to_search()
        {
            query = new ConsumerViewQuery
            {
                IdNumber = Constants.SearchID,
                PhoneNumber = Constants.SearchPhone,
                EmailAddress = Constants.SearchEmail
            };
        }
        public override void Observe()
        {
            request = query.CreateRequest();
        }

        [Observation]
        public void the_request_contains_the_id_number()
        {
            request.Parameters.Count.ShouldEqual(4);

            foreach (var param in request.Parameters)
            {
                switch (param.Name)
                {
                    case Constants.ParamID:
                        param.Value.ShouldEqual(Constants.SearchID);
                        break;
                    case Constants.ParamPhone:
                        param.Value.ShouldEqual(Constants.SearchPhone);
                        break;
                    case Constants.ParamEmail:
                        param.Value.ShouldEqual(Constants.SearchEmail);
                        break;
                    case Constants.ParamFormat:
                        param.Value.ShouldEqual(Constants.SearchFormatJson);
                        break;
                    default:
                        param.Value.ShouldEqual(Constants.SearchDefault);
                        break;
                }
            }
        }
    }
}