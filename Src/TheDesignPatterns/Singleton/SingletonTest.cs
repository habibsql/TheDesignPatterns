using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheDesignPatterns.Singleton
{
    public class SingletonTest
    {
        [Fact]
        public void ShouldWork()
        {
            ApplicationObject applicationObject = ApplicationObject.GetInstance();

            applicationObject.Should().NotBeNull();
            applicationObject.ApplicationId.Should().NotBeEmpty();
        }
    }
}
