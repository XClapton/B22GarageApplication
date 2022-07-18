using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.enums;
using Ex03.GarageLogic.classes;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eAmountOfDoors m_AmountOfDoors;

        public Car(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels) { }

        public eCarColor       eCarColor
        {
            get { return m_CarColor; }
        }

        public eAmountOfDoors  eAmountOfDoors
        {
            get { return m_AmountOfDoors; }
        }

        public override void   SetDataToGetList()
        {
            s_ExclusiveAtrributeStrings.Add("Car color:\n(1) Red\n(2) White\n(3) Green\n(4) Blue");
            s_ExclusiveAtrributeStrings.Add("Amount of doors:\n(1) Two\n(2) Three\n(3) Four\n(4) Five");
        }

        public override void   SetUniqAttribute(List<string> dataList)
        {
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), dataList[0]);
            if (Enum.IsDefined(typeof(eCarColor), m_CarColor) == false)
            {
                throw new ArgumentException("Setting vehicle color failed");
            }

            m_AmountOfDoors = (eAmountOfDoors)Enum.Parse(typeof(eAmountOfDoors), dataList[1]);
            if (Enum.IsDefined(typeof(eAmountOfDoors), m_AmountOfDoors) == false)
            {
                throw new ArgumentException("Setting amount of doors failed");
            }
        }

        public override string ToString()
        {
            StringBuilder carData = new StringBuilder();

            carData.AppendFormat("Car color: {1}.{0}Amount of doors: {2}.{0}"
   , Environment.NewLine, m_CarColor, m_AmountOfDoors);

            carData.AppendFormat("{0}", base.ToString());

            return carData.ToString();
            
        }
    }
}
