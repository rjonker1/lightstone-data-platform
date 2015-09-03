using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Lace.Toolbox.Signio.Extensions;
using RestSharp;

namespace Lace.Toolbox.Signio
{
    public class DecryptDriversLicenseService : IDecryptDriversLicenseService
    {
        private readonly RestClient _client;
        private readonly Guid _userId;
        private IConfiguration _configuration;
        private static readonly ILog Log = LogManager.GetLogger<DecryptDriversLicenseService>();

        public DecryptDriversLicenseService(RestClient client, Guid userId)
        {
            _client = client;
            _configuration = new Configuration();
            _userId = userId;
        }



        public void AddConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IRestResponse<string> Search(string scannedDriversLicense)
        {
            throw new NotImplementedException();
        }
    }
}
