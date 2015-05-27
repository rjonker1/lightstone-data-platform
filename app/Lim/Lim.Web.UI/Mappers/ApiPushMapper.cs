using System;
using System.CodeDom;
using System.Data;
using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Web.UI.Models.Api;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Web.UI.Mappers
{
    public class ApiPushMapper : IMapToTheDatabase
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;
        private readonly PushConfiguration _configuration;

        private const string SaveConfiguration =
            @"update Configuration SET FrequencyType = @FrequencyType,ActionType = @ActionType,IntegrationType = @IntegrationType,ClientId = @ClientId,IsActive = @IsActive,CustomFrequencyTime = @CustomFrequencyTime, CustomFrequencyDay = @CustomFrequencyDay, DateModified = @DateModified WHERE Id = @Id
 if @@ROWCOUNT = 0 
 begin 
 insert into Configuration (FrequencyType,ActionType,IntegrationType,ClientId,IsActive,CustomFrequencyTime,CustomFrequencyDay) values (@FrequencyType, @ActionType, @IntegrationType,@ClientId,@IsActive,@CustomFrequencyTime,@CustomFrequencyDay) select cast(SCOPE_IDENTITY() as bigint) 
 end else begin select @Id end";

        private const string SaveApiConfiguration =
            @"update ConfigurationApi set BaseAddress = @BaseAddress,Suffix = @Suffix,Username = @Username,Password = @Password,HasAuthentication = @HasAuthentication,AuthenticationToken = @AuthenticationToken,AuthenticationKey = @AuthenticationKey,AuthenticationType = @AuthenticationType where Id = (select ca.id from ConfigurationApi ca join Configuration c on c.Id = ca.ConfigurationId)
if @@ROWCOUNT = 0
begin
insert into ConfigurationApi (ConfigurationId,BaseAddress,Suffix,Username,Password ,HasAuthentication,AuthenticationToken,AuthenticationKey,AuthenticationType) values(@ConfigurationId,@BaseAddress,@Suffix,@Username,@Password,@HasAuthentication,@AuthenticationToken,@AuthenticationKey,@AuthenticationType)
end";

        private const string ResetPackages = @"update IntegrationPackages set IsActive = 0 where ConfigurationId = @ConfigurationId";

        private const string SavePackages =
            @"update IntegrationPackages set IsActive = 1, ContractId = @ContractId where ConfigurationId = @ConfigurationId and PackageId = @PackageId
if @@ROWCOUNT = 0
begin
insert into IntegrationPackages(ConfigurationId,PackageId,ContractId,IsActive) values (@ConfigurationId,@PackageId,@ContractId,1)
end";

        private const string ResetClients = @"update IntegrationClients set IsActive = 0 where ConfigurationId = @ConfigurationId";

        private const string SaveClients =
            @"update IntegrationClients set AccountNumber = @AccountNumber ,ConfigurationId = @ConfigurationId, IsActive = 1,DateModified = @DateModified,ModifiedBy = @ModifiedBy WHERE ConfigurationId = @ConfigurationId and ClientCustomerId = @ClientCustomerId
if @@ROWCOUNT = 0
begin
insert into IntegrationClients (ClientCustomerId,AccountNumber,ConfigurationId,IsActive) values (@ClientCustomerId,@AccountNumber,@ConfigurationId,1)
end";

        private const string SaveContracts = @"update IntegrationContracts set ConfigurationId = @ConfigurationId, ClientCustomerId = ClientCustomerId   ,IsActive = 1,DateModified = @DateModified,ModifiedBy = @ModifiedBy where ConfigurationId =  @ConfigurationId and Contract = @Contract
if @@ROWCOUNT = 0
begin
USE Lim
insert into IntegrationContracts (Contract,ConfigurationId,ClientCustomerId,IsActive) values (@Contract,@ConfigurationId,@ClientCustomerId,1)
end";
        private const string ResetContracts = @"update IntegrationContracts set IsActive = 0 where ConfigurationId = @ConfigurationId ";

        public ApiPushMapper(IDbConnection connection, PushConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
            _log = LogManager.GetLogger(GetType());
        }

        public bool Save()
        {
            try
            {
                var configuration = new
                {
                    @Id = _configuration.Id,
                    @FrequencyType = _configuration.FrequencyType,
                    @ActionType = _configuration.ActionType,
                    @IntegrationType = _configuration.IntegrationType,
                    @ClientId = _configuration.ClientId,
                    @AccountNumber = _configuration.AccountNumber,
                    @IsActive = _configuration.IsActive,
                    @CustomFrequencyTime = _configuration.FrequencyType == (int)Frequency.Custom ? _configuration.CustomFrequency.TimeOfDay : TimeSpan.Parse("00:00"),
                    @CustomFrequencyDay = _configuration.FrequencyType == (int) Frequency.Custom ? _configuration.CustomDay : null,
                    @DateModified = DateTime.UtcNow,
                    @ModifiedBy = _configuration.User ?? Environment.MachineName
                };

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        var configurationId = _connection.Query<int>(SaveConfiguration, configuration, transaction).Single();

                        if (configurationId == 0)
                            throw new Exception("Could not insert LIM configuration because configuration id is not valid");

                        var apiConfiguration = new
                        {
                            @ConfigurationId = configurationId,
                            @BaseAddress = _configuration.BaseAddress,
                            @Suffix = _configuration.Suffix,
                            @Username = _configuration.Username,
                            @Password = _configuration.Password,
                            @HasAuthentication = _configuration.HasAuthentication,
                            @AuthenticationToken = _configuration.AuthenticationToken,
                            @AuthenticationKey = _configuration.AuthenticationKey,
                            @AuthenticationType = _configuration.AuthenticationType,
                        };

                        _connection.Execute(SaveApiConfiguration, apiConfiguration, transaction);

                        _connection.Execute(ResetPackages, new {@ConfigurationId = configurationId}, transaction);
                        _connection.Execute(ResetClients, new {@ConfigurationId = configurationId}, transaction);
                        _connection.Execute(ResetContracts, new {@ConfigurationId = configurationId}, transaction);

                        foreach (var id in _configuration.IntegrationPackages)
                        {
                            var contractId = _configuration.SelectableDataPlatformPackages.FirstOrDefault(w => w.Id == id).ContractId;
                            _connection.Execute(SavePackages, new { @ConfigurationId = configurationId, @PackageId = id, @ContractId = contractId }, transaction);
                        }

                        foreach (var id in _configuration.IntegrationClients)
                        {
                            _connection.Execute(SaveClients, new { @ClientCustomerId = id, @AccountNumber = 0, @ConfigurationId = configurationId, @DateModified = DateTime.UtcNow, @ModifiedBy = _configuration.User ?? Environment.MachineName }, transaction);
                        }

                        foreach (var id in _configuration.IntegrationContracts)
                        {
                            var clientCustomerId = _configuration.SelectableDataPlatformContracts.FirstOrDefault(w => w.Id == id).ClientId;
                            _connection.Execute(SaveContracts, new { @Contract = id, @ConfigurationId = configurationId, @ClientCustomerId = clientCustomerId, @DateModified = DateTime.UtcNow, @ModifiedBy = _configuration.User ?? Environment.MachineName }, transaction);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to save information in the LIM database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return false;
        }
    }
}