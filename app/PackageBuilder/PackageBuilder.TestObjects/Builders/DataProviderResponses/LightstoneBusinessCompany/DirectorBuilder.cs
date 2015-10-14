using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class DirectorBuilder
    {
        string _birthDate;
        string _businessAddress1;
        string _businessAddress2;
        string _businessAddress3;
        string _businessAddress4;
        string _businessPostCode;
        int _companyId;
        string _companyRegNumber;
        string _countryCode;
        string _designationCode;
        int _directorId;
        string _estate;
        int _exclCon;
        string _executorAppointDate;
        string _executorName;
        string _fineExpiryDate;
        string _firstName;
        string _formLodgeDate;
        string _formReceiveDate;
        string _foundingStatementDate;
        int _id;
        string _idNumber;
        string _initials;
        int _lsId;
        double _memberContribution;
        string _memberContributionType;
        double _memberSize;
        string _nationalityCode;
        string _natureOfChange;
        string _occupationCode;
        string _postalAddress1;
        string _postalAddress2;
        string _postalAddress3;
        string _postalAddress4;
        string _postalPostCode;
        string _previousSurname;
        string _profession;
        string _registeredAddress1;
        string _registeredAddress2;
        string _registeredAddress3;
        string _registeredAddress4;
        string _registeredPostCode;
        string _registerNumber;
        string _residentialAddress1;
        string _residentialAddress2;
        string _residentialAddress3;
        string _residentialAddress4;
        string _residentialPostCode;
        string _resignationDate;
        string _rsaResident;
        string _statusCode;
        string _statusDate;
        int _statusOrder;
        string _surname;
        string _surnameParticular;
        string _trusteeName;
        string _typeCode;
        string _withdrawPublic;

        public IProvideDirector Build()
        {
            var response = new DirectorResponse(_id, _directorId, _companyId, _companyRegNumber, _firstName, _initials,
                _surname, _surnameParticular, _previousSurname, _idNumber, _birthDate, _designationCode, _rsaResident,
                _withdrawPublic, _countryCode, _typeCode, _statusCode, _statusDate, _registerNumber, _executorName,
                _executorAppointDate, _trusteeName, _formLodgeDate, _formReceiveDate, _foundingStatementDate, _memberSize,
                _memberContribution, _memberContributionType, _exclCon, _occupationCode, _fineExpiryDate, _natureOfChange,
                _nationalityCode, _profession, _resignationDate, _estate, _lsId, _statusOrder);
            response.SetBusinessAddress(_businessAddress1, _businessAddress2, _businessAddress3, _businessAddress4, _businessPostCode);
            response.SetPostalAddress(_postalAddress1, _postalAddress2, _postalAddress3, _postalAddress4, _postalPostCode);
            response.SetRegisteredAddress(_registeredAddress1, _registeredAddress2, _registeredAddress3, _registeredAddress4, _registeredPostCode);
            response.SetResidentialAddress(_residentialAddress1, _residentialAddress2, _residentialAddress3, _residentialAddress4, _residentialPostCode);

            return response;
        }

        public DirectorBuilder With(int id, int directorId, int companyId, string companyRegNumber, string firstName, string initials,
                string surname, string surnameParticular, string previousSurname, string idNumber, string birthDate, string designationCode, string rsaResident,
                string withdrawPublic, string countryCode, string typeCode, string statusCode, string statusDate, string registerNumber, string executorName,
                string executorAppointDate, string trusteeName, string formLodgeDate, string formReceiveDate, string foundingStatementDate, double memberSize,
                double memberContribution, string memberContributionType, int exclCon, string occupationCode, string fineExpiryDate, string natureOfChange,
                string nationalityCode, string profession, string resignationDate, string estate, int lsId, int statusOrder)
        {
            _id = id;
            _directorId = directorId;
            _companyId = companyId;
            _companyRegNumber = companyRegNumber;
            _firstName = firstName;
            _initials = initials;
            _surname = surname;
            _surnameParticular = surnameParticular;
            _previousSurname = previousSurname;
            _idNumber = idNumber;
            _birthDate = birthDate;
            _designationCode = designationCode;
            _rsaResident = rsaResident;
            _withdrawPublic = withdrawPublic;
            _countryCode = countryCode;
            _typeCode = typeCode;
            _statusCode = statusCode;
            _statusDate = statusDate;
            _registerNumber = registerNumber;
            _executorName = executorName;
            _executorAppointDate = executorAppointDate;
            _trusteeName = trusteeName;
            _formLodgeDate = formLodgeDate;
            _formReceiveDate = formReceiveDate;
            _foundingStatementDate = foundingStatementDate;
            _memberSize = memberSize;
            _memberContribution = memberContribution;
            _memberContributionType = memberContributionType;
            _exclCon = exclCon;
            _occupationCode = occupationCode;
            _fineExpiryDate = fineExpiryDate;
            _natureOfChange = natureOfChange;
            _nationalityCode = nationalityCode;
            _profession = profession;
            _resignationDate = resignationDate;
            _estate = estate;
            _lsId = lsId;
            _statusOrder = statusOrder;
            return this;
        }

        public DirectorBuilder With(string businessAddress1, string businessAddress2, string businessAddress3, string businessAddress4, string businessPostCode,
            string postalAddress1, string postalAddress2, string postalAddress3, string postalAddress4, string postalPostCode,
            string registeredAddress1, string registeredAddress2, string registeredAddress3, string registeredAddress4, string registeredPostCode,
            string residentialAddress1, string residentialAddress2, string residentialAddress3, string residentialAddress4, string residentialPostCode)
        {
            _businessAddress1 = businessAddress1;
            _businessAddress2 = businessAddress2;
            _businessAddress3 = businessAddress3;
            _businessAddress4 = businessAddress4;
            _businessPostCode = businessPostCode;
            _postalAddress1 = postalAddress1;
            _postalAddress2 = postalAddress2;
            _postalAddress3 = postalAddress3;
            _postalAddress4 = postalAddress4;
            _postalPostCode = postalPostCode;
            _registeredAddress1 = registeredAddress1;
            _registeredAddress2 = registeredAddress2;
            _registeredAddress3 = registeredAddress3;
            _registeredAddress4 = registeredAddress4;
            _registeredPostCode = registeredPostCode;
            _residentialAddress1 = residentialAddress1;
            _residentialAddress2 = residentialAddress2;
            _residentialAddress3 = residentialAddress3;
            _residentialAddress4 = residentialAddress4;
            _residentialPostCode = residentialPostCode;
            return this;
        }
    }
}