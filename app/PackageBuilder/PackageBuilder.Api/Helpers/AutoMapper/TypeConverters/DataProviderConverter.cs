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

        protected override DataProvider ConvertCore(IDataProviderOverride source)
        {
            var dataProvider = _repository.GetById(source.Id);

            dataProvider.OverrideCostValuesFromPackage(source.CostOfSale);

            dataProvider.RequestFields.ToNamespace().ToList().Cast<DataField>()
                               .RecursiveForEach(x => Mapper.Map(source.RequestFieldOverrides.ToNamespace().Filter(f => x != null && f.Namespace == x.Namespace).FirstOrDefault(), x));

            dataProvider.DataFields.ToNamespace().ToList().Cast<DataField>()
                               .RecursiveForEach(x => Mapper.Map(source.DataFieldOverrides.ToNamespace().Filter(f => x != null && f.Namespace == x.Namespace).FirstOrDefault(), x));

            return dataProvider;
        }
    }
}