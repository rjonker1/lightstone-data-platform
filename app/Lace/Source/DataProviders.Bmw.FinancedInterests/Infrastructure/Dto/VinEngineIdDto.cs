namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Dto
{
    public sealed class VinEngineIdDto
    {
        public VinEngineIdDto (string vinNumber, string engineNumber)
        {
            VinNumber = vinNumber ?? "";
            EngineNumber = engineNumber ?? "";
        }

        public readonly string VinNumber;
        public readonly string EngineNumber;

        public string VinAndEngineNumber
        {
            get
            {
                if (string.IsNullOrEmpty(VinNumber))
                {
                    return EngineNumber ?? string.Empty;
                }

                return (7 >= VinNumber.Length)
                    ? string.Format("{0}{1}", VinNumber, (EngineNumber ?? "").TrimStart('0'))
                    : string.Format("{0}{1}", VinNumber.Substring(VinNumber.Length - 7), (EngineNumber ?? "").TrimStart('0'));
            }
        }
    }
}