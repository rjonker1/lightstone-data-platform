using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class PlatformStatus : ValueEntity
    {
        protected PlatformStatus() { }

        public PlatformStatus(string val) : base(val)
        {
            Value = val;
        }
    }
}
