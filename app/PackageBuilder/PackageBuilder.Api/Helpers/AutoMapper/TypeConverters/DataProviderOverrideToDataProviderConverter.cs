using System.Linq;
using AutoMapper;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataProviderOverrideToDataProviderConverter : TypeConverter<DataProviderOverride, IDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _repository;

        public DataProviderOverrideToDataProviderConverter(INEventStoreRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        protected override IDataProvider ConvertCore(DataProviderOverride source)
        {
            var dataProvider = _repository.GetById(source.Id);

            dataProvider.OverrideCostValuesFromPackage(source.CostOfSale);

            var currentDataFields = dataProvider.DataFields.Traverse().ToList();
            foreach (var dataFieldValueOverride in source.DataFieldOverrides.Traverse())
            {
                var dataField = currentDataFields.FirstOrDefault(fld => fld.Namespace.Trim().ToLower() == dataFieldValueOverride.Namespace.Trim().ToLower());
                if (dataField != null)
                    dataField.SetPrice(dataFieldValueOverride.CostOfSale);
            }

            return dataProvider;
        }
    }
}