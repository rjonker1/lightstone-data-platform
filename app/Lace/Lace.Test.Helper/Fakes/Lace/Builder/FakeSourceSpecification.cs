using System;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Test.Helper.Fakes.Lace.Consumer;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceSpecification
    {
        public Func<Action<ILaceRequest, ILaceEvent, ILaceResponse>>
          LicenseNumberRequestSpecification =
              () =>
                  (request, @event, response) =>
                      new FakeSourceConsumer(
                          new FakeAudatexConsumer(request,
                              new FakeRgtVinConsumer(request,
                                  new FakeIvidTitleHolderConsumer(request,
                                      new FakeIvidConsumer(request, null, null), null),
                                  null), null), null).CallSource(response, @event);
    }
}
