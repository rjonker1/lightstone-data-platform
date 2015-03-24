using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace PackageBuilder.Domain.Dtos.Read
{
    public interface IDataProviderRequest
    {
        Guid Id { get; }
        string Name { get; }
        IAction Action { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
    }
    public class DataProviderRequestDto : IDataProviderRequest
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IAction Action { get; private set; }

        public IEnumerable<IDataProvider> DataProviders { get; private set; }

        public DataProviderRequestDto()
        {
        }

        public DataProviderRequestDto(Guid id, string name, IAction action)
        {
            Id = id;
            Name = name;
            Action = action;
        }

        public void SetDataProviders(PackageDto package)
        {
            var dataProviders = GetSelectedDataProvidersForSearchRequest(package);

            DataProviders = dataProviders.Select(
                s =>
                    new DataProvider(s.Id, (DataProviderName) Enum.Parse(typeof (DataProviderName), s.Name),
                        s.Description, s.CostOfSale, null,
                        s.FieldLevelCostPriceOverride, s.Owner, s.CreatedDate, s.EditedDate,
                        s.DataFields.Select(
                            d =>
                                new DataField(d.Name, d.Type, d.Definition, d.Industries, d.Price,
                                    d.IsSelected.HasValue ? d.IsSelected.Value : false))));
        }


        private static IEnumerable<Write.DataProviderDto> GetSelectedDataProvidersForSearchRequest(PackageDto package)
        {
            var dataProviderList = new List<Write.DataProviderDto>();

            foreach (var dataProvider in package.DataProviders)
            {

                CheckForSelectedDataFields(dataProvider.DataFields.ToList(), dataProviderList,
                    dataProvider);
            }

            return dataProviderList;
        }

        private static bool CheckForSelectedDataFields(IEnumerable<DataProviderFieldItemDto> dataFields,
          ICollection<Write.DataProviderDto> dataProviderList, Write.DataProviderDto dataProvider)
        {
            //Debug.Write("\n\n***********************");
            //Debug.Write(string.Format("\nData Provider {0}", dataProvider.Name));

            foreach (var field in dataFields)
            {
                var isSelected = field.IsSelected != null && field.IsSelected.Value ||
                                 field.DataFields.FirstOrDefault(
                                     w => w.IsSelected != null && w.IsSelected.Value) != null;

                //Debug.Write(string.Format("\n{0} has selected datafields or is selected? {1} Fields Selected Value {2}",
                //    field.Name, isSelected, field.IsSelected));

                if (isSelected)
                {
                    dataProviderList.Add(dataProvider);
                    return true;
                }

                //Debug.Write("\n++++++++++++++++++++++++++++++++++++++++");
                //Debug.Write("\nContinue to next list.....");
                var stop = CheckForSelectedDataFields(field.DataFields.ToList(), dataProviderList, dataProvider);

                if (stop)
                    return true;
            }

            //Debug.Write("\n========================================");
            //Debug.Write("\nReturning false.....");
            return false;
        }

    }
}
