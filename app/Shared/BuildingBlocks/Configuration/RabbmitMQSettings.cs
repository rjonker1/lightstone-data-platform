namespace BuildingBlocks.Configuration
{
    public class RabbmitMQSettings
    {
        private readonly AppSettingsReader reader;

        private RabbmitMQSettings()
        {
        }

        internal RabbmitMQSettings(AppSettingsReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called rabbitMQ/config/subscriptionPrefix
        /// </summary>
        public string SubscriptionPrefix
        {
            get { return reader.GetString("rabbitMQ/config/subscriptionPrefix", () => "UNKNOWN_SUBSCRIPTION_PREFIX"); }
        }
    }
}