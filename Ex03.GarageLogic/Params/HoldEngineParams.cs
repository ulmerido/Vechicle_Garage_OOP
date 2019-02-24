using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class HoldEngineParams
    {
        private readonly eEngineEnergyTypes r_EngineType;
        private readonly float              r_MaxEnergy;
        private readonly float              r_RemainEnergy;

        public HoldEngineParams(eEngineEnergyTypes i_EngineType, float i_MaxEnergy, float i_RemainEnergy)
        {
            r_EngineType = i_EngineType;
            r_MaxEnergy = i_MaxEnergy;
            r_RemainEnergy = i_RemainEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float RemainEnergy
        {
            get
            {
                return r_RemainEnergy;
            }
        }

        public eEngineEnergyTypes EngineType
        {
            get
            {
                return r_EngineType;
            }
        }
    }
}
