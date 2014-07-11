namespace Lace.Models.Lightstone
{
    public interface IResponseFromLightstone
    {
        int? CarId { get; }

        int? Year { get; }

        string Vin { get; }

        string ImageUrl { get; }

        string Quarter { get; }

        string CarFullname { get; }

        string Model { get; }

    }
}
