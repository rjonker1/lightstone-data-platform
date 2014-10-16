namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class PackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Mapper.CreateMap<DataProviderDto, DataProvider>()
            //    .ConvertUsing(x => new DataProvider(x.Id, x.Name, Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(x.DataFields)));
        }
    }
}