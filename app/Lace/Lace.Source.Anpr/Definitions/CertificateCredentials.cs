namespace Lace.Source.Anpr.Definitions
{
    public class CertificateCredentials: IDefineTheCredentials
    {

        public CertificateCredentials()
        {
            
        }

        public CertificateCredentials(string domain, string userName, string password)
        {
            Domain = domain;
            Username = userName;
            Password = password;
        }

        public string Domain { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }
    }
}
