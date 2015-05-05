namespace Workflow.DataProvider.Bus.Consumer
{
    public interface IDataProviderWorker
    {
        void Start();
        void Stop();
    }
}
