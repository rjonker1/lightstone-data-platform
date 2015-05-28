using System;
using System.Data;
using Common.Logging;
using Lim.Domain.Models;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Web.UI.Mappers
{
    public class ClientMapper : IMapToTheDatabase
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;
        private readonly Client _client;

        private const string SaveClient = @"update Client set IsActive = @IsActive,Name = @Name,Email = @Email,ContactPerson = @ContactPerson,ContactNumber = @ContactNumber,DateModified = @DateModified,ModifiedBy = @ModifiedBy WHERE Id = @Id
if @@ROWCOUNT = 0
begin
insert into Client (IsActive,Name,Email,ContactPerson,ContactNumber,CreatedBy) values (@IsActive,@Name,@Email,@ContactPerson,@ContactNumber,@CreatedBy)
end";

        public ClientMapper(IDbConnection connection, Client client)
        {
            _connection = connection;
            _client = client;
            _log = LogManager.GetLogger(GetType());
        }

        public bool Save()
        {
            try
            {
                var parameters = new
                {
                    @Id = _client.Id,
                    @IsActive = _client.IsActive,
                    @Name = _client.Name,
                    @Email = _client.Email,
                    @ContactPerson = _client.ContactPerson,
                    @ContactNumber = _client.ContactNumber,
                    @CreatedBy = _client.CreatedBy ?? Environment.MachineName,
                    @DateModified = DateTime.UtcNow,
                    @ModifiedBy = _client.ModifiedBy ?? Environment.MachineName
                };

                if(_connection.State == ConnectionState.Closed)
                    _connection.Open();

                _connection.Execute(SaveClient, parameters);
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to save a Client in the LIM database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return false;
        }
    }
}