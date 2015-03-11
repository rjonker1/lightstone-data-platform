using System;
using System.Runtime.Serialization;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class ReturnPropertiesRequest //: IProvidePropertyInformationForRequest
    {
        public ReturnPropertiesRequest()
        {
            
        }


        public ReturnPropertiesRequest(string userId, string province, string municipality, string deedTown, string erf,
            string sectionalTitle, string unit, string suburb, string street, string streetNumber, string ownerName,
            string idCk, string estateName, string farmName, int maxRowsToReturn, string trackingNumber)
        {
            TrackingNumber = trackingNumber;
            MaxRowsToReturn = maxRowsToReturn;
            FARM_NAME = farmName;
            Estate_Name = estateName;
            ID_CK = idCk;
            Owner_Name = ownerName;
            StreetNumber = streetNumber;
            Street = street;
            Suburb = suburb;
            Unit = unit;
            Sectional_Title = sectionalTitle;
            Erf = erf;
            DeedTown = deedTown;
            Municipality = municipality;
            Province = province;
            User_ID = userId;
        }

        [DataMember]
        public string User_ID { get; private set; }

        [DataMember]
        public string Province { get; private set; }

        [DataMember]
        public string Municipality { get; private set; }

        [DataMember]
        public string DeedTown { get; private set; }

        [DataMember]
        public string Erf { get; private set; }

        [DataMember]
        public string Portion { get; private set; }

        [DataMember]
        public string Sectional_Title { get; private set; }

        [DataMember]
        public string Unit { get; private set; }

        [DataMember]
        public string Suburb { get; private set; }

        [DataMember]
        public string Street { get; private set; }

        [DataMember]
        public string StreetNumber { get; private set; }

        [DataMember]
        public string Owner_Name { get; private set; }

        [DataMember]
        public string ID_CK { get; private set; }

        [DataMember]
        public string Estate_Name { get; private set; }

        [DataMember]
        public string FARM_NAME { get; private set; }

        [DataMember]
        public int MaxRowsToReturn { get; private set; }

        [DataMember]
        public string TrackingNumber { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class ReturnPropertiesResponse
    {
        
        // Default Constructor
        public ReturnPropertiesResponse()
        {
            
        }




        public ReturnPropertiesResponse(Type type, string typeName, decimal propId, decimal proptypeId, decimal ssId,
            string propertyType, string province, string municname, string deedtown, string farmname,
            string sectionalTitle, int unit, decimal portion, string buyerName, string firstname, string middlename,
            string middlename2, string middlename3, string surname, string personTypeId, string buyerIdck,
            decimal municId, decimal provId, string streetNumber, string streetType, string poCode, Guid userId,
            int garage, string ssNumber, int ssUnitNoFrom, int ssUnitTo, double size, double x, double y, string suburb,
            string titleDeedNo, string regDate, string townShip, int purchasePrice, int purchaseDate, string bondNumber,
            string townshipAlt, string addDescription, int subId, decimal streetId, string activeStatus,
            string estateName, int estId, int reqStatusId, bool estimatedcad)
        {
            Estimatedcad = estimatedcad;
            ReqStatus_ID = reqStatusId;
            est_id = estId;
            Estate_Name = estateName;
            Active_Status = activeStatus;
            street_id = streetId;
            sub_id = subId;
            ADD_Description = addDescription;
            Township_alt = townshipAlt;
            Bond_Number = bondNumber;
            Purchase_Date = purchaseDate;
            Purchase_Price = purchasePrice;
            TownShip = townShip;
            Reg_Date = regDate;
            Title_Deed_No = titleDeedNo;
            SUBURB = suburb;
            Y = y;
            X = x;
            Size = size;
            SS_UnitTo = ssUnitTo;
            SS_UnitNoFrom = ssUnitNoFrom;
            SS_Number = ssNumber;
            GARAGE = garage;
            User_ID = userId;
            PO_CODE = poCode;
            STREET_TYPE = streetType;
            STREET_NUMBER = streetNumber;
            PROV_ID = provId;
            MUNIC_ID = municId;
            BUYER_IDCK = buyerIdck;
            PERSON_TYPE_ID = personTypeId;
            SURNAME = surname;
            MIDDLENAME3 = middlename3;
            MIDDLENAME2 = middlename2;
            MIDDLENAME = middlename;
            FIRSTNAME = firstname;
            BUYER_NAME = buyerName;
            PORTION = portion;
            UNIT = unit;
            SECTIONAL_TITLE = sectionalTitle;
            FARMNAME = farmname;
            DEEDTOWN = deedtown;
            MUNICNAME = municname;
            PROVINCE = province;
            property_type = propertyType;
            SS_ID = ssId;
            PROPTYPE_ID = proptypeId;
            prop_id = propId;
            TypeName = typeName;
            Type = type;
        }

        [DataMember]
        public Type Type { get; private set; }

        [DataMember]
        public string TypeName { get; private set; }

        [DataMember]
        public int sr_id { get; set; }

        [DataMember]
        public decimal prop_id { get; private set; }

        [DataMember]
        public decimal DEED_ID { get; set; }

        [DataMember]
        public decimal PROPTYPE_ID { get; private set; }

        [DataMember]
        public decimal SS_ID { get; private set; }

        [DataMember]
        public decimal NAD_ID { get; private set; }

        [DataMember]
        public string property_type { get; private set; }

        [DataMember]
        public string PROVINCE { get; private set; }

        [DataMember]
        public string MUNICNAME { get; private set; }

        [DataMember]
        public string DEEDTOWN { get; private set; }

        [DataMember]
        public string FARMNAME { get; private set; }

        [DataMember]
        public string SECTIONAL_TITLE { get; private set; }

        [DataMember]
        public int UNIT { get; private set; }

        [DataMember]
        public decimal PORTION { get; private set; }

        [DataMember]
        public string BUYER_NAME { get; private set; }

        [DataMember]
        public string FIRSTNAME { get; private set; }

        [DataMember]
        public string MIDDLENAME { get; private set; }

        [DataMember]
        public string MIDDLENAME2 { get; private set; }

        [DataMember]
        public string MIDDLENAME3 { get; private set; }

        [DataMember]
        public string SURNAME { get; private set; }

        [DataMember]
        public string PERSON_TYPE_ID { get; private set; }

        [DataMember]
        public string BUYER_IDCK { get; private set; }

        [DataMember]
        public decimal MUNIC_ID { get; private set; }

        [DataMember]
        public decimal PROV_ID { get; private set; }

        [DataMember]
        public string STREET_NUMBER { get; private set; }

        [DataMember]
        public string STREET_TYPE { get; private set; }

        [DataMember]
        public string PO_CODE { get; private set; }

        [DataMember]
        public Guid User_ID { get; private set; }

        [DataMember]
        public int GARAGE { get; private set; }

        [DataMember]
        public string SS_Number { get; private set; }

        [DataMember]
        public int SS_UnitNoFrom { get; private set; }

        [DataMember]
        public int SS_UnitTo { get; private set; }

        [DataMember]
        public double Size { get; private set; }

        [DataMember]
        public double X { get; private set; }

        [DataMember]
        public double Y { get; private set; }

        [DataMember]
        public string SUBURB { get; private set; }

        [DataMember]
        public string Title_Deed_No { get; private set; }

        [DataMember]
        public string Reg_Date { get; private set; }

        [DataMember]
        public string TownShip { get; private set; }

        [DataMember]
        public int Purchase_Price { get; private set; }

        [DataMember]
        public int Purchase_Date { get; private set; }

        [DataMember]
        public string Bond_Number { get; private set; }

        [DataMember]
        public string Township_alt { get; private set; }

        [DataMember]
        public bool RE { get; private set; }

        [DataMember]
        public string ADD_Description { get; private set; }

        [DataMember]
        public int sub_id { get; private set; }

        [DataMember]
        public decimal street_id { get; private set; }

        [DataMember]
        public string Active_Status { get; private set; }

        [DataMember]
        public string Estate_Name { get; private set; }

        [DataMember]
        public int est_id { get; private set; }

        [DataMember]
        public int ReqStatus_ID { get; private set; }

        [DataMember]
        public bool Estimatedcad { get; private set; }
    }
}
