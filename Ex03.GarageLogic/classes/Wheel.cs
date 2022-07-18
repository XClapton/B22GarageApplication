using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.classes
{
    public class Wheel
    {
        private string m_ManufacturerName;
        readonly private float r_MaxAirPressure;
        private float m_CurrAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string          ManufacturerName
        {
            set { m_ManufacturerName = value; }
        }

        public float           MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }
                               
        public float           CurrAirPressure
        {
            get { return m_CurrAirPressure; }
            set { m_CurrAirPressure = value; }
        }
                               
        public void            WheelInflation(float i_HowMuchToInflate)
        {
            m_CurrAirPressure += i_HowMuchToInflate;
        }

        public override string ToString()
        {
            string wheelData = string.Format("Manufacturer name: {1}.{0}" +
                                             "Maximum air pressure: {2}.{0}" +
                                             "Current air pressure: {3}.{0}"
                                            , Environment.NewLine, m_ManufacturerName, r_MaxAirPressure, m_CurrAirPressure);

            return wheelData;
        }
    }
}
