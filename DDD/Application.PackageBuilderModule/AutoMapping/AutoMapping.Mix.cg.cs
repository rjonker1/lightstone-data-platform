using AutoMapper;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;


namespace LightstoneApp.Application.PackageBuilderModule.AutoMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profiles : Profile
    {
    	/// <summary>
        /// AutoMapper configuration
        /// </summary>
        protected override void Configure()
    	{
    		// Mapping config for Domain.PackageBuilderModule.Entities.DataField => DataField
    		Mapper.CreateMap<Domain.PackageBuilderModule.Entities.DataField, DataField>()
    			.ForMember(m => m.DataProvider, options => options.MapFrom(f => f.DataProvider))
    			.ForMember(m => m.Industry, options => options.MapFrom(f => f.Industry))
    			.ForMember(m => m.PackageDataFields, options => options.MapFrom(f => f.PackageDataFields));
    
    		// Mapping config for CustomQuery<Domain.PackageBuilderModule.Entities.DataField> => CustomQuery<DataField>
    		Mapper.CreateMap<CustomQuery<Domain.PackageBuilderModule.Entities.DataField>, CustomQuery<DataField>>();
    
    		// Mapping config for PagedCollection<Domain.PackageBuilderModule.Entities.DataField> => PagedCollection<DataField>
    		Mapper.CreateMap<PagedCollection<Domain.PackageBuilderModule.Entities.DataField>, PagedCollection<DataField>>();
    
    		// Reverse mapping config for DataField => Domain.PackageBuilderModule.Entities.DataField
    		Mapper.CreateMap<DataField, Domain.PackageBuilderModule.Entities.DataField>()
    			.ForMember(m => m.DataProvider, options => options.MapFrom(f => f.DataProvider))
    			.ForMember(m => m.Industry, options => options.MapFrom(f => f.Industry))
    			.ForMember(m => m.PackageDataFields, options => options.MapFrom(f => f.PackageDataFields));
    
    		// Reverse mapping config for CustomQuery<DataField> => CustomQuery<Domain.PackageBuilderModule.Entities.DataField>
    		Mapper.CreateMap<CustomQuery<DataField>, CustomQuery<Domain.PackageBuilderModule.Entities.DataField>>();
    
    		// Reverse mapping config for PagedCollection<DataField> => PagedCollection<Domain.PackageBuilderModule.Entities.DataField>
    		Mapper.CreateMap<PagedCollection<DataField>, PagedCollection<Domain.PackageBuilderModule.Entities.DataField>>();
    		// Mapping config for Domain.PackageBuilderModule.Entities.DataProvider => DataProvider
    		Mapper.CreateMap<Domain.PackageBuilderModule.Entities.DataProvider, DataProvider>()
    			.ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
    			.ForMember(m => m.State, options => options.MapFrom(f => f.State));
    
    		// Mapping config for CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider> => CustomQuery<DataProvider>
    		Mapper.CreateMap<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>, CustomQuery<DataProvider>>();
    
    		// Mapping config for PagedCollection<Domain.PackageBuilderModule.Entities.DataProvider> => PagedCollection<DataProvider>
    		Mapper.CreateMap<PagedCollection<Domain.PackageBuilderModule.Entities.DataProvider>, PagedCollection<DataProvider>>();
    
    		// Reverse mapping config for DataProvider => Domain.PackageBuilderModule.Entities.DataProvider
    		Mapper.CreateMap<DataProvider, Domain.PackageBuilderModule.Entities.DataProvider>()
    			.ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
    			.ForMember(m => m.State, options => options.MapFrom(f => f.State));
    
    		// Reverse mapping config for CustomQuery<DataProvider> => CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>
    		Mapper.CreateMap<CustomQuery<DataProvider>, CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>();
    
    		// Reverse mapping config for PagedCollection<DataProvider> => PagedCollection<Domain.PackageBuilderModule.Entities.DataProvider>
    		Mapper.CreateMap<PagedCollection<DataProvider>, PagedCollection<Domain.PackageBuilderModule.Entities.DataProvider>>();
    		// Mapping config for Domain.PackageBuilderModule.Entities.Industry => Industry
    		Mapper.CreateMap<Domain.PackageBuilderModule.Entities.Industry, Industry>()
    			.ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
    			.ForMember(m => m.Packages, options => options.MapFrom(f => f.Packages));
    
    		// Mapping config for CustomQuery<Domain.PackageBuilderModule.Entities.Industry> => CustomQuery<Industry>
    		Mapper.CreateMap<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>, CustomQuery<Industry>>();
    
    		// Mapping config for PagedCollection<Domain.PackageBuilderModule.Entities.Industry> => PagedCollection<Industry>
    		Mapper.CreateMap<PagedCollection<Domain.PackageBuilderModule.Entities.Industry>, PagedCollection<Industry>>();
    
    		// Reverse mapping config for Industry => Domain.PackageBuilderModule.Entities.Industry
    		Mapper.CreateMap<Industry, Domain.PackageBuilderModule.Entities.Industry>()
    			.ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
    			.ForMember(m => m.Packages, options => options.MapFrom(f => f.Packages));
    
    		// Reverse mapping config for CustomQuery<Industry> => CustomQuery<Domain.PackageBuilderModule.Entities.Industry>
    		Mapper.CreateMap<CustomQuery<Industry>, CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>();
    
    		// Reverse mapping config for PagedCollection<Industry> => PagedCollection<Domain.PackageBuilderModule.Entities.Industry>
    		Mapper.CreateMap<PagedCollection<Industry>, PagedCollection<Domain.PackageBuilderModule.Entities.Industry>>();
    		// Mapping config for Domain.PackageBuilderModule.Entities.Package => Package
    		Mapper.CreateMap<Domain.PackageBuilderModule.Entities.Package, Package>()
    			.ForMember(m => m.Industry, options => options.MapFrom(f => f.Industry))
    			.ForMember(m => m.State, options => options.MapFrom(f => f.State))
    			.ForMember(m => m.PackageDataFields, options => options.MapFrom(f => f.PackageDataFields));
    
    		// Mapping config for CustomQuery<Domain.PackageBuilderModule.Entities.Package> => CustomQuery<Package>
    		Mapper.CreateMap<CustomQuery<Domain.PackageBuilderModule.Entities.Package>, CustomQuery<Package>>();
    
    		// Mapping config for PagedCollection<Domain.PackageBuilderModule.Entities.Package> => PagedCollection<Package>
    		Mapper.CreateMap<PagedCollection<Domain.PackageBuilderModule.Entities.Package>, PagedCollection<Package>>();
    
    		// Reverse mapping config for Package => Domain.PackageBuilderModule.Entities.Package
    		Mapper.CreateMap<Package, Domain.PackageBuilderModule.Entities.Package>()
    			.ForMember(m => m.Industry, options => options.MapFrom(f => f.Industry))
    			.ForMember(m => m.State, options => options.MapFrom(f => f.State))
    			.ForMember(m => m.PackageDataFields, options => options.MapFrom(f => f.PackageDataFields));
    
    		// Reverse mapping config for CustomQuery<Package> => CustomQuery<Domain.PackageBuilderModule.Entities.Package>
    		Mapper.CreateMap<CustomQuery<Package>, CustomQuery<Domain.PackageBuilderModule.Entities.Package>>();
    
    		// Reverse mapping config for PagedCollection<Package> => PagedCollection<Domain.PackageBuilderModule.Entities.Package>
    		Mapper.CreateMap<PagedCollection<Package>, PagedCollection<Domain.PackageBuilderModule.Entities.Package>>();
    		// Mapping config for Domain.PackageBuilderModule.Entities.PackageDataField => PackageDataField
    		Mapper.CreateMap<Domain.PackageBuilderModule.Entities.PackageDataField, PackageDataField>()
    			.ForMember(m => m.DataField, options => options.MapFrom(f => f.DataField))
    			.ForMember(m => m.Package, options => options.MapFrom(f => f.Package));
    
    		// Mapping config for CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField> => CustomQuery<PackageDataField>
    		Mapper.CreateMap<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>, CustomQuery<PackageDataField>>();
    
    		// Mapping config for PagedCollection<Domain.PackageBuilderModule.Entities.PackageDataField> => PagedCollection<PackageDataField>
    		Mapper.CreateMap<PagedCollection<Domain.PackageBuilderModule.Entities.PackageDataField>, PagedCollection<PackageDataField>>();
    
    		// Reverse mapping config for PackageDataField => Domain.PackageBuilderModule.Entities.PackageDataField
    		Mapper.CreateMap<PackageDataField, Domain.PackageBuilderModule.Entities.PackageDataField>()
    			.ForMember(m => m.DataField, options => options.MapFrom(f => f.DataField))
    			.ForMember(m => m.Package, options => options.MapFrom(f => f.Package));
    
    		// Reverse mapping config for CustomQuery<PackageDataField> => CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>
    		Mapper.CreateMap<CustomQuery<PackageDataField>, CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>();
    
    		// Reverse mapping config for PagedCollection<PackageDataField> => PagedCollection<Domain.PackageBuilderModule.Entities.PackageDataField>
    		Mapper.CreateMap<PagedCollection<PackageDataField>, PagedCollection<Domain.PackageBuilderModule.Entities.PackageDataField>>();
    		// Mapping config for Domain.PackageBuilderModule.Entities.State => State
    		Mapper.CreateMap<Domain.PackageBuilderModule.Entities.State, State>()
    			.ForMember(m => m.DataProviders, options => options.MapFrom(f => f.DataProviders))
    			.ForMember(m => m.Packages, options => options.MapFrom(f => f.Packages));
    
    		// Mapping config for CustomQuery<Domain.PackageBuilderModule.Entities.State> => CustomQuery<State>
    		Mapper.CreateMap<CustomQuery<Domain.PackageBuilderModule.Entities.State>, CustomQuery<State>>();
    
    		// Mapping config for PagedCollection<Domain.PackageBuilderModule.Entities.State> => PagedCollection<State>
    		Mapper.CreateMap<PagedCollection<Domain.PackageBuilderModule.Entities.State>, PagedCollection<State>>();
    
    		// Reverse mapping config for State => Domain.PackageBuilderModule.Entities.State
    		Mapper.CreateMap<State, Domain.PackageBuilderModule.Entities.State>()
    			.ForMember(m => m.DataProviders, options => options.MapFrom(f => f.DataProviders))
    			.ForMember(m => m.Packages, options => options.MapFrom(f => f.Packages));
    
    		// Reverse mapping config for CustomQuery<State> => CustomQuery<Domain.PackageBuilderModule.Entities.State>
    		Mapper.CreateMap<CustomQuery<State>, CustomQuery<Domain.PackageBuilderModule.Entities.State>>();
    
    		// Reverse mapping config for PagedCollection<State> => PagedCollection<Domain.PackageBuilderModule.Entities.State>
    		Mapper.CreateMap<PagedCollection<State>, PagedCollection<Domain.PackageBuilderModule.Entities.State>>();
    			
    		ConfigureMappingCustom();
    	}
    
    }
}
