using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractAuditor<T> : IAudit<T>
    {
        public abstract void Audit(T command);

        public void Audit(object command)
        {
            Audit((T) command);
        }
    }
}