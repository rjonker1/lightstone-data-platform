using System;
namespace Lim.Dtos
{
    public class BmwFinanceDto
    {
        public  Guid Id { get; set; }
        public  string FinanceHouse { get; set; }
        public  string DealReference { get; set; }
        public  DateTime? StartDate { get; set; }
        public  DateTime? ExpireDate { get; set; }
        public  string Chassis { get; set; }
        public  string Engine { get; set; }
        public  string RegistrationNumber { get; set; }
        public  string Description { get; set; }
        public  int RegistrationYear { get; set; }
        public  string DealType { get; set; }
        public  string DealStatus { get; set; }
        public  string VinEngineId { get; set; }
        public  string ClientNumber { get; set; }
        public  DateTime DateAdded { get; set; }
    }
}
