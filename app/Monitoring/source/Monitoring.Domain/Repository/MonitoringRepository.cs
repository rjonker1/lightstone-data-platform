using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRepositoryMapper _mapper;

        public MonitoringRepository(IDbConnection connection, IRepositoryMapper mapper)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                var mapping = _mapper.GetMapping(typeof(TType));
                return mapping.Get(_connection, id) as TType;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Add<TType>(TType instance)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                var mapping = _mapper.GetMapping(instance);
                mapping.Insert(_connection, instance);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<TItem> Items<TItem>(string sql) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection.Query<TItem>(sql);
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>();
        }
    }
}
