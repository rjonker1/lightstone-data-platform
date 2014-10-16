using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Countries
{
    /// <summary>
    ///     Contract for aggregate Country repository
    /// </summary>
    public interface ICountryRepository
        : IRepository<Country>
    {
    }
}