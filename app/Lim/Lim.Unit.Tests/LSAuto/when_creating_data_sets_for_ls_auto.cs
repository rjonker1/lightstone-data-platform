using System;
using System.Linq;
using Lim.Test.Helper.Builder;
using Lim.Test.Helper.Fakes;
using Lim.Unit.Tests.LSAuto.Helpers;
using Toolbox.LightstoneAuto.Domain.Base;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Xunit.Extensions;

namespace Lim.Unit.Tests.LSAuto
{
    public class when_creating_data_sets_for_ls_auto : Specification
    {
        private readonly FakeBus _bus;
        private readonly IReadDatabaseExtractFacade _readFacade;
        private readonly Guid _id;

        public when_creating_data_sets_for_ls_auto()
        {
            _bus = FakeBusBuilder.LsAutoBus();
            _readFacade = new FakeDataSetReadModel();
           // _id = new Random().Next(1000, 10000000);
            _id = Guid.NewGuid();
        }
        public override void Observe()
        {
            _bus.Send(new CreateDataExtract(FakeDataSetDtoBuilder.ForLsAutoSpecsData(_id), Guid.NewGuid()));
        }

        [Observation(Skip = "Fake bus not working")]
        public void then_aggregate_must_be_created()
        {
            var datasets = _readFacade.GetDataExtracts();
            datasets.Count().ShouldEqual(1);

            var dto = _readFacade.GetDataExtracts().FirstOrDefault(f => f.AggregateId == _id);
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
