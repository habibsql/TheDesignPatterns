using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheDesignPatterns.Adapter
{
    public class AdapterImplementationTest
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
