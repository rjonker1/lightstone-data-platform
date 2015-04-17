namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmRequestField
    {
        string Field { get; }
    }

    public interface IAmVinRequestField : IAmRequestField
    {

    }

    public interface IAmLicenseNumberRequestField : IAmRequestField
    {

    }

    public interface IAmRegisterNumberRequestField : IAmRequestField
    {

    }
}
