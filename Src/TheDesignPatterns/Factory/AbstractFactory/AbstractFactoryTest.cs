using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.Factory.AbstractFactory
{
    public class AbstractFactoryTest
    {
        [Fact]
        public void ShoudWorkForOfficeFurnitureCreation()
        {
            IFurnitureFactory officeFurnitureFactory = new OfficeFurnitureFactory();
            IChair chair = officeFurnitureFactory.CreateChair();
            ITable table = officeFurnitureFactory.CreateTable();

            chair.GetType().Name.Should().Be("ComputerChair");
            table.GetType().Name.Should().Be("ComputerTable");
        }

        [Fact]
        public void ShoudWorkForHomeFurnitureCreation()
        {
            IFurnitureFactory officeFurnitureFactory = new HomeFurnitureFactory();
            IChair chair = officeFurnitureFactory.CreateChair();
            ITable table = officeFurnitureFactory.CreateTable();

            chair.GetType().Name.Should().Be("SofaChair");
            table.GetType().Name.Should().Be("DyningTable");
        }
    }
}
