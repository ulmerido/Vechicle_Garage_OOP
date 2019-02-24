using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class HoldVehicleParams
    {
        private readonly string      r_VehicleModel;
        private readonly string      r_LicensePlate;
        private readonly Engine      r_Engine;
        private readonly List<Wheel> r_Wheels;

        public HoldVehicleParams(string i_VehicleModel, string i_LicensePlate, Engine i_Engine, List<Wheel> i_Wheels)
        {
            r_VehicleModel = i_VehicleModel;
            r_LicensePlate = i_LicensePlate;
            r_Engine = i_Engine;
            r_Wheels = i_Wheels;
        }

        public string VehicleModel
        {
            get
            {
                return r_VehicleModel;
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public Engine Engine
        {
            get
            {
                return r_Engine;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }
    }
}
