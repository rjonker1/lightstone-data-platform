using System;
using System.Linq;
using Lim.Test.Helper.Builder;
using Lim.Test.Helper.Fakes;
using Lim.Unit.Tests.LSAuto.Helpers;
using Toolbox.LightstoneAuto.Database.Domain;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;
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
            var id = Guid.NewGuid();
            _bus.Send(new CreateDataSetExport(FakeDataSetDtoBuilder.ForLsAutoSpecsData(), Guid.NewGuid()));
            var datasets = _readFacade.GetDataSets();
            datasets.Count().ShouldEqual(1);

            var dto = _readFacade.GetDataSets().FirstOrDefault(f => f.Id == id);
            dto.ShouldNotBeNull();
        }

        //[Observation]
        //public void then_modifiying_an_aggregate_should_get_a_new_version()
        //{
        //    var id = Guid.NewGuid();
        //    _bus.Send(new CreateDataSetExport(id, "test data set"));
        //    var datasets = _readFacade.GetDataSets();
        //    datasets.Count().ShouldEqual(1);

        //    var dto = _readFacade.GetDataSet(id);
        //    dto.ShouldNotBeNull();

        //    var newName = "new name for data set";
        //    _bus.Send(new RenameDataSet(dto.Id, newName, dto.Version++));

        //    datasets = _readFacade.GetDataSets();
        //    datasets.Count().ShouldEqual(1);

        //    datasets.FirstOrDefault().Name.ShouldEqual(newName);
        //}
    }
}
