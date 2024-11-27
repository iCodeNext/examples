namespace Examples.E2;

public class SlackNotificationAdapter : INotification
{
    private readonly SlackNotification _slackNotification;

    public SlackNotificationAdapter(SlackNotification slackNotification)
    {
        _slackNotification = slackNotification;
    }

    public void Send(string message)
    {
        _slackNotification.PostMessageToChannel("Channel",message);
    }
}