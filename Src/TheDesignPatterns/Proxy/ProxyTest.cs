using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.Proxy
{
    public class ProxyTest
    {
        [Fact]
        public void ShouldWorkProperlyUsingProxyDesingPattern()
        {
            IAccountService accountService = new ProxyAccountService();
            int todaysIncome = accountService.GetTodaysIncome();
            int todaysExpense = accountService.GetTodaysExpense();

            todaysIncome.Should().BeLessOrEqualTo(1000000 / 2);
            todaysExpense.Should().BeGreaterOrEqualTo(500 * 2);
        }
    }
}
