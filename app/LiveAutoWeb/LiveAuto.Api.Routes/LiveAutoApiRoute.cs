namespace LiveAuto.Api.Routes
{
    public class LiveAutoApiRoute
    {
        public struct Authorization
        {
            /// <summary>
            /// Verb: PUT
            /// Purpose: Used to generate and email the user the reset password link
            /// Parameters: username
            /// Route: /Users/ResetPassword/{username}
            /// </summary>
            public const string ChangePassword = "/Authorizations/ChangePassword";
        }
    }
}
