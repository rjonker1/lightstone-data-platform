namespace Monitoring.Domain.Core.Constants
{
    public class DefinedMessages
    {
        public const string StartCallingDataProvider = "LACE Starting Data Provider Call";

        public const string EndCallingDataProvider = "LACE Ending Data Provider Call";

        public const string StartConfigurationForDataProvider =
            "LACE Starting Configuration for Data Provider Call";

        public const string EndConfigurationForDataProvider =
            "LACE Ending Configuration for Data Provider Call";

        public const string DataProviderCallFailed = "LACE Data Provider Call Failed";

        public const string NoResponseReceivedFromDataProvider =
            "LACE Response from Data Provider is null or does not exist";

        public const string RequestSentToDataProvider = "LACE Sent Request Sent to Data Provider";

        public const string ResponseReceivedFromDataProvider =
            "LACE Received Response from Data Provider";

        public const string DataProviderIsBeingHandled = "LACE Data Provider is Being Handled";

        public const string DataProviderIsNotBeingHandled = "LACE Data Provider is Not Being Handled";

        public const string TransformingResponseFromDataProviderHasStarted =
            "LACE Started Transforming Response from Data Provider";

        public const string TransformingResponseFromDataProviderHasFinished =
            "LACE Finished Transforming Response from Data Provider";

        public const string TransformingResponseFromDataProviderHasFailed =
            "LACE Failed to Transform Response from Data Provider";

        public const string LaceReceivedRequestStarted =
            "LACE Request Received and Data Collection has started";

        public const string LaceProcessedRequestAndResturnedResponse =
            "LACE Processed Request and Response has been Returned";

        public const string LaceCannotProcessRequestAndErrorHasBeenLogged =
            "LACE Could not Process Request and an Error has been Logged";
    }
}
