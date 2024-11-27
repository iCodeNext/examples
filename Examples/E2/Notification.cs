public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email sent: {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS sent: {message}");
}

public class SlackNotificationSender(SlackNotification slackNotification) : INotification
{
    public void Send(string message) 
    {
        slackNotification.PostMessageToChannel("iCodeNext", message);
    } 
}



#region Thid block of code is not in your code base, it is a library(3rd party)
public class SlackNotification
{
    public void PostMessageToChannel(string channel, string message)
    {
        Console.WriteLine($"Message sent to Slack channel {channel}: {message}");
    }
} 
#endregion

public class NotificationService()
{
    public INotification Get(string type)
    {
        if (type == "Email")
            return new EmailNotification();
        else if (type == "SMS")
            return new SmsNotification();
        else if (type == "Slack")
            return new SlackNotificationSender(new SlackNotification());

        else
            throw new ArgumentException("Invalid notification type.");
    }
}
