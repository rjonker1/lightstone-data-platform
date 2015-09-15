namespace Lim.Infrastructure
{
    public class LimConfiguration : AbstractConfigurationReader
    {
        public string ConnectionString
        {
            get
            {
                return GetConnectionString("lim/schedule/database",
                    "Data Source=.;Initial Catalog=Lim;Integrated Security=True;MultipleActiveResultSets=true;");
            }
        }
    }
}
