using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheDesignPatterns.Bridge
{
    public class BridgeTest
    {
        [Fact]
        public void ShouldWork()
        {
            IBridge bridge = new EmailBridge();
            bridge.SendNotication("Hello! Everyone!");

            bridge = new SmsBridge();
            bridge.SendNotication("Good Morning!");
        }
    }
}
