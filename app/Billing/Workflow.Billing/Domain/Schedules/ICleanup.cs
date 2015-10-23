namespace Workflow.Billing.Domain.Schedules
{
    public interface ICleanup : ISchedule
    {
        void Clean();
    }
}