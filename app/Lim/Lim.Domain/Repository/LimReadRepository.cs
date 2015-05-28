using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Logging;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Domain.Repository
{
    public class LimReadRepository : IReadLimRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;

        public LimReadRepository(IDbConnection connection)
        {
            _connection = connection;
            _log = LogManager.GetLogger(GetType());
        }

        public IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return _connection.Query<TItem>(sql, param);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the LIM database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>();
        }

        public TItem Item<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return _connection.Query<TItem>(sql, param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the LIM database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>().FirstOrDefault();
        }

        //public void Add(string sql, object param)
        //{
        //    try
        //    {
        //        if (_connection.State == ConnectionState.Closed)
        //            _connection.Open();
        //        _connection.Execute(sql, param);
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.ErrorFormat("Failed to add information to the LIM database, because {0}", ex, ex.Message);
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }
        //}
    }
}