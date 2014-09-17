using Lace.Models.Responses.Sources.Metric;

namespace Lace.Models.Responses.Sources.Specifics
{
    public interface IRespondWithTotalSalesByAgeModel
    {
        string Band { get; }
        IPair<string, double>[] Values { get; }
    }
}