using Lace.Toolbox.PCubed;
using RestSharp;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.PCubed
{
    public class when_creating_email_query : Specification
    {
        private readonly ConsumerViewQuery _query;
        private IRestRequest _request;

        public when_creating_email_query()
        {
            _query = new ConsumerViewQuery { EmailAddress = Constants.SearchEmail };
        }

        public override void Observe()
        {
            _request = _query.CreateRequest();
        }

        [Observation]
        public void the_request_contains_the_id_number()
        {
            _request.Parameters.Count.ShouldEqual(4);

            foreach (var param in _request.Parameters)
            {
                switch (param.Name)
                {
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
