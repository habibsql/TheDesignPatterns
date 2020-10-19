using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.Factory.FactoryMethod
{
    public class FactoryMethodTest
    {
        [Fact]
        public void ShouldWork()
        {
            IVehicleFactory vehicleFactory = new VehicleFactory(VehicleType.Car);
            IVehicle vehicle = vehicleFactory.CreateVehicle();

            vehicle.Should().NotBeNull();
            vehicle.GetType().Name.Should().Equals("Car");
        }
    }
}
