using System.Linq;
using AutoMapper;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataProviderConverter : TypeConverter<IDataProviderOverride, DataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _repository;

        public DataProviderConverter(INEventStoreRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Maps the current package data provider values onto the latest data provider structure so that at any given time,  
        /// a package will have the latest changes made to any of the data providers available. eg:
        /// 
        /// If a package is created with the 1st initial version of the IVID data provider and 2 months from now the package is 
        /// edited, this method will map and make the latest structure or changes made to the IVID data provider available to 
        /// the package.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected override DataProvider ConvertCore(IDataProviderOverride source)
        {
            var dataProvider = _repository.GetById(source.Id);

            dataProvider.RequestFields.ToNamespace().ToList().Cast<DataField>()
                               .RecursiveForEach(x => Mapper.Map(source.RequestFieldOverrides.ToNamespace().Filter(f => x != null && f.Namespace == x.Namespace).FirstOrDefault(), x));

            dataProvider.DataFields.ToNamespace().ToList().Cast<DataField>()
                               .RecursiveForEach(x => Mapper.Map(source.DataFieldOverrides.ToNamespace().Filter(f => x != null && f.Namespace == x.Namespace).FirstOrDefault(), x));

            return dataProvider;
        }
    }
}