namespace Lace.Models.Product
{
    public class LaceProduct : ILaceProduct
    {
        public int ContractId { get; set; }

        public int CustomerId { get; set; }

        public string ProductName { get; set; }

        public bool ProductIsAvailable { get; set; }
    }
}
