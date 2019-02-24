using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const string   k_ErrNumOfWheels = "Error: Truck only can have 12 four wheels";
        private readonly bool  r_IsTruckRefrigerated;
        private readonly float r_TrunkSize; // meter^3

        public Truck(bool i_IsTruckRefrigerated, float i_TrunkSize, HoldVehicleParams i_MyVehicle) : base(i_MyVehicle)
        {
            r_IsTruckRefrigerated = i_IsTruckRefrigerated;
            r_TrunkSize = i_TrunkSize;
            if (i_MyVehicle.Wheels.Count > (int) eNumOfWheels.TwelveWheeledTruck)
            {
                throw new ArgumentException(k_ErrNumOfWheels);
            }
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendLine(base.ToString());
            strBuild.AppendFormat("Truck Properties:{0}{1}", Environment.NewLine, Environment.NewLine);    
            strBuild.AppendFormat("Is The Truck Refrigerated: {0} {1}", r_IsTruckRefrigerated.ToString(), Environment.NewLine);
            strBuild.AppendFormat("Trunk Volume:              {0} m^3{1}", r_TrunkSize, Environment.NewLine);
            return strBuild.ToString();
        }
    }
}
