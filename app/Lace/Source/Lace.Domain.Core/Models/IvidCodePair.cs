namespace Lace.Domain.Core.Models
{
    public class IvidCodePair
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public IvidCodePair(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
