using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.Builder
{
    public class BuilderTest
    {
        [Fact]
        public void ShouldBuildCar()
        {
            ICarBuilder carBuilder = new CardBuilder();
            var carBuildingProcess = new CardBuildingProcess(carBuilder);
            Car car = carBuildingProcess.BuildCar();

            car.GetAllParts().Should().HaveCount(3);
            car.GetColor().Should().BeNull();
        }
    }
}
