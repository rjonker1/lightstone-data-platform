namespace Lace.Request
{
    public interface IProvideCarInformationForRequest
    {
        int? CarId { get; }
        string Make { get; }
        string Model { get; }
        string Vin { get; }
        string Username { get; }
        string Password { get; }
        int? Year { get; }
        int MakeId { get; }
        bool IsVin12 { get; }

        void SetCarModelYear(int? carId, string model, int? year);
    }
}
