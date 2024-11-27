public class SmsService : INotificationService
{
    public void Push(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}
