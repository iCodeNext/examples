public class NotificationService()
{
    public void Get(string type)
    {
        if (type == "Email")
            new EmailNotification().SendNotification(type);
        else if (type == "SMS")
            new SmsNotification().SendNotification(type);
        //else if (type == "Push")
        //	return new ...();

        else
            throw new ArgumentException("Invalid notification type.");
    }
}

public interface INotification
{
    public void SendNotification(string type);
}

public class SmsNotification : INotification
{
    public void SendNotification(string type)
    {
        throw new NotImplementedException();
    }
}

public class EmailNotification : INotification
{
    public void SendNotification(string type)
    {
        throw new NotImplementedException();
    }
}

