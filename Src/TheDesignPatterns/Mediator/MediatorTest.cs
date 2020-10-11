using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheDesignPatterns.Mediator
{
    public class MediatorTest
    {
        [Fact]
        public void ShouldWork()
        {
            IExpenseMoneyCollector mother = new Mother();
            int totalExpenseAmount = mother.CollectExpenseAmount();

            totalExpenseAmount.Should().Be(3000);
        }
    }
}
