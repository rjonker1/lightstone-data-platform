namespace Lace.Source
{
    public class ExecuteSourceBase
    {
        public IExecuteTheSource Next { get; protected set; }

        public void Append(IExecuteTheSource nextSource)
        {
            Next = nextSource;
        }
    }
}
