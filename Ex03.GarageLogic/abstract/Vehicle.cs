using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.classes;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        readonly private string r_LicenseNumber;
        private string m_Model;
        readonly private Engine r_Engine;
        readonly private List<Wheel> r_Wheels;
        public static List<string> s_ExclusiveAtrributeStrings;

        public Vehicle(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Engine = i_Engine;
            r_Wheels = i_Wheels;
            s_ExclusiveAtrributeStrings = new List<string>();
        }

        public string          Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }
                               
        public Engine          Engine
        {
            get { return r_Engine; }
        }

        public List<Wheel>     Wheels
        {
            get { return r_Wheels; }
        }

        public abstract void   SetUniqAttribute(List<string> dataList);
                               
        public abstract void   SetDataToGetList();

        public void            SetAllWheels(string i_ManufacturerName, float i_CurrAirPressure)
        {
            foreach(Wheel wheel in r_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.CurrAirPressure = i_CurrAirPressure;
            }
        }
                               
        public void            InflateAllWheels()
        {
            float howMuchToInflate;

            foreach (Wheel wheel in r_Wheels)
            {
                howMuchToInflate = wheel.MaxAirPressure - wheel.CurrAirPressure;
                wheel.WheelInflation(howMuchToInflate);
            }
        }

        public override string ToString()
        {
            StringBuilder VehicleData = new StringBuilder();

            VehicleData.AppendFormat("License number: {1}.{0}" +
                                     "Model: {2}.{0}"
                                     ,Environment.NewLine, r_LicenseNumber, m_Model);

            VehicleData.AppendFormat(r_Engine.ToString());
            VehicleData.AppendFormat(r_Wheels[0].ToString());

            return VehicleData.ToString();
        }
    }
}
