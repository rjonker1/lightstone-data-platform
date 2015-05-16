using System;
using System.Data;
using Common.Logging;
using Lim.Schedule.Commands;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Schedule.Audits
{
    public interface IAuditIntegration
    {
        void Audit(AuditIntegrationCommand command);
    }

    public class StoreIntegrationAudit : IAuditIntegration
    {
        private readonly ILog _log;
        private readonly IDbConnection _connection;

        public StoreIntegrationAudit(IDbConnection connection)
        {
            _log = LogManager.GetLogger(GetType());
            _connection = connection;
        }

        public void Audit(AuditIntegrationCommand command)
        {
            _log.Info("Storing Integration Audit information to the database");
            try
            {
                const string sql =
                    @"insert into AuditApiIntegration (ConfigurationKey,ActionType,IntegrationType,Date,WasSuccessful,Address,Suffix,Payload) values (@ConfigurationKey,@ActionType,@IntegrationType,@Date,@WasSuccessful,@Address,@Suffix,@Payload)";
                var parameters = new
                {
                    @ConfigurationKey = command.ConfigurationKey,
                    @ActionType = command.Action,
                    @IntegrationType = command.Type,
                    @Date = DateTime.UtcNow,
                    @WasSuccessful = command.WasSuccessful,
                    @Address = command.Address,
                    @Suffix = command.Suffix,
                    @Payload = command.Payload
                };

                _connection.Open();
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to audit the integration information, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}