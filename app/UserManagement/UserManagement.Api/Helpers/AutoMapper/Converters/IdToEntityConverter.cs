using System;
using AutoMapper;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Converters
{
    public class IdToEntityConverter<T> : TypeConverter<Guid, T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public IdToEntityConverter(IRepository<T> repository)
        {
            _repository = repository;
        }

        protected override T ConvertCore(Guid source)
        {
            return _repository.Get(source);
        }
    }
}