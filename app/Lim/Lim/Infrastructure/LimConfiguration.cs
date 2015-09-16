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

        public bool UpdateDatabase
        {
            get
            {
                return bool.Parse(GetAppSetting("lim/schedule/database/doUpdate",
                    "false"));
            }
        }
    }
}
