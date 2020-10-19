using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace TheDesignPatterns.Adapter
{
    public class AdapterTest
    {
        [Fact]
        public void ShouldWork()
        {
            IThirdParty thirdParty = new CountryAdaptee();
            ITarget adapter = new CountryCodeAdapter(thirdParty);
            IEnumerable<string> countryCodeList =  adapter.GetAsianCountryCodeList();

            countryCodeList.Should().HaveCount(3);
        }
    }
}
