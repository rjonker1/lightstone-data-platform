namespace Lim.Infrastructure
{
    public class LsAutoConfiguration : AbstractConfigurationReader
    {
        public string ConnectionString
        {
            get
            {
                return GetConnectionString("lim/schedule/lsAuto/database",
                    "Data Source=.;Initial Catalog=Lim.LSAuto;Integrated Security=True;MultipleActiveResultSets=true;");
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
