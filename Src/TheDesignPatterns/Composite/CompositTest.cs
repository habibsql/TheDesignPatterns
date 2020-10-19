using Xunit;

namespace TheDesignPatterns.Composite
{
    public class CompositTest
    {
        [Fact]
        public void ShouldDemonastrateCompositDesignPattern()
        {
            var countryDirectory = new FileDirectory() { Name = "Contries" };

            var bangladeshFile = new FileContent { Name = "BangladeshFile.txt" };
            bangladeshFile.AddContent("Bangladesh is a best country");

            var IndiaFile = new FileContent { Name = "India.txt" };
            IndiaFile.AddContent("India is a country");

            countryDirectory.Add(bangladeshFile);
            countryDirectory.Add(IndiaFile);

            countryDirectory.Display();

            // Please check debug window 
        }
    }
}
