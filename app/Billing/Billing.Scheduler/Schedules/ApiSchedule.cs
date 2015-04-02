using System;
using Hangfire;
using Shared.BuildingBlocks.Api.ApiClients;
using UserManagementApiClient = Billing.Scheduler.Clients.UserManagementApiClient;

namespace Billing.Scheduler.Schedules
{
    public class ApiSchedule
    {
        public ApiSchedule(IApiClient client)
        {
            //ob.Enqueue(() => new UserManagementApiClient().InvokeApi(client, "", "Users/All"));
            //BackgroundJob.Schedule(() => new UserManagementApiClient().InvokeApi(client, "", "Users/All"), TimeSpan.FromSeconds(0));
        }
    }
}