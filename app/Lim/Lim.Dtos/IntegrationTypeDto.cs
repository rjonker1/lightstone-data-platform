namespace Lim.Dtos
{
    public class IntegrationTypeDto
    {
         public IntegrationTypeDto()
        {

        }
         private IntegrationTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

         public static IntegrationTypeDto Existing(int id, string name)
        {
            return new IntegrationTypeDto(id, name);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
