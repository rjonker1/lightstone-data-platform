namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveCarInformation
    {
        int CarId { get; }
        string Make { get; }
        string Model { get; }
        string Vin { get; }
        string Username { get; }
        string Password { get; }
        int Year { get; }
        int MakeId { get; }
        bool IsVin12 { get; }

        void SetCarModelYearMake(int? carId, string model, int? year, int makeId);
        bool HasValidCarIdAndYear();
        bool HasValidCarId();
    }
}
