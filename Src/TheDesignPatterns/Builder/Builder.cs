using System.Collections.Generic;

namespace TheDesignPatterns.Builder
{
    public interface ICarBuilder
    {
        void BuildWheel();

        void BuildEngine();

        void BuildBody();

        void SetBlackColor();

        Car GetCar();

    }

    /// <summary>
    /// Concreate builder
    /// </summary>
    public class CardBuilder : ICarBuilder
    {
        private readonly Car car = new Car();

        public void BuildBody()
        {
            car.AddPart("Body");
        }

        public void BuildEngine()
        {
            car.AddPart("Engine");
        }

        public void BuildWheel()
        {
            car.AddPart("Wheel");
        }

        public void SetBlackColor()
        {
            car.SetBlackColor();
        }

        public Car GetCar()
        {
            return car;
        }
    }

    /// <summary>
    /// Product that need to build step by step
    /// </summary>
    public class Car
    {
        private readonly List<object> parts = new List<object>();
        private string color = null;

        public void AddPart(object part)
        {
            parts.Add(part);
        }

        public IEnumerable<object> GetAllParts()
        {
            return parts;
        }

        public void SetBlackColor()
        {
            color = "Black";
        }

        public string GetColor()
        {
            return color;
        }

    }

    /// <summary>
    /// Director
    /// </summary>
    public class CardBuildingProcess
    {
        private readonly ICarBuilder carBuilder;

        public CardBuildingProcess(ICarBuilder carBBuilder)
        {
            this.carBuilder = carBBuilder;
        }

        public Car BuildCar()
        {
            carBuilder.BuildEngine();
            carBuilder.BuildWheel();
            carBuilder.BuildBody();

            return carBuilder.GetCar();
        }

        public Car BuildCarWithBlackColor()
        {
            carBuilder.BuildEngine();
            carBuilder.BuildWheel();
            carBuilder.BuildBody();
            carBuilder.SetBlackColor();

            return carBuilder.GetCar();
        }

    }
}
