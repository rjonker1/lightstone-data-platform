﻿using System;
using System.Linq;
using System.Threading;
using Lim.Test.Helper.Builder;
using Lim.Test.Helper.Fakes;
using Lim.Unit.Tests.LSAuto.Helpers;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Infrastructure.Commands;
using Xunit.Extensions;

namespace Lim.Unit.Tests.LSAuto
{
    public class when_modifying_data_sets_for_ls_auto : Specification
    {
        private readonly FakeBus _bus;
        private readonly IReadModelFacade _readFacade;
        private readonly Guid _id;
        private readonly Guid _user;
        private readonly Guid _correlationId;

        public when_modifying_data_sets_for_ls_auto()
        {
            _bus = FakeBusBuilder.Bus();
            _readFacade = new FakeDataSetReadModel();
           // _id = new Random().Next(1000, 10000000);
            _id = Guid.NewGuid();
            _user = Guid.NewGuid();
            _correlationId = Guid.NewGuid();
        }

        public override void Observe()
        {
            _bus.Send(new CreateDataSetExport(FakeDataSetDtoBuilder.ForLsAutoSpecsData(_id), _user));
        }

        [Observation]
        public void then_changes_to_data_set_should_be_visible()
        {
            var datasets = _readFacade.GetDataSets();
            datasets.Count().ShouldEqual(1);

            var dto = _readFacade.GetDataSets().FirstOrDefault(f => f.Id == _id);
            dto.ShouldNotBeNull();

            const string modifiedName = "this has been changed name";
            dto.Name = modifiedName;
            _bus.Send(new ModifyDataSetExport(dto, _user, dto.Version, _correlationId));

            Thread.Sleep(5000);

            dto = _readFacade.GetDataSets().FirstOrDefault(f => f.Id == _id);
            dto.Name.ShouldEqual(modifiedName);


        }
    }
}