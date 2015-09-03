using RestSharp;

namespace Lace.Toolbox.Signio
{
    public interface IDecryptDriversLicenseService
    {
        void AddConfiguration(IConfiguration configuration);
        IRestResponse<string> Search(string scannedDriversLicense);
    }
}
