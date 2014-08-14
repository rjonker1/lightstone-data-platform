namespace Lace.Models.Lightstone
{
    public interface IRespondWithCarModel
    {
        long CarModelId { get; }
        int CarId { get; }
        string CarMake { get; }
        string CarType { get; }
        int? CarYearId { get; }
        string CarModelName { get; }
        string CarFullname { get; }
        byte[] RowVersion { get; }
        string ImageUrl { get; }
    }
}