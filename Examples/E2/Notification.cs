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


#region This block of code is not in your code base, it is a library(3rd party)
public class SlackNotification
{
    public void PostMessageToChannel(string channel, string message)
    {
        Console.WriteLine($"Message sent to Slack channel {channel}: {message}");
    }
}
#endregion
// We Should Create New Class And Inherit From SlackNotification And Impelement INotification InterFace
// Then We Can Call PostMessageToChannel In INotification Send Method
// For Channel Parameter We Can Get that from constructor or Hardcode That
public class CustomSlackNotification : SlackNotification, INotification
{
    private readonly string _channel;

    public CustomSlackNotification(string channel)
    {
        _channel = channel;
    }
    public void Send(string message)
    {
        PostMessageToChannel(_channel, message);
    }
}

public class NotificationService()
{
    public INotification Get(string type)
    {
        if (type == "Email")
            return new EmailNotification();
        else if (type == "SMS")
            return new SmsNotification();
        else if (type == "Slack")
            return new CustomSlackNotification("Channel1");

        else
            throw new ArgumentException("Invalid notification type.");
    }
}
