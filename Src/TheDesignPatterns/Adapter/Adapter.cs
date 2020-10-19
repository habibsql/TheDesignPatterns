using System.Collections.Generic;

namespace TheDesignPatterns.Adapter
{
    public interface ITarget
    {
        IEnumerable<string> GetAsianCountryCodeList();
    }

    /// <summary>
    /// Adapter
    /// </summary>
    public class CountryCodeAdapter : ITarget
    {
        private readonly IThirdParty country;

        public CountryCodeAdapter(IThirdParty country)
        {
            this.country = country;
        }

        public IEnumerable<string> GetAsianCountryCodeList()
        {
            var countryCodeList = new List<string>();

            Dictionary<string, string> countries = country.GetAsianCountryList();

            foreach(string countryCode in countries.Keys)
            {
                countryCodeList.Add(countryCode);
            }

            return countryCodeList;
        }
    }

    public interface IThirdParty
    {
        public Dictionary<string, string> GetAsianCountryList();
    }

    /// <summary>
    /// Adaptee
    /// </summary>
    public class CountryAdaptee : IThirdParty
    {
        public Dictionary<string, string> GetAsianCountryList()
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("bd", "Bangladesh");
            dictionary.Add("in", "India");
            dictionary.Add("pk", "Pakistan");

            return dictionary;
        }
    }
}
