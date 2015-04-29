using System.Collections;
using System.Collections.Generic;
using System.Text;
using CsQuery.ExtensionMethods;
using Nancy;
using Newtonsoft.Json;

namespace Lim.Tests.Api
{
    public class RestIntegrationModule : NancyModule
    {
        public RestIntegrationModule()
        {
            Get["/"] = _ =>
            {
                var model = new {Message = "Response from no parameters"};
                return model.ToJSON();
            };

            Get["/integration/get/fakeDealersWithUsers"] = _ =>
            {
                //var model = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new FakeIntegrationRepository().GetAll()));

                return Response.AsJson(new FakeIntegrationRepository().GetAll());
                
                //return new Response
                //{
                //    ContentType = "application/json",
                //    Contents = s => s.Write(model, 0, model.Length)
                //};
            };
        }
    }

    public class FakeIntegrationRepository
    {
        public IList<dynamic> GetAll()
        {
            return new List<dynamic>(new[]
            {
                new {DealerName = "Toyota Fourways", Username = "Fred"},
                new {DealerName = "Toyota Fourways", Username = "Mike"},
                new {DealerName = "Toyota Fourways", Username = "Alfred"}
            });
        }
    }
}
