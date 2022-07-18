using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.enums;
using Ex03.GarageLogic.classes;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_RefrigeratedContents;
        private float m_CargoCapacity;

        public Truck(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels) { }

        public bool            RefrigeratedContents
        {
            get { return m_RefrigeratedContents; }
        }

        public float           CargoCapacity
        {
            get { return m_CargoCapacity; }
        }

        public override void   SetDataToGetList()
        {
            s_ExclusiveAtrributeStrings.Add("if carrying refrigerated contents:\n(1) True\n(2)False\n");
            s_ExclusiveAtrributeStrings.Add("Cargo size");
        }
                               
        public override void   SetUniqAttribute(List<string> dataList)
        {
            if(dataList[0] == "1")
            {
                m_RefrigeratedContents = true;
            }
            else if(dataList[0] == "0")
            {
                m_RefrigeratedContents = false;
            }
            else
            {
                throw new ArgumentException("Setting if carrying refrigerated contents failed.");
            }

            try
            {
                m_CargoCapacity = int.Parse(dataList[1]);
                if (m_CargoCapacity <= 0)
                {
                    throw new ArgumentException("The cargo capacity should be bigger then 0.");
                }
            }
            catch
            {
                throw new ArgumentException("Setting cargo capacity failed.");
            }
        }

        public override string ToString()
        {
            StringBuilder truckData = new StringBuilder();

            truckData.AppendFormat("Refrigerated contents: {1}.{0}" +
                                   "Cargo capacity: {2}.{0}"
                                   , Environment.NewLine, m_RefrigeratedContents.ToString(), m_CargoCapacity);

            truckData.AppendFormat("{0}", base.ToString());

            return truckData.ToString();
        }
    }
}
