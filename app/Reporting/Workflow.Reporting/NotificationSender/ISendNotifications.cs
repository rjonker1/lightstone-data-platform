namespace Workflow.Reporting.NotificationSender
{
    public interface ISendNotifications<in T> where T: class 
    {
        void Send(T Object);
    }
}