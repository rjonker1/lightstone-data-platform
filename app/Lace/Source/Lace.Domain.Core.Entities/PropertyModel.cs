using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Property;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class PropertyModel : IRespondWithProperty
    {

        public PropertyModel()
        {
            
        }

        public PropertyModel(int srId,decimal propertyId, decimal propertyTypeId, decimal ssId,
            string propertyType, string province, string municipality, string deedtown, string farmname,
            string sectionalTitle, int unit, decimal portion, string buyerName, string firstname, string middlename,
            string middlename2, string middlename3, string surname, string personTypeId, string buyerIdck,
            decimal municId, decimal provId, string streetNumber, string streetType, string postalCode, Guid userId,
            int garage, string ssNumber, int ssUnitNoFrom, int ssUnitTo, double size, double xCoOrdinates, double yCordinates, string suburb,
            string titleDeedNo, string regDate, string townShip, int purchasePrice, int purchaseDate, string bondNumber,
            string townshipAlt, string addDescription, int subId, decimal streetId, string activeStatus,
            string estateName, int estateId, int reqStatusId, bool estimatedCordinates)
        {
            SrId = srId;
            EstimatedCoOrdinates = estimatedCordinates;
            ReqStatusId = reqStatusId;
            EstateId = estateId;
            EstateName = estateName;
            ActiveStatus = activeStatus;
            StreetId = streetId;
            SubId = subId;
            AddDescription = addDescription;
            TownshipAlt = townshipAlt;
            BondNumber = bondNumber;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            TownShip = townShip;
            RegDate = regDate;
            TitleDeedNo = titleDeedNo;
            Suburb = suburb;
            YCoOrdinates = yCordinates;
            XCoOrdinates = xCoOrdinates;
            Size = size;
            SsUnitTo = ssUnitTo;
            SsUnitNoFrom = ssUnitNoFrom;
            SsNumber = ssNumber;
            Garage = garage;
            UserId = userId;
            PostalCode = postalCode;
            StreetType = streetType;
            StreetNumber = streetNumber;
            ProvId = provId;
            MunicId = municId;
            BuyerIdCk = buyerIdck;
            PersonTypeId = personTypeId;
            Surname = surname;
            ThirdMiddleName = middlename3;
            SecondMiddleName = middlename2;
            MiddleName = middlename;
            FirstName = firstname;
            BuyerName = buyerName;
            Portion = portion;
            Unit = unit;
            SectionalTitle = sectionalTitle;
            FarmName = farmname;
            Deedtown = deedtown;
            Muncipality = municipality;
            Province = province;
            PropertyType = propertyType;
            SsId = ssId;
            PropTypeId = propertyTypeId;
            PropertyId = propertyId;
        }




        [DataMember]
        public int SrId { get; private set; }

        [DataMember]
        public decimal PropertyId { get; private set; }

        [DataMember]
        public decimal DeedId { get; private set; }

        [DataMember]
        public decimal PropTypeId { get; private set; }

        [DataMember]
        public decimal SsId { get; private set; }

        [DataMember]
        public decimal NadId { get; private set; }

        [DataMember]
        public string PropertyType { get; private set; }

        [DataMember]
        public string Province { get; private set; }

        [DataMember]
        public string Muncipality { get; private set; }

        [DataMember]
        public string Deedtown { get; private set; }

        [DataMember]
        public string FarmName { get; private set; }

        [DataMember]
        public string SectionalTitle { get; private set; }

        [DataMember]
        public int Unit { get; private set; }

        [DataMember]
        public decimal Portion { get; private set; }

        [DataMember]
        public string BuyerName { get; private set; }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string SecondMiddleName { get; private set; }

        [DataMember]
        public string ThirdMiddleName { get; private set; }

        [DataMember]
        public string Surname { get; private set; }

        [DataMember]
        public string PersonTypeId { get; private set; }

        [DataMember]
        public string BuyerIdCk { get; private set; }

        [DataMember]
        public decimal MunicId { get; private set; }

        [DataMember]
        public decimal ProvId { get; private set; }

        [DataMember]
        public string StreetNumber { get; private set; }

        [DataMember]
        public string StreetType { get; private set; }

        [DataMember]
        public string PostalCode { get; private set; }

        [DataMember]
        public Guid UserId { get; private set; }

        [DataMember]
        public int Garage { get; private set; }

        [DataMember]
        public string SsNumber { get; private set; }

        [DataMember]
        public int SsUnitNoFrom { get; private set; }

        [DataMember]
        public int SsUnitTo { get; private set; }

        [DataMember]
        public double Size { get; private set; }

        [DataMember]
        public double XCoOrdinates { get; private set; }

        [DataMember]
        public double YCoOrdinates { get; private set; }

        [DataMember]
        public string Suburb { get; private set; }

        [DataMember]
        public string TitleDeedNo { get; private set; }

        [DataMember]
        public string RegDate { get; private set; }

        [DataMember]
        public string TownShip { get; private set; }

        [DataMember]
        public int PurchasePrice { get; private set; }

        [DataMember]
        public int PurchaseDate { get; private set; }

        [DataMember]
        public string BondNumber { get; private set; }

        [DataMember]
        public string TownshipAlt { get; private set; }

        [DataMember]
        public bool RemainingExtent { get; private set; }

        [DataMember]
        public string AddDescription { get; private set; }

        [DataMember]
        public int SubId { get; private set; }

        [DataMember]
        public decimal StreetId { get; private set; }

        [DataMember]
        public string ActiveStatus { get; private set; }

        [DataMember]
        public string EstateName { get; private set; }

        [DataMember]
        public int EstateId { get; private set; }

        [DataMember]
        public int ReqStatusId { get; private set; }

        [DataMember]
        public bool EstimatedCoOrdinates { get; private set; }

        [DataMember]
        public string MiddleName { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

    }
}
