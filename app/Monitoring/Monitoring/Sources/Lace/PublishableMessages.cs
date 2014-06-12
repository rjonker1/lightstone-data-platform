using System;
namespace Monitoring.Sources.Lace
{
    public class PublishableLaceMessages
    {
        public static Func<string> StartCallingExternalSource = () => "LACE Starting External Source Call";

        public static Func<string> EndCallingExternalSource = () => "LACE Ending External Source Call";

        public static Func<string> StartConfigurationForExternalSource =
            () => "LACE Starting Configuration for External Source Call";

        public static Func<string> EndConfigurationForExternalSource =
            () => "LACE Ending Configuration for External Source Call";

        public static Func<string> ExternalSourceCallFailed = () => "LACE External Source Call Failed";

        public static Func<string> NoResponseReceivedFromExternalSource =
            () => "LACE Response from External Source is null or does not exist";

        public static Func<string> RequestSentToExternalSource = () => "LACE Sent Request Sent to External Source";

        public static Func<string> ResponseReceivedFromExternalSource =
            () => "LACE Received Response from External Source";

        public static Func<string> ExternalSourceIsBeingHandled = () => "LACE External Source is Being Handled";

        public static Func<string> ExternalSourceIsNotBeingHandled = () => "LACE External Source is Not Being Handled";

        public static Func<string> TransformingResponseFromExternalSourceHasStarted =
            () => "LACE Started Transforming Response from External Source";


        public static Func<string> TransformingResponseFromExternalSourceHasFinished =
            () => "LACE Finished Transforming Response from External Source";

        public static Func<string> TransformingResponseFromExternalSourceHasFailed =
            () => "LACE Failed to Transform Response from External Source";


    }
}
