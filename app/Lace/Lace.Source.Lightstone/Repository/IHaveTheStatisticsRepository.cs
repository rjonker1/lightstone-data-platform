using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Repository
{
    public interface IHaveTheStatisticsRepository
    {
        IReadOnlyRepository<Statistics> Repository { set; }
    }
}
