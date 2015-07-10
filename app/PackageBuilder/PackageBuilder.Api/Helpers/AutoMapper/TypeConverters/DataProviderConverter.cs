using System.Linq;
using AutoMapper;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
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

            var currentRequestFields = dataProvider.RequestFields.ToNamespace().ToList();
            foreach (var requestFieldOverrides in source.RequestFieldOverrides.ToNamespace())
            {
                var requestField = currentRequestFields.FirstOrDefault(fld => fld != null && fld.Namespace.Trim().ToLower() == requestFieldOverrides.Namespace.Trim().ToLower());
                if (requestField != null)
                    requestField.OverrideValuesFromPackage(requestFieldOverrides.CostOfSale, requestFieldOverrides.IsSelected);
            }

            var currentDataFields = dataProvider.DataFields.ToNamespace().ToList();
            foreach (var dataFieldValueOverride in source.DataFieldOverrides.ToNamespace())
            {
                var dataField = currentDataFields.FirstOrDefault(fld => fld.Namespace.Trim().ToLower() == dataFieldValueOverride.Namespace.Trim().ToLower());
                if (dataField != null)
                    dataField.OverrideValuesFromPackage(dataFieldValueOverride.CostOfSale, dataFieldValueOverride.IsSelected);
            }

            return dataProvider;
        }
    }
}