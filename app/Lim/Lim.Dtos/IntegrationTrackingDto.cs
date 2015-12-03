using System;
namespace Lim.Dtos
{
    class IntegrationTrackingDto
    {
        public  long Id { get; set; }
        public  ConfigurationDto Configuration { get; set; }
        public  DateTime MaxTransactionDate { get; set; }
        public  long TransactionCount { get; set; }
        public  DateTime Updated { get; set; }
    }
}
