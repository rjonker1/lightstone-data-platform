namespace Lim.Dtos
{
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