using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.classes;
using Ex03.GarageLogic.enums;

namespace Ex03.GarageLogic
{
    public class GarageShop
    {
        readonly private Dictionary<string, VehicleRecord> r_VehicleRecords;

        public GarageShop()
        {
            r_VehicleRecords = new Dictionary<string, VehicleRecord>();
        }

        public void         AddNewCarToGarrage(string i_LicenseNumber, VehicleRecord newVehicleRecord)
        {
            r_VehicleRecords.Add(i_LicenseNumber, newVehicleRecord);
        }
                            
        public bool         CheckIfVehicleInGarage(string i_LicenseNumber)
        {
            bool ifInGarage = false;

            if (r_VehicleRecords.ContainsKey(i_LicenseNumber))
            {
                ifInGarage = true;
            }

            return ifInGarage;
        }
                            
        public void         ModifyVehicleStatus(string i_LicenseNumber, eVehicleStatus i_UpdatedStatus)
        {
            r_VehicleRecords[i_LicenseNumber].VehicleStatus = i_UpdatedStatus;
        }

        public List<string> GetLicenseNumbersByStatus(eVehicleStatus i_Status, bool i_filterOn)
        {
            List<string> LicenseNumbersList = new List<string>();

            foreach (var vehicleRecord in r_VehicleRecords)
            {
                if (i_filterOn && vehicleRecord.Value.VehicleStatus == i_Status)
                {
                    LicenseNumbersList.Add(vehicleRecord.Key);
                }
                else if (!i_filterOn)
                {
                    LicenseNumbersList.Add(vehicleRecord.Key);
                }
            }

            return LicenseNumbersList;
        }

        public void         InflateWheelsToMax(string i_LicenseNumber)
        {
            r_VehicleRecords[i_LicenseNumber].Vehicle.InflateAllWheels();
        }
                            
        public void         RefuelVehicle(string i_LicenseNumber, eTypeOfFuel i_TypeOfFuel, float i_AmountOfFuel)
        {
            FuelEngine fuelEngine = r_VehicleRecords[i_LicenseNumber].Vehicle.Engine as FuelEngine;

            if (fuelEngine == null)
            {
                throw new ArgumentException("You are tring to refuel an electric vehicle");
            }

            fuelEngine.RefuelVehicle(i_TypeOfFuel, i_AmountOfFuel);
        }
                            
        public void         RechargeVehicle(string i_LicenseNumber, float i_amountOfChargingMinutes)
        {
            ElectricEngine electricEngine = r_VehicleRecords[i_LicenseNumber].Vehicle.Engine as ElectricEngine;

            if(electricEngine==null)
            {
                throw new ArgumentException("You are tring to charge an regular vehicle");
            }

            electricEngine.FillVehicleBattery(i_amountOfChargingMinutes);
        }

        public string       GetVehicleRecordData(string i_LicenseNumber)
        {
            string VehicleData = r_VehicleRecords[i_LicenseNumber].ToString();

            return VehicleData;
        }
                            
        public bool         GarageIsEmpty()
        {
            return r_VehicleRecords.Count() == 0;
        }
    }
}
