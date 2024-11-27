public class NotificationService
{
    private readonly INotificationService _notificationService;


    public NotificationService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void PushNotification(string message)
    {
        _notificationService.Push(message);
    }
}