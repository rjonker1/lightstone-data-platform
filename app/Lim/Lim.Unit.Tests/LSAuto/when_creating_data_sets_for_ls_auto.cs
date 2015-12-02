using System;
using Lim.Test.Helper.Builder;
using Lim.Test.Helper.Fakes;
using Lim.Unit.Tests.LSAuto.Helpers;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;
using Xunit.Extensions;

namespace Lim.Unit.Tests.LSAuto
{
    public class when_creating_data_sets_for_ls_auto : Specification
    {
        private readonly FakeBus _bus;
        private readonly IReadModelFacade _readFacade;

        public when_creating_data_sets_for_ls_auto()
        {
            _bus = FakeBusBuilder.Bus();
            _readFacade = new FakeDataSetReadModel();
        }
        public override void Observe()
        {
           
        }

        [Observation]
        public void then_aggregate_must_be_created()
        {
            _bus.Send(new DataSetc);
        }
    }
}
