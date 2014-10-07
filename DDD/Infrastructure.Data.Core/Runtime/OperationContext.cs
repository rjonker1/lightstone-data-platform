using System;
using System.Collections.Generic;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Runtime
{
	public class OperationContext : IOperationContext
	{
		readonly Dictionary<String, Object> data = new Dictionary<string, object>();

		public void Dispose()
		{
			this.CorrelationId = null;
			this.data.Clear();
		}

		public IOperationContext ForOperation( string correlationId )
		{
			//Ensure.That( correlationId ).Named( () => correlationId ).IsNotNullNorEmpty();
			Ensure.That( this.CorrelationId ).Is( null );

			this.CorrelationId = correlationId;

			return this;
		}


		public string CorrelationId
		{
			get;
			private set;
		}

		public void Add( string key, object value )
		{
			this.data.Add( key, value );
		}

		public T Get<T>( string key )
		{
			return ( T )this.data[ key ];
		}
	}
}