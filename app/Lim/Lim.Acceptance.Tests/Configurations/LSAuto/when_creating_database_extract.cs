using System;
using System.Collections.Generic;
using System.Linq;
using EasyNetQ;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Base;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Mapping;
using Toolbox.LightstoneAuto.Factories;
using Toolbox.LightstoneAuto.Infrastructure.ReadModels;
using Toolbox.LightstoneAuto.Repository;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Configurations.LSAuto
{
    public class when_creating_database_extract : Specification //AbstracLsAutoInMemoryDatabase, IDisposable
    {

        private readonly IReadDatabaseExtractFacade _readDataExtractFacade;
        private readonly IReadDatabaseViewFacade _readDatabaseViewFacade;
        private readonly IReadOnlyRepository _repository;

        private readonly IPersist<DatabaseExtractDto> _databaseExtractPersist;
        private readonly IPersist<DatabaseViewDto> _databaseViewPersist; 

     
        private readonly CreateDataExtract _command;
        private readonly Guid _id;
        private readonly IAdvancedBus _bus;
        private readonly List<DatabaseViewDto> _views;
        private readonly Guid _aggregateId;

        private DatabaseExtractDto _databaseExtractDto;
        private DatabaseViewDto _databaseViewDto;



        public when_creating_database_extract()
        {
            AutoMapper.Mapper.Initialize(i =>
            {
                i.AddProfile<DatabaseExtractMapping>();
                i.AddProfile<DatabaseViewMapping>();
            });


            _repository = new LsAutoReadRepository();
            _readDataExtractFacade = new DatabaseExtractReadModel(_repository);
            _readDatabaseViewFacade = new DatabaseViewReadModel(_repository);

            _aggregateId = Guid.NewGuid();

            _databaseExtractPersist = new DatabaseExtractCommit();
            _databaseViewPersist = new DatabaseViewCommit();

            _views = new BuildViewDtoFactory().Build(_aggregateId);
        }

        public override void Observe()
        {
            var view = _views.FirstOrDefault();
            _databaseViewPersist.Persist(view);

            _databaseViewDto = _readDatabaseViewFacade.GetDatabaseViews().FirstOrDefault();

            _databaseExtractDto = AutoMapper.Mapper.Map<DatabaseExtractDto>(_databaseViewDto);
            _databaseExtractDto.Fields.ForEach(f => f.Selected = true);
            _databaseExtractDto.AggregateId = Guid.NewGuid();
            _databaseExtractPersist.Persist(_databaseExtractDto);
        }

        [Observation]
        public void then_data_base_extract_dto_must_be_created_from_view()
        {
            var dto = _readDataExtractFacade.GetDataExtracts().FirstOrDefault(w => w.AggregateId != Guid.Empty);
            dto.ShouldNotBeNull();
            dto.Fields.Count.ShouldEqual(_databaseViewDto.ViewColumns.Count);
        }
    }
}
