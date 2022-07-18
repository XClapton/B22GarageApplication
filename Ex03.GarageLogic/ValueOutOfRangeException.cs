using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }

        public       ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("Value out of range. The value should be between {0} and {1}",
            i_MinValue, i_MaxValue))
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
