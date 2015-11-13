namespace Workflow.Billing.Helpers.Schedules
{
    public interface ICleanup : ISchedule
    {
        void Clean();
    }
}