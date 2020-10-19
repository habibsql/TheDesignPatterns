using System.Collections.Generic;
using System.Diagnostics;

namespace TheDesignPatterns.PublisherSubScriber
{
    /// <summary>
    /// Custom message broker. Here It should be any popular message brokers
    /// like Apachi Kakfa/RabbitMq/ActiveMq etc.
    /// </summary>
    public interface IMessageBroker
    {
        void Subscribe(string topic, IMessageSubscriber subscriber);

        void Publish(string topic, string message);
    }


    public class CustomMessageBroker : IMessageBroker
    {
        private IList<TopicSubscriber> topicSubscribers = new List<TopicSubscriber>();

        public void Subscribe(string topic, IMessageSubscriber messageSubscriber)
        {
            topicSubscribers.Add(new TopicSubscriber(topic, messageSubscriber));
        }

        public void Publish(string topic, string message)
        {
            foreach(TopicSubscriber topicSubscriber in topicSubscribers)
            {
                if (!topicSubscriber.Topic.Equals( topic))
                {
                    break;
                }

                topicSubscriber.MessageSubscriber.OnMessage(message);
            }
        }
    }

    /// <summary>
    /// Publisher component who publish the messages
    /// </summary>
    public class Management
    {
        private readonly IMessageBroker messageBroker;
        public Management(IMessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public void PublishKeyboardNeedMessage()
        {
            this.messageBroker.Publish("KEYBOARDNEEDED", "Please organize more keyboards");
        }
    }

    /// <summary>
    /// Message Subscription interface. Who are interested to listen should implement this. 
    /// </summary>
    public interface IMessageSubscriber
    {
        /// <summary>
        /// Publisher will execute this method with message
        /// </summary>
        /// <param name="message"></param>
        void OnMessage(string message);
    }

    /// <summary>
    /// A subscriber
    /// </summary>
    public class AccountsManager : IMessageSubscriber
    {
        public void OnMessage(string message)
        {
            ArrangeMoney(message);
        }

        private void ArrangeMoney(string message)
        {
            Debug.WriteLine($"Arranging money. Message={message}");
        }
    }

    /// <summary>
    /// Another subscriber
    /// </summary>
    public class PurchaseManager : IMessageSubscriber
    {
        public void OnMessage(string message)
        {
            PurchaseKeyboards(message);
        }

        private void PurchaseKeyboards(string message)
        {
            Debug.WriteLine($"Arranging keyboards. Message={message}");
        }
    }

    public class TopicSubscriber
    {
        public string Topic { get; private set; }
        public IMessageSubscriber MessageSubscriber { get; private set; }

        public TopicSubscriber(string topic, IMessageSubscriber messageSubscriber )
        {
            this.Topic = topic;
            this.MessageSubscriber = messageSubscriber;
        }
    }
}
