namespace Lim.Domain.Dto
{
    public class AuthenticationTypeDto
    {
        public AuthenticationTypeDto()
        {
            
        }
        private AuthenticationTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static AuthenticationTypeDto Existing(int id, string name)
        {
            return new AuthenticationTypeDto(id,name);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

    public class FrequencyTypeDto
    {
        public FrequencyTypeDto()
        {
            
        }
        private FrequencyTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static FrequencyTypeDto Existing(int id, string name)
        {
            return new FrequencyTypeDto(id,name);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

   
}