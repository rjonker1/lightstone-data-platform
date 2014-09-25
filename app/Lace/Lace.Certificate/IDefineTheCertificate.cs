namespace Lace.Certificate
{
    public interface IDefineTheCertificate
    {
        bool HasCredentials { get; }
        bool HasProximity { get; }

        string Name { get; }
        string DisplayName { get; }
        bool IsActive { get; }

        bool IsDefault { get; }

        string Description { get; }

        IDefineTheProximity Proximity { get; }
        IDefineTheCredentials Credentials { get; }

        string Endpoint { get; }
    }
}
