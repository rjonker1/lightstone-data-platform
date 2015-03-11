using System;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.LightstoneProperty
{
    public interface IRespondWithProperty : IProvideType
    {
        /// <summary>
        /// This is an internal number used by Lightstone
        /// </summary>
        int SrId { get; }

        /// <summary>
        /// This is the unique property ID for each property on the Lightstone property database and must be stored for 
        /// validated properties where further processing is required for the selected property
        /// </summary>
        decimal PropertyId { get; }

        /// <summary>
        /// This is an internal Lightstone field
        /// </summary>
        decimal DeedId { get; }

        /// <summary>
        /// 1 = Farm, 2 = Sectional Scheme, 3 = Freehold
        /// </summary>
        decimal PropTypeId { get; }

        /// <summary>
        /// This is an internal number used by Lightstone
        /// </summary>

        decimal SsId { get; }

        /// <summary>
        /// This is an internal Lightstone field
        /// </summary>
        decimal NadId { get; }


        /// <summary>
        /// SS = Sectional scheme, FH = Free Hold, FR = Farm
        /// </summary>
        string PropertyType { get; }

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
        string Province { get; }

        //This is the textual description of the municipality name that the property resides in.
        string Muncipality { get; }

        /// <summary>
        /// This is the textual description of the Deedtown name that the property resides in.
        /// </summary>
        string Deedtown { get; }

        /// <summary>
        /// This is the name of the farm if the property returned is a farm.
        /// </summary>
        string FarmName { get; }

        /// <summary>
        /// This is the textual description of the Sectional Title scheme name that the property resides in.
        /// </summary>
        string SectionalTitle { get; }
      
        /// <summary>
        /// If the property is registered in a sectional scheme the unit number is populated in this field.
        /// </summary>
        int Unit { get; }

        /// <summary>
        /// This field contains the portion number of the property.
        /// </summary>
        decimal Portion { get; }

        /// <summary>
        /// This field contains the full registered owner’s name of the property.
        /// </summary>
        string BuyerName { get; }

        /// <summary>
        /// This field contains the registered owner’s first name of the property.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// This field contains the registered owner’s first middle name of the property.
        /// </summary>
        string MiddleName { get; }

        /// <summary>
        /// This field contains the registered owner’s second middle name of the property.
        /// </summary>
        string SecondMiddleName { get; }

        /// <summary>
        /// This field contains the registered owner’s third middle name of the property.
        /// </summary>
        string ThirdMiddleName { get; }

        /// <summary>
        /// This field contains the registered owner’s surname of the property.
        /// </summary>
        string Surname { get; }

        /// <summary>
        /// PERSON_TYPE_ID: PERSON_TYPE_NAME
        /// AD ADMINISTRATORS
        /// AS ASSOCIATION
        /// BC BODY CORPORATE
        /// CC CLOSE CORPORATION
        /// CH CHURCHES
        /// CO COMPANY
        /// ES ESTATES
        /// FI FINACIAL INSTITUTION
        /// FN FUND
        /// GV GOVERNMENT
        /// IG INACTIVE GOVERNMENT PROPERTIES
        /// LA LOCAL AUTHORITY
        /// NG NATIONAL GOVERNMENT
        /// NO NO TYPE
        /// OG OTHER GOVERNMENT PROPERTIES
        /// PG PARASTATAL GOVERNMENT
        /// PP PRIVATE PERSON
        /// PS PARTNERSHIP
        /// SC SCHOOL
        /// TR TRUSTS
        /// TS TRUSTEES
        /// UN UNION
        /// </summary>
        string PersonTypeId { get; }

        /// <summary>
        /// ID number of the property buyer if a natural person or Company Registration number of property owners if Legal Entity
        /// </summary>
        string BuyerIdCk { get; }

        /// <summary>
        /// This is an internal number used by Lightstone so you can disregard 
        /// </summary>
        decimal MunicId { get; }

        decimal ProvId { get; }

        /// <summary>
        /// This field contains the street number of the property.
        /// </summary>
        string StreetNumber { get; }

        /// <summary>
        /// street_type
        /// 1 ALLEY         
        /// 2 AVENUE        
        /// 3 AVENUE EAST   
        /// 4 AVENUE NORTH  
        /// 5 AVENUE SOUTH  
        /// 6 AVENUE WEST   
        /// 7 AVNEUE        
        /// 8 BAY           
        /// 9 BEND          
        /// 10 BOULEVARD     
        /// 11 BRIDGE        
        /// 12 CAUSEWAY      
        /// 13 CIRCLE        
        /// 14 CIRCUS        
        /// 15 CLOSE         
        /// 16 CLOSE NORTH   
        /// 17 CLOSE SOUTH   
        /// 18 CLOSE WEST    
        /// 19 CORNER        
        /// 20 COURT         
        /// 21 COVE          
        /// 22 CRESCENT      
        /// 23 CRESCENT EAST 
        /// 24 CRESCENT NORTH
        /// 25 CRESCENT WEST 
        /// 26 CUL DE SAC    
        /// 27 CURVE         
        /// 28 DRIVE         
        /// 29 DRIVE EAST    
        /// 30 DRIVE EXT     
        /// 31 DRIVE NORTH   
        /// 32 DRIVE SOUTH   
        /// 33 DRIVE WEST    
        /// 34 EAST          
        /// 35 END           
        /// 36 FREEWAY       
        /// 37 GARDENS       
        /// 38 GLADES        
        /// 39 GROVE         
        /// 40 HEIGHTS       
        /// 41 HIGHWAY       
        /// 42 HIGHWAY EAST  
        /// 43 HIGHWAY NORTH 
        /// 44 HILL          
        /// 45 KLOO          
        /// 46 LAAN          
        /// 47 LANE          
        /// 48 LANE NORTH    
        /// 49 LANE SOUTH    
        /// 50 LAPA          
        /// 51 LIBYA DRIVE   
        /// 52 LINK          
        /// 53 LOOP          
        /// 54 MEWS          
        /// 55 NORTH         
        /// 56 NORTH CLOSE   
        /// 57 NR.           
        /// 58 PAD           
        /// 59 PARK          
        /// 60 PASS          
        /// 61 PATH          
        /// 62 PLACE         
        /// 63 PLACE EAST    
        /// 64 PLACE SOUTH   
        /// 65 PLACE WEST    
        /// 66 PLEIN         
        /// 67 PLEK          
        /// 68 RAMP          
        /// 69 RAMP EAST     
        /// 70 RAMP NORTH    
        /// 71 RAMP SOUTH    
        /// 72 RAMP WEST     
        /// 73 RIDGE         
        /// 74 ROAD          
        /// 75 ROAD EAST     
        /// 76 ROAD EXT      
        /// 77 ROAD NORTH    
        /// 78 ROAD SOUTH    
        /// 79 ROAD WEST     
        /// 80 SOUTH         
        /// 81 SOUTH CLOSE   
        /// 82 SQUARE        
        /// 83 STRAAT        
        /// 84 STREET        
        /// 85 STREET EAST   
        /// 86 STREET EXT    
        /// 87 STREET NORTH  
        /// 88 STREET SOUTH  
        /// 89 STREET WEST   
        /// 90 TERRACE       
        /// 91 TURN          
        /// 92 VALLEI        
        /// 93 WALK          
        /// 94 WAY           
        /// 95 WAY EAST      
        /// 96 WAY EXT       
        /// 97 WAY SOUTH     
        /// 98 WAY WEST      
        /// 99 WEST
        /// </summary>
        string StreetType { get; }

        /// <summary>
        /// This field contains the postal code of the property.
        /// </summary>
        string PostalCode { get; }

        /// <summary>
        /// Is a unique sequence of characters that is given to a user of the system and this is used to identify that user.
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// This field contains the garage number of the property if the property is a sectional title unit.
        /// </summary>
        int Garage { get; }

        /// <summary>
        /// This is the registered sectional scheme number if the property is of type SS
        /// </summary>
        string SsNumber { get; }

        /// <summary>
        /// This is the unit number range from is the property is of type sectional scheme.
        /// </summary>
        int SsUnitNoFrom { get; }

        /// <summary>
        /// This is the unit number range to is the property is of type sectional scheme.
        /// </summary>
        int SsUnitTo { get; }

        /// <summary>
        /// This is the unit size if the property is a sectional scheme or the erf size if free hold.
        /// </summary>
        double Size { get; }

        /// <summary>
        /// This is the X co-ordinate of the subject property.
        /// </summary>
        double XCoOrdinates { get; }

        /// <summary>
        /// This is the Y co-ordinate of the subject property.
        /// </summary>
        double YCoOrdinates { get; }

        /// <summary>
        /// This is the suburb name that the property is registered in 
        /// </summary>
        string Suburb { get; }

        /// <summary>
        /// the title deed number of the property if any
        /// </summary>
        string TitleDeedNo { get; }

        /// <summary>
        /// the date the property was registered to the current owner
        /// </summary>
        string RegDate { get; }

        /// <summary>
        /// the township name that the property is registered in
        /// </summary>
        string TownShip { get; }

        /// <summary>
        /// the purchase price of the property
        /// </summary>
        int PurchasePrice { get; }

        int PurchaseDate { get; }

        /// <summary>
        /// the bond number held over the property if any
        /// </summary>
        string BondNumber { get; }


        /// <summary>
        /// This is an internal mapping field used by Lightstone and ABSA
        /// </summary>
        string TownshipAlt { get; }

        /// <summary>
        /// if the property is a remaining extent this will be populated
        /// </summary>
        bool RemainingExtent { get; }

        
        /// <summary>
        /// This field refers to the additional description/ sub division description of the system
        /// </summary>
        string AddDescription { get; }

        /// <summary>
        /// this is the lookup key for suburbs in the lookups web servcie (separate to the properties web service) 
        /// </summary>
        int SubId { get; }

        /// <summary>
        /// this is the lookup key for suburbs in the lookups web servcie (separate to the properties web service) 
        /// </summary>
        decimal StreetId { get; }

        /// <summary>
        /// The service returns properties that are retired where clients need this information 
        /// e.g. the mother erf of a sectional title development may still be searchable on the system even though there is now a sectional scheme registered on it.
        /// In this case the Active _Status will be false and users of the service can choose to filter this property out of their results or not. 
        /// </summary>
        string ActiveStatus { get; }

        /// <summary>
        /// This is the name of the Estate that the property is located in
        /// </summary>
        string EstateName { get; }

        /// <summary>
        /// This is a lookup ID that references the Estate name lookup
        /// </summary>
        int EstateId { get; }


        int ReqStatusId { get; }

        /// <summary>
        /// This is an indicator that shows if the GPS co-ordinates linked to the property are estimated or not. 
        /// If they are estimated then Lightstone does not guarantee accuracy and GPS co-ortinates should not be displayed. 
        /// </summary>
        bool EstimatedCoOrdinates { get; }
    }
}