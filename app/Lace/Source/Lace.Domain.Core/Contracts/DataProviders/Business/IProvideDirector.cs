using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Business
{
    public interface IProvideDirector : IProvideType
    {
        int Id { get; }
        int DirectorId { get; }
        int CompanyId { get; }
        string CompanyRegNumber { get; }
        string FirstName { get; }
        string Initials { get; }
        string Surname { get; }
        string SurnameParticular { get; }
        string PreviousSurname { get; }
        string IdNumber { get; }
        string BirthDate { get; }
        string DesignationCode { get; }
        string RsaResident { get; }
        string WithdrawPublic { get; }
        string CountryCode { get; }
        string TypeCode { get; }
        string StatusCode { get; }
        string StatusDate { get; }
        string RegisterNumber { get; }
        string ExecutorName { get; }
        string ExecutorAppointDate { get; }
        string TrusteeName { get; }
        string FormLodgeDate { get; }
        string FormReceiveDate { get; }
        string FoundingStatementDate { get; }
        double MemberSize { get; }
        double MemberContribution { get; }
        string MemberContributionType { get; }
        int ExclCon { get; }
        string RegisteredAddress1 { get; }
        string RegisteredAddress2 { get; }
        string RegisteredAddress3 { get; }
        string RegisteredAddress4 { get; }
        string RegisteredPostCode { get; }
        string ResidentialAddress1 { get; }
        string ResidentialAddress2 { get; }
        string ResidentialAddress3 { get; }
        string ResidentialAddress4 { get; }
        string ResidentialPostCode { get; }
        string BusinessAddress1 { get; }
        string BusinessAddress2 { get; }
        string BusinessAddress3 { get; }
        string BusinessAddress4 { get; }
        string BusinessPostCode { get; }
        string PostalAddress1 { get; }
        string PostalAddress2 { get; }
        string PostalAddress3 { get; }
        string PostalAddress4 { get; }
        string PostalPostCode { get; }
        string OccupationCode { get; }
        string FineExpiryDate { get; }
        string NatureOfChange { get; }
        string NationalityCode { get; }
        string Profession { get; }
        string ResignationDate { get; }
        string Estate { get; }
        string LsId { get; }
        string StatusOrder { get; }
    }
}