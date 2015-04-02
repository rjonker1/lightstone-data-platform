namespace Lace.Domain.Core.Requests.Contracts
{
    /// <summary>
    /// ReturnCompanies Input Data
    /// </summary>
    public interface IHaveBusiness
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