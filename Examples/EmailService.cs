public class EmailService : INotificationService
{
    public void Push(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}
