namespace Lim.Infrastructure
{
    public class LimEventStoreConfiguration : AbstractConfigurationReader
    {
        public string ConnectionString
        {
            get
            {
                return GetConnectionString("lim/schedule/event/store/database",
                    "Data Source=.;Initial Catalog=Lim.EventStore;Integrated Security=True;MultipleActiveResultSets=true;");
            }
        }

        public bool UpdateDatabase
        {
            get
            {
                return bool.Parse(GetAppSetting("lim/schedule//event/store/database/doUpdate",
                    "false"));
            }
        }
    }
}
