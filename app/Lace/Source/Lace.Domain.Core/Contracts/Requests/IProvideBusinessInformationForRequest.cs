namespace Lace.Domain.Core.Contracts.Requests
{
    /// <summary>
    /// ReturnCompanies Input Data
    /// </summary>
    public interface IProvideBusinessInformationForRequest
    {
        /// <summary>
        /// user_token
        /// </summary>
        string UserToken { get; }

        /// <summary>
        /// company_name
        /// </summary>
        string CompanyName { get; }

        /// <summary>
        /// company_regnum
        /// </summary>
        string CompanyRegNumber { get; }

        /// <summary>
        /// company_vatnumber
        /// </summary>
        string CompanyVatNumber { get; }


        
    }
}