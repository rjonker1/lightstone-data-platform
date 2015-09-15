namespace Lim.Infrastructure
{
    public class BmwConfiguration : AbstractConfigurationReader
    {
        public string ConnectionString
        {
            get
            {
                return GetConnectionString("lim/schedule/bmw/database",
                    "Data Source=.;Initial Catalog=Lim.BMW;Integrated Security=True;MultipleActiveResultSets=true;");
            }
        }
    }
}
