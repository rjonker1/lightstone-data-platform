using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Lsp
{
    public interface IRespondWithLspInformation : IProvideType
    {
        IRespondWithReturnProperties Properties { get; set; }
       
    }

    public interface IRespondWithReturnProperties : IProvideType
    {
        /// <summary>
        /// This is an internal number used by Lightstone
        /// </summary>
        int sr_id { get; set; }

        /// <summary>
        /// This is the unique property ID for each property on the Lightstone property database and must be stored for 
        /// validated properties where further processing is required for the selected property
        /// </summary>
        decimal prop_id { get; set; }

        /// <summary>
        /// This is an internal Lightstone field
        /// </summary>
        decimal DEED_ID { get; set; }

        /// <summary>
        /// 1 = Farm, 2 = Sectional Scheme, 3 = Freehold
        /// </summary>
        decimal PROPTYPE_ID { get; set; }

        /// <summary>
        /// This is an internal number used by Lightstone
        /// </summary>

        decimal SS_ID { get; set; }

        /// <summary>
        /// This is an internal Lightstone field
        /// </summary>
        decimal NAD_ID { get; set; }


        /// <summary>
        /// SS = Sectional scheme, FH = Free Hold, FR = Farm
        /// </summary>
        string property_type { get; set; }

        /// <summary>
        /// "PROV_ID:PROVINCE:PROVINCE_ABBREV
        ///1 LIMPOPO LIM
        ///2 FREE STATE FS
        ///3 NORTHERN CAPE NC
        ///4 WESTERN CAPE WC
        ///5 KWAZULU NATAL KN
        ///6 MPUMALANGA MP
        ///7 NORTH WEST NW
        ///8 GAUTENG GA
        ///9 EASTERN CAPE EC
        ///10 FARMS FR"
        /// </summary>
        string PROVINCE { get; set; }

        //This is the textual description of the municipality name that the property resides in.
        string MUNICNAME { get; set; }

        /// <summary>
        /// This is the textual description of the Deedtown name that the property resides in.
        /// </summary>
        string DEEDTOWN { get; set; }

        /// <summary>
        /// This is the name of the farm if the property returned is a farm.
        /// </summary>
        string FARMNAME { get; set; }

        /// <summary>
        /// This is the textual description of the Sectional Title scheme name that the property resides in.
        /// </summary>
        string SECTIONAL_TITLE { get; set; }

        //TODO: the reset of the fields as per the specification in excel speadsheet
        
        

    }

}
