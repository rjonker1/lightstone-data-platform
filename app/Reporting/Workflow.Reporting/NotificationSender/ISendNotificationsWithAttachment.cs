namespace Workflow.Reporting.NotificationSender
{
    public interface ISendNotificationsWithAttachment<in T> where T: class 
    {
        void Send(T Object);
    }

    public interface ISendNotifications
    {
        void Send(string subject, string body);
    }
}