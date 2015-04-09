using UserManagement.Domain.Core.Security;
using Xunit.Extensions;

namespace UserManagement.Domain.Core.Tests
{
    public class when_hashing_password : Specification
    {
        private SaltedHash _saltedHash = new SaltedHash();
        private string _hash = "VyzZX98egf9lVB+HcO8svMY6y9jEkH5yKdZf59cSce8=";
        private string _salt = "ivcPLQ==";
        public override void Observe()
        {
            _saltedHash.GetHashAndSaltString("RightPassword123", out _hash, out _salt);
        }

        [Observation]
        public void should_verify_hash_string()
        {
            _saltedHash.VerifyHashString("RightPassword123", _hash, _salt).ShouldBeTrue();
        }

        [Observation]
        public void should_not_verify_hash_string()
        {
            _saltedHash.VerifyHashString("WrongPassword123", _hash, _salt).ShouldBeFalse();
        }
    }
}
