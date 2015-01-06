namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Contracts
{
    public interface IProvideCertificate
    {
        IDefineTheCertificate Certificate { get; }
        bool IsSuccessfull { get; }
        void GenerateCertificate();
    }
}
