using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxAmountOfEnergy) : base(i_MaxAmountOfEnergy) { }

        public void            FillVehicleBattery(float i_amountOfChargingMinutes)
        {
            base.RechargeEnergy(i_amountOfChargingMinutes);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
