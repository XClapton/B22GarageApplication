using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.enums;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        readonly private eTypeOfFuel r_TypeOfFuel;

        public FuelEngine(float i_MaxAmountOfEnergy, eTypeOfFuel i_TypeOfFuel) 
            : base(i_MaxAmountOfEnergy)
        {
            r_TypeOfFuel = i_TypeOfFuel;
        }
       
        public eTypeOfFuel     TypeOfFuel
        {
            get { return r_TypeOfFuel; }
        }

        public void            RefuelVehicle(eTypeOfFuel i_TypeOfFuel, float i_AmountOfFuel)
        {
            if(r_TypeOfFuel != i_TypeOfFuel)
            {
                throw new ArgumentException("you are tring to refuel with the wrong type of fuel");
            }

            base.RechargeEnergy(i_AmountOfFuel);
        }

        public override string ToString()
        {
            StringBuilder EngineData = new StringBuilder();

            EngineData.AppendFormat("Type of fuel: {1}.{0}", Environment.NewLine, r_TypeOfFuel);

            EngineData.AppendFormat("{0}", base.ToString());

            return EngineData.ToString();
        }
    }
}
