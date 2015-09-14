namespace Cradle.KeepAlive.Service.Helpers.Notifications
{
    public interface ISendNotifications
    {
        void Send(string subject, string body);
    }
}