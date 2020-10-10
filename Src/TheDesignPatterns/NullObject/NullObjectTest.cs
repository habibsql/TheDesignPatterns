using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheDesignPatterns.NullObject
{
    public class NullObjectTest
    {
        private readonly IMathService mathService;

        public NullObjectTest()
        {
            ILogger logger = new NullLogger();
            this.mathService = new MathService(logger);
        }

        [Fact]
        public void ShouldWork()
        {
            int result = mathService.Addition(20, 10);

            result.Should().Be(30);
        }

    }
}
