using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.enums;

namespace Ex03.GarageLogic.classes
{
    public class VehicleRecord
    {
        readonly private string r_OwnerName;
        readonly private string r_OwnerNumber;
        readonly private Vehicle r_Vehicle;
        private eVehicleStatus r_VehicleStatus;
        
        public VehicleRecord(string i_OwnerName, string i_OwnerNumber, Vehicle i_InGarageVehicle, eVehicleStatus i_VehicleStatus = eVehicleStatus.InRepair)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerNumber = i_OwnerNumber;
            r_Vehicle = i_InGarageVehicle;
            r_VehicleStatus = i_VehicleStatus;
        }

        public string          OwnerName
        {
            get { return r_OwnerName; }
        }
                               
        public string          OwnerNumber
        {
            get { return r_OwnerNumber; }
        }

        public Vehicle         Vehicle
        {
            get { return r_Vehicle; }
        }

        public eVehicleStatus  VehicleStatus
        {
            get { return r_VehicleStatus; }
            set { r_VehicleStatus = value; }
        }

        public override string ToString()
        {
            StringBuilder allVehicleData = new StringBuilder();

            allVehicleData.AppendFormat("Vehicle owner name: {1}.{0}" +
                                        "Phone number: {2}.{0}" +
                                        "Vehicle status: {3}.{0}"
                , Environment.NewLine, r_OwnerName, r_OwnerNumber, Enum.GetName(typeof(eVehicleStatus), r_VehicleStatus));
            allVehicleData.AppendFormat("{0}", r_Vehicle.ToString());
            
            return allVehicleData.ToString();
        }
    }
}
