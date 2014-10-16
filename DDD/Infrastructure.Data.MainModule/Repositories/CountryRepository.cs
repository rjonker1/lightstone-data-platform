using LightstoneApp.Domain.MainModule.Countries;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.Core;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;

namespace LightstoneApp.Infrastructure.Data.MainModule.Repositories
{
    /// <summary>
    ///     ICountryRepository implementation
    ///     for more information <see cref="LightstoneApp.Domain.MainModule.Countries.ICountryRepository" />
    /// </summary>
    public class CountryRepository
        : Repository<Country>, ICountryRepository
    {
        #region Constructor

        /// <summary>
        ///     Default constructor for this repository
        /// </summary>
        /// <param name="unitOfWork">IMainModuleUnitOfWork dependency, intented to be resolved with IoC</param>
        /// <param name="traceManager">ITraceManager context, intended to be resolved wiht IoC</param>
        public CountryRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager)
            : base(unitOfWork, traceManager)
        {
        }

        #endregion
    }
}