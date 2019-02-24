 using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly eEngineEnergyTypes r_EngineType;

        protected Engine(eEngineEnergyTypes i_EngineType)
        {
            r_EngineType = i_EngineType;
        }

        public eEngineEnergyTypes GetEngineType
        {
            get
            {
                return r_EngineType;
            }
        }

        public abstract float GetRemainingEnergyPercentage();

        public abstract void FillEnergy(eEngineEnergyTypes i_EngineType, float i_AmountToAdd);

        public abstract float GetMaxEnergy();
    }
}
