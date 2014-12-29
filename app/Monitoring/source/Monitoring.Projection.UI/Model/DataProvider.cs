namespace Monitoring.Projection.UI.Model
{
    public class DataProvider
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public DataProvider(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}