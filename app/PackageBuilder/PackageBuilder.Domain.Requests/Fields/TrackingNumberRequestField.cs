using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class TrackingNumberRequestField : IAmTrackingNumberRequestField
    {
        public TrackingNumberRequestField(string field)
        {
            Field = field;
        }
        public string Field { get; private set; }
    }
}
