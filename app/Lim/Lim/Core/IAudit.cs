namespace Lim.Core
{
    public interface IAudit
    {
        void Audit(object command);
    }

    public interface IAudit<in T> : IAudit
    {
        void Audit(T comamnd);
    }
}