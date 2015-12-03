namespace Workflow.BuildingBlocks.Configurations
{
    public static class ConfigurationReader
    {
        public static readonly WorkflowBusConfiguration Bus;
        public static readonly EnvironmentConfiguration Environment;

        static ConfigurationReader()
        {
            Bus = new WorkflowBusConfiguration();
            Environment = new EnvironmentConfiguration();
        }
    }
}