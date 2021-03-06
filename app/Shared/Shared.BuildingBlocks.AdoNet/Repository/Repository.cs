﻿using System;
using System.Data;

namespace Shared.BuildingBlocks.AdoNet.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRepositoryMapper _mapper;

        public Repository(IDbConnection connection, IRepositoryMapper mapper)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            var mapping = _mapper.GetMapping(typeof(TType));

            return mapping.Get(_connection, id) as TType;

        }

        public void Add<TType>(TType instance)
        {
            var mapping = _mapper.GetMapping(instance);

            mapping.Insert(_connection, instance);
        }
    }
}
