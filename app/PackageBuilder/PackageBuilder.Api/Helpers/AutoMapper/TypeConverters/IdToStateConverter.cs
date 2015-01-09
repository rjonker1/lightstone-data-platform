using System;
using AutoMapper;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class IdToStateConverter : TypeConverter<Guid, State>
    {
        private readonly IStateRepository _repository;

        public IdToStateConverter(IStateRepository repository)
        {
            _repository = repository;
        }

        protected override State ConvertCore(Guid source)
        {
            //var stateName = (StateName)Enum.Parse(typeof(StateName), source, true);

            return _repository.Get(source);
        }
    }
}