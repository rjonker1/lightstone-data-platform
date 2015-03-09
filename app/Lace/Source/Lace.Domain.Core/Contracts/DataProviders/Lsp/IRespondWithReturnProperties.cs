using System;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Lsp
{
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

        /// <summary>
        /// If the property is registered in a sectional scheme the unit number is populated in this field.
        /// </summary>
        int UNIT { get; set; }

        /// <summary>
        /// This field contains the portion number of the property.
        /// </summary>
        decimal PORTION { get; set; }

        /// <summary>
        /// This field contains the full registered owner�s name of the property.
        /// </summary>
        string BUYER_NAME { get; set; }

        /// <summary>
        /// This field contains the registered owner�s first name of the property.
        /// </summary>
        string FIRSTNAME { get; set; }

        /// <summary>
        /// This field contains the registered owner�s first middle name of the property.
        /// </summary>
        string MIDDLENAME { get; set; }

        /// <summary>
        /// This field contains the registered owner�s second middle name of the property.
        /// </summary>
        string MIDDLENAME2 { get; set; }

        /// <summary>
        /// This field contains the registered owner�s third middle name of the property.
        /// </summary>
        string MIDDLENAME3 { get; set; }

        /// <summary>
        /// This field contains the registered owner�s surname of the property.
        /// </summary>
        string SURNAME { get; set; }

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
        string PERSON_TYPE_ID { get; set; }

        /// <summary>
        /// ID number of the property buyer if a natural person or Company Registration number of property owners if Legal Entity
        /// </summary>
        string BUYER_IDCK { get; set; }

        /// <summary>
        /// This is an internal number used by Lightstone so you can disregard 
        /// </summary>
        decimal MUNIC_ID { get; set; }

        decimal PROV_ID { get; set; }

        /// <summary>
        /// This field contains the street number of the property.
        /// </summary>
        string STREET_NUMBER { get; set; }

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
        string STREET_TYPE { get; set; }

        /// <summary>
        /// This field contains the postal code of the property.
        /// </summary>
        string PO_CODE { get; set; }

        /// <summary>
        /// Is a unique sequence of characters that is given to a user of the system and this is used to identify that user.
        /// </summary>
        Guid User_ID { get; set; }

        /// <summary>
        /// This field contains the garage number of the property if the property is a sectional title unit.
        /// </summary>
        int GARAGE { get; set; }

        /// <summary>
        /// This is the registered sectional scheme number if the property is of type SS
        /// </summary>
        string SS_Number { get; set; }

        /// <summary>
        /// This is the unit number range from is the property is of type sectional scheme.
        /// </summary>
        int SS_UnitNoFrom { get; set; }

        /// <summary>
        /// This is the unit number range to is the property is of type sectional scheme.
        /// </summary>
        int SS_UnitTo { get; set; }

        /// <summary>
        /// This is the unit size if the property is a sectional scheme or the erf size if free hold.
        /// </summary>
        double Size { get; set; }

        /// <summary>
        /// This is the X co-ordinate of the subject property.
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// This is the Y co-ordinate of the subject property.
        /// </summary>
        double Y { get; set; }

        /// <summary>
        /// This is the suburb name that the property is registered in 
        /// </summary>
        string SUBURB { get; set; }

        /// <summary>
        /// the title deed number of the property if any
        /// </summary>
        string Title_Deed_No { get; set; }

        /// <summary>
        /// the date the property was registered to the current owner
        /// </summary>
        string Reg_Date { get; set; }

        /// <summary>
        /// the township name that the property is registered in
        /// </summary>
        string TownShip { get; set; }

        /// <summary>
        /// the purchase price of the property
        /// </summary>
        int Purchase_Price { get; set; }

        int Purchase_Date { get; set; }

        /// <summary>
        /// the bond number held over the property if any
        /// </summary>
        string Bond_Number { get; set; }


        /// <summary>
        /// This is an internal mapping field used by Lightstone and ABSA
        /// </summary>
        string Township_alt { get; set; }

        /// <summary>
        /// if the property is a remaining extent this will be populated
        /// </summary>
        bool RE { get; set; }

        
        /// <summary>
        /// This field refers to the additional description/ sub division description of the system
        /// </summary>
        string ADD_Description { get; set; }

        /// <summary>
        /// this is the lookup key for suburbs in the lookups web servcie (separate to the properties web service) 
        /// </summary>
        int sub_id { get; set; }

        /// <summary>
        /// this is the lookup key for suburbs in the lookups web servcie (separate to the properties web service) 
        /// </summary>
        decimal street_id { get; set; }

        /// <summary>
        /// The service returns properties that are retired where clients need this information 
        /// e.g. the mother erf of a sectional title development may still be searchable on the system even though there is now a sectional scheme registered on it.
        /// In this case the Active _Status will be false and users of the service can choose to filter this property out of their results or not. 
        /// </summary>
        string Active_Status { get; set; }

        /// <summary>
        /// This is the name of the Estate that the property is located in
        /// </summary>
        string Estate_Name { get; set; }

        /// <summary>
        /// This is a lookup ID that references the Estate name lookup
        /// </summary>
        int est_id { get; set; }


        int ReqStatus_ID { get; set; }

        /// <summary>
        /// This is an indicator that shows if the GPS co-ordinates linked to the property are estimated or not. 
        /// If they are estimated then Lightstone does not guarantee accuracy and GPS co-ortinates should not be displayed. 
        /// </summary>
        bool Estimatedcad { get; set; }

        













    }
}