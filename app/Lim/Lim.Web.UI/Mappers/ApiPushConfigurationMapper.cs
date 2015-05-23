using System;
using System.Data;
using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Web.UI.Models.Api;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Web.UI.Mappers
{
    public class ApiPushConfigurationMapper
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;
        private readonly PushConfiguration _configuration;

        private const string InsertOrUpdate =
            @"update Configuration SET FrequencyType = @FrequencyType,ActionType = @ActionType,IntegrationType = @IntegrationType,ClientId = @ClientId,ContractId = @ContractId,AccountNumber = @AccountNumber,IsActive = @IsActive,CustomFrequencyTime = @CustomFrequencyTime, CustomFrequencyDay = @CustomFrequencyDay WHERE Id = @Id
 if @@ROWCOUNT = 0 
 begin 
 insert into Configuration (FrequencyType,ActionType,IntegrationType,ClientId,ContractId,AccountNumber,IsActive,CustomFrequencyTime,CustomFrequencyDay) values (@FrequencyType, @ActionType, @IntegrationType,@ClientId,@ContractId,@AccountNumber, @IsActive,@CustomFrequencyTime,@CustomFrequencyDay) select cast(SCOPE_IDENTITY() as bigint) 
 end else begin select @Id end";

        private const string IntertOrUpdateApi =
            @"update ConfigurationApi set BaseAddress = @BaseAddress,Suffix = @Suffix,Username = @Username,Password = @Password,HasAuthentication = @HasAuthentication,AuthenticationToken = @AuthenticationToken,AuthenticationKey = @AuthenticationKey,AuthenticationType = @AuthenticationType where Id = (select ca.id from ConfigurationApi ca join Configuration c on c.Id = ca.ConfigurationId)
if @@ROWCOUNT = 0
begin
insert into ConfigurationApi (ConfigurationId,BaseAddress,Suffix,Username,Password ,HasAuthentication,AuthenticationToken,AuthenticationKey,AuthenticationType) values(@ConfigurationId,@BaseAddress,@Suffix,@Username,@Password,@HasAuthentication,@AuthenticationToken,@AuthenticationKey,@AuthenticationType)
end";

        private const string ResetPackages = @"update Packages set IsActive = 0 where ConfigurationId = @ConfigurationId";

        private const string InsertOrUpdatePackage =
            @"update Packages set IsActive = 1 where ConfigurationId = @ConfigurationId and PackageId = @PackageId
if @@ROWCOUNT = 0
begin
insert into Packages(ConfigurationId,PackageId,IsActive) values (@ConfigurationId,@PackageId,1)
end";

        public ApiPushConfigurationMapper(IDbConnection connection, PushConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
            _log = LogManager.GetLogger(GetType());
        }

        public bool InsertUpdate()
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
                    @ContractId = _configuration.ContractId,
                    @AccountNumber = _configuration.AccountNumber,
                    @IsActive = _configuration.IsActive,
                    @CustomFrequencyTime = _configuration.FrequencyType == (int)Frequency.Custom ? _configuration.CustomFrequency.TimeOfDay : TimeSpan.Parse("00:00"),
                    @CustomFrequencyDay = _configuration.FrequencyType == (int) Frequency.Custom ? _configuration.CustomDay : null
                };

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        var configurationId = _connection.Query<int>(InsertOrUpdate, configuration, transaction).Single();

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

                        _connection.Execute(IntertOrUpdateApi, apiConfiguration, transaction);

                        _connection.Execute(ResetPackages, new {@ConfigurationId = configurationId}, transaction);

                        foreach (var id in _configuration.Packages)
                        {
                            _connection.Execute(InsertOrUpdatePackage, new {@ConfigurationId = configurationId, @PackageId = id}, transaction);
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