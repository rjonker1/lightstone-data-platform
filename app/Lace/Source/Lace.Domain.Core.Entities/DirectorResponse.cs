using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Business;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class DirectorResponse : IProvideDirector
    {

        public DirectorResponse(int id, int directorId, int companyId, string companyRegNumber, string firstName, string initals, string surname,
            string surnameParticular, string previousSurname, string idNumber, string birthDate,
            string designationCode, string rsaResident, string withdrawPublic, string countryCode, string typeCode, string statusCode,
            string statusDate, string registerNumber, string executorName, string executorAppointDate, string trusteeName, string formLodgeDate, string formReceiveDate, string foundingStatementDate, double memberSize, double memberContribution,
            string memberContributionType, int exclCon, string occupationCode, string fineExpiryDate, string natureOfChange, string nationalityCode, string profession,
            string resignationDate, string estate, int lsId, int statusOrder)
        {
            Id = id;
            DirectorId = directorId;
            CompanyId = companyId;
            CompanyRegNumber = companyRegNumber;
            FirstName = firstName;
            Initials = initals;
            Surname = surname;
            SurnameParticular = surnameParticular;
            PreviousSurname = previousSurname;
            IdNumber = idNumber;
            BirthDate = birthDate;
            DesignationCode = designationCode;
            RsaResident = rsaResident;
            WithdrawPublic = withdrawPublic;
            CountryCode = countryCode;
            TypeCode = typeCode;
            StatusCode = statusCode;
            StatusDate = statusDate;
            RegisterNumber = registerNumber;
            ExecutorName = executorName;
            ExecutorAppointDate = executorAppointDate;
            TrusteeName = trusteeName;
            FormLodgeDate = formLodgeDate;
            FormReceiveDate = formReceiveDate;
            FoundingStatementDate = foundingStatementDate;
            MemberSize = memberSize;
            MemberContribution = memberContribution;
            MemberContributionType = memberContributionType;
            ExclCon = exclCon;
            OccupationCode = occupationCode;
            FineExpiryDate = fineExpiryDate;
            NatureOfChange = natureOfChange;
            NationalityCode = nationalityCode;
            Profession = profession;
            ResignationDate = resignationDate;
            Estate = estate;
            LsId = lsId;
            StatusOrder = statusOrder;
        }

        public int Id { get; private set; }

        public int DirectorId { get; private set; }

        public int CompanyId { get; private set; }

        public string CompanyRegNumber { get; private set; }

        public string FirstName { get; private set; }

        public string Initials { get; private set; }

        public string Surname { get; private set; }

        public string SurnameParticular { get; private set; }

        public string PreviousSurname { get; private set; }

        public string IdNumber { get; private set; }

        public string BirthDate { get; private set; }

        public string DesignationCode { get; private set; }

        public string RsaResident { get; private set; }

        public string WithdrawPublic { get; private set; }

        public string CountryCode { get; private set; }

        public string TypeCode { get; private set; }

        public string StatusCode { get; private set; }

        public string StatusDate { get; private set; }

        public string RegisterNumber { get; private set; }

        public string ExecutorName { get; private set; }

        public string ExecutorAppointDate { get; private set; }

        public string TrusteeName { get; private set; }

        public string FormLodgeDate { get; private set; }

        public string FormReceiveDate { get; private set; }
        public string FoundingStatementDate { get; private set; }
        public double MemberSize { get; private set; }
        public double MemberContribution { get; private set; }
        public string MemberContributionType { get; private set; }
        public int ExclCon { get; private set; }

        public DirectorResponse SetRegisteredAddress(string registeredAddress1, string registeredAddress2, string registeredAddress3,
            string registeredAddress4, string registeredPostCode)
        {
            RegisteredAddress1 = registeredAddress1;
            RegisteredAddress2 = registeredAddress2;
            RegisteredAddress3 = registeredAddress3;
            RegisteredAddress4 = registeredAddress4;
            RegisteredPostCode = registeredPostCode;
            return this;
        }

        public string RegisteredAddress1 { get; private set; }

        public string RegisteredAddress2 { get; private set; }

        public string RegisteredAddress3 { get; private set; }

        public string RegisteredAddress4 { get; private set; }

        public string RegisteredPostCode { get; private set; }

        public DirectorResponse SetResidentialAddress(string residentialAddress1, string residentialAddress2, string residentialAddress3,
            string residentialAddress4, string residentialPostCode)
        {
            ResidentialAddress1 = residentialAddress1;
            ResidentialAddress2 = residentialAddress2;
            ResidentialAddress3 = residentialAddress3;
            ResidentialAddress4 = residentialAddress4;
            ResidentialPostCode = residentialPostCode;
            return this;
        }

        public string ResidentialAddress1 { get; private set; }

        public string ResidentialAddress2 { get; private set; }

        public string ResidentialAddress3 { get; private set; }

        public string ResidentialAddress4 { get; private set; }

        public string ResidentialPostCode { get; private set; }

        public DirectorResponse SetBusinessAddress(string businessAddress1, string businessAddress2, string businessAddress3, string businessAddress4,
            string businessPostCode)
        {
            BusinessAddress1 = businessAddress1;
            BusinessAddress2 = businessAddress2;
            BusinessAddress3 = businessAddress3;
            BusinessAddress4 = businessAddress4;
            BusinessPostCode = businessPostCode;
            return this;
        }

        public string BusinessAddress1 { get; private set; }

        public string BusinessAddress2 { get; private set; }

        public string BusinessAddress3 { get; private set; }

        public string BusinessAddress4 { get; private set; }

        public string BusinessPostCode { get; private set; }

        public DirectorResponse SetPostalAddress(string postalAddress1, string postalAddress2, string postalAddress3, string postalAddress4,
            string postalCode)
        {
            PostalAddress1 = postalAddress1;
            PostalAddress2 = postalAddress2;
            PostalAddress3 = postalAddress3;
            PostalAddress4 = postalAddress4;
            PostalPostCode = postalCode;
            return this;
        }

        public string PostalAddress1 { get; private set; }

        public string PostalAddress2 { get; private set; }

        public string PostalAddress3 { get; private set; }

        public string PostalAddress4 { get; private set; }

        public string PostalPostCode { get; private set; }

        public string OccupationCode { get; private set; }

        public string FineExpiryDate { get; private set; }

        public string NatureOfChange { get; private set; }

        public string NationalityCode { get; private set; }

        public string Profession { get; private set; }

        public string ResignationDate { get; private set; }

        public string Estate { get; private set; }

        public int LsId { get; private set; }

        public int StatusOrder { get; private set; }

        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }

        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
