namespace Lace.CrossCutting.DataProvider.Certificate.Core.Contracts
{
    public interface IProvideCertificate
    {
        IDefineTheCertificate Certificate { get; }
        bool IsSuccessfull { get; }
        void GenerateCertificate();
    }
}
