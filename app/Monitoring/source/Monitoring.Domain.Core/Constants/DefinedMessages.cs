namespace Monitoring.Domain.Core.Constants
{
    public class DefinedMessages
    {
        public const string StartCallingExternalSource = "LACE Starting External Source Call";

        public const string EndCallingExternalSource = "LACE Ending External Source Call";

        public const string StartConfigurationForExternalSource =
            "LACE Starting Configuration for External Source Call";

        public const string EndConfigurationForExternalSource =
            "LACE Ending Configuration for External Source Call";

        public const string ExternalSourceCallFailed = "LACE External Source Call Failed";

        public const string NoResponseReceivedFromExternalSource =
            "LACE Response from External Source is null or does not exist";

        public const string RequestSentToExternalSource = "LACE Sent Request Sent to External Source";

        public const string ResponseReceivedFromExternalSource =
            "LACE Received Response from External Source";

        public const string ExternalSourceIsBeingHandled = "LACE External Source is Being Handled";

        public const string ExternalSourceIsNotBeingHandled = "LACE External Source is Not Being Handled";

        public const string TransformingResponseFromExternalSourceHasStarted =
            "LACE Started Transforming Response from External Source";

        public const string TransformingResponseFromExternalSourceHasFinished =
            "LACE Finished Transforming Response from External Source";

        public const string TransformingResponseFromExternalSourceHasFailed =
            "LACE Failed to Transform Response from External Source";

        public const string LaceReceivedRequestStarted =
            "LACE Request Received and Data Collection has started";

        public const string LaceProcessedRequestAndResturnedResponse =
            "LACE Processed Request and Response has been Returned";

        public const string LaceCannotProcessRequestAndErrorHasBeenLogged =
            "LACE Could not Process Request and an Error has been Logged";
    }
}
