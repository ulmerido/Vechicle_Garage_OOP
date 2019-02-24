using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class HoldAddGarageVehicleParams
    {
        private readonly string           r_ClientName;
        private readonly string           r_PhoneNumber;
        private readonly string           r_VehicleModel;
        private readonly string           r_LicencePlate;
        private readonly eVehicleTypes    r_VehicleType;
        private readonly HoldWheelParams  r_Wheels;
        private readonly HoldEngineParams r_Engine;

        public HoldAddGarageVehicleParams(string i_Name, string i_Phone, string i_Model, string i_Plate, HoldWheelParams i_Wheel, HoldEngineParams i_Engine, Garage.eVehicleStatus i_Status, eVehicleTypes i_Type)
        {
            r_ClientName = i_Name;
            r_PhoneNumber = i_Phone;
            r_VehicleType = i_Type;
            r_VehicleModel = i_Model;
            r_LicencePlate = i_Plate;
            r_Wheels = i_Wheel;
            r_Engine = i_Engine;
        }

        public string ClientName
        {
            get
            {
                return r_ClientName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        public string VehicleModel
        {
            get
            {
                return r_VehicleModel;
            }
        }

        public string LicencePlate
        {
            get
            {
                return r_LicencePlate;
            }
        }

        public eVehicleTypes VehicleType
        {
            get
            {
                return r_VehicleType;
            }
        }

        public HoldWheelParams Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public HoldEngineParams Engine
        {
            get
            {
                return r_Engine;
            }
        }
    }
}
