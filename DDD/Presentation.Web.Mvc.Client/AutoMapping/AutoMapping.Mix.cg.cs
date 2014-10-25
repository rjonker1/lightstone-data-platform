using AutoMapper;

namespace LightstoneApp.Presentation.Web.Mvc.Client.AutoMapping
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
    		
    		ConfigureMappingCustom();
    	}
    }
}
