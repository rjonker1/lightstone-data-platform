using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Lsp
{
    public interface IRespondWithLspInformation : IProvideType
    {
        IRespondWithReturnProperties Properties { get; }
       
    }

    public interface IRespondWithReturnProperties : IProvideType
    {
        /// <summary>
        /// This is an internal number used by Lightstone
        /// </summary>
        int sr_id { get; set; }

        /// <summary>
        /// This is the unique property ID for each property on the Lightstone property database and 
        /// must be stored for validated properties where further processing is required for 
        /// the selected property
        /// </summary>
        decimal prop_id { get; set; }

        /// <summary>
        /// This is an internal Lightstone field
        /// </summary>
        decimal DEED_ID { get; set; }

        // TODO: the reset of the fields as per LS Properties Web Service documentation
        
        

    }

}
