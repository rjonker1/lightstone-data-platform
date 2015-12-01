namespace Workflow.Publisher.Configurations
{
    public class EnvironmentConfiguration : AbstractConfigurationReader
    {
        public string Name
        {
            get { return ReadAppSettings("workflow/environment", ""); }
        }

        public string AppendEnvironment(string settingValue)
        {
            return string.Format("{0}-{1}", Name.ToLowerInvariant(), settingValue);
        }
    }
}