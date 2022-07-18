using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.enums;
using Ex03.GarageLogic.classes;

namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
    {
        private eBikeLicenseType m_BikeLicenseType;
        private int m_EngineVolume;

        public Bike(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels) { }

        public eBikeLicenseType BikeLicenseType
        {
            get { return m_BikeLicenseType; }
        }

        public int              EngineVolume
        {
            get { return m_EngineVolume; }
        }

        public override void    SetDataToGetList()
        {
            s_ExclusiveAtrributeStrings.Add("Bike license type:\n(1) A\n(2) B1\n(3) AA\n(4) BB");
            s_ExclusiveAtrributeStrings.Add("Engine volume");
        }
                               
        public override void    SetUniqAttribute(List<string> dataList)
        {
            m_BikeLicenseType = (eBikeLicenseType)Enum.Parse(typeof(eBikeLicenseType), dataList[0]);
            if (Enum.IsDefined(typeof(eBikeLicenseType), m_BikeLicenseType) == false)
            {
                throw new ArgumentException("Setting bike license type failed.");
            }

            try
            {
                m_EngineVolume = int.Parse(dataList[1]);
                if(m_EngineVolume <=0)
                {
                    throw new ArgumentException("The bike volum should be bigger than 0.");
                }
            }
            catch
            {
                throw new ArgumentException("Setting bike volume failed.");
            }
        }

        public override string  ToString()
        {
            StringBuilder bikeData = new StringBuilder();

            bikeData.AppendFormat("Bike license type: {1}.{0}" +
                                  "Engine volume: {2}.{0}"
                                  , Environment.NewLine, Enum.GetName(typeof(eBikeLicenseType), m_BikeLicenseType), m_EngineVolume);

            bikeData.AppendFormat("{0}", base.ToString());

            return bikeData.ToString();
        }
    }
}
