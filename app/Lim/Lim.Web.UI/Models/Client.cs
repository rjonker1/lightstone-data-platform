using System;

namespace Lim.Web.UI.Models
{
    public class Client
    {
        public const string Select = @"select c.Id,cc.ContractId,c.Name,c.ClientAccountNumberId AccountNumber from Client c join ClientContract cc on c.Id = cc.ClientId";

        public Client()
        {
            
        }
        
        public Client(Guid id, string name, string accountNumber, Guid contractId)
        {
            Id = id;
            Name = name;
            AccountNumber = accountNumber;
            ContractId = contractId;
        }

        //public static IEnumerable<Client> Get(IUserManagementRepository repository)
        //{

        //    return repository.Items<Client>(Select, new {});

        //    //return new List<Client>()
        //    //{
        //    //    new Client(new Guid("85FA96F5-771C-45C2-B588-A9C906789561"), "ABC Client", "ABC 0001", Guid.NewGuid()),
        //    //    new Client(new Guid("621cfed9-ea8e-4df1-aa6b-192f18a2b9ae"), "DEF Client", "DEF 0001", Guid.NewGuid()),
        //    //    new Client(new Guid("713669a9-1506-42aa-88a6-80edb14757dc"), "HIJ Client", "HIJ 0001", Guid.NewGuid()),
        //    //    new Client(new Guid("713669a9-1506-42aa-88a6-80edb14757dc"), "KLM Client", "KLM 0001", Guid.NewGuid()),
        //    //    new Client(new Guid("713669a9-1506-42aa-88a6-80edb14757dc"), "MNO Client", "MNO 0001", Guid.NewGuid())
        //    //};
        //}

        public Guid Id { get; private set; }
        public Guid ContractId { get; private set; }
        public string Name { get; private set; }
        public string AccountNumber { get; private set; }
    }
}