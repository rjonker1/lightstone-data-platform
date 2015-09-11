namespace LiveAuto.Api.Routes
{
    public class LiveAutoApiRoute
    {
        public struct Authorization
        {
            /// <summary>
            /// Verb: GET
            /// Purpose: Used to render change password page
            /// Parameters: reset password token
            /// Route: /Authorizations/ChangePassword/{token:guid}
            /// </summary>
            public const string GetChangePassword = "/Authorizations/ChangePassword/{token:guid}";
            /// <summary>
            /// Verb: PUT
            /// Purpose: Used to change password
            /// Parameters: reset password token, new password
            /// Route: /Authorizations/ChangePassword
            /// </summary>
            public const string PutChangePassword = "/Authorizations/ChangePassword";
        }
    }
}
