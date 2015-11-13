namespace UserManagement.Api.Routes
{
    public static class UserManagementApiRoute
    {
        public struct User
        {
            /// <summary>
            /// Verb: PUT
            /// Purpose: Used to generate and email the user the reset password link
            /// Parameters: username
            /// Route: /Users/ResetPassword/{username}
            /// </summary>
            public const string RequestResetPassword = "/Users/ResetPassword/{username}";
            /// <summary>
            /// Verb: PUT
            /// Purpose: Used to reset a user's password
            /// Parameters: token, password
            /// Route: /Users/ResetPassword/{token:guid}
            /// </summary>
            public const string ResetPassword = "/Users/ResetPassword/{token:guid}";
        }
    }
}
