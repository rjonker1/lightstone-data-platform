namespace Lace.Source
{
    public class ExecuteSourceBase
    {
        public IExecuteTheSource Next { get; private set; }
        public IExecuteTheSource FallBack { get; private set; }

        public ExecuteSourceBase(IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
        {
            Next = nextSource;
            FallBack = fallbackSource;
        }

        //public void Append()
        //{
        //    Next = nextSource;
        //    FallBack = fallbackSource;
        //}
    }
}
