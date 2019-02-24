using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private const string   k_CtrErrorMsg = "Current fuel should be positive and lower or equal to max fuel";
        private const string   k_WrongEngineType = "Fuel does not match the Engine";
        private const string   k_ErrAddNegativeAmountOfFuel = "Error: Can not add Negative Amount Of Fuel";
        private readonly float r_MaxFuelEnergy;
        private float          m_RemainFuelEnergy;
        
        public FuelEngine(HoldEngineParams i_Engine) : base(i_Engine.EngineType)
        {
            m_RemainFuelEnergy = i_Engine.RemainEnergy;
            r_MaxFuelEnergy = i_Engine.MaxEnergy;
            if ((m_RemainFuelEnergy > r_MaxFuelEnergy) || (r_MaxFuelEnergy <= 0) || (m_RemainFuelEnergy <= 0))
            {
                throw new ArgumentException(k_CtrErrorMsg);
            }
        }

        public float RemainFuelEnergy
        {
            get
            {
                return m_RemainFuelEnergy;
            }
        }

        public override float GetMaxEnergy()
        {
            return r_MaxFuelEnergy;
        }

        public override void FillEnergy(eEngineEnergyTypes i_EngineType, float i_FuelToAdd)
        {
            if (i_EngineType == this.r_EngineType)
            {
                if (i_FuelToAdd < 0)
                {
                    throw new ArgumentException(k_ErrAddNegativeAmountOfFuel);
                }

                if (m_RemainFuelEnergy + i_FuelToAdd <= r_MaxFuelEnergy)
                {
                    m_RemainFuelEnergy += i_FuelToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeExecption(0, r_MaxFuelEnergy - m_RemainFuelEnergy);
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
            engineString.AppendFormat("{0}Engine properties:{1}{2}", Environment.NewLine, Environment.NewLine, Environment.NewLine);
            engineString.AppendFormat("Engine type:              {0}{1}", r_EngineType.ToString(), Environment.NewLine);
            engineString.AppendFormat("Remaining fuel status:    {0} / {1} litters{2}", m_RemainFuelEnergy, r_MaxFuelEnergy, Environment.NewLine);
            return engineString.ToString();
        }

        public override float GetRemainingEnergyPercentage()
        {
            return (m_RemainFuelEnergy / r_MaxFuelEnergy) * 100;
        }
    }
}
