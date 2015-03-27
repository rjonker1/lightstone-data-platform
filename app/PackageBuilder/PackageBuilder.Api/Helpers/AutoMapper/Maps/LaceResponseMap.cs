using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.Packages.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class LaceResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IPackage, Package>()
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => x.DataProviders.Select(Mapper.Map<IDataProvider, DataProvider>).ToList()));

            Mapper.CreateMap<IPointToLaceProvider, DataProviderName>()
                .Include<IProvideDataFromIvid, DataProviderName>()
                .Include<IProvideDataFromIvidTitleHolder, DataProviderName>()
                .Include<IProvideDataFromLightstoneAuto, DataProviderName>()
                .Include<IProvideDataFromRgt, DataProviderName>()
                .Include<IProvideDataFromRgtVin, DataProviderName>()
                .Include<IProvideDataFromAudatex, DataProviderName>()
                .Include<IProvideDataFromLightstoneProperty, DataProviderName>()
                .Include<IProvideDataFromSignioDriversLicenseDecryption, DataProviderName>()
                .Include<IProvideDataFromPCubedFicaVerfication, DataProviderName>();
            Mapper.CreateMap<IProvideDataFromIvid, DataProviderName>().ConvertUsing(s => DataProviderName.Ivid);
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, DataProviderName>().ConvertUsing(s => DataProviderName.IvidTitleHolder);
            Mapper.CreateMap<IProvideDataFromLightstoneAuto, DataProviderName>().ConvertUsing(s => DataProviderName.LightstoneAuto);
            Mapper.CreateMap<IProvideDataFromRgt, DataProviderName>().ConvertUsing(s => DataProviderName.Rgt);
            Mapper.CreateMap<IProvideDataFromRgtVin, DataProviderName>().ConvertUsing(s => DataProviderName.RgtVin);
            Mapper.CreateMap<IProvideDataFromAudatex, DataProviderName>().ConvertUsing(s => DataProviderName.Audatex);
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, DataProviderName>().ConvertUsing(s => DataProviderName.LightstoneProperty);
            Mapper.CreateMap<IProvideDataFromSignioDriversLicenseDecryption, DataProviderName>().ConvertUsing(s => DataProviderName.SignioDecryptDriversLicense);
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, DataProviderName>().ConvertUsing(s => DataProviderName.PCubedFica);

            Mapper.CreateMap<IPointToLaceProvider, DataProvider>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(DataProviderName))))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map(x, x.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>));

            Mapper.CreateMap<IDataProvider, DataProvider>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .BeforeMap((s, d) =>
                {
                    if (s.DataFields != null)
                    {
                        var objects = s.DataFields.ToNamespace().Select(x => (IDataField)Mapper.Map(x, d.DataFields.ToNamespace().Filter(f => x != null && f.Namespace == x.Namespace)
                            .FirstOrDefault(), typeof(IDataField), typeof(DataField))).ToList();
                        d.DataFields = objects.Filter(x => x.IsSelected == true);
                    }
                })
            .ForMember(d => d.DataFields, opt => opt.Ignore());
            //.ForMember(d => d.DataFields, opt => opt.ResolveUsing(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataField>>(x.DataFields)));
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map(x.DataFields, typeof(IEnumerable<DataField>))));
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields.Select(f => Mapper.Map(f, typeof(DataField)))));
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields.SelectHierarchy(fld => fld.DataFields, fld => fld.IsSelected == true)))
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataField>>(x.DataFields.SelectHierarchy(fld => fld.DataFields, fld => fld.IsSelected == true))))
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields.SelectHierarchy(fld => fld.DataFields, fld => fld.IsSelected == true).Select(Mapper.Map<IDataField, DataField>)))
            //.AfterMap((s, d) =>
            //{
            //    d.DataFields = d.DataFields.SelectHierarchy(fld => fld.DataFields, fld => fld.IsSelected == true).ToList();
            //    if (!d.DataFields.Any())
            //        d = null;
            //});

            //Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataField>>()
            //    .BeforeMap((s, d) =>
            //    {
            //        d = s.Traverse()
            //            .Select(x => Mapper.Map(x, d.Traverse()
            //                .SelectHierarchy(f => f.DataFields, f => f.Namespace == x.Namespace).FirstOrDefault())).Cast<DataField>();
            //    })
             //.ConvertUsing<ITypeConverter<IEnumerable<IDataField>, IEnumerable<DataField>>>();
               //.ConvertUsing(s => s != null ? s.Select(Mapper.Map<IDataField, DataField>) : Enumerable.Empty<DataField>());
               //.ConvertUsing(s => s != null ? s.Select(x => Mapper.Map(x, typeof(DataField))).Cast<DataField>() : Enumerable.Empty<DataField>());
            Mapper.CreateMap<IDataField, DataField>()
                .BeforeMap((s, d) =>
                {

                })
                .ForMember(d => d.IsSelected, opt => opt.Ignore());
            //.ForMember(d => d.IsSelected, opt => opt.MapFrom(x => Mapper.Map<IDataField, bool>(x)))
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields.Where(fld => fld.IsSelected == true)))
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map(x.DataFields, typeof(IEnumerable<IDataField>))));
            //.ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataField>>(x.DataFields)));

            //Mapper.CreateMap<IDataField, bool>()
            //    .ConvertUsing<ITypeConverter<IDataField, bool>>();
        }
    }
}