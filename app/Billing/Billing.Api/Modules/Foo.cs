using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;

namespace Billing.Api.Modules
{
    public class FooBar
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class Foo : NancyModule
    {
        public Foo() : base("/foo")
        {
            Get["/"] = o =>
            {
                var i = this.Bind<FooBar>();
                return CannedResponses.OK;
            };

            Post["/"] = o =>
            {
                var i = this.Bind<FooBar>();

                return 200;
            };
        }
    }
}