using System;
using System.Data;
using System.Linq;
using Lace.CrossCutting.DataProvider.Certificate.Core.Models;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.CrossCutting.DataProvider.Certificate.Repositories
{
    public class BaseStationRepository : IReadOnlyRepository<BaseStation>
    {
        private readonly IDbConnection _connection;

        public BaseStationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public BaseStation Find(double latitude, double longitude)
        {
            using (var client = CacheConnectionFactory.LocalClient.GetReadOnlyClient())
            {
                if (!client.ContinueUsingCache())
                {
                    return _connection.Query<BaseStation>("spx_returnBaseStation", new { @x = latitude, @y = longitude },
                        commandType: CommandType.StoredProcedure).First();
                }

                var type = client.GetTypedClient<BaseStation>();
                using (type)
                {
                    return type.GetAll().Any() ? type.GetAll().FirstOrDefault() : _connection.Query<BaseStation>("spx_returnBaseStation", new { @x = latitude, @y = longitude },
                        commandType: CommandType.StoredProcedure).First();
                }
            }
        }
        public BaseStation[] GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
