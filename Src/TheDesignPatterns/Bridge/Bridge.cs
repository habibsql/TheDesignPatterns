using System.Diagnostics;

namespace TheDesignPatterns.Bridge
{

    public interface IBridge
    {
        void SendNotication(string message);
    }

    public class EmailBridge : IBridge
    {
        private readonly ISendNotification emailNotication;

        public EmailBridge()
        {
            emailNotication = new EmailNotificaiton(); // IOC container need to use here
        }

        public void SendNotication(string message)
        {
            emailNotication.Send(message);
        }
    }

    public class SmsBridge : IBridge
    {
        private readonly ISendNotification smsNotication;

        public SmsBridge()
        {
            smsNotication = new SmsNotification(); // IOC container need to use here
        }

        public void SendNotication(string message)
        {
            smsNotication.Send(message);
        }
    }

    public interface ISendNotification
    {
        void Send(string message);
    }

    public class EmailNotificaiton : ISendNotification
    {
        public object Dubug { get; private set; }

        public void Send(string message)
        {
            Debug.WriteLine($"Sending Email:{message}");
        }
    }

    public class SmsNotification : ISendNotification
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Sending Sms:{message}");
        }
    }
}
