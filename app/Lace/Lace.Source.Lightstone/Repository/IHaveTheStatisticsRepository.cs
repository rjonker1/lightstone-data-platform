using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Repository
{
    public interface IHaveTheStatisticsRepository
    {
        IReadOnlyRepository<Statistic> Repository { set; }
    }
}
