using Nancy;

namespace CentralInterfuseApplication.Modules
{
    public class SecurityModule : NancyModule
    {
        public SecurityModule()
        {
            Get["/login"] = parameters =>
            {
                // Called when the user visits the login page or is redirected here because
                // an attempt was made to access a restricted resource. It should return
                // the view that contains the login form
                return View["Index"];
            };

            Get["/logout"] = parameters =>
            {
                // Called when the user clicks the sign out button in the application. Should
                // perform one of the Logout actions (see below)
                return null;
            };

            Post["/login"] = parameters =>
            {
                // Called when the user submits the contents of the login form. Should
                // validate the user based on the posted form data, and perform one of the
                // Login actions (see below)
                return null;
            };
        }
    }
}