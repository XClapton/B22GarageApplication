using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.enums;
using Ex03.GarageLogic.classes;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        public static Vehicle      BuildVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;
            Engine engine = null;
            List<Wheel> wheels = null;

            switch (i_VehicleType)
            {
                case eVehicleType.RegularCar:
                    {
                        wheels = buildWheels(4, 29f);
                        engine = new FuelEngine(38f, eTypeOfFuel.Octan95);
                        vehicle = new Car(i_LicenseNumber, engine, wheels);
                        vehicle.SetDataToGetList();
                        break;
                    }
                case eVehicleType.ElectricCar:
                    {
                        wheels = buildWheels(4, 29f);
                        engine = new ElectricEngine(3.3f);
                        vehicle = new Car(i_LicenseNumber, engine, wheels);
                        vehicle.SetDataToGetList();
                        break;
                    }
                case eVehicleType.RegularBike:
                    {
                        wheels = buildWheels(2, 31f);
                        engine = new FuelEngine(6.2f, eTypeOfFuel.Octan98);
                        vehicle = new Bike(i_LicenseNumber, engine, wheels);
                        vehicle.SetDataToGetList();
                        break;
                    }
                case eVehicleType.ElectricBike:
                    {
                        wheels = buildWheels(2, 31f);
                        engine = new ElectricEngine(2.5f);
                        vehicle = new Bike(i_LicenseNumber, engine, wheels);
                        vehicle.SetDataToGetList();
                        break;
                    }
                case eVehicleType.Truck:
                    {
                        wheels = buildWheels(16, 24f);
                        engine = new FuelEngine(120f, eTypeOfFuel.Soler);
                        vehicle = new Truck(i_LicenseNumber, engine, wheels);
                        vehicle.SetDataToGetList();
                        break;
                    }
            }

            return vehicle;
        }

        private static List<Wheel> buildWheels(int i_AmountOfWheels, float i_MaxAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            for(int i=0;i<i_AmountOfWheels;i++)
            {
                wheels.Add(new Wheel(i_MaxAirPressure));
            }

            return wheels;
        }
    }
}
