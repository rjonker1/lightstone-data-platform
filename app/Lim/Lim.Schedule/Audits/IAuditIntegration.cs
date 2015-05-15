using System;
using System.Data;
using Common.Logging;
using Lim.Schedule.Commands;

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
                //TODO: Implement Audit Insert
                const string sql = @"Insert into ....";
                var parameters = new
                {
                    ConfigurationKey = command.ConfigurationKey,
                    Date = command.Date
                };

                //_connection.Open();
                //_connection.Execute(sql, parameters);
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