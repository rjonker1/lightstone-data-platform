namespace Lim.Domain.Dto
{
    public class AuthenticationTypeDto
    {
        public const string Select = @"select Id, Type as Name from AuthenticationType where IsActive = 1";

        public AuthenticationTypeDto()
        {
            
        }
        public AuthenticationTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

    public class FrequencyTypeDto
    {
        public const string Select = @"select Id, Type as Name from FrequencyType where IsActive = 1";

        public FrequencyTypeDto()
        {
            
        }
        public FrequencyTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

   
}