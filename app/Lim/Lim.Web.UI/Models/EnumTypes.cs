namespace Lim.Web.UI.Models
{
    public class AuthenticationType
    {
        public const string Select = @"select Id, Type as Name from AuthenticationType where IsActive = 1";

        public AuthenticationType()
        {
            
        }
        public AuthenticationType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

    public class FrequencyType
    {
        public const string Select = @"select Id, Type as Name from FrequencyType where IsActive = 1";

        public FrequencyType()
        {
            
        }
        public FrequencyType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

   
}