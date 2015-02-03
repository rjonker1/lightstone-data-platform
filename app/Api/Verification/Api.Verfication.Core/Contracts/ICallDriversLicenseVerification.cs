namespace Api.Verfication.Core.Contracts
{
    public interface ICallDriversLicenseVerification
    {
        //DrivingLicenseCard DecodeDriversLincenseFromScan(string scanData, string registrationCode, string username,
        //    Guid userId, out string decodedData);
        IHaveDriversLicenseResponse DecodeDriversLincenseFromScan(IHaveDriversLicenseRequest request);
    }
}
