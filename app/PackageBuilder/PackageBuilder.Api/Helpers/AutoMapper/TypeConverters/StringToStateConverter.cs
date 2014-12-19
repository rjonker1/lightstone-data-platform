using System;
using AutoMapper;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class StringToStateConverter : TypeConverter<string, State>
    {
        private readonly IStateRepository _repository;

        public StringToStateConverter(IStateRepository repository)
        {
            _repository = repository;
        }

        protected override State ConvertCore(string source)
        {
            var stateName = (StateName)Enum.Parse(typeof(StateName), source, true);

            return _repository.GetByName(stateName);
        }
    }
}