using Billing.Api.Dtos;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;

namespace Billing.Api
{
    public class Transactions : NancyModule
    {
        public Transactions()
        {
            Get["/transactions/{customerId:guid}/{year?}/{month?}/{page?1}"] = _ =>
                                                                               {
                                                                                   return string.Format("c: {0}; y: {1}; m: {2}; page: {3}");
                                                                               };

            Post["/transaction"] = o =>
                                   {
                                       var transaction = this.Bind<CreateTransaction>();

                                       return CannedResponses.OK;
                                   };
        }
    }
}