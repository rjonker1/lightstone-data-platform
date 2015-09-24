using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nancy.Extensions;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataProviderConverter : TypeConverter<IEnumerable<IDataProviderOverride>, IEnumerable<DataProvider>>
    {
        private readonly IRepository<Domain.Entities.DataProviders.Read.DataProvider> _readRepository;
        private readonly INEventStoreRepository<DataProvider> _writeRepository;

        public DataProviderConverter(IRepository<Domain.Entities.DataProviders.Read.DataProvider> readRepository, INEventStoreRepository<DataProvider> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        /// <summary>
        /// Maps the current package data provider values onto the latest data provider structure so that at any given time,  
        /// a package will have the latest changes made to any of the data providers available. eg:
        /// 
        /// If a package is created with the 1st initial version of the IVID data provider and 2 months from now the package is 
        /// edited, this method will map and make the latest structure or changes made to the IVID data provider available to 
        /// the package.
        /// 
        /// Note: For NewDps vs source comparision, older packages created before new imported DPs will always result in NewDps being
        /// populated by 'n' number of dataprovider depending on 'n' imported. Not applicable to packages created after new DPs imported.
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected override IEnumerable<DataProvider> ConvertCore(IEnumerable<IDataProviderOverride> source)
        {
            var sourceCompare = source.Select(o => o.Id);
            var newDps = _readRepository.Where(x => !sourceCompare.Contains(x.DataProviderId)).DistinctBy(x => x.DataProviderId);

            var list = new List<DataProvider>();
            list.AddRange(DataProviders(source));
            list.AddRange(newDps.Select(x => Mapper.Map<IDataProvider, DataProvider>(_writeRepository.GetById(x.DataProviderId, false))));

            return list;
        }

        private IEnumerable<DataProvider> DataProviders(IEnumerable<IDataProviderOverride> source)
        {
            foreach (var dataProviderOverride in source)
            {
                var dataProvider = _writeRepository.GetById(dataProviderOverride.Id);

                dataProvider.RequestFields.ToNamespace().ToList().Cast<DataField>()
                    .RecursiveForEach(x => Mapper.Map(dataProviderOverride.RequestFieldOverrides.ToNamespace()
                                    .Filter(f => x != null && f.Namespace == x.Namespace)
                                    .FirstOrDefault(), x));

                //var d = dataProvider.DataFields.ToNamespace().ToList().Cast<DataField>();
                //var c = dataProviderOverride.DataFieldOverrides.ToNamespace();

                //foreach (var dataField in d)
                //{
                //    var test = Mapper.Map(c
                //        .Filter(f => f.Namespace == dataField.Namespace)
                //        .FirstOrDefault(), dataField);
                //}

                dataProvider.DataFields.ToNamespace().ToList().Cast<DataField>()
                    .RecursiveForEach(x => Mapper.Map(dataProviderOverride.DataFieldOverrides.ToNamespace()
                                    .Filter(f => x != null && f.Namespace == x.Namespace)
                                    .FirstOrDefault(), x));

                yield return dataProvider;
            }
        }
    }
}