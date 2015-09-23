using System;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneProperty
{
    public class PropertyBuilder
    {
        private Guid _userId;

        private bool _estimatedCoOrdinates;
        private bool _remainingExtent;

        private int _srId;
        private int _unit;
        private int _suburbId;
        private int _sectionalSchemeUnitTo;
        private int _sectionlSchemeUnitNoFrom;
        private int _reqStatusId;
        private int _garage;
        private int _estateId;
        private int _purchaseDate;
        private int _purchasePrice;

        private double _xCoOrdinates;
        private double _yCoOrdinates;
        private double _size;

        private decimal _deedId;
        private decimal _propertyTypeId;
        private decimal _provId;
        private decimal _municId;
        private decimal _nadId;
        private decimal _propertyId;
        private decimal _portion;
        private decimal _ssId;
        private decimal _streetId;

        private string _activeStatus;
        private string _additionalDescription;
        private string _bondNumber;
        private string _buyerIdCk;
        private string _buyerName;
        private string _deedtown;
        private string _estateName;
        private string _farmName;
        private string _firstName;
        private string _middleName;
        private string _muncipality;
        private string _personTypeId;
        private string _postalCode;
        private string _propertyType;
        private string _province;
        private string _registrationDate;
        private string _secondMiddleName;
        private string _sectionalTitle;
        private string _sectionSchemeNumber;
        private string _streetNumber;
        private string _streetType;
        private string _suburb;
        private string _surname;
        private string _thirdMiddleName;
        private string _titleDeedNo;
        private string _township;
        private string _townshipAlt;
        

        public IRespondWithProperty Build()
        {
            return new PropertyModel(_srId, _propertyId, _propertyTypeId, _ssId, _propertyType, _province,
                _muncipality, _deedtown, _farmName, _sectionalTitle, _unit, _portion, _buyerName, _firstName, _middleName,
                _secondMiddleName, _thirdMiddleName, _surname, _personTypeId, _buyerIdCk, _municId, _provId, _streetNumber,
                _streetType, _postalCode, _userId, _garage, _sectionSchemeNumber, _sectionlSchemeUnitNoFrom,
                _sectionalSchemeUnitTo, _size, _xCoOrdinates, _yCoOrdinates, _suburb, _titleDeedNo, _registrationDate, _township,
                _purchasePrice, _purchaseDate, _bondNumber, _townshipAlt, _additionalDescription, _suburbId, _streetId,
                _activeStatus, _estateName, _estateId, _reqStatusId, _estimatedCoOrdinates);
        }

        public PropertyBuilder With(Guid userId)
        {
            _userId = userId;
            return this;
        }

        public PropertyBuilder With(bool estimatedCoOrdinates, bool remainingExtent)
        {
            _estimatedCoOrdinates = estimatedCoOrdinates;
            _remainingExtent = remainingExtent;
            return this;
        }

        public PropertyBuilder With(int srId, int unit, int suburbId, int sectionalSchemeUnitTo,
         int sectionlSchemeUnitNoFrom, int reqStatusId, int garage, int estateId,
         int purchaseDate, int purchasePrice, double xCoOrdinates, double yCoOrdinates, double size,
         decimal deedId, decimal propertyTypeId, decimal provId, decimal municId,
         decimal nadId, decimal propertyId, decimal portion, decimal ssId, decimal streetId)
        {
            _srId = srId;
            _unit = unit;
            _suburbId = suburbId;
            _sectionalSchemeUnitTo = sectionalSchemeUnitTo;
            _sectionlSchemeUnitNoFrom = sectionlSchemeUnitNoFrom;
            _reqStatusId = reqStatusId;
            _garage = garage;
            _srId = srId;
            _estateId = estateId;
            _purchaseDate = purchaseDate;
            _purchasePrice = purchasePrice;
            _xCoOrdinates = xCoOrdinates;
            _yCoOrdinates = yCoOrdinates;
            _size = size;
            _deedId = deedId;
            _propertyTypeId = propertyTypeId;
            _provId = provId;
            _municId = municId;
            _nadId = nadId;
            _propertyId = propertyId;
            _portion = portion;
            _ssId = ssId;
            _streetId = streetId;
            return this;
        }

        public PropertyBuilder With(string activeStatus, string additionalDescription, string bondNumber, string buyerIdCk,
         string buyerName, string deedtown, string estateName, string farmName,
         string firstName, string middleName, string muncipality, string personTypeId,
         string postalCode, string propertyType, string province, string registrationDate,
         string secondMiddleName, string sectionalTitle, string sectionSchemeNumber, string streetNumber,
         string streetType, string suburb, string surname, string thirdMiddleName,
         string titleDeedNo, string township, string townshipAlt)
        {
            _activeStatus = activeStatus;
            _additionalDescription = additionalDescription;
            _bondNumber = bondNumber;
            _buyerIdCk = buyerIdCk;

            _buyerName = buyerName;
            _deedtown = deedtown;
            _estateName = estateName;
            _farmName = farmName;

            _firstName = firstName;
            _middleName = middleName;
            _muncipality = muncipality;
            _personTypeId = personTypeId;

            _postalCode = postalCode;
            _propertyType = propertyType;
            _province = province;
            _registrationDate = registrationDate;

            _secondMiddleName = secondMiddleName;
            _sectionalTitle = sectionalTitle;
            _sectionSchemeNumber = sectionSchemeNumber;
            _streetNumber = streetNumber;

            _streetType = streetType;
            _suburb = suburb;
            _surname = surname;
            _thirdMiddleName = thirdMiddleName;

            _titleDeedNo = titleDeedNo;
            _township = township;
            _townshipAlt = townshipAlt;
            return this;
        }
    }
}