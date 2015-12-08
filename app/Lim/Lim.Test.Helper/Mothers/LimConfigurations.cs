using System;
using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Test.Helper.Mothers
{
    public class LimConfigurations
    {
        public static List<ApiPushConfigurationDto> ApiPushConfigurations()
        {
            return new List<ApiPushConfigurationDto>()
            {
                ApiPushConfigurationDto.Existing(1,Guid.NewGuid(), (short)Enums.Frequency.AlwaysOn,(short)Enums.IntegrationAction.Push, (short)Enums.IntegrationType.Api,"http://dev.lim.test.api.lightstone.co.za","api/push","LightStoneAuto","49q42FwDSajrF9","2b1eeb42-0cf7-4234-b798-3bbaa293e273","X-Auth-Token",true,(short)Enums.AuthenticationType.Basic,1),
                ApiPushConfigurationDto.Existing(1,Guid.NewGuid(), (short)Enums.Frequency.Custom,(short)Enums.IntegrationAction.Push, (short)Enums.IntegrationType.Api,"http://dev.lim.test.api.lightstone.co.za","api/push","LightStoneAuto","49q42FwDSajrF9","2b1eeb42-0cf7-4234-b798-3bbaa293e273","X-Auth-Token",true,(short)Enums.AuthenticationType.Basic,1),
                ApiPushConfigurationDto.Existing(1,Guid.NewGuid(), (short)Enums.Frequency.Daily,(short)Enums.IntegrationAction.Push, (short)Enums.IntegrationType.Api,"http://dev.lim.test.api.lightstone.co.za","api/push","LightStoneAuto","49q42FwDSajrF9","2b1eeb42-0cf7-4234-b798-3bbaa293e273","X-Auth-Token",true,(short)Enums.AuthenticationType.Basic,1),
                ApiPushConfigurationDto.Existing(1,Guid.NewGuid(), (short)Enums.Frequency.EveryMinute,(short)Enums.IntegrationAction.Push, (short)Enums.IntegrationType.Api,"http://dev.lim.test.api.lightstone.co.za","api/push","LightStoneAuto","49q42FwDSajrF9","2b1eeb42-0cf7-4234-b798-3bbaa293e273","X-Auth-Token",true,(short)Enums.AuthenticationType.Basic,1),
                ApiPushConfigurationDto.Existing(1,Guid.NewGuid(), (short)Enums.Frequency.Hourly,(short)Enums.IntegrationAction.Push, (short)Enums.IntegrationType.Api,"http://dev.lim.test.api.lightstone.co.za","api/push","LightStoneAuto","49q42FwDSajrF9","2b1eeb42-0cf7-4234-b798-3bbaa293e273","X-Auth-Token",true,(short)Enums.AuthenticationType.Basic,1)
            };
        }
    }
}
