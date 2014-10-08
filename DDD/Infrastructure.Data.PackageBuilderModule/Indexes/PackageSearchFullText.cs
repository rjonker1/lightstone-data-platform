using System;
using System.Linq;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Indexes
{
	public class PackageSearchFullText : AbstractMultiMapIndexCreationTask<PackageSearchFullText.SearchResult>
	{
		public class SearchMap
		{
			public object[] Content { get; private set; }
		}

		public class SearchResult
		{
			public String Id { get; private set; }
			public String DisplayName { get; private set; }
			public String ClrType { get; private set; }
			public String Collection { get; private set; }
		}

		public PackageSearchFullText()
		{
			AddMap<Package>( docs => from doc in docs
										 select new
										 {
											 Id = doc.PackageId,
											 Content = new object[] 
											 { 
												 doc.Name,
												 doc.Version
											 },
											 DisplayName = doc.Name + " " + doc.Version,
											 ClrType = MetadataFor( doc ).Value<String>( "Raven-Clr-Type" ),
											 Collection = MetadataFor( doc ).Value<String>( "Raven-Entity-Name" ),
										 } );

			AddMap<DataSource>( docs => from doc in docs
										  select new
										  {
											  Id = doc.DataSourceId,
											  Content = new object[] 
											  { 
												  doc.Name
											  },
											  DisplayName = doc.Name,
											  ClrType = MetadataFor( doc ).Value<String>( "Raven-Clr-Type" ),
											  Collection = MetadataFor( doc ).Value<String>( "Raven-Entity-Name" ),
										  } );

			Store( r => r.Id, FieldStorage.Yes );
			Store( r => r.DisplayName, FieldStorage.Yes );
			Store( r => r.ClrType, FieldStorage.Yes );
			Store( r => r.Collection, FieldStorage.Yes );
		}
	}
}
