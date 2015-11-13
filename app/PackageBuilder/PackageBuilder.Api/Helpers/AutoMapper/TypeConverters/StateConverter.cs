using System;
using AutoMapper;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class StateConverter : TypeConverter<Guid, State> 
    {
        private readonly IRepository<State> _repository;

        public StateConverter(IRepository<State> repository)
        {
            _repository = repository;
        }

        protected override State ConvertCore(Guid source)
        {
            return _repository.Get(source);
        }
    }
}