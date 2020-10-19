using Xunit;

namespace TheDesignPatterns.PublisherSubScriber
{
    public class PublisherSubscriberTest
    {
        [Fact]
        public void ShouldPublishAndSubscibeMessageUsingPubSubDesignPattern()
        {
            IMessageBroker messageBroker = new CustomMessageBroker();
            IMessageSubscriber accountManager = new AccountsManager();
            IMessageSubscriber purchaseManager = new PurchaseManager();

            messageBroker.Subscribe("KEYBOARDNEEDED", accountManager);
            messageBroker.Subscribe("KEYBOARDNEEDED", purchaseManager);

            var manaement = new Management(messageBroker);

            manaement.PublishKeyboardNeedMessage(); 
            
            // Please check the debug window for message information.
        }
    }


}
