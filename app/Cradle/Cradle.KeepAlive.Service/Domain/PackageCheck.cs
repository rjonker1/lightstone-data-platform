using System.Configuration;
using Cradle.KeepAlive.Service.Helpers;
using DataPlatform.Shared.Dtos;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Cradle.KeepAlive.Service.Domain
{
    public class PackageCheck
    {
        private readonly IApiClient _apiClient;

        public PackageCheck(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void InvokePackage()
        {
            var token = new Login().GetToken();

            //if (token != null)
            //{
            //    var apiRequest = new ApiRequestDto();
            //    apiRequest.CustomerClientId = ConfigurationManager.AppSettings[""];

            //    _apiClient.Post(token, "/action",null, new ApiCommitRequestDto
            //    {
                   
            //    },  null);
            //}
        }
    }
}