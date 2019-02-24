using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private const float    k_MinutesToHour = 60;
        private const string   k_CtrErrorMsg = "Current battery life should be positive and lower or equal to max battery life";
        private const string   k_WrongEngineType = "Engine is not chargeable";
        private const string   k_ErrAddNegativeAmountOfFuel = "Error: Can not charge negative amount of minutes";
        private readonly float r_MaxBatteryLifeInHours;
        private float          m_RemainingBatteryInHours;

        public ElectricEngine(HoldEngineParams i_Engine) : base(i_Engine.EngineType)
        {
            m_RemainingBatteryInHours = i_Engine.RemainEnergy;
            r_MaxBatteryLifeInHours = i_Engine.MaxEnergy;
            if ((m_RemainingBatteryInHours > r_MaxBatteryLifeInHours) || (r_MaxBatteryLifeInHours <= 0) || (m_RemainingBatteryInHours <= 0))
            {
                throw new ArgumentException(k_CtrErrorMsg);
            }
        }

        public float RemainFuelEnergy
        {
            get
            {
                return m_RemainingBatteryInHours;
            }
        }

        public override float GetMaxEnergy()
        {
            return r_MaxBatteryLifeInHours;
        }

         public override void FillEnergy(eEngineEnergyTypes i_EngineType, float i_TimeToChargeInMin)
        {
            float timeToChargeInHours = i_TimeToChargeInMin / k_MinutesToHour;

            if (i_EngineType == this.r_EngineType)
            {
                if (i_TimeToChargeInMin < 0)
                {
                    throw new ArgumentException(k_ErrAddNegativeAmountOfFuel);
                }

                if (m_RemainingBatteryInHours + timeToChargeInHours <= r_MaxBatteryLifeInHours)
                {
                    m_RemainingBatteryInHours += timeToChargeInHours;
                }
                else
                {
                    throw new ValueOutOfRangeExecption(0, r_MaxBatteryLifeInHours - m_RemainingBatteryInHours);
                }
            }
            else
            {
                throw new ArgumentException(k_WrongEngineType);
            }
        }

        public override string ToString()
        {
            StringBuilder engineString = new StringBuilder();
            engineString.AppendFormat("{0}Engine properties:  {1}{2}", Environment.NewLine, Environment.NewLine, Environment.NewLine);
            engineString.AppendFormat("Engine type:              {0}{1}", r_EngineType.ToString(), Environment.NewLine);
            engineString.AppendFormat("Remaining battery status: {0} / {1} hours{2}", m_RemainingBatteryInHours, r_MaxBatteryLifeInHours, Environment.NewLine);
            return engineString.ToString();
        }

        public override float GetRemainingEnergyPercentage()
        {
            return (m_RemainingBatteryInHours / r_MaxBatteryLifeInHours) * 100;
        }     
    }
}
