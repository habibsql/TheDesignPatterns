using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TheDesignPatterns.Factory.FactoryMethod
{
    public interface IVehicle
    {
        void Run();
    }

    public class Car : IVehicle
    {
        public void Run()
        {
            Debug.WriteLine("Car is running");
        }
    }

    public class MotorBike : IVehicle
    {
        public void Run()
        {
            Debug.WriteLine("MotorBike is running");
        }
    }

    public interface IVehicleFactory
    {
        public IVehicle CreateVehicle();
    }

    public class VehicleFactory : IVehicleFactory
    {
        private VehicleType vehicleType;

        public VehicleFactory(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
        }
        public IVehicle CreateVehicle()
        {
            IVehicle vehicle = null;

            switch(vehicleType)
            {
                case VehicleType.Car:
                    vehicle = new Car();
                    break;
                case VehicleType.MotorBike:
                    vehicle = new MotorBike();
                    break;
                default:
                    throw new NotImplementedException($"Sorry! {vehicleType} not yet launched!");
            }

            return vehicle;
        }
    }

    public enum VehicleType
    {
        Car,
        MotorBike,
        Truck
    }
}
