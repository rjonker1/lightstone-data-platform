namespace Lim.Web.UI.Models
{
    public class AuthenticationType
    {
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
        public FrequencyType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

   
}