using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Repository
{
    public interface IHaveStatisticsRepository
    {
        IReadOnlyRepository<Statistics> Repository { set; }
    }
}
