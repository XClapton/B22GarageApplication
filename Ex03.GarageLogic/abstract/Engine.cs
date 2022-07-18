using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        readonly private float r_MaxAmountOfEnergy;
        private float m_CurrAmountOfEnergy;

        public Engine(float i_MaxAmountOfEnergy)
        {
            r_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        public float           MaxAmountOfEnergy
        {
            get { return r_MaxAmountOfEnergy; }
        }

        public float           CurrAmountOfEnergy
        {
            get { return m_CurrAmountOfEnergy; }
            set { m_CurrAmountOfEnergy = value; }
        }

        public void            RechargeEnergy(float i_AmountOfEnergy)
        {
            if (m_CurrAmountOfEnergy + i_AmountOfEnergy > r_MaxAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(1, r_MaxAmountOfEnergy - m_CurrAmountOfEnergy);
            }

            m_CurrAmountOfEnergy += i_AmountOfEnergy;
        }

        public override string ToString()
        {
            string EngineData = string.Format("Maximum amount of energy: {1}.{0}" +
                                              "Current amount of energy: {2}.{0}"
                                             , Environment.NewLine, r_MaxAmountOfEnergy, m_CurrAmountOfEnergy);

            return EngineData;
        }
    }
}
