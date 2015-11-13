using System;
using System.Collections.Generic;
using Lim.Domain.Dto;

namespace Lim.Test.Helper.Mothers
{
    public class LimClients
    {
        public static List<ClientDto> Clients()
        {
            return new List<ClientDto>()
            {
                ClientDto.Existing(1,true,"Lim Client","client@lim.co.za","Lim contact", "0118493190","modified", DateTime.UtcNow)
            };
        }
    }
}
